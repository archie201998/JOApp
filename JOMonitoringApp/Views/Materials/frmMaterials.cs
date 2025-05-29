using AccountingSystem;
using JOMonitoringApp.Views.MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Materials
{
    public partial class frmMaterials : Form
    {
        public frmMaterials()
        {
            InitializeComponent();
        }


        private void ShowMdiChildForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }


        private void frmMaterials_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowMdiChildForm(new frmListOfMaterials());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowMdiChildForm(new frmJobOrderMaterials());
        }
    }
}
