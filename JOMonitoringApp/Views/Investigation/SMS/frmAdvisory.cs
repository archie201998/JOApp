using AccountingSystem;
using JOMonitoringApp.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace JOMonitoringApp.Views.Investigation.SMS
{
    public partial class frmAdvisory : Form
    {

        private SerialPort serialPort;
        private bool isConnected = false;

        public frmAdvisory()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmAdvisory_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyleEditable(dgRecipients);
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void customizeMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInvestigationsToGrid(dgRecipients);
        }

        private void messageConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private async void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                LogMessage($"Connecting to COM6");

                serialPort = new SerialPort
                {
                    PortName = "COM6",
                    BaudRate = 57600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Handshake = Handshake.None,
                    ReadTimeout = 3000,
                    WriteTimeout = 3000
                };

                serialPort.Open();
                await Task.Delay(1000);

                // Test connection
                string response = await SendATCommandAsync("AT");

                if (response.Contains("OK"))
                {
                    response = await SendATCommandAsync("AT+CPIN?");

                    if (response.Contains("READY") || response.Contains("OK"))
                    {
                        // Configure SMS mode
                        await SendATCommandAsync("AT+CMGF=1");
                        await SendATCommandAsync("AT+CSCS=\"GSM\"");

                        isConnected = true;
                        LogMessage("✓ Connected successfully!");

                        // Check initial signal
                        await CheckSignalStrength();
                    }
                    else
                    {
                        throw new Exception("SIM card not ready. Please check SIM card.");
                    }
                }
                else
                {
                    throw new Exception("GSM module not responding.");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"✗ Connection failed: {ex.Message}");
                MessageBox.Show($"Connection failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                connectToolStripMenuItem.Enabled = true;
                connectToolStripMenuItem.Text = "Connect";
            }
        }

       


        public void Disconnect()
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    isConnected = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Disconnection failed: " + ex.Message);
            }
        }

        #region Select ALl

        private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;

                if (dataGridView.IsCurrentCellDirty && dataGridView.CurrentCell is DataGridViewCheckBoxCell)
                {
                    dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error committing edit: " + ex.Message);
            }
        }

        // Event handler for column header click (Select All functionality)
        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;

                if (e.ColumnIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "Select")
                {
                    // Determine if we should select all or deselect all
                    bool selectAll = true;

                    // Check if all are already selected
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["Select"].Value == null || !Convert.ToBoolean(row.Cells["Select"].Value))
                        {
                            selectAll = true;
                            break;
                        }
                        selectAll = false;
                    }

                    // Toggle all checkboxes
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        row.Cells["Select"].Value = selectAll;
                    }

                    dataGridView.EndEdit();
                    dataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Select All: " + ex.Message);
            }
        }

        #endregion

        public void LoadInvestigationsToGrid(DataGridView dataGridView)
        {
            try
            {
                DataTable dt = GetApprovedInvestigations();
                dataGridView.DataSource = dt;

                // Configure checkbox column
                if (dataGridView.Columns.Contains("Select"))
                {
                    dataGridView.Columns["Select"].HeaderText = "Select All";
                    dataGridView.Columns["Select"].Width = 70;
                    dataGridView.Columns["Select"].DisplayIndex = 0; // Move to first position

                    // Add event handlers
                    dataGridView.CurrentCellDirtyStateChanged -= DataGridView_CurrentCellDirtyStateChanged;
                    dataGridView.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
                    dataGridView.ColumnHeaderMouseClick -= DataGridView_ColumnHeaderMouseClick;
                    dataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
                }

                if (dataGridView.Columns.Contains("job_order_no"))
                {
                    dataGridView.Columns["job_order_no"].HeaderText = "J.O. No.";
                    dataGridView.Columns["job_order_no"].Width = 60;
                }
                if (dataGridView.Columns.Contains("account_number"))
                {
                    dataGridView.Columns["account_number"].HeaderText = "Account Number";
                    dataGridView.Columns["account_number"].Width = 100;
                }
                if (dataGridView.Columns.Contains("account_name"))
                {
                    dataGridView.Columns["account_name"].HeaderText = "Account Name";
                    dataGridView.Columns["account_name"].Width = 200;
                }
                if (dataGridView.Columns.Contains("contact_number"))
                {
                    dataGridView.Columns["contact_number"].HeaderText = "Contact No.";
                    dataGridView.Columns["contact_number"].Width = 150;
                }
                if (dataGridView.Columns.Contains("nature_of_complaint"))
                {
                    dataGridView.Columns["nature_of_complaint"].HeaderText = "Particular";
                    dataGridView.Columns["nature_of_complaint"].Width = 150;
                }
                if (dataGridView.Columns.Contains("result"))
                {
                    dataGridView.Columns["result"].HeaderText = "Result";
                    dataGridView.Columns["result"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error binding to DataGridView: " + ex.Message);
            }
        }


        public DataTable GetApprovedInvestigations()
        {
            try
            {
                // Get approved investigations from repository
                DataTable investigations = Factory.InvestigationRepository().GetApprovedInvestigations();

                // Create DataTable for DataGridView
                DataTable dt = new DataTable();

                // Add checkbox column FIRST as a boolean type
                dt.Columns.Add("Select", typeof(bool));

                // Add other columns
                dt.Columns.Add("job_order_no", typeof(string));
                dt.Columns.Add("account_number", typeof(string));
                dt.Columns.Add("account_name", typeof(string));
                dt.Columns.Add("contact_number", typeof(string));
                dt.Columns.Add("nature_of_complaint", typeof(string));
                dt.Columns.Add("result", typeof(string));

                // Populate DataTable
                foreach (DataRow investigation in investigations.Rows)
                {
                    DataRow row = dt.NewRow();
                    row["Select"] = false; // Initialize checkbox as unchecked
                    row["job_order_no"] = investigation["job_order_no"];
                    row["account_number"] = investigation["account_number"];
                    row["account_name"] = investigation["account_name"];
                    row["contact_number"] = investigation["contact_number"];
                    row["nature_of_complaint"] = investigation["nature_of_complaint"];
                    row["result"] = string.Empty;
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading approved investigations: " + ex.Message);
            }
        }

        private void LogMessage(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            lblSignal.Text = $"[{timestamp}] - {message}\r\n";
        }


        private string ReadResponse(int timeout)
        {
            string response = string.Empty;
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < timeout)
            {
                try
                {
                    if (serialPort.BytesToRead > 0)
                    {
                        response += serialPort.ReadExisting();
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
                catch
                {
                    break;
                }
            }

            return response;
        }

        private async Task<string> SendATCommandAsync(string command, int timeout = 2000)
        {
            return await Task.Run(() =>
            {
                try
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.WriteLine(command);
                    Thread.Sleep(timeout);
                    return ReadResponse(timeout);
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            });
        }


        private async void btnPrint_Click(object sender, EventArgs e)
        {
            string phoneNumber = string.Empty;
            string message = string.Empty;

            try
            {
                btnSendSMS.Enabled = false;
                btnSendSMS.Text = "Sending...";

                progressBar1.Visible = true;
                progressBar1.Value = 0;

                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.WriteLine("AT+CMGF=1\r"); // set text mode once
                await Task.Delay(200);

                int total = dgRecipients.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                int count = 0;

                foreach (DataGridViewRow row in dgRecipients.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Skip the new row placeholder if it's allowed in your grid
                    if (row.IsNewRow) continue;

                    dgRecipients.ClearSelection();
                    row.Selected = true;
                    dgRecipients.FirstDisplayedScrollingRowIndex = row.Index;
                    Application.DoEvents();

                    //phoneNumber = row.Cells["contact_number"].Value?.ToString().Trim();
                    phoneNumber = "+639511905651"; 
                    message = row.Cells["account_number"].Value?.ToString().Trim();

                    if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
                        continue; // skip invalid rows instead of stopping loop

                    LogMessage($"Sending SMS to {phoneNumber}...");
                    LogMessage($"Message: {message}");

                    serialPort.WriteLine($"AT+CMGS=\"{phoneNumber}\"\r");

                    string response = ReadResponse(4000);
                    if (!response.Contains(">"))
                    {
                        LogMessage("No prompt received, skipping...");
                        continue;
                    }

                    serialPort.Write(message + char.ConvertFromUtf32(26)); // send + Ctrl+Z
                    response = ReadResponse(6000);

                    if (response.Contains("+CMGS:") || response.Contains("OK"))
                    {
                        LogMessage("SMS sent successfully!");
                    }
                    else
                    {
                        LogMessage("SMS send failed. Response: " + response.Trim());
                    }

                    // minimal delay to prevent modem overload
                    await Task.Delay(300);

                    // progress update
                    count++;
                    progressBar1.Value = (int)((count / (double)total) * 100);
                }

                LogMessage("All messages processed.");
            }
            catch (Exception ex)
            {
                LogMessage($"SMS failed: {ex.Message}");
                MessageBox.Show($"Failed to send SMS:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendSMS.Enabled = true;
                btnSendSMS.Text = "Send SMS";
                progressBar1.Visible = false;
            }
        }


        private async Task CheckSignalStrength()
        {
            try
            {
                string response = await SendATCommandAsync("AT+CSQ");

                if (response.Contains("+CSQ:"))
                {
                    string[] parts = response.Split(new[] { "+CSQ:" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        string[] values = parts[1].Split(',');
                        if (int.TryParse(values[0].Trim(), out int rssi))
                        {
                            if (rssi == 99)
                            {
                                lblSignal.Text = "Signal: Unknown";
                                lblSignal.ForeColor = Color.Gray;
                            }
                            else
                            {
                                int signalPercent = (rssi * 100) / 31;
                                lblSignal.Text = $"Signal: {rssi}/31 ({signalPercent}%)";

                                if (rssi < 10)
                                    lblSignal.ForeColor = Color.Red;
                                else if (rssi < 20)
                                    lblSignal.ForeColor = Color.Orange;
                                else
                                    lblSignal.ForeColor = Color.Green;

                                LogMessage($"Signal strength: {rssi}/31 ({signalPercent}%)");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Failed to check signal: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = string.Empty;
            string messageHeader = "Pamana Water Corp - Pagadian:";

            switch (cmbAdvisory.SelectedItem.ToString())
            {
                case "Adjustment":
                    message = "Your meter has been adjusted after inspection. No further action needed. For concerns, visit our office.";
                    break;
                case "Change Category":
                    message = "Your account has been reclassified after investigation. For inquiries, please visit our office.";
                    break;
                case "No Leaking":
                    message = "Inspection complete. No leaks detected in your service connection. For concerns, visit our office.";
                    break;
                case "Leaking":
                    message = " Leak detected in your service connection. Immediate action recommended. Please visit our office for assistance.";
                    break;
                case "Illegal":
                    message = "Unauthorized connection detected in your account. Please visit our office to regularize.";
                    break;
                case "For calibration":
                    message = "Your meter requires calibration. Please bring it to our office for verification.";
                    break;
                case "Passed in calibration":
                    message = "Your meter has passed calibration and is in proper working condition. For inquiries, visit our office.";
                    break;
                case "Failed in calibration":
                    message = "Your meter failed calibration and needs replacement/adjustment. Please visit our office for resolution.";
                    break;
            }
            txtMessage.Text = messageHeader + Environment.NewLine + Environment.NewLine + message;
        }
    }
}
