using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

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
            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

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

        private static bool IsWhite(Color color)
        {
            return color.R == 255 && color.G == 255 && color.B == 255;
        }

        private void ProcessImage(Func<int[], Color> processFunction)
        {
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
    }
}
