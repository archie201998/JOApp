using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationImageViewer : Form
    {
        private List<string> imageFiles;
        private int currentImageIndex;

        private string _imageFilePath;

        public frmInvestigationImageViewer(string imageFilePath)
        {
            InitializeComponent();
            imageFiles = new List<string>();
            currentImageIndex = 0;
            _imageFilePath = imageFilePath;

            Helper.LoadFormIcon(this);
        }

        private void frmInvestigationImageViewer_Load(object sender, EventArgs e)
        {
            string sharedFolderPath = @"\\192.168.18.183\InvestigationImages\Dacol"; // Replace with your shared folder path

            if (Directory.Exists(sharedFolderPath))
            {
                imageFiles = Directory.GetFiles(sharedFolderPath, "*.*")
                                      .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".bmp") || file.EndsWith(".gif"))
                                      .ToList();

                if (imageFiles.Count > 0)
                {
                    LoadImage();
                }
                else
                {
                    MessageBox.Show("No images found in the folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Shared folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadImage()
        {
            if (!string.IsNullOrEmpty(_imageFilePath))
            {
                Image image = Image.FromFile(_imageFilePath);
                Image watermarkedImage = AddWatermark(image, "CAPTURED BY DACOL"); // Replace "Watermark Text" with your desired watermark text
                pictureBox1.Image = watermarkedImage;
            }
        }

        public static Image AddWatermark(Image image, string watermarkText)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
                Color color = Color.FromArgb(128, 255, 255, 255); // White color with transparency
                SolidBrush brush = new SolidBrush(color);
                Point atPoint = new Point(image.Width - 120, image.Height - 30); // Position of the watermark

                graphics.DrawString(watermarkText, font, brush, atPoint);
            }
            return image;
        }

        private void frmInvestigationImageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Or Application.Exit();
            }
        }
    }
}
