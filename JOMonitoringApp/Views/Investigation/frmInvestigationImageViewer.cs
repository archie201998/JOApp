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
        private string _secondaryImageFilePath;

        public frmInvestigationImageViewer(string imageFilePath, string secondaryImageFilePath)
        {
            InitializeComponent();
            imageFiles = new List<string>();
            currentImageIndex = 0;
            _imageFilePath = imageFilePath;
            _secondaryImageFilePath = secondaryImageFilePath;

            Helper.LoadFormIcon(this);
        }

        public frmInvestigationImageViewer(string jobOrderNumber)
        {
            InitializeComponent();
            imageFiles = new List<string>();
            currentImageIndex = 0;
            Helper.LoadFormIcon(this);

        }

        private void frmInvestigationImageViewer_Load(object sender, EventArgs e)
        {
            Cursor cursor = Cursors.WaitCursor;
            string sharedFolderPath = @"\\192.168.18.68\InvestigationImages\Dacol"; // Replace with your shared folder path

            if (Directory.Exists(sharedFolderPath))
            {
                imageFiles = Directory.GetFiles(sharedFolderPath, "*.*")
                                      .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".bmp") || file.EndsWith(".gif"))
                                      .ToList();

                if (imageFiles.Count > 0)
                {
                    LoadImage();
                    LoadSecondImage();
                }
                else
                {
                    MessageBox.Show("No images found in the folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Shared folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;

            ChangeImageLayout();
        }

        private void ChangeImageLayout()
        {
            if (_secondaryImageFilePath == "\\\\192.168.18.68\\InvestigationImages\\Dacol\\")
            {
                // Make pictureBox1 fill the form
                pictureBox1.Dock = DockStyle.Fill;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // Optionally hide pictureBox2
                pictureBox2.Visible = false;
            }
            else
            {
                // Restore layout if pictureBox2 is not empty
                pictureBox1.Dock = DockStyle.None;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // Set your own sizes and positions
                pictureBox1.Location = new Point(10, 10);
                pictureBox1.Size = new Size(625, 662);

                pictureBox2.Visible = true;
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
                        pictureBox1.Visible = false;
                    }

                    using (var tempImage = Image.FromFile(_imageFilePath))
                    {
                        // Clone the image to avoid locking the file
                        pictureBox1.Image = new Bitmap(tempImage);
                    }
                }
                catch (Exception ex)
                {
                    //Helper.MessageBoxSuccess("No image uploaded");
                }
            }

        }

        public void LoadSecondImage()
        {
            if (!string.IsNullOrEmpty(_secondaryImageFilePath))
            {
                try
                {
                    // Dispose the previous image if any
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                        pictureBox2.Visible = true;
                    }

                    using (var tempImage = Image.FromFile(_secondaryImageFilePath))
                    {
                        // Clone the image to avoid locking the file
                        pictureBox2.Image = new Bitmap(tempImage);
                    }
                }
                catch (Exception ex)
                {
                    //Helper.MessageBoxSuccess("No image uploaded");
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
