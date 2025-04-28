namespace JOMonitoringApp.Views.MainForm
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMaterials = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripParticulars = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRolesAndPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSignatories = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripJOSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripJOProgressTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSROF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripInvestigation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFS = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investigationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hydrantWithdrawalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trackJOProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investigationDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPing = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCheckingUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.systemUpdateChecker = new System.Windows.Forms.Timer(this.components);
            this.lblSystemDateAndTime = new System.Windows.Forms.Label();
            this.timerSystemDateAndTime = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucDashboardSummaryView1 = new JOMonitoringApp.Views.Dashboard.ucDashboardSummaryView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgJobOrders = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.cmbxParticulars = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbxStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxRowLimit = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelInputField = new System.Windows.Forms.Panel();
            this.ucJoborder1 = new JOMonitoringApp.Views.JobOrder.ucJoborder();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer_investigator = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInputField.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(5, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1753, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseBackupToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.databaseBackupToolStripMenuItem.Text = "Database ";
            this.databaseBackupToolStripMenuItem.Click += new System.EventHandler(this.databaseBackupToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.manualToolStripMenuItem.Text = "Backup";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUser,
            this.toolStripMaterials,
            this.toolStripParticulars,
            this.toolStripRolesAndPermissions,
            this.toolStripSignatories});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripUser
            // 
            this.toolStripUser.Name = "toolStripUser";
            this.toolStripUser.Size = new System.Drawing.Size(207, 22);
            this.toolStripUser.Text = "Users";
            this.toolStripUser.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // toolStripMaterials
            // 
            this.toolStripMaterials.Name = "toolStripMaterials";
            this.toolStripMaterials.Size = new System.Drawing.Size(207, 22);
            this.toolStripMaterials.Text = "Materials";
            this.toolStripMaterials.Click += new System.EventHandler(this.toolStripMaterials_Click);
            // 
            // toolStripParticulars
            // 
            this.toolStripParticulars.Name = "toolStripParticulars";
            this.toolStripParticulars.Size = new System.Drawing.Size(207, 22);
            this.toolStripParticulars.Text = "Particulars";
            this.toolStripParticulars.Click += new System.EventHandler(this.particularsToolStripMenuItem_Click);
            // 
            // toolStripRolesAndPermissions
            // 
            this.toolStripRolesAndPermissions.Name = "toolStripRolesAndPermissions";
            this.toolStripRolesAndPermissions.Size = new System.Drawing.Size(207, 22);
            this.toolStripRolesAndPermissions.Text = "Roles and Permissions";
            this.toolStripRolesAndPermissions.Click += new System.EventHandler(this.rolesAndPermissionsToolStripMenuItem_Click);
            // 
            // toolStripSignatories
            // 
            this.toolStripSignatories.Name = "toolStripSignatories";
            this.toolStripSignatories.Size = new System.Drawing.Size(207, 22);
            this.toolStripSignatories.Text = "Report Signatories";
            this.toolStripSignatories.Click += new System.EventHandler(this.toolStripSignatories_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripJOSummary,
            this.toolStripJOProgressTracking,
            this.toolStripSROF,
            this.toolStripInvestigation,
            this.toolStripFS});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.reportToolStripMenuItem.Text = "Reports";
            // 
            // toolStripJOSummary
            // 
            this.toolStripJOSummary.Name = "toolStripJOSummary";
            this.toolStripJOSummary.Size = new System.Drawing.Size(310, 22);
            this.toolStripJOSummary.Text = "J.O Summary";
            this.toolStripJOSummary.Click += new System.EventHandler(this.JOSummaryToolStripMenuItem_Click);
            // 
            // toolStripJOProgressTracking
            // 
            this.toolStripJOProgressTracking.Name = "toolStripJOProgressTracking";
            this.toolStripJOProgressTracking.Size = new System.Drawing.Size(310, 22);
            this.toolStripJOProgressTracking.Text = "J.O Progress Tracking";
            this.toolStripJOProgressTracking.Click += new System.EventHandler(this.jOTrackingToolStripMenuItem_Click);
            // 
            // toolStripSROF
            // 
            this.toolStripSROF.Name = "toolStripSROF";
            this.toolStripSROF.Size = new System.Drawing.Size(310, 22);
            this.toolStripSROF.Text = "Service Request and Order Form (SROF)";
            this.toolStripSROF.Click += new System.EventHandler(this.requistionAndIssueSlipRISToolStripMenuItem_Click);
            // 
            // toolStripInvestigation
            // 
            this.toolStripInvestigation.Name = "toolStripInvestigation";
            this.toolStripInvestigation.Size = new System.Drawing.Size(310, 22);
            this.toolStripInvestigation.Text = "Investigation";
            this.toolStripInvestigation.Click += new System.EventHandler(this.investigationToolStripMenuItem_Click);
            // 
            // toolStripFS
            // 
            this.toolStripFS.Name = "toolStripFS";
            this.toolStripFS.Size = new System.Drawing.Size(310, 22);
            this.toolStripFS.Text = "FS / Estimates of Materials";
            this.toolStripFS.Click += new System.EventHandler(this.estimatesOfMaterialsToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.investigationsToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // investigationsToolStripMenuItem
            // 
            this.investigationsToolStripMenuItem.Name = "investigationsToolStripMenuItem";
            this.investigationsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.investigationsToolStripMenuItem.Text = "Investigations";
            this.investigationsToolStripMenuItem.Click += new System.EventHandler(this.investigationsToolStripMenuItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem1});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.sessionToolStripMenuItem.Text = "Session";
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.logoutToolStripMenuItem1.Text = "Log-out";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.LogoutToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.userManualToolStripMenuItem.Text = "User Guide";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.hydrantWithdrawalToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.trackJOProgressToolStripMenuItem,
            this.investigationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 120);
            this.contextMenuStrip1.Text = "PRINT ";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItem2.Text = "FS / Estimates of Materials";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // hydrantWithdrawalToolStripMenuItem
            // 
            this.hydrantWithdrawalToolStripMenuItem.Name = "hydrantWithdrawalToolStripMenuItem";
            this.hydrantWithdrawalToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.hydrantWithdrawalToolStripMenuItem.Text = "Hydrant Withdrawal";
            this.hydrantWithdrawalToolStripMenuItem.Click += new System.EventHandler(this.hydrantWithdrawalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItem1.Text = "SROF";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // trackJOProgressToolStripMenuItem
            // 
            this.trackJOProgressToolStripMenuItem.Name = "trackJOProgressToolStripMenuItem";
            this.trackJOProgressToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.trackJOProgressToolStripMenuItem.Text = "Track J.O Progress";
            this.trackJOProgressToolStripMenuItem.Click += new System.EventHandler(this.trackJOProgressToolStripMenuItem_Click);
            // 
            // investigationToolStripMenuItem
            // 
            this.investigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printFormToolStripMenuItem,
            this.investigationDataToolStripMenuItem});
            this.investigationToolStripMenuItem.Name = "investigationToolStripMenuItem";
            this.investigationToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.investigationToolStripMenuItem.Text = "Investigation";
            this.investigationToolStripMenuItem.Click += new System.EventHandler(this.investigationToolStripMenuItem_Click_2);
            // 
            // printFormToolStripMenuItem
            // 
            this.printFormToolStripMenuItem.Name = "printFormToolStripMenuItem";
            this.printFormToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.printFormToolStripMenuItem.Text = "Print Form";
            this.printFormToolStripMenuItem.Click += new System.EventHandler(this.printFormToolStripMenuItem_Click);
            // 
            // investigationDataToolStripMenuItem
            // 
            this.investigationDataToolStripMenuItem.Name = "investigationDataToolStripMenuItem";
            this.investigationDataToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.investigationDataToolStripMenuItem.Text = "Investigation Data";
            this.investigationDataToolStripMenuItem.Click += new System.EventHandler(this.investigationDataToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCurrentUser,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel7,
            this.lblUserRole,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel6,
            this.lblPing,
            this.toolStripStatusLabel9,
            this.lblCheckingUpdate});
            this.statusStrip1.Location = new System.Drawing.Point(5, 948);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1753, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "SYSTEM USER : ";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(121, 17);
            this.lblCurrentUser.Text = "System Administrator";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel7.Text = "USER ROLE : ";
            // 
            // lblUserRole
            // 
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(121, 17);
            this.lblUserRole.Text = "System Administrator";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel8.Text = "|";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel6.Text = "SERVER PING : ";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPing
            // 
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(32, 17);
            this.lblPing.Text = "0 ms";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel9.Text = "|";
            // 
            // lblCheckingUpdate
            // 
            this.lblCheckingUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckingUpdate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCheckingUpdate.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lblCheckingUpdate.Name = "lblCheckingUpdate";
            this.lblCheckingUpdate.Size = new System.Drawing.Size(580, 17);
            this.lblCheckingUpdate.Text = "A NEW VERSION OF THE SYSTEM IS AVAILABLE. PLEASE RESTART THE APPLICATION TO APPLY" +
    " THE UPDATE.";
            this.lblCheckingUpdate.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "You may search for";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JOMonitoringApp.Properties.Resources.icons8_information_14;
            this.pictureBox1.Location = new System.Drawing.Point(898, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "JO Number, Account Number, \r\nWAR, MRS, MRIS Number and O.R. Number.");
            // 
            // systemUpdateChecker
            // 
            this.systemUpdateChecker.Enabled = true;
            this.systemUpdateChecker.Interval = 1000;
            this.systemUpdateChecker.Tick += new System.EventHandler(this.systemUpdateChecker_Tick);
            // 
            // lblSystemDateAndTime
            // 
            this.lblSystemDateAndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemDateAndTime.AutoSize = true;
            this.lblSystemDateAndTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSystemDateAndTime.Location = new System.Drawing.Point(1757, 1123);
            this.lblSystemDateAndTime.Name = "lblSystemDateAndTime";
            this.lblSystemDateAndTime.Size = new System.Drawing.Size(280, 15);
            this.lblSystemDateAndTime.TabIndex = 6;
            this.lblSystemDateAndTime.Text = "SYSTEM DATE AND TIME : yyyy-MM-dd, HH:mm:ss";
            this.lblSystemDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerSystemDateAndTime
            // 
            this.timerSystemDateAndTime.Enabled = true;
            this.timerSystemDateAndTime.Interval = 1000;
            this.timerSystemDateAndTime.Tick += new System.EventHandler(this.timerSystemDateAndTime_Tick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucDashboardSummaryView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1745, 890);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SUMMARY";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucDashboardSummaryView1
            // 
            this.ucDashboardSummaryView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDashboardSummaryView1.Location = new System.Drawing.Point(3, 3);
            this.ucDashboardSummaryView1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDashboardSummaryView1.Name = "ucDashboardSummaryView1";
            this.ucDashboardSummaryView1.Padding = new System.Windows.Forms.Padding(10);
            this.ucDashboardSummaryView1.Size = new System.Drawing.Size(1739, 1944);
            this.ucDashboardSummaryView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panelInputField);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1745, 890);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "JOB ORDERS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(466, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1276, 884);
            this.panel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgJobOrders);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(5, 61);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4);
            this.panel6.Size = new System.Drawing.Size(1266, 818);
            this.panel6.TabIndex = 9;
            // 
            // dgJobOrders
            // 
            this.dgJobOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgJobOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgJobOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dgJobOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJobOrders.Location = new System.Drawing.Point(4, 4);
            this.dgJobOrders.MultiSelect = false;
            this.dgJobOrders.Name = "dgJobOrders";
            this.dgJobOrders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgJobOrders.RowHeadersWidth = 51;
            this.dgJobOrders.Size = new System.Drawing.Size(1258, 810);
            this.dgJobOrders.TabIndex = 0;
            this.dgJobOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgJobOrders_CellFormatting);
            this.dgJobOrders.SelectionChanged += new System.EventHandler(this.dgJobOrders_SelectionChanged);
            this.dgJobOrders.DoubleClick += new System.EventHandler(this.DgJobOrders_DoubleClick);
            this.dgJobOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgJobOrders_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 43);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1266, 18);
            this.panel3.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBar1.Location = new System.Drawing.Point(5, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1256, 8);
            this.progressBar1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnX);
            this.panel2.Controls.Add(this.cmbxParticulars);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.cmbxStatus);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbxRowLimit);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1266, 38);
            this.panel2.TabIndex = 8;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.Image = global::JOMonitoringApp.Properties.Resources.icons8_x_24;
            this.btnX.Location = new System.Drawing.Point(987, 8);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(31, 23);
            this.btnX.TabIndex = 32;
            this.btnX.TabStop = false;
            this.btnX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Visible = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // cmbxParticulars
            // 
            this.cmbxParticulars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxParticulars.FormattingEnabled = true;
            this.cmbxParticulars.Location = new System.Drawing.Point(473, 8);
            this.cmbxParticulars.Name = "cmbxParticulars";
            this.cmbxParticulars.Size = new System.Drawing.Size(228, 23);
            this.cmbxParticulars.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "PARTICULARS ";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(918, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cmbxStatus
            // 
            this.cmbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxStatus.FormattingEnabled = true;
            this.cmbxStatus.Location = new System.Drawing.Point(248, 8);
            this.cmbxStatus.Name = "cmbxStatus";
            this.cmbxStatus.Size = new System.Drawing.Size(121, 23);
            this.cmbxStatus.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "STATUS";
            // 
            // cmbxRowLimit
            // 
            this.cmbxRowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxRowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxRowLimit.FormattingEnabled = true;
            this.cmbxRowLimit.Location = new System.Drawing.Point(77, 8);
            this.cmbxRowLimit.Name = "cmbxRowLimit";
            this.cmbxRowLimit.Size = new System.Drawing.Size(106, 23);
            this.cmbxRowLimit.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(744, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "RECORDS";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(707, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "FIND";
            // 
            // panelInputField
            // 
            this.panelInputField.Controls.Add(this.ucJoborder1);
            this.panelInputField.Controls.Add(this.panel4);
            this.panelInputField.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInputField.Location = new System.Drawing.Point(3, 3);
            this.panelInputField.Name = "panelInputField";
            this.panelInputField.Size = new System.Drawing.Size(463, 884);
            this.panelInputField.TabIndex = 1;
            // 
            // ucJoborder1
            // 
            this.ucJoborder1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucJoborder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucJoborder1.Location = new System.Drawing.Point(0, 0);
            this.ucJoborder1.Margin = new System.Windows.Forms.Padding(4);
            this.ucJoborder1.Name = "ucJoborder1";
            this.ucJoborder1.Padding = new System.Windows.Forms.Padding(10);
            this.ucJoborder1.Size = new System.Drawing.Size(463, 840);
            this.ucJoborder1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 840);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 44);
            this.panel4.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(362, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel [Esc]";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(192, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save [Ctrl + S]";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1753, 918);
            this.tabControl1.TabIndex = 4;
            // 
            // timer_investigator
            // 
            this.timer_investigator.Enabled = true;
            this.timer_investigator.Interval = 5000;
            this.timer_investigator.Tick += new System.EventHandler(this.timer_investigator_Tick);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 975);
            this.Controls.Add(this.lblSystemDateAndTime);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1344, 772);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Order Monitoring App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJobOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelInputField.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMaterials;
        private System.Windows.Forms.ToolStripMenuItem toolStripParticulars;
        private System.Windows.Forms.ToolStripMenuItem toolStripRolesAndPermissions;
        private System.Windows.Forms.ToolStripMenuItem toolStripSignatories;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripJOSummary;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem toolStripSROF;
        private System.Windows.Forms.ToolStripMenuItem toolStripJOProgressTracking;
        private System.Windows.Forms.ToolStripMenuItem toolStripInvestigation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel lblPing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.Timer systemUpdateChecker;
        private System.Windows.Forms.ToolStripMenuItem toolStripFS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.Label lblSystemDateAndTime;
        private System.Windows.Forms.Timer timerSystemDateAndTime;
        private System.Windows.Forms.ToolStripStatusLabel lblCheckingUpdate;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hydrantWithdrawalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trackJOProgressToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private Dashboard.ucDashboardSummaryView ucDashboardSummaryView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgJobOrders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxParticulars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelInputField;
        private JobOrder.ucJoborder ucJoborder1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investigationsToolStripMenuItem;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.ToolStripMenuItem investigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investigationDataToolStripMenuItem;
        public System.Windows.Forms.Timer timer_investigator;
    }
}