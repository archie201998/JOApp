namespace JOMonitoringApp.Views.Dashboard
{
    partial class ucDashboardSummaryView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPending = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtOnGoing = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtCancelled = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtAccomplished = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgStatPerParticular = new System.Windows.Forms.DataGridView();
            this.gbParticulars = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecentMovement = new System.Windows.Forms.Label();
            this.cmbxStatus = new System.Windows.Forms.ComboBox();
            this.btnCountPending = new System.Windows.Forms.Button();
            this.cmbxCount = new System.Windows.Forms.ComboBox();
            this.cmbxPeriod = new System.Windows.Forms.ComboBox();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatPerParticular)).BeginInit();
            this.gbParticulars.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.txtPending);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(184, 66);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(168, 150);
            this.panel6.TabIndex = 2;
            // 
            // txtPending
            // 
            this.txtPending.BackColor = System.Drawing.Color.White;
            this.txtPending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPending.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtPending.Enabled = false;
            this.txtPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPending.Location = new System.Drawing.Point(0, 38);
            this.txtPending.Name = "txtPending";
            this.txtPending.ReadOnly = true;
            this.txtPending.Size = new System.Drawing.Size(168, 73);
            this.txtPending.TabIndex = 8;
            this.txtPending.Text = "0";
            this.txtPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPending.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gold;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 111);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(168, 39);
            this.panel7.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(33, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "PENDING";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.txtOnGoing);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(358, 66);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(168, 150);
            this.panel8.TabIndex = 4;
            // 
            // txtOnGoing
            // 
            this.txtOnGoing.BackColor = System.Drawing.Color.White;
            this.txtOnGoing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOnGoing.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOnGoing.Enabled = false;
            this.txtOnGoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnGoing.Location = new System.Drawing.Point(0, 38);
            this.txtOnGoing.Name = "txtOnGoing";
            this.txtOnGoing.ReadOnly = true;
            this.txtOnGoing.Size = new System.Drawing.Size(168, 73);
            this.txtOnGoing.TabIndex = 9;
            this.txtOnGoing.Text = "0";
            this.txtOnGoing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel9.Controls.Add(this.label13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 111);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(168, 39);
            this.panel9.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "PROCESSING";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.txtCancelled);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(532, 66);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(168, 150);
            this.panel10.TabIndex = 5;
            // 
            // txtCancelled
            // 
            this.txtCancelled.BackColor = System.Drawing.Color.White;
            this.txtCancelled.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCancelled.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCancelled.Enabled = false;
            this.txtCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCancelled.Location = new System.Drawing.Point(0, 38);
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.ReadOnly = true;
            this.txtCancelled.Size = new System.Drawing.Size(168, 73);
            this.txtCancelled.TabIndex = 9;
            this.txtCancelled.Text = "0";
            this.txtCancelled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.IndianRed;
            this.panel11.Controls.Add(this.label16);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 111);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(168, 39);
            this.panel11.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(11, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 25);
            this.label16.TabIndex = 0;
            this.label16.Text = "CANCELLED";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.txtAccomplished);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Location = new System.Drawing.Point(706, 66);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(168, 150);
            this.panel12.TabIndex = 6;
            // 
            // txtAccomplished
            // 
            this.txtAccomplished.BackColor = System.Drawing.Color.White;
            this.txtAccomplished.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccomplished.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtAccomplished.Enabled = false;
            this.txtAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccomplished.Location = new System.Drawing.Point(0, 38);
            this.txtAccomplished.Name = "txtAccomplished";
            this.txtAccomplished.ReadOnly = true;
            this.txtAccomplished.Size = new System.Drawing.Size(168, 73);
            this.txtAccomplished.TabIndex = 9;
            this.txtAccomplished.Text = "0";
            this.txtAccomplished.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.SteelBlue;
            this.panel13.Controls.Add(this.label18);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 111);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(168, 39);
            this.panel13.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(1, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 24);
            this.label18.TabIndex = 0;
            this.label18.Text = "ACCOMPLISHED";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 40);
            this.panel1.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(427, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "LOAD";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(260, 10);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(164, 22);
            this.dtpTo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(232, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "TO";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(54, 10);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(164, 22);
            this.dtpFrom.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "FROM";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.lblPercentage);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(10, 222);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 39);
            this.panel3.TabIndex = 4;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPercentage.ForeColor = System.Drawing.Color.White;
            this.lblPercentage.Location = new System.Drawing.Point(278, 8);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(21, 24);
            this.lblPercentage.TabIndex = 9;
            this.lblPercentage.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "ACCOMPLISHMENT RATE : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(10, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 150);
            this.panel2.TabIndex = 8;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            this.txtTotal.Location = new System.Drawing.Point(0, 20);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(168, 91);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 39);
            this.panel4.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(40, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(83, 24);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL ";
            // 
            // dgStatPerParticular
            // 
            this.dgStatPerParticular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStatPerParticular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStatPerParticular.Location = new System.Drawing.Point(3, 3);
            this.dgStatPerParticular.Name = "dgStatPerParticular";
            this.dgStatPerParticular.Size = new System.Drawing.Size(546, 365);
            this.dgStatPerParticular.TabIndex = 9;
            // 
            // gbParticulars
            // 
            this.gbParticulars.Controls.Add(this.panel5);
            this.gbParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbParticulars.Location = new System.Drawing.Point(10, 280);
            this.gbParticulars.Name = "gbParticulars";
            this.gbParticulars.Size = new System.Drawing.Size(558, 390);
            this.gbParticulars.TabIndex = 10;
            this.gbParticulars.TabStop = false;
            this.gbParticulars.Text = "STATUS PER PARTICULAR";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgStatPerParticular);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 16);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(552, 371);
            this.panel5.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBar1.Location = new System.Drawing.Point(10, 53);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1113, 8);
            this.progressBar1.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRecentMovement);
            this.groupBox1.Controls.Add(this.cmbxStatus);
            this.groupBox1.Controls.Add(this.btnCountPending);
            this.groupBox1.Controls.Add(this.cmbxCount);
            this.groupBox1.Controls.Add(this.cmbxPeriod);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(574, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 390);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JOB ORDER PHASE";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 305);
            this.dataGridView1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "SEARCH RESULT : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(284, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "PERIOD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(176, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "NO. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "STATUS ";
            // 
            // lblRecentMovement
            // 
            this.lblRecentMovement.AutoSize = true;
            this.lblRecentMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentMovement.ForeColor = System.Drawing.Color.Black;
            this.lblRecentMovement.Location = new System.Drawing.Point(118, 61);
            this.lblRecentMovement.Name = "lblRecentMovement";
            this.lblRecentMovement.Size = new System.Drawing.Size(14, 15);
            this.lblRecentMovement.TabIndex = 19;
            this.lblRecentMovement.Text = "- ";
            // 
            // cmbxStatus
            // 
            this.cmbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxStatus.FormattingEnabled = true;
            this.cmbxStatus.Items.AddRange(new object[] {
            "Pending",
            "Processing",
            "Cancelled",
            "Accomplished"});
            this.cmbxStatus.Location = new System.Drawing.Point(61, 30);
            this.cmbxStatus.Name = "cmbxStatus";
            this.cmbxStatus.Size = new System.Drawing.Size(105, 23);
            this.cmbxStatus.TabIndex = 17;
            // 
            // btnCountPending
            // 
            this.btnCountPending.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCountPending.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCountPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountPending.ForeColor = System.Drawing.Color.White;
            this.btnCountPending.Location = new System.Drawing.Point(471, 29);
            this.btnCountPending.Name = "btnCountPending";
            this.btnCountPending.Size = new System.Drawing.Size(68, 23);
            this.btnCountPending.TabIndex = 17;
            this.btnCountPending.Text = "Count";
            this.btnCountPending.UseVisualStyleBackColor = false;
            this.btnCountPending.Click += new System.EventHandler(this.btnCountPending_Click);
            // 
            // cmbxCount
            // 
            this.cmbxCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxCount.FormattingEnabled = true;
            this.cmbxCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbxCount.Location = new System.Drawing.Point(213, 31);
            this.cmbxCount.Name = "cmbxCount";
            this.cmbxCount.Size = new System.Drawing.Size(55, 23);
            this.cmbxCount.TabIndex = 16;
            // 
            // cmbxPeriod
            // 
            this.cmbxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxPeriod.FormattingEnabled = true;
            this.cmbxPeriod.Items.AddRange(new object[] {
            "Day/s",
            "Week/s",
            "Month/s",
            "Year/s"});
            this.cmbxPeriod.Location = new System.Drawing.Point(341, 30);
            this.cmbxPeriod.Name = "cmbxPeriod";
            this.cmbxPeriod.Size = new System.Drawing.Size(121, 23);
            this.cmbxPeriod.TabIndex = 15;
            // 
            // ucDashboardSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.gbParticulars);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Name = "ucDashboardSummaryView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1133, 704);
            this.Load += new System.EventHandler(this.UcDashboardSummaryView_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatPerParticular)).EndInit();
            this.gbParticulars.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPending;
        private System.Windows.Forms.TextBox txtOnGoing;
        private System.Windows.Forms.TextBox txtCancelled;
        private System.Windows.Forms.TextBox txtAccomplished;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.DataGridView dgStatPerParticular;
        private System.Windows.Forms.GroupBox gbParticulars;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbxCount;
        private System.Windows.Forms.ComboBox cmbxPeriod;
        private System.Windows.Forms.Button btnCountPending;
        private System.Windows.Forms.ComboBox cmbxStatus;
        private System.Windows.Forms.Label lblRecentMovement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
