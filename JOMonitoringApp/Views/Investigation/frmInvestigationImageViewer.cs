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

        public frmInvestigationImageViewer()
        {
            InitializeComponent();
            imageFiles = new List<string>();
            currentImageIndex = 0;
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
                    LoadImage(imageFiles[currentImageIndex]);
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

        public void LoadImage(string imagePath)
        {
            pictureBox1.Image = Image.FromFile(imagePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (imageFiles.Count > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % imageFiles.Count;
                LoadImage(imageFiles[currentImageIndex]);
            }
        }
    }
}
