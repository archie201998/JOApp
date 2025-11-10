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

namespace JOMonitoringApp.Views.Investigation.SMS
{
    public partial class frmAdvisory : Form
    {
        private SerialPort gsmPort;
        private bool isConnected = false;
        private DataTable investigationsTable;
        private int currentIndex = 0;
        public frmAdvisory()
        {
            InitializeComponent();
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



        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Connect("COM6", 9600))
            {
                lblConnectionStatus.Text = "CONNECTED";
                lblConnectionStatus.ForeColor = Color.Green;
                return;
            }

            lblConnectionStatus.Text = "DISCONNECTED";
            lblConnectionStatus.ForeColor = Color.Red;
        }

        public bool Connect(string portName, int baudRate)
        {
            try
            {
                // Initialize serial port
                gsmPort = new SerialPort();
                gsmPort.PortName = portName;
                gsmPort.BaudRate = baudRate;
                gsmPort.DataBits = 8;
                gsmPort.StopBits = StopBits.One;
                gsmPort.Parity = Parity.None;
                gsmPort.ReadTimeout = 3000;
                gsmPort.WriteTimeout = 3000;
                gsmPort.Handshake = Handshake.None;
                gsmPort.DtrEnable = true;
                gsmPort.RtsEnable = true;

                // Open the port
                gsmPort.Open();
                Thread.Sleep(500); // Wait for modem to be ready

                // Test connection with AT command
                gsmPort.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(500);
                string response = gsmPort.ReadExisting();

                if (response.Contains("OK"))
                {
                    // Set modem to text mode for SMS
                    gsmPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                    Thread.Sleep(300);
                    string textModeResponse = gsmPort.ReadExisting();

                    if (textModeResponse.Contains("OK"))
                    {
                        isConnected = true;
                        return true;
                    }
                    else
                    {
                        gsmPort.Close();
                        return false;
                    }
                }
                else
                {
                    gsmPort.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (gsmPort != null && gsmPort.IsOpen)
                {
                    gsmPort.Close();
                }
                throw new Exception("Connection failed: " + ex.Message);
            }
        }


        public void Disconnect()
        {
            try
            {
                if (gsmPort != null && gsmPort.IsOpen)
                {
                    gsmPort.Close();
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
    }
}
