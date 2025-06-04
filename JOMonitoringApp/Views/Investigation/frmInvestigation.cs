using AccountingSystem;
using JOMonitoringApp.Views.PromptBox;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigation : Form
    {
        public frmInvestigation()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
          
        }

        private void ShowMdiChildForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowMdiChildForm(new frmInvestigationList());
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
        }
    }
}
