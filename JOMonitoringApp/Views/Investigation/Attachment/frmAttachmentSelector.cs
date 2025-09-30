using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation.Attachment
{
    public partial class frmAttachmentSelector : Form
    {
        public frmAttachmentSelector()
        {
            InitializeComponent();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
           Helper.attachLink = true;
           this.Close();
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            Helper.attachLink = false;
            this.Close();
        }
        private void frmAttachmentSelector_Load(object sender, EventArgs e)
        {

        }

       
    }
}
