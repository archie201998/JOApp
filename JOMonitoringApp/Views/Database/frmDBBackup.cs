using AccountingSystem;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Database
{
    public partial class frmDBBackup : Form
    {
        private CancellationTokenSource cts;
        public frmDBBackup()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Starting...";
            Thread.Sleep(2000);
            cts = new CancellationTokenSource();

            // Start spinner animation in the label
            var spinnerTask = ShowSpinner(lblStatus, cts.Token);

            // Run the batch file
            await Task.Run(() => RunBatchFile());

            // Stop spinner and update label
            cts.Cancel();
            await spinnerTask;
            lblStatus.Text = "Batch file completed!";
        }

        private void RunBatchFile()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"\\192.168.18.68\J.O e-Monitoring\mysql_backup.bat";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }

        private async Task ShowSpinner(Label label, CancellationToken token)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                label.Invoke(new Action(() =>
                {
                    label.Text = "Running... " + spinner[index];
                }));

                index = (index + 1) % spinner.Length;
                await Task.Delay(200);
            }
        }

        private void frmDBBackup_Load(object sender, EventArgs e)
        {

        }
    }
}
