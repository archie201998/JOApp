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

namespace JOMonitoringApp.Views.PromptBox
{
    public partial class frmMessagePrompt : Form
    {
        public frmMessagePrompt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmMessagePrompt_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
