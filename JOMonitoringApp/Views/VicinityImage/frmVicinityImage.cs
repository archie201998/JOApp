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

        public enum PaperSize
        {
            Short,  // 8.5" x 11"
            Long    // 8.5" x 13"

        }
        private Image originalImage;
        private string currentImagePath;

        private PaperSize selectedPaperSize = PaperSize.Short;
        private List<string> signatories = new List<string>();



        private int _jobOrderId; // For loading existing images
        private string _accountName;

        private int defaulTitleFontSize = 40; 
        private int defaulDescritpionFontSize = 20;


        private int defaultTitleX = 22;
        private int defaultTitleY = 22;

        private int defaultDescriptionX = 22;
        private int defaultDescriptionY = 82;

        public frmVicinityImage(int jobOrderId, string accountName)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            pbImageDisplay.AllowDrop = true;
            _jobOrderId = jobOrderId;
            _accountName = accountName;
            //SetupPrintDocument();
            
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
                    g.DrawString(title, titleFont, shadowBrush, defaultTitleX, defaultTitleY + 2);
                    g.DrawString(title, titleFont, textBrush, defaultTitleX, defaultTitleY);
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
            // Check if image exists first
            if (pbImageDisplay.Image == null)
            {
                MessageBox.Show("Please load an image first!", "No Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Setup signatories
            List<string> signatures = new List<string>
            {
                "DOME BERNABE JR.\nProject Officer",
            };

            SetupPrinting(PaperSize.Long, signatures);

            // Show print dialog
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

            // Optional: Show print preview instead
            // PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            // previewDialog.Document = printDocument1;
            // if (previewDialog.ShowDialog() == DialogResult.OK)
            // {
            //     printDocument1.Print();
            // }
        }

        private void SetupPrinting(PaperSize paperSize, List<string> signatureNames)
        {
            selectedPaperSize = paperSize;
            signatories = signatureNames ?? new List<string>();

            // Configure the paper size
            System.Drawing.Printing.PaperSize ps;
            if (paperSize == PaperSize.Short)
            {
                // Short bond: 8.5" x 11" (850 x 1100 in hundredths of an inch)
                ps = new System.Drawing.Printing.PaperSize("Short Bond", 850, 1100);
            }
            else
            {
                // Long bond: 8.5" x 13" (850 x 1300 in hundredths of an inch)
                ps = new System.Drawing.Printing.PaperSize("Long Bond", 850, 1300);
            }

            printDocument1.DefaultPageSettings.PaperSize = ps;
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

            // Reserve space for signatories at the bottom (adjust as needed)
            float signatoryHeight = signatories.Count > 0 ? 120 : 0; // Space for signature area
            float gapBetweenImageAndSignature = 100; // 1 inch gap

            // Calculate printable area (reduced by signatory space + gap)
            float printableWidth = e.PageBounds.Width - marginLeft - marginRight;
            float printableHeight = e.PageBounds.Height - marginTop - marginBottom - signatoryHeight - gapBetweenImageAndSignature;

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

            // Center the image horizontally, align to top vertically
            float x = marginLeft + (printableWidth - printWidth) / 2;
            float y = marginTop;

            // Draw the image
            RectangleF destRect = new RectangleF(x, y, printWidth, printHeight);
            e.Graphics.DrawImage(img, destRect);

            // Draw signatories 1 inch below the image
            if (signatories.Count > 0)
            {
                float signatoryY = y + printHeight + gapBetweenImageAndSignature; // 1 inch below image
                DrawSignatories(e.Graphics, marginLeft, signatoryY, printableWidth, signatoryHeight);
            }

            // No more pages to print
            e.HasMorePages = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            defaulTitleFontSize -= 5;
            UpdateImagePreview();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            defaulTitleFontSize += 5;
            UpdateImagePreview();
        }

        private void btnDecreasedDescriptionFont_Click(object sender, EventArgs e)
        {
            defaulDescritpionFontSize -= 5;
            UpdateImagePreview();
        }

        private void btnIncreasedDescriptionFont_Click(object sender, EventArgs e)
        {
            defaulDescritpionFontSize += 5;
            UpdateImagePreview();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {

            defaultTitleX -= 6;
            UpdateImagePreview();
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            defaultTitleX += 6;
            UpdateImagePreview();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            defaultTitleY += 6;
            UpdateImagePreview();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            defaultTitleY -= 6;
            UpdateImagePreview();
        }

        private void DrawSignatories(Graphics g, float x, float y, float width, float height)
        {
            Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            Font nameFont = new Font("Arial", 10, FontStyle.Regular);
            Pen linePen = new Pen(Color.Black, 1);

            // Draw "Checked by:" label at the top
            float labelY = y;
            g.DrawString("Checked by:", labelFont, Brushes.Black, x, labelY);

            int count = signatories.Count;
            float columnWidth = width / count;
            float lineY = y + 50; // Space for label + signature space
            float nameY = lineY + 5;

            for (int i = 0; i < count; i++)
            {
                float colX = x + (i * columnWidth);
                float centerX = colX + (columnWidth / 2);

                // Draw signature line
                float lineStart = centerX - 80;
                float lineEnd = centerX + 80;
                g.DrawLine(linePen, lineStart, lineY, lineEnd, lineY);

                // Draw signatory name and position (centered)
                string[] lines = signatories[i].Split('\n');
                float currentY = nameY;

                foreach (string line in lines)
                {
                    SizeF textSize = g.MeasureString(line, nameFont);
                    float textX = centerX - (textSize.Width / 2);
                    g.DrawString(line, nameFont, Brushes.Black, textX, currentY);
                    currentY += textSize.Height;
                }
            }

            labelFont.Dispose();
            nameFont.Dispose();
            linePen.Dispose();
        }

    }
}
