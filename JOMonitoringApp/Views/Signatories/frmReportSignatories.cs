using AccountingSystem;
using JOMonitoringApp.Views.PromptBox;
using System;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Signatories
{
    public partial class frmReportSignatories : Form
    {
        public frmReportSignatories()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgDocuments);
            Helper.DatagridFullRowSelectStyle(dgUsers);
        }

        private void frmReportSignatories_Load(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
        }
    }
}
