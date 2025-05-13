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
            string sharedFolderPath = @"\\192.168.18.68\InvestigationImages\Dacol"; // Replace with your shared folder path

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
                try
                {
                    // Dispose the previous image if any
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }

                    using (var tempImage = Image.FromFile(_imageFilePath))
                    {
                        // Clone the image to avoid locking the file
                        pictureBox1.Image = new Bitmap(tempImage);
                    }
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxSuccess("No image uploaded");
                }
            }

        }

        private void frmInvestigationImageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Or Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
