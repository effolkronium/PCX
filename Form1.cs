using System;
using System.Drawing;
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
                try
                {
                    MessageBox.Show(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "pcx files (*.pcx)|*.pcx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // TODO: myStream.Write
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }
    }
}
