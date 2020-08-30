using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PCX
{
    public partial class MainWindow : Form
    {
        private Bitmap m_bitmap = null;
        private PCXImage m_image = null;
        private PictureBox m_pictureBox = null;
        private string m_imagePath = null;
        private string m_operationsRecord = String.Empty;
        private bool m_isRecording = false;
        private int zoomCount = 0;
        readonly System.Windows.Forms.Timer m_recordBlinkTimer = new System.Windows.Forms.Timer();

        public MainWindow()
        {
            InitializeComponent();

            m_pictureBox = new PictureBox();
            m_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            m_pictureBox.BackColor = Color.Transparent;

            labelRecordIndicator.Hide();

            m_recordBlinkTimer.Tick += new EventHandler((Object myObject,
                                            EventArgs myEventArgs) =>
            {
                if (labelRecordIndicator.Visible)
                    labelRecordIndicator.Hide();
                else
                    labelRecordIndicator.Show();
            });

            m_recordBlinkTimer.Interval = 500;
            textBox.MaxLength = 1;

            LoadSymbolsDatabase();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Add(m_pictureBox);

            this.Text = "SIZE - " + 0 + " x " + 0;
        }

        private void OpenImage(string path)
        {
            using var myStream = File.Open(path, FileMode.Open);

            if (myStream != null)
            {
                using MemoryStream memoryStream = new MemoryStream();
                myStream.CopyTo(memoryStream);

                m_image = new PCXImage(memoryStream.ToArray());

                m_pictureBox.Height = m_image.Width;
                m_pictureBox.Width = m_image.Height;

                m_bitmap = new Bitmap(m_image.Width, m_image.Height);

                for (int i = 0; i < m_image.Height; ++i)
                    for (int j = 0; j < m_image.Width; ++j)
                        m_bitmap.SetPixel(j, i, m_image.ImageData[i, j]);

                m_pictureBox.Image = m_bitmap;

                this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_imagePath = openFileDialog.FileName;
                OpenImage(m_imagePath);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (m_imagePath != null)
            {
                OpenImage(m_imagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "pcx files (*.pcx)|*.pcx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var myStream = saveFileDialog.OpenFile();
                if (myStream != null)
                {
                    byte[] pcxBytes = m_image.BitmapToPCX((Bitmap)m_pictureBox.Image);
                    myStream.Write(pcxBytes, 0, pcxBytes.Length);
                }
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            if (sender != null)
                zoomCount++;

            Size newSize = new Size((int)(m_pictureBox.Image.Width * 1.2), (int)(m_pictureBox.Image.Height * 1.2));
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();

            this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            if(sender != null)
            zoomCount--;

            Size newSize = new Size((int)(m_pictureBox.Image.Width / 1.2), (int)(m_pictureBox.Image.Height / 1.2));
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();

            this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            m_bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void RefreshImage()
        {
            m_pictureBox.Image = m_bitmap;

            if(zoomCount < 0)
            {
                var _zoomCount = Math.Abs(zoomCount);
                for (int i = 0; i < _zoomCount; ++i)
                    btnZoomOut_Click(null, null);
            }
            else if(zoomCount > 0)
            {
                for (int i = 0; i < zoomCount; ++i)
                    btnZoomIn_Click(null, null);
            }

            m_pictureBox.Refresh();
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            m_bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnMirrorX_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            m_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnMirrorY_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            m_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            for (int y = 0; (y <= (m_bitmap.Height - 1)); y++)
            {
                for (int x = 0; (x <= (m_bitmap.Width - 1)); x++)
                {
                    Color inv = m_bitmap.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    m_bitmap.SetPixel(x, y, inv);
                }
            }

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnBlackWhite_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            for (int y = 0; y < m_bitmap.Height; y++)
            {
                for (int x = 0; x < m_bitmap.Width; x++)
                {
                    Color p = m_bitmap.GetPixel(x, y);
                    int avg = (p.R + p.G + p.B) / 3;
                    avg = avg < 255 * (nmBlackWhiteRate.Value / 100) ? 0 : 255;
                    m_bitmap.SetPixel(x, y, Color.FromArgb(p.A, avg, avg, avg));
                }
            }

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n" + nmBlackWhiteRate.Value + "\n";
        }

        private static ICollection<Color> GetPixelSquare(Bitmap image, int x, int y)
        {
            var pixels = new List<Color>();
            pixels.Add(image.GetPixel(x + 1, y));
            pixels.Add(image.GetPixel(x + 1, y - 1));
            pixels.Add(image.GetPixel(x, y - 1));
            pixels.Add(image.GetPixel(x - 1, y - 1));
            pixels.Add(image.GetPixel(x - 1, y));
            pixels.Add(image.GetPixel(x - 1, y + 1));
            pixels.Add(image.GetPixel(x, y + 1));
            pixels.Add(image.GetPixel(x + 1, y + 1));
            pixels.Add(image.GetPixel(x, y));

            return pixels;
        }

        private static int PixelTo1or0(Color pixel)
        {
            if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0 && pixel.A != 0)
                return 1;
            return 0;
        }

        private static Color PixelFrom1or0(int pixel1or0)
        {
            switch (pixel1or0)
            {
                case 1: return Color.Black;

                case 0: return Color.White;

                default: throw new Exception();
            }
        }

        private void btnVoidFilling_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            btnBlackWhite_Click(null, null);

            var imgAfterProcess = new Bitmap(m_bitmap);

            Color[,] newImageData = new Color[m_bitmap.Width, m_bitmap.Height];
            for (int i = 1; i < m_bitmap.Width - 1; i++)
            {
                for (int j = 1; j < m_bitmap.Height - 1; j++)
                {
                    var pixelSquare = GetPixelSquare(m_bitmap, i, j);
                    var pixels = pixelSquare.Select(PixelTo1or0).ToArray();

                    var oldCentralPixel = pixels[pixels.Length - 1];
                    if (pixels.Sum() - oldCentralPixel >= 5)
                        imgAfterProcess.SetPixel(i, j, Color.Black);
                }
            }

            m_bitmap = imgAfterProcess;

            RefreshImage();

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private Color ThinningLines(int[] pixels, int step)
        {
            var flags = new bool[pixels.Length];
            for (var i = 0; i < pixels.Length; i++)
                flags[i] = pixels[i] == 1;

            if (!(!flags[(2 + step) % 8] && flags[(6 + step) % 8] && flags[flags.Length - 1]))
                return PixelFrom1or0(pixels[pixels.Length - 1]);

            var newPixelColor = !flags[(2 + step) % 8]
                & flags[(6 + step) % 8]
                & flags[flags.Length - 1]
                & (!flags[(1 + step) % 8] & flags[(4 + step) % 8] | !flags[(3 + step) % 8] & flags[(0 + step) % 8] | flags[(0 + step) % 8] & flags[(4 + step) % 8]);

            return newPixelColor ? Color.White : PixelFrom1or0(pixels[pixels.Length - 1]);
        }

        public Color FringeBlurring(int[] pixels, int step)
        {
            var flags = new bool[pixels.Length];
            for (var i = 0; i < pixels.Length; i++)
                flags[i] = pixels[i] == 1;

            var newPixelColor = flags[pixels.Length - 1]
                & !flags[(0 + step) % 8]
                & !flags[(1 + step) % 8]
                & !flags[(2 + step) % 8]
                & !flags[(3 + step) % 8]
                & !flags[(4 + step) % 8]
                & (!flags[(5 + step) % 8] | flags[(6 + step) % 8]);


            var newPixelValue = newPixelColor ? 1 : 0;
            return PixelFrom1or0(((newPixelValue + pixels[pixels.Length - 1]) % 2));
        }

        private static bool IsTransparent(Color color)
        {
            return color.A < 25;
        }

        public static bool IsWhite(Color color)
        {
            return color.R == 255 && color.G == 255 && color.B == 255;
        }

        private void ProcessImage(Func<int[], Color> processFunction)
        {
            btnBlackWhite_Click(null, null);

            var imgAfterProcess = new Bitmap(m_bitmap);

            Color[,] newImageData = new Color[m_bitmap.Width, m_bitmap.Height];
            for (int i = 1; i < m_bitmap.Width - 1; i++)
            {
                for (int j = 1; j < m_bitmap.Height - 1; j++)
                {
                    var pixelSquare = GetPixelSquare(m_bitmap, i, j);
                    var pixels = pixelSquare.Select(PixelTo1or0).ToArray();
                    var currentPixel = m_bitmap.GetPixel(i, j);

                    Color newColor = processFunction(pixels);

                    if (IsWhite(newColor) && IsTransparent(currentPixel))
                        newColor = Color.FromArgb(currentPixel.A, newColor.R, newColor.G, newColor.B);

                    imgAfterProcess.SetPixel(i, j, newColor);
                }
            }

            m_bitmap = imgAfterProcess;

            RefreshImage();
        }

        private void btnThinningLinesRight_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => ThinningLines(array, 6));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnThinningLinesLeft_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => ThinningLines(array, 2));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnThinningLinesTop_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => FringeBlurring(array, 0));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnThinningLinesBot_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => ThinningLines(array, 4));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnFringeBlurringRight_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => FringeBlurring(array, 6));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnFringeBlurringLeft_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => FringeBlurring(array, 2));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnFringeBlurringTop_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => FringeBlurring(array, 0));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnFringeBlurringBot_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            ProcessImage((array) => FringeBlurring(array, 4));

            m_operationsRecord += MethodBase.GetCurrentMethod().Name + "\n";
        }

        private void btnRecordStart_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            btnRecordStart.ForeColor = Color.Red;
            labelRecordIndicator.ForeColor = Color.Red;
            m_operationsRecord = String.Empty;

            labelRecordIndicator.Show();

            m_isRecording = true;
            m_recordBlinkTimer.Start();
        }

        private void btnRecordStop_Click(object sender, EventArgs e)
        {
            if (m_image == null || m_isRecording == false)
                return;

            m_isRecording = false;
            m_recordBlinkTimer.Stop();
            labelRecordIndicator.Show();

            if (m_operationsRecord.Length == 0)
                labelRecordIndicator.Hide();
            else
                labelRecordIndicator.ForeColor = Color.Aqua;

            btnRecordStart.ForeColor = Color.White;
        }

        private void btnRecordSave_Click(object sender, EventArgs e)
        {
            if (m_image == null || m_operationsRecord.Length == 0)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "record files (*.record)|*.record|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var myStream = saveFileDialog.OpenFile();

                if (myStream != null)
                {
                    using var streamWriter = new StreamWriter(myStream);
                    streamWriter.Write(m_operationsRecord);
                }
            }
        }

        private void btnRecordRun_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            var openFileDialog = new OpenFileDialog();
            var operationsRecord = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var myStream = openFileDialog.OpenFile();
                if (myStream != null)
                {
                    using var streamReader = new StreamReader(myStream);
                    operationsRecord = streamReader.ReadToEnd();
                }
                OpenImage(m_imagePath);
            }

            string[] records = operationsRecord.Split(
                new[] { "\n" }, StringSplitOptions.None
            );

            for (int i = 0; i < records.Length; ++i)
            {
                if (String.IsNullOrWhiteSpace(records[i]))
                    continue;

                Type thisType = this.GetType();

                MethodInfo theMethod = thisType.GetMethod(records[i],
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    CallingConventions.Any,
                    new Type[] { typeof(object), typeof(EventArgs) },
                    null);

                if (records[i] == "btnBlackWhite_Click")
                    nmBlackWhiteRate.Value = int.Parse(records[++i]);

                Thread.Sleep(200);

                theMethod.Invoke(this, new object[] { null, null });
            }
        }

        private List<Rectangle> allSymbols = null;
        private int currentSymbol = 0;

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (m_image == null)
                return;

            btnBlackWhite_Click(null, null);

            allSymbols = SortSymbols(DefineAllSymbols());

            if (null == sender)
                return;

            var symbolBitmap = m_bitmap.Clone(allSymbols[0], System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pictureBoxSymbol.Image = symbolBitmap;

            SetMeasure();
            UpdateCurrentSymbol();
        }

        private void btnAnalyzeRight_Click(object sender, EventArgs e)
        {
            if (m_image == null || allSymbols == null || allSymbols.Count == 0 || currentSymbol == allSymbols.Count - 1)
                return;

            var symbolBitmap = m_bitmap.Clone(allSymbols[++currentSymbol], System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pictureBoxSymbol.Image = symbolBitmap;

            SetMeasure();
            UpdateCurrentSymbol();
        }

        private void btnAnalyzeLeft_Click(object sender, EventArgs e)
        {
            if (m_image == null || allSymbols == null || allSymbols.Count == 0 || currentSymbol == 0)
                return;

            var symbolBitmap = m_bitmap.Clone(allSymbols[--currentSymbol], System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pictureBoxSymbol.Image = symbolBitmap;

            SetMeasure();
            UpdateCurrentSymbol();
        }

        private void btnTeach_Click(object sender, EventArgs e)
        {
            if (m_image == null || allSymbols == null)
                return;

            m_symbolsDatabase.TryAdd(labelHorizontalAnalyze.Text + " | " + labelVerticalAnalyze.Text, textBox.Text[0]);

            m_symbolsDatabase[labelHorizontalAnalyze.Text + " | " + labelVerticalAnalyze.Text] = textBox.Text[0];

            SaveSymbolDatabase();
        }

        private byte[,] ImageData;
        private List<Point> CurrPoints;

        public List<Rectangle> DefineAllSymbols()
        {
            var symbolCoords = new List<Rectangle>();

            ImageData = new byte[m_bitmap.Width, m_bitmap.Height];
            for (int i = 0; i < m_bitmap.Width; i++)
                for (int j = 0; j < m_bitmap.Height; j++)
                    ImageData[i, j] = (byte)(IsWhite(m_bitmap.GetPixel(i, j)) == true ? 0 : 1);

            for (int i = 0; i < m_bitmap.Width; i++)
                for (int j = 0; j < m_bitmap.Height; j++)
                {
                    if (ImageData[i, j] == 1)
                        symbolCoords.Add(DefineSymbolCoords(i, j));
                }

            return symbolCoords;
        }

        public static List<Rectangle> SortSymbols(List<Rectangle> symbols)
        {
            List<Rectangle> sortedSymbols = new List<Rectangle>();
            List<List<Rectangle>> allRows = new List<List<Rectangle>>();

            allRows = DefineRows(symbols);
            foreach (var row in allRows)
                foreach (var symbol in row)
                    sortedSymbols.Add(symbol);

            return sortedSymbols;
        }

        public static List<List<Rectangle>> DefineRows(List<Rectangle> symbols)
        {
            List<List<Rectangle>> allRows = new List<List<Rectangle>>();

            while (symbols.Any())
            {
                Rectangle currSymbol = symbols[0];
                symbols.Remove(currSymbol);

                int avgY = (int)(currSymbol.Y + currSymbol.Height / 2);
                List<Rectangle> currRow = new List<Rectangle> { currSymbol };
                foreach (var item in symbols)
                {
                    if (item.Y < avgY && item.Y + item.Height > avgY)
                        currRow.Add(item);
                }

                currRow.Sort((a, b) => a.X.CompareTo(b.X));
                symbols = symbols.Except(currRow).ToList();
                allRows.Add(currRow);
            }

            allRows.Sort((a, b) => a.Min(p => p.Y).CompareTo(b.Min(p => p.Y)));

            return allRows;
        }


        private Rectangle DefineSymbolCoords(int i, int j)
        {
            CurrPoints = new List<Point>();
            FillSymbol(i, j);
            int minX = CurrPoints.Min(a => (int)a.X);
            int minY = CurrPoints.Min(a => (int)a.Y);
            int maxX = CurrPoints.Max(a => (int)a.X);
            int maxY = CurrPoints.Max(a => (int)a.Y);

            var rect = new Rectangle(new Point(minX, minY), new Size(maxX - minX, maxY - minY));
            return rect;
        }

        private void FillSymbol(int i, int j)
        {
            ImageData[i, j] = 2;
            CurrPoints.Add(new Point(i, j));

            for (int k = 1; k < 5; ++k)
            {
                try
                {
                    if (ImageData[i - k, j + 1] == 1)
                        FillSymbol(i - k, j + 1);
                }
                catch (Exception e) { }

                try
                {
                    if (ImageData[i, j + k] == 1)
                    FillSymbol(i, j + k);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i + k, j + k] == 1)
                    FillSymbol(i + k, j + k);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i + k, j] == 1)
                    FillSymbol(i + k, j);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i + k, j - k] == 1)
                    FillSymbol(i + k, j - k);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i, j - k] == 1)
                    FillSymbol(i, j - k);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i - k, j - k] == 1)
                    FillSymbol(i - k, j - k);
                }
                catch (Exception e) { }

                try
                {
                if (ImageData[i - k, j] == 1)
                    FillSymbol(i - k, j);
                }
                catch (Exception e) { }
            }
        }

        private void SetMeasure()
        {
            Rectangle currRect = allSymbols[currentSymbol];

            int minX = (int)(currRect.X);
            int minY = (int)(currRect.Y);
            int maxX = (int)(currRect.Width + currRect.X);
            int maxY = (int)(currRect.Height + currRect.Y);

            bool[,] symbolData = new bool[maxX - minX, maxY - minY];
            for (int i = minX, x = 0; i < maxX; i++, x++)
                for (int j = minY, y = 0; j < maxY; j++, y++)
                    symbolData[x, y] = IsWhite(m_bitmap.GetPixel(i, j));

            var horizontalMeasure = GetHorizontalMeasure(symbolData, maxX - minX, maxY - minY);
            labelHorizontalAnalyze.Text = string.Join(" ", horizontalMeasure);

            var rectBitmap = m_bitmap.Clone(currRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            rectBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);


            symbolData = new bool[rectBitmap.Width, rectBitmap.Height];
            for (int i = 0, x = 0; i < rectBitmap.Width; i++, x++)
                for (int j = 0, y = 0; j < rectBitmap.Height; j++, y++)
                    symbolData[x, y] = IsWhite(rectBitmap.GetPixel(i, j));


            var verticalMeasure = GetHorizontalMeasure(symbolData, rectBitmap.Width, rectBitmap.Height);
            labelVerticalAnalyze.Text = string.Join(" ", verticalMeasure);
        }

        private static List<int> RemoveDuplicates(List<int> list)
        {
            var nonDuplicates = new List<int>();

            foreach (var element in list)
            {
                if (nonDuplicates.Count == 0 || nonDuplicates.Last() != element)
                    nonDuplicates.Add(element);
            }

            return nonDuplicates;
        }

        private static bool[] RemoveSmallSequences(bool[] array, int smallNumber)
        {
            int count = 0;
            bool currTarget = array[0];

            List<bool> newArray = new List<bool>();

            for (int i = 0; i < array.Length; ++i)
            {
                if (currTarget == array[i])
                {
                    ++count;
                }
                else
                {
                    if (count > smallNumber)
                    {
                        for (int j = 0; j < count; ++j)
                            newArray.Add(currTarget);
                    }

                    currTarget = array[i];
                    count = 1;
                }
            }

            if (count > smallNumber)
            {
                for (int j = 0; j < count; ++j)
                    newArray.Add(currTarget);
            }

            return newArray.ToArray();
        }

        public static List<int> GetHorizontalMeasure(bool[,] symbolData, int width, int height)
        {
            List<int> measures = new List<int>();

            bool[] line = new bool[width];

            int horizontalParts = 20;
            if (horizontalParts > height)
                horizontalParts = height;

            var parts = (height - 1) / (double)horizontalParts;
            double startH = 0;
            int currH = (int)Math.Round(startH);

            int smallPart = (int)(width * 0.06);
            int bigPart = (int)(width * 0.70);

            for (int i = 0; i <= horizontalParts; i++)
            {
                var newH = (int)Math.Round(startH);
                if (currH == newH && i != 0)
                    continue;

                currH = newH;

                for (int j = 0; j < width; j++)
                {
                    line[j] = symbolData[j, currH];
                }

                bool[] fixedLine = RemoveSmallSequences(line, smallPart);


                bool currSign = line[0];
                int currCount = 0;
                int result = 0;

                for (int j = 0; j < fixedLine.Length; j++)
                {
                    if (fixedLine[j] == currSign)
                        currCount++;
                    else
                    {
                        if (currSign == false)
                        {
                            if (currCount > smallPart)
                            {
                                if (currCount > bigPart)
                                    result = -1;
                                else if (result != -1)
                                    result++;
                            }
                        }

                        currCount = 0;
                        currSign = fixedLine[j];
                    }
                }

                if (currSign == false)
                {
                    if (currCount > smallPart)
                    {
                        if (currCount > bigPart)
                            result = -1;
                        else if (result != -1)
                            result++;
                    }
                }

                measures.Add(result);

                startH += parts;
            }

            measures.RemoveAll(i => i == 0);

            List<int> uniqueMeansures = RemoveDuplicates(measures);

            return uniqueMeansures;
        }

        SortedDictionary<string, char> m_symbolsDatabase = new SortedDictionary<string, char>();

        string m_symDbPath = AppDomain.CurrentDomain.BaseDirectory +
                Path.DirectorySeparatorChar + "PCX_SYMBOLS_DATABASE.json";
        private void SaveSymbolDatabase()
        {
            var serializedSymbolsDB = JsonConvert.SerializeObject(m_symbolsDatabase);

            File.WriteAllText(m_symDbPath, serializedSymbolsDB);
        }

        private void LoadSymbolsDatabase()
        {
            if (File.Exists(m_symDbPath))
                m_symbolsDatabase = JsonConvert.DeserializeObject<
                    SortedDictionary<string, char>
                >(File.ReadAllText(m_symDbPath));
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSymbolDatabase();
        }

        private void UpdateCurrentSymbol()
        {
            char val;
            if (m_symbolsDatabase.TryGetValue(labelHorizontalAnalyze.Text + " | " + labelVerticalAnalyze.Text, out val))
                textBox.Text = val.ToString();
            else
                textBox.Text = "?";
        }

        private void btnGetText_Click(object sender, EventArgs e)
        {
            btnAnalyze_Click(null, null);

            List<Rectangle> rects = DefineAllSymbols();
            rects = SortSymbols(rects);
            List<List<Rectangle>> allRows = DefineRows(rects);
            string charsOnImage = "";

            foreach (var row in allRows)
            {
                foreach (var currRect in row)
                {
                    int minX = (currRect.X);
                    int minY = (currRect.Y);
                    int maxX = (currRect.Width + currRect.X);
                    int maxY = (currRect.Height + currRect.Y);

                    bool[,] symbolData = new bool[maxX - minX, maxY - minY];
                    for (int i = minX, x = 0; i < maxX; i++, x++)
                        for (int j = minY, y = 0; j < maxY; j++, y++)
                            symbolData[x, y] = IsWhite(m_bitmap.GetPixel(i, j));

                    var horizontalMeasure = GetHorizontalMeasure(symbolData, maxX - minX, maxY - minY);

                    var rectBitmap = m_bitmap.Clone(currRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    rectBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);


                    symbolData = new bool[rectBitmap.Width, rectBitmap.Height];
                    for (int i = 0, x = 0; i < rectBitmap.Width; i++, x++)
                        for (int j = 0, y = 0; j < rectBitmap.Height; j++, y++)
                            symbolData[x, y] = IsWhite(rectBitmap.GetPixel(i, j));


                    var verticalMeasure = GetHorizontalMeasure(symbolData, rectBitmap.Width, rectBitmap.Height);

                    char val;
                    if (m_symbolsDatabase.TryGetValue(
                        string.Join(" ", horizontalMeasure) + " | " + string.Join(" ", verticalMeasure), out val))
                        charsOnImage += val.ToString();
                    else
                        charsOnImage += "?";
                }
                charsOnImage += "\r\n";
            }

            MessageBox.Show(charsOnImage, "TEXT");
        }
    }
}
