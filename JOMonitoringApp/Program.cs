using JOMonitoringApp.Views.Config;
using JOMonitoringApp.Views.Customers;
using JOMonitoringApp.Views.Investigation;
using JOMonitoringApp.Views.MainForm.Approval;
using JOMonitoringApp.Views.Materials;
using System;
using System.Windows.Forms;

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
            Application.Run(new frmSignIn());
        }
    }
}

