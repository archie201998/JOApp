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

namespace JOMonitoringApp.Views.Investigation
{
    
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber; 

        public frmInvestigationAdjustment(string accountNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _accountNumber = accountNumber; 
        }

        private void frmInvestigationAdjustment_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string particular = cmbxParticular.Text;
            //Leaking
            //Leaking(Not Visible)
            //Failed Calibration
            //Erroneous Reading
            //RFB + Illegal


            switch (particular)
            {
                case "Leaking":
                    ComputeLeaking();
                    break;
                case "Failed Calibration":
                    ComputeFailedCalibration();
                    break;

                case "Erroneous Reading":
                    ComputeErroneousReading();
                    break;

                case "Leaking (Not Visible)":
                    ComputeLeakingNotVisible();
                    break;

                default:
                    break;
            }
        }

        private void ComputeLeaking()
        {
            MessageBox.Show("ComputeLeaking");
        }

        private void ComputeLeakingNotVisible()
        {
            MessageBox.Show("ComputeLeakingNotVisible");
        }

        private void ComputeErroneousReading()
        {
            MessageBox.Show("ComputeErroneousReading");
        }

        private void ComputeFailedCalibration()
        {
            MessageBox.Show("ComputeFailedCalibration");
        }
    }
}
