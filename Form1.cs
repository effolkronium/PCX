using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PCX
{
    public partial class MainWindow : Form
    {
        private Bitmap m_bitmap = null;
        private PCXImage m_image = null;
        private PictureBox m_pictureBox = null;

        public MainWindow()
        {
            InitializeComponent();

            flowLayoutPanel.AutoScroll = true;
            m_pictureBox = new PictureBox();
            m_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            m_pictureBox.BackColor = Color.Transparent;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Add(m_pictureBox);

            this.Text = "SIZE - " + 0 + " x " + 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var myStream = openFileDialog.OpenFile();
                if (myStream != null)
                {
                    using MemoryStream memoryStream = new MemoryStream();
                    myStream.CopyTo(memoryStream);

                    m_image = new PCXImage(memoryStream.ToArray());

                    DrawImage();

                    this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;
                }
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
            Size newSize = new Size((int)(m_pictureBox.Image.Width * 1.2), (int)(m_pictureBox.Image.Height * 1.2));
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();

            this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            Size newSize = new Size((int)(m_pictureBox.Image.Width / 1.2), (int)(m_pictureBox.Image.Height / 1.2));
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();

            this.Text = "SIZE - " + m_pictureBox.Image.Width + " x " + m_pictureBox.Image.Height;
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            m_bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            
            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            m_bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();
        }

        private void btnMirrorX_Click(object sender, EventArgs e)
        {
            m_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();
        }

        private void btnMirrorY_Click(object sender, EventArgs e)
        {
            m_bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            for (int y = 0; (y <= (m_bitmap.Height - 1)); y++)
            {
                for (int x = 0; (x <= (m_bitmap.Width - 1)); x++)
                {
                    Color inv = m_bitmap.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    m_bitmap.SetPixel(x, y, inv);
                }
            }

            Size newSize = new Size(m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            Bitmap newBitMap = new Bitmap(m_bitmap, newSize);
            m_pictureBox.Image = newBitMap;

            m_pictureBox.Refresh();
        }

        void DrawImage()
        {
            if (m_image == null)
                return;

            m_pictureBox.Height = m_image.Width;
            m_pictureBox.Width = m_image.Height;

            m_bitmap = new Bitmap(m_image.Width, m_image.Height);

            for (int i = 0; i < m_image.Height; ++i)
                for (int j = 0; j < m_image.Width; ++j)
                    m_bitmap.SetPixel(j, i, m_image.ImageData[i, j]);

            m_pictureBox.Image = m_bitmap;
        }
    }
}
