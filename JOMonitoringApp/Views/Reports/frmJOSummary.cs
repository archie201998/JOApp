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

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmJOSummary : Form
    {
        public frmJOSummary()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
        }

        private void FrmJOSummary_Load(object sender, EventArgs e)
        {
            LoadMonths();
            this.reportViewer1.RefreshReport();
        }



        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                comboBox1.Items.Add(item);
            comboBox1.SelectedIndex = 1;
        }

        private void LoadReports()
        { 
        
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReports();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
