using AccountingSystem;
using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private int _investigationId;

        private bool updateFirstImage = false;  
        private bool updateSecondImage = false;


        private bool removeFirstImage = false;
        private bool removeSecondImage = false;

        private float zoom = 1.0f;
        private Point mouseDownPosition;
        private bool isPanning = false;

        public frmInvestigationImageViewer(string imageFilePath, string secondaryImageFilePath, int investigationId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            imageFiles = new List<string>();
            currentImageIndex = 0;

            _investigationId = investigationId;
            _imageFilePath  = imageFilePath;
            _secondaryImageFilePath = secondaryImageFilePath;

        }

      

        private void OnLoad()
        {
            if (!string.IsNullOrEmpty(_imageFilePath) || !string.IsNullOrEmpty(_secondaryImageFilePath))
            {
                Cursor cursor = Cursors.WaitCursor;
                string sharedFolderPath = @"\\PWCServerPag\InvestigationImage"; // Replace with your shared folder path

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
                return;
            }

            Dictionary<string, string> GetImagePath = Factory.InvestigationRepository().GetImagePathByInvestigationId(_investigationId);

            _imageFilePath = GetImagePath["image_path"];
            _secondaryImageFilePath = GetImagePath["secondary_image_path"];
        }

        private void frmInvestigationImageViewer_Load(object sender, EventArgs e)
        {
            OnLoad();
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


        private InvestigationModel InvestigationModel()
        {

            string folderPath = "\\\\" + Helper.ServerName + "\\InvestigationImage\\";
            string secondFolderPath = "\\\\" + Helper.ServerName + "\\InvestigationImage\\";

            var model = new InvestigationModel
            {
                Id = _investigationId,
                ImagePath = removeFirstImage ? string.Empty : folderPath + Path.GetFileName(_imageFilePath),
                SecondaryImagePath = removeSecondImage ? string.Empty : secondFolderPath + Path.GetFileName(_secondaryImageFilePath),
             
            };

            return model;
        }

        private bool UpdateImage()
        {
            var investigationModel = InvestigationModel();
            var investigationResult = Factory.InvestigationRepository().UpdateImage(investigationModel);


            return investigationResult;
        }

        private void SaveFirstImage()
        {
            try
            {

                if (!string.IsNullOrEmpty(_imageFilePath) && UpdateImage())
                {
                    string sharedFolderPath = @"\\PWCServerPag\InvestigationImage";

                    if (!Directory.Exists(sharedFolderPath))
                    {
                        Helper.MessageBoxSuccess("Shared folder not found: " + sharedFolderPath);
                        return;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    string destination1 = Path.Combine(sharedFolderPath, Path.GetFileName(_imageFilePath));
                    File.Copy(_imageFilePath, destination1, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void DeleteImage()
        {
            try
            {
                var investigationModel = InvestigationModel();
                var investigationResult = Factory.InvestigationRepository().UpdateImage(investigationModel);

                if (investigationResult)
                {
                    removeFirstImage = false;
                    removeSecondImage = false;
                    btnApproved.Enabled = false;
                }
                return;
            }
            catch (Exception)
            {
            }
        }

        private void SaveSecondImage()
        {
            try
            {
                if (!string.IsNullOrEmpty(_secondaryImageFilePath) &&  UpdateImage())
                {
                    string sharedFolderPath = @"\\PWCServerPag\InvestigationImage";

                    if (!Directory.Exists(sharedFolderPath))
                    {
                        Helper.MessageBoxSuccess("Shared folder not found: " + sharedFolderPath);
                        return;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    string destination1 = Path.Combine(sharedFolderPath, Path.GetFileName(_secondaryImageFilePath));
                    File.Copy(_secondaryImageFilePath, destination1, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
           if (updateFirstImage) 
                SaveFirstImage(); 

           if (updateSecondImage) 
                SaveSecondImage();


            if (removeFirstImage || removeSecondImage)
            {
                DeleteImage();
            }

            Helper.MessageBoxSuccess("Image/s successfully updated.");
            Helper.ImagePath = _imageFilePath;
            Helper.SecondaryImagePath = _secondaryImageFilePath;    
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDisapproved_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to cancel updating images?"))
            {
                btnApproved.Enabled = false;
                this.Close();
            }

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Clone the image to avoid modifying the original
                using (var bmp = new Bitmap(pictureBox1.Image))
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    // Dispose previous image
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = new Bitmap(bmp);
                }
            }
        }


        private void btnRotateImage2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                // Clone the image to avoid modifying the original
                using (var bmp = new Bitmap(pictureBox2.Image))
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    // Dispose previous image
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = new Bitmap(bmp);
                }
            }
        }

        private void btnDeleteImage1_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to remove this first image?"))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image = null;
                    _imageFilePath = string.Empty; // Clear the file path
                    removeFirstImage = true;
                    btnApproved.Enabled = true;
                }
                return;
            }
        }

        private void btnDeleteImage2_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to remove this 2nd image?"))
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image = null;
                    _secondaryImageFilePath = string.Empty; // Clear the file path
                    removeSecondImage = true;
                    btnApproved.Enabled = true;

                }
                return;
            }
        }

        private void frmInvestigationImageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.ImagePath = _imageFilePath;
            Helper.SecondaryImagePath = _secondaryImageFilePath;
        }

        private void btnUpdateImage1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int selectedCount = openFileDialog.FileNames.Length;

                    if (selectedCount > 2)
                    {
                        Helper.MessageBoxSuccess("Please select only 1");
                        return;
                    }

                    _imageFilePath = openFileDialog.FileNames[0];

                    // Insert after setting _imageFilePath in btnUpdateImageOne_Click
                    if (!string.IsNullOrEmpty(_imageFilePath))
                    {
                        // Dispose the previous image if any
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                        }
                        using (var tempImage = Image.FromFile(_imageFilePath))
                        {
                            pictureBox1.Image = new Bitmap(tempImage);
                        }
                    }
                    Helper.ImagePath = _imageFilePath;
                    btnApproved.Enabled = true;
                    updateFirstImage = true;
                }
            }
        }

        private void btnUpdateImage2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int selectedCount = openFileDialog.FileNames.Length;

                    if (selectedCount > 2)
                    {
                        Helper.MessageBoxSuccess("Please select only 1");
                        return;
                    }

                    _secondaryImageFilePath = openFileDialog.FileNames[0];


                    // Insert after setting _imageFilePath in btnUpdateImageOne_Click
                    if (!string.IsNullOrEmpty(_secondaryImageFilePath))
                    {
                        // Dispose the previous image if any
                        if (pictureBox2.Image != null)
                        {
                            pictureBox2.Image.Dispose();
                            pictureBox2.Image = null;
                        }
                        using (var tempImage = Image.FromFile(_secondaryImageFilePath))
                        {
                            pictureBox2.Image = new Bitmap(tempImage);
                        }
                    }
                    Helper.SecondaryImagePath = _secondaryImageFilePath;
                    btnApproved.Enabled = true;
                    updateSecondImage = true;
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenImageExternally(_imageFilePath);
        }

        private void OpenImageExternally(string imagePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo(imagePath)
                {
                    UseShellExecute = true // important to open with default app
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open image: " + ex.Message);
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            OpenImageExternally(_secondaryImageFilePath);
        }
    }
}
