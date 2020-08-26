using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PCX
{
    public partial class MainWindow : Form
    {
        private Graphics graphics = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            graphics = pictureBox.CreateGraphics();
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

                    var image = new PCXImage(memoryStream.ToArray());

                    DrawImage(image);
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
                //using var myStream = saveFileDialog.OpenFile();
                //if (myStream != null)
                //{
                //    using MemoryStream memoryStream = new MemoryStream();
                //    myStream.CopyTo(memoryStream);

                //    var image = new PCXImage(memoryStream.ToArray());
                //}
            }
        }

        void DrawImage(PCXImage image)
        {
            var X = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Height; ++i)
                for (int j = 0; j < image.Width; ++j)
                    X.SetPixel(j, i, image.ImageData[i, j]);

            graphics.DrawImage(X, Point.Empty);

            X.Save(@"C:\Users\effol\Desktop\TEST\igor_data.png", ImageFormat.Png);
        }
    }
}
