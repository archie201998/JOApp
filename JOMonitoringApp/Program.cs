using JOMonitoringApp.Views;
using JOMonitoringApp.Views.Config;
using JOMonitoringApp.Views.Customers;
using JOMonitoringApp.Views.Investigation;
using JOMonitoringApp.Views.JobOrder.JobOrderRepairs;
using JOMonitoringApp.Views.MainForm.Approval;
using JOMonitoringApp.Views.Materials;
using JOMonitoringApp.Views.Reports;
using JOMonitoringApp.Views.Updates;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace JOMonitoringApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UpdateNotificationManager.CheckAndShowUpdateNotification();
            Application.Run(new frmSignIn());
        }
    }
}

