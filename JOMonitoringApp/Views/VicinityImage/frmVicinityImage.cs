using AccountingSystem;
using JOMonitoringApp.Properties;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Nancy.Routing.Trie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace JOMonitoringApp.Views.VicinityImage
{
    public partial class frmVicinityImage : Form
    {

        private Image originalImage;
        private string currentImagePath;


        private int _jobOrderId; // For loading existing images
        private string _accountName;

        private int defaulTitleFontSize = 40; 
        private int defaulDescritpionFontSize = 20; 

        public frmVicinityImage(int jobOrderId, string accountName)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            pbImageDisplay.AllowDrop = true;
            _jobOrderId = jobOrderId;
            _accountName = accountName;
            SetupPrintDocument();
            
        }

        private void frmVicinityImage_Load(object sender, EventArgs e)
        {
            LoadImageFromDatabase(_jobOrderId);
            txtTitle.Text = _accountName;
        }

        private void LoadImage(string path)
        {
            try
            {
                // Dispose previous image to free memory
                originalImage?.Dispose();

                // Load new image
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    originalImage = Image.FromStream(stream);
                }

                currentImagePath = path;
                UpdateImagePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbImageDisplay_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void pbImageDisplay_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
                LoadImage(files[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofdImageUpload.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofdImageUpload.ShowDialog() == DialogResult.OK)
                LoadImage(ofdImageUpload.FileName);

        }

        private void UpdateImagePreview()
        {
            if (originalImage == null) return;

            // Create a copy of the original image
            Bitmap overlayImage = new Bitmap(originalImage);

            using (Graphics g = Graphics.FromImage(overlayImage))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Prepare text 
                string title = txtTitle.Text;
                string description = txtDescription.Text;

                // Configure font and brush
         
                Font titleFont = new Font("Arial", defaulTitleFontSize, FontStyle.Bold);
                Font descFont = new Font("Arial", defaulDescritpionFontSize);
                Brush textBrush = Brushes.White;
                Brush shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));

                // Draw title with shadow
                if (!string.IsNullOrEmpty(title))
                {
                    g.DrawString(title, titleFont, shadowBrush, 22, 22);
                    g.DrawString(title, titleFont, textBrush, 20, 20);
                }

                // Draw description with shadow
                if (!string.IsNullOrEmpty(description))
                {
                    g.DrawString(description, descFont, shadowBrush, 22, 82);
                    g.DrawString(description, descFont, textBrush, 20, 80);
                }
            }

            pbImageDisplay.Image = overlayImage;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateImagePreview();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateImagePreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please select an image first.", "No Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the image.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            try
            {
                Image imageToSave = pbImageDisplay.Image;
                string fileName = Path.GetFileName(currentImagePath);

                // Save to database
                bool success = Factory.JobOrdersRepository().InsertVicinityImage(
                    _jobOrderId,
                    imageToSave
                );

                if (success)
                {
                    MessageBox.Show("Vicinity Image Saved.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Failed to save image to database.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to database: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable controls
                btnSave.Enabled = true;
                btnBrowse.Enabled = true;
                btnClear.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void ClearForm()
        {
            // Dispose images to free memory
            if (originalImage != null)
            {
                originalImage.Dispose();
                originalImage = null;
            }

            if (pbImageDisplay.Image != null)
            {
                pbImageDisplay.Image.Dispose();
                pbImageDisplay.Image = Resources.Drop_image_file_here;
            }

            // Clear textboxes
            txtTitle.Text = "Enter Caption Here";
            txtDescription.Text = "Enter Caption Details Here";

            // Reset path
            currentImagePath = null;

            // Reset file dialog
            ofdImageUpload.FileName = string.Empty;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadImageFromDatabase(Convert.ToInt32(textBox1.Text));
        }

        private void LoadImageFromDatabase(int imageId)
        {

                // Dispose previous image to free memory
                if (pbImageDisplay.Image != null)
                {
                    pbImageDisplay.Image.Dispose();
                    pbImageDisplay.Image = null;
                }

                // Load image from database
                Image loadedImage = Factory.JobOrdersRepository().GetVicinityImage(imageId);

                if (loadedImage != null)
                {
                    pbImageDisplay.Image = loadedImage;
                    MessageBox.Show("Image loaded successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No image found for this record.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (pbImageDisplay.Image == null)
            {
                MessageBox.Show("Please load an image first!", "No Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show print preview dialog (optional)
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;

            //if (previewDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Print the document
            //    printDocument1.Print();
            //}

            // Or print directly without preview:
            printDocument1.Print();
        }

        private void SetupPrintDocument()
        {
            // Set paper size to half bond (8.5" x 5.5") portrait
            PaperSize halfBond = new PaperSize("Half Bond", 850, 550);
            printDocument1.DefaultPageSettings.PaperSize = halfBond;
            printDocument1.DefaultPageSettings.Landscape = false; // Portrait orientation
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            if (pbImageDisplay.Image == null)
                return;

            // Get the image from PictureBox
            Image img = pbImageDisplay.Image;

            // Define margins (in hundredths of an inch)
            float marginLeft = 50;   // 0.5 inch
            float marginTop = 50;    // 0.5 inch
            float marginRight = 50;  // 0.5 inch
            float marginBottom = 50; // 0.5 inch

            // Calculate printable area
            float printableWidth = e.PageBounds.Width - marginLeft - marginRight;
            float printableHeight = e.PageBounds.Height - marginTop - marginBottom;

            // Calculate image dimensions maintaining aspect ratio
            float imgWidth = img.Width;
            float imgHeight = img.Height;
            float aspectRatio = imgWidth / imgHeight;

            float printWidth, printHeight;

            if (printableWidth / printableHeight > aspectRatio)
            {
                // Height is the limiting factor
                printHeight = printableHeight;
                printWidth = printHeight * aspectRatio;
            }
            else
            {
                // Width is the limiting factor
                printWidth = printableWidth;
                printHeight = printWidth / aspectRatio;
            }

            // Center the image on the page
            float x = marginLeft + (printableWidth - printWidth) / 2;
            float y = marginTop + (printableHeight - printHeight) / 2;

            // Draw the image
            RectangleF destRect = new RectangleF(x, y, printWidth, printHeight);
            e.Graphics.DrawImage(img, destRect);

            // No more pages to print
            e.HasMorePages = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            defaulTitleFontSize -= 1;
            UpdateImagePreview();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            defaulTitleFontSize += 1;
            UpdateImagePreview();
        }

        private void btnDecreasedDescriptionFont_Click(object sender, EventArgs e)
        {
            defaulDescritpionFontSize -= 1;
            UpdateImagePreview();
        }

        private void btnIncreasedDescriptionFont_Click(object sender, EventArgs e)
        {
            defaulDescritpionFontSize += 1;
            UpdateImagePreview();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

    }
}
