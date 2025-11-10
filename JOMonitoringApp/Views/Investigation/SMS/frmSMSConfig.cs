using AccountingSystem;
using Nancy.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation.SMS
{
    public partial class frmSMSConfig : Form
    {
        public frmSMSConfig()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings.Remove("SMS_ComPort");
                config.AppSettings.Settings.Add("SMS_ComPort", cmbxComport.Text);

                config.AppSettings.Settings.Remove("SMS_DefaultHeader");
                config.AppSettings.Settings.Add("SMS_DefaultHeader", txtMessageHeader.Text);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                Helper.MessageBoxSuccess("Configuration saved successfully!");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"Error saving configuration: {ex.Message}");
            }
        }
    }
}
