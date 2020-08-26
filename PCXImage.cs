using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PCX
{
    class PCXImage
    {
        const int c_HeaderSize = 128;
        public byte Version { get; set; }
        public bool IsRLE { get; set; }
        public byte BitPerPixel { get; set; }
        public int xStart { get; set; }
        public int xEnd { get; set; }
        public int yStart { get; set; }
        public int yEnd { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public uint HorizontalDPI { get; set; }
        public uint VerticalDPI { get; set; }
        public byte[] Colormap { get; set; }
        public byte NumOfPlanes { get; set; }
        public uint BytesPerLine { get; set; }
        public uint PaletteInfo { get; set; }
        public uint HorizontalRes { get; set; }
        public uint VerticalRes { get; set; }
        public int ScanLineLength { get; set; }
        public int LinePaddingSize { get; set; }

        public Color[,] ImageData { get; set; }

        public PCXImage()
        {

        }

        public PCXImage(byte[] array)
        {
            bool IsPCXImage = array[0] == 10;
            if (!IsPCXImage)
                throw new Exception("Invalid PCX format");

            Version = array[1];
            IsRLE = array[2] == 1;
            BitPerPixel = array[3];

            xEnd = BitConverter.ToUInt16(array, 8);
            xStart = BitConverter.ToUInt16(array, 4);

            yEnd = BitConverter.ToUInt16(array, 10);
            yStart = BitConverter.ToUInt16(array, 6);

            Width = xEnd - xStart + 1;
            Height = yEnd - yStart + 1;

            HorizontalDPI = BitConverter.ToUInt16(array, 12);
            VerticalDPI = BitConverter.ToUInt16(array, 14);

            Colormap = new byte[48];
            for (int i = 0; i < 48; i++)
                Colormap[i] = array[i + 16];

            NumOfPlanes = array[65];
            BytesPerLine = BitConverter.ToUInt16(array, 66);
            PaletteInfo = BitConverter.ToUInt16(array, 68);
            HorizontalRes = BitConverter.ToUInt16(array, 70);
            VerticalRes = BitConverter.ToUInt16(array, 72);

            ScanLineLength = (int)(NumOfPlanes * BytesPerLine);

            ParseDataSection(array);

            if (NumOfPlanes != 4 || BitPerPixel != 8)
                throw new Exception("Unsupported PCX format");
        }

        private void ParseDataSection(byte[] array)
        {
            var compressedData = array.TakeLast(array.Length - c_HeaderSize);

            var scanLines = UncompressRle(compressedData);
            IEnumerator scanLinesEnum = scanLines.GetEnumerator();

            scanLinesEnum.MoveNext();

            ImageData = new Color[Height, Width];

            for (int i = 0; i < Height; ++i)
            {
                for (int k = 0; k < NumOfPlanes; ++k)
                {
                    for (int j = 0; j < Width; ++j)
                    {
                        byte R = ImageData[i, j].R;
                        byte G = ImageData[i, j].G;
                        byte B = ImageData[i, j].B;
                        byte A = ImageData[i, j].A;

                        switch (k)
                        {
                            case 0:
                                R = (byte)scanLinesEnum.Current;
                                break;
                            case 1:
                                G = (byte)scanLinesEnum.Current;
                                break;
                            case 2:
                                B = (byte)scanLinesEnum.Current;
                                break;
                            case 3:
                                A = (byte)scanLinesEnum.Current;
                                break;
                        }

                        ImageData[i, j] = Color.FromArgb(A, R, G, B);

                        scanLinesEnum.MoveNext();
                    }
                }
            }
        }

        private byte[] UncompressRle(IEnumerable<byte> bytesEnum)
        {
            var uncompressedBytes = new List<byte>();
            var bytes = bytesEnum.GetEnumerator();

            if (!bytes.MoveNext())
                throw new FieldAccessException();

            do
            {
                if ((bytes.Current & 0xC0) == 0xC0) // RLE byte
                {
                    int runcount = bytes.Current & 0x3F; // Get length of byte sequency

                    if (!bytes.MoveNext())
                        throw new FieldAccessException();

                    for (int i = 0; i < runcount; ++i)
                        uncompressedBytes.Add(bytes.Current);
                }
                else
                {
                    uncompressedBytes.Add(bytes.Current);
                }
            } while (bytes.MoveNext());

            return uncompressedBytes.ToArray();
        }

        public byte[] BitmapToPCX(Bitmap bitmap)
        {
            var imageBytes = new List<byte>();

            for (int i = 0; i < bitmap.Height; ++i)
            {
                for (int k = 0; k < NumOfPlanes; ++k)
                {
                    for (int j = 0; j < bitmap.Width; ++j)
                    {
                        var pixel = bitmap.GetPixel(j, i);

                        switch (k)
                        {
                            case 0:
                                imageBytes.Add(pixel.R);
                                break;
                            case 1:
                                imageBytes.Add(pixel.G);
                                break;
                            case 2:
                                imageBytes.Add(pixel.B);
                                break;
                            case 3:
                                imageBytes.Add(pixel.A);
                                break;
                        }
                    }
                }
            }

            byte[] rleBytes = CompressRLE(imageBytes.ToArray());

            List<byte> bytes = new List<byte>();

            bytes.Add((byte)10);
            bytes.Add(Version);
            bytes.Add(IsRLE ? (byte)1 : (byte)0);
            bytes.Add(BitPerPixel);
            
            bytes.AddRange(BitConverter.GetBytes((UInt16)0));
            bytes.AddRange(BitConverter.GetBytes((UInt16)0));

            bytes.AddRange(BitConverter.GetBytes((UInt16)(bitmap.Width - 1)));
            bytes.AddRange(BitConverter.GetBytes((UInt16)(bitmap.Height - 1)));

            bytes.AddRange(BitConverter.GetBytes((UInt16)HorizontalDPI));
            bytes.AddRange(BitConverter.GetBytes((UInt16)VerticalDPI));
            bytes.AddRange(Colormap);
            bytes.Add(0);
            bytes.Add(NumOfPlanes);

            bytes.AddRange(BitConverter.GetBytes((UInt16)(bitmap.Width)));
            bytes.AddRange(BitConverter.GetBytes((UInt16)PaletteInfo));
            bytes.AddRange(BitConverter.GetBytes((UInt16)HorizontalRes));

            bytes.AddRange(BitConverter.GetBytes((UInt16)VerticalRes));

            bytes.AddRange(new byte[54]);

            bytes.AddRange(rleBytes);

            return bytes.ToArray();
        }

        public byte[] CompressRLE(byte[] bytesArray)
        {
            const byte sequenceFlagByte = 192;
            const byte maxSequence = 63;

            if (bytesArray.Length == 0)
                return bytesArray;

            List<byte> returnedArray = new List<byte>();
            byte currByte = 0;
            byte sequence = 0;

            foreach (byte b in bytesArray)
            {
                if (sequence == 0)
                {
                    currByte = b;
                    sequence++;
                }
                else
                {
                    if (currByte == b)
                    {
                        sequence++;
                        if (sequence == maxSequence)
                        {
                            returnedArray.Add((byte)(sequenceFlagByte + sequence));
                            returnedArray.Add(currByte);
                            sequence = 0;
                        }
                    }
                    else
                    {
                        if (sequence > 1 || currByte >= 192)
                        {
                            returnedArray.Add((byte)(sequenceFlagByte + sequence));
                        }
                        returnedArray.Add(currByte);

                        currByte = b;
                        sequence = 1;
                    }
                }
            }

            if (sequence > 1 || currByte >= 192)
            {
                returnedArray.Add((byte)(sequenceFlagByte + sequence));
            }
            returnedArray.Add(currByte);

            return returnedArray.ToArray();
        }
    }
}
