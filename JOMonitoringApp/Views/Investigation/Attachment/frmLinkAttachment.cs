using AccountingSystem;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation.Attachment
{
    public partial class frmLinkAttachment : Form
    {

        public frmLinkAttachment(string link1, string link2)
        {
            InitializeComponent();

            textBox1.Text = link1;
            textBox2.Text = link2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenLink(textBox1.Text.Trim());
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            Helper.imageLink1 = textBox1.Text.Trim();   
            Helper.imageLink2 = textBox2.Text.Trim();
            Helper.MessageBoxSuccess("The link has been attached temporarily; please save it on the main form.");
            Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            OpenLink(textBox2.Text.Trim());
        }

        private void OpenLink(string link)
        {
            string url = link;

            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    // Ensure it has a protocol
                    if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    {
                        url = "http://" + url;
                    }

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // required to open in default browser
                    });
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError("Could not open link");
                }
            }
        }
    }
}
