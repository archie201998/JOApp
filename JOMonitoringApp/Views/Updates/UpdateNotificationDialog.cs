using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Updates
{
    public partial class UpdateNotificationDialog : Form
    {
        public bool DontShowAgain => dontShowCheckBox.Checked;

        public UpdateNotificationDialog(string version, string changelog)
        {
            InitializeComponent();
        }

        private void UpdateNotificationDialog_Load(object sender, EventArgs e)
        {
            FormatChangelog();

        }

        private void FormatChangelog()
        {
            changelogTextBox.SelectAll();
            changelogTextBox.SelectionFont = new Font("Segoe UI", 9.5F);

            string text = changelogTextBox.Text;
            changelogTextBox.Clear();

            string[] lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.StartsWith("##") || line.StartsWith("###"))
                {
                    // Header
                    changelogTextBox.SelectionFont = new Font("Segoe UI", 11F, FontStyle.Bold);
                    changelogTextBox.SelectionColor = Color.FromArgb(0, 120, 215);
                    changelogTextBox.AppendText(line.TrimStart('#', ' ') + "\n");
                }
                else if (line.StartsWith("- ") || line.StartsWith("* "))
                {
                    // Bullet point
                    changelogTextBox.SelectionFont = new Font("Segoe UI", 9.5F);
                    changelogTextBox.SelectionColor = Color.Black;
                    changelogTextBox.AppendText("  • " + line.Substring(2) + "\n");
                }
                else
                {
                    // Regular text
                    changelogTextBox.SelectionFont = new Font("Segoe UI", 9.5F);
                    changelogTextBox.SelectionColor = Color.Black;
                    changelogTextBox.AppendText(line + "\n");
                }
            }

            changelogTextBox.SelectionStart = 0;
            changelogTextBox.ScrollToCaret();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
