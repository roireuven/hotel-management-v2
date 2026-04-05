namespace HotelManager
{
    partial class fSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();

            // Hotel Settings group
            this.grpHotelSettings = new System.Windows.Forms.GroupBox();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.txbHotelName = new System.Windows.Forms.TextBox();
            this.lblHotelEmail = new System.Windows.Forms.Label();
            this.txbHotelEmail = new System.Windows.Forms.TextBox();
            this.lblHotelPhone = new System.Windows.Forms.Label();
            this.txbHotelPhone = new System.Windows.Forms.TextBox();
            this.lblHotelCurrency = new System.Windows.Forms.Label();
            this.txbHotelCurrency = new System.Windows.Forms.TextBox();
            this.lblHotelAddress = new System.Windows.Forms.Label();
            this.txbHotelAddress = new System.Windows.Forms.TextBox();

            // Regulations sub-group
            this.grpRegulations = new System.Windows.Forms.GroupBox();
            this.lblMaxGuests = new System.Windows.Forms.Label();
            this.numMaxGuests = new System.Windows.Forms.NumericUpDown();
            this.lblSurchargeRate = new System.Windows.Forms.Label();
            this.numSurchargeRate = new System.Windows.Forms.NumericUpDown();
            this.lblCheckInTime = new System.Windows.Forms.Label();
            this.txbCheckInTime = new System.Windows.Forms.TextBox();
            this.lblCheckOutTime = new System.Windows.Forms.Label();
            this.txbCheckOutTime = new System.Windows.Forms.TextBox();

            this.btnSaveSettings = new System.Windows.Forms.Button();

            // System Configuration group
            this.grpSysConfig = new System.Windows.Forms.GroupBox();
            this.lblDefaultTax = new System.Windows.Forms.Label();
            this.numDefaultTax = new System.Windows.Forms.NumericUpDown();
            this.lblServiceTax = new System.Windows.Forms.Label();
            this.numServiceTax = new System.Windows.Forms.NumericUpDown();
            this.lblPeakMultiplier = new System.Windows.Forms.Label();
            this.numPeakMultiplier = new System.Windows.Forms.NumericUpDown();
            this.lblPeakDates = new System.Windows.Forms.Label();
            this.dtpPeakStart = new System.Windows.Forms.DateTimePicker();
            this.lblPeakTo = new System.Windows.Forms.Label();
            this.dtpPeakEnd = new System.Windows.Forms.DateTimePicker();
            this.lblOffMultiplier = new System.Windows.Forms.Label();
            this.numOffMultiplier = new System.Windows.Forms.NumericUpDown();
            this.lblOffDates = new System.Windows.Forms.Label();
            this.dtpOffStart = new System.Windows.Forms.DateTimePicker();
            this.lblOffTo = new System.Windows.Forms.Label();
            this.dtpOffEnd = new System.Windows.Forms.DateTimePicker();

            // Backup & Restore group
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnImportData = new System.Windows.Forms.Button();
            this.lblTableExports = new System.Windows.Forms.Label();
            this.flowTableExports = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportRooms = new System.Windows.Forms.Button();
            this.btnExportGuests = new System.Windows.Forms.Button();
            this.btnExportBookings = new System.Windows.Forms.Button();
            this.btnExportServices = new System.Windows.Forms.Button();
            this.btnExportInvoices = new System.Windows.Forms.Button();
            this.btnExportInventory = new System.Windows.Forms.Button();
            this.btnExportMenu = new System.Windows.Forms.Button();
            this.btnExportStore = new System.Windows.Forms.Button();
            this.btnExportTickets = new System.Windows.Forms.Button();
            this.btnExportAccounts = new System.Windows.Forms.Button();
            this.btnExportTransactions = new System.Windows.Forms.Button();
            this.btnExportPOSSales = new System.Windows.Forms.Button();
            this.btnExportRestaurant = new System.Windows.Forms.Button();
            this.btnExportSvcRequests = new System.Windows.Forms.Button();
            this.btnExportMessages = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numMaxGuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSurchargeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeakMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffMultiplier)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpHotelSettings.SuspendLayout();
            this.grpRegulations.SuspendLayout();
            this.grpSysConfig.SuspendLayout();
            this.grpBackup.SuspendLayout();
            this.flowTableExports.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.SeaGreen;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(780, 50);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.Text = "Settings & Configuration";

            // btnClose
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.SeaGreen;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(744, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // panelMain
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(780, 700);
            this.panelMain.Controls.Add(this.grpBackup);
            this.panelMain.Controls.Add(this.grpSysConfig);
            this.panelMain.Controls.Add(this.btnSaveSettings);
            this.panelMain.Controls.Add(this.grpHotelSettings);

            // ==================== HOTEL SETTINGS ====================
            // grpHotelSettings
            this.grpHotelSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHotelSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpHotelSettings.ForeColor = System.Drawing.Color.SeaGreen;
            this.grpHotelSettings.Location = new System.Drawing.Point(15, 15);
            this.grpHotelSettings.Name = "grpHotelSettings";
            this.grpHotelSettings.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpHotelSettings.Size = new System.Drawing.Size(750, 340);
            this.grpHotelSettings.Text = "Hotel Settings";
            this.grpHotelSettings.Controls.Add(this.grpRegulations);
            this.grpHotelSettings.Controls.Add(this.txbHotelAddress);
            this.grpHotelSettings.Controls.Add(this.lblHotelAddress);
            this.grpHotelSettings.Controls.Add(this.txbHotelCurrency);
            this.grpHotelSettings.Controls.Add(this.lblHotelCurrency);
            this.grpHotelSettings.Controls.Add(this.txbHotelPhone);
            this.grpHotelSettings.Controls.Add(this.lblHotelPhone);
            this.grpHotelSettings.Controls.Add(this.txbHotelEmail);
            this.grpHotelSettings.Controls.Add(this.lblHotelEmail);
            this.grpHotelSettings.Controls.Add(this.txbHotelName);
            this.grpHotelSettings.Controls.Add(this.lblHotelName);

            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI", 9.75F);
            System.Drawing.Font textFont = new System.Drawing.Font("Segoe UI", 9.75F);
            System.Drawing.Color lblColor = System.Drawing.Color.FromArgb(64, 64, 64);

            // Hotel Name
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Font = labelFont;
            this.lblHotelName.ForeColor = lblColor;
            this.lblHotelName.Location = new System.Drawing.Point(18, 32);
            this.lblHotelName.Text = "Hotel Name";
            this.txbHotelName.Font = textFont;
            this.txbHotelName.ForeColor = System.Drawing.Color.Black;
            this.txbHotelName.Location = new System.Drawing.Point(140, 29);
            this.txbHotelName.Size = new System.Drawing.Size(300, 25);
            this.txbHotelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Hotel Email
            this.lblHotelEmail.AutoSize = true;
            this.lblHotelEmail.Font = labelFont;
            this.lblHotelEmail.ForeColor = lblColor;
            this.lblHotelEmail.Location = new System.Drawing.Point(18, 62);
            this.lblHotelEmail.Text = "Email";
            this.txbHotelEmail.Font = textFont;
            this.txbHotelEmail.ForeColor = System.Drawing.Color.Black;
            this.txbHotelEmail.Location = new System.Drawing.Point(140, 59);
            this.txbHotelEmail.Size = new System.Drawing.Size(300, 25);
            this.txbHotelEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Hotel Phone
            this.lblHotelPhone.AutoSize = true;
            this.lblHotelPhone.Font = labelFont;
            this.lblHotelPhone.ForeColor = lblColor;
            this.lblHotelPhone.Location = new System.Drawing.Point(18, 92);
            this.lblHotelPhone.Text = "Phone";
            this.txbHotelPhone.Font = textFont;
            this.txbHotelPhone.ForeColor = System.Drawing.Color.Black;
            this.txbHotelPhone.Location = new System.Drawing.Point(140, 89);
            this.txbHotelPhone.Size = new System.Drawing.Size(300, 25);
            this.txbHotelPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Hotel Currency
            this.lblHotelCurrency.AutoSize = true;
            this.lblHotelCurrency.Font = labelFont;
            this.lblHotelCurrency.ForeColor = lblColor;
            this.lblHotelCurrency.Location = new System.Drawing.Point(460, 32);
            this.lblHotelCurrency.Text = "Currency";
            this.txbHotelCurrency.Font = textFont;
            this.txbHotelCurrency.ForeColor = System.Drawing.Color.Black;
            this.txbHotelCurrency.Location = new System.Drawing.Point(540, 29);
            this.txbHotelCurrency.Size = new System.Drawing.Size(190, 25);
            this.txbHotelCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Hotel Address
            this.lblHotelAddress.AutoSize = true;
            this.lblHotelAddress.Font = labelFont;
            this.lblHotelAddress.ForeColor = lblColor;
            this.lblHotelAddress.Location = new System.Drawing.Point(18, 122);
            this.lblHotelAddress.Text = "Address";
            this.txbHotelAddress.Font = textFont;
            this.txbHotelAddress.ForeColor = System.Drawing.Color.Black;
            this.txbHotelAddress.Location = new System.Drawing.Point(140, 119);
            this.txbHotelAddress.Size = new System.Drawing.Size(590, 25);
            this.txbHotelAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // grpRegulations
            this.grpRegulations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpRegulations.ForeColor = System.Drawing.Color.FromArgb(46, 139, 87);
            this.grpRegulations.Location = new System.Drawing.Point(18, 155);
            this.grpRegulations.Size = new System.Drawing.Size(712, 170);
            this.grpRegulations.Text = "Regulations";
            this.grpRegulations.Controls.Add(this.lblMaxGuests);
            this.grpRegulations.Controls.Add(this.numMaxGuests);
            this.grpRegulations.Controls.Add(this.lblSurchargeRate);
            this.grpRegulations.Controls.Add(this.numSurchargeRate);
            this.grpRegulations.Controls.Add(this.lblCheckInTime);
            this.grpRegulations.Controls.Add(this.txbCheckInTime);
            this.grpRegulations.Controls.Add(this.lblCheckOutTime);
            this.grpRegulations.Controls.Add(this.txbCheckOutTime);

            // Max Guests
            this.lblMaxGuests.AutoSize = true;
            this.lblMaxGuests.Font = labelFont;
            this.lblMaxGuests.ForeColor = lblColor;
            this.lblMaxGuests.Location = new System.Drawing.Point(15, 30);
            this.lblMaxGuests.Text = "Max Guests";
            this.numMaxGuests.Font = textFont;
            this.numMaxGuests.ForeColor = System.Drawing.Color.Black;
            this.numMaxGuests.Location = new System.Drawing.Point(130, 27);
            this.numMaxGuests.Size = new System.Drawing.Size(100, 25);
            this.numMaxGuests.Minimum = 1;
            this.numMaxGuests.Maximum = 100;

            // Surcharge Rate
            this.lblSurchargeRate.AutoSize = true;
            this.lblSurchargeRate.Font = labelFont;
            this.lblSurchargeRate.ForeColor = lblColor;
            this.lblSurchargeRate.Location = new System.Drawing.Point(15, 65);
            this.lblSurchargeRate.Text = "Surcharge Rate (%)";
            this.numSurchargeRate.Font = textFont;
            this.numSurchargeRate.ForeColor = System.Drawing.Color.Black;
            this.numSurchargeRate.Location = new System.Drawing.Point(170, 62);
            this.numSurchargeRate.Size = new System.Drawing.Size(100, 25);
            this.numSurchargeRate.DecimalPlaces = 2;
            this.numSurchargeRate.Maximum = 1000;

            // Check-in Time
            this.lblCheckInTime.AutoSize = true;
            this.lblCheckInTime.Font = labelFont;
            this.lblCheckInTime.ForeColor = lblColor;
            this.lblCheckInTime.Location = new System.Drawing.Point(350, 30);
            this.lblCheckInTime.Text = "Check-in Time";
            this.txbCheckInTime.Font = textFont;
            this.txbCheckInTime.ForeColor = System.Drawing.Color.Black;
            this.txbCheckInTime.Location = new System.Drawing.Point(470, 27);
            this.txbCheckInTime.Size = new System.Drawing.Size(100, 25);
            this.txbCheckInTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Check-out Time
            this.lblCheckOutTime.AutoSize = true;
            this.lblCheckOutTime.Font = labelFont;
            this.lblCheckOutTime.ForeColor = lblColor;
            this.lblCheckOutTime.Location = new System.Drawing.Point(350, 65);
            this.lblCheckOutTime.Text = "Check-out Time";
            this.txbCheckOutTime.Font = textFont;
            this.txbCheckOutTime.ForeColor = System.Drawing.Color.Black;
            this.txbCheckOutTime.Location = new System.Drawing.Point(470, 62);
            this.txbCheckOutTime.Size = new System.Drawing.Size(100, 25);
            this.txbCheckOutTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnSaveSettings
            this.btnSaveSettings.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveSettings.FlatAppearance.BorderSize = 0;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(15, 360);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(750, 42);
            this.btnSaveSettings.Text = "SAVE SETTINGS";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);

            // ==================== SYSTEM CONFIGURATION ====================
            this.grpSysConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSysConfig.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSysConfig.ForeColor = System.Drawing.Color.SeaGreen;
            this.grpSysConfig.Location = new System.Drawing.Point(15, 410);
            this.grpSysConfig.Name = "grpSysConfig";
            this.grpSysConfig.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpSysConfig.Size = new System.Drawing.Size(750, 210);
            this.grpSysConfig.Text = "System Configuration";
            this.grpSysConfig.Controls.Add(this.dtpOffEnd);
            this.grpSysConfig.Controls.Add(this.lblOffTo);
            this.grpSysConfig.Controls.Add(this.dtpOffStart);
            this.grpSysConfig.Controls.Add(this.lblOffDates);
            this.grpSysConfig.Controls.Add(this.numOffMultiplier);
            this.grpSysConfig.Controls.Add(this.lblOffMultiplier);
            this.grpSysConfig.Controls.Add(this.dtpPeakEnd);
            this.grpSysConfig.Controls.Add(this.lblPeakTo);
            this.grpSysConfig.Controls.Add(this.dtpPeakStart);
            this.grpSysConfig.Controls.Add(this.lblPeakDates);
            this.grpSysConfig.Controls.Add(this.numPeakMultiplier);
            this.grpSysConfig.Controls.Add(this.lblPeakMultiplier);
            this.grpSysConfig.Controls.Add(this.numServiceTax);
            this.grpSysConfig.Controls.Add(this.lblServiceTax);
            this.grpSysConfig.Controls.Add(this.numDefaultTax);
            this.grpSysConfig.Controls.Add(this.lblDefaultTax);

            // Default Tax
            this.lblDefaultTax.AutoSize = true;
            this.lblDefaultTax.Font = labelFont;
            this.lblDefaultTax.ForeColor = lblColor;
            this.lblDefaultTax.Location = new System.Drawing.Point(18, 32);
            this.lblDefaultTax.Text = "Default Tax Rate (%)";
            this.numDefaultTax.Font = textFont;
            this.numDefaultTax.ForeColor = System.Drawing.Color.Black;
            this.numDefaultTax.Location = new System.Drawing.Point(180, 29);
            this.numDefaultTax.Size = new System.Drawing.Size(100, 25);
            this.numDefaultTax.DecimalPlaces = 2;
            this.numDefaultTax.Maximum = 100;

            // Service Tax
            this.lblServiceTax.AutoSize = true;
            this.lblServiceTax.Font = labelFont;
            this.lblServiceTax.ForeColor = lblColor;
            this.lblServiceTax.Location = new System.Drawing.Point(350, 32);
            this.lblServiceTax.Text = "Service Tax (%)";
            this.numServiceTax.Font = textFont;
            this.numServiceTax.ForeColor = System.Drawing.Color.Black;
            this.numServiceTax.Location = new System.Drawing.Point(480, 29);
            this.numServiceTax.Size = new System.Drawing.Size(100, 25);
            this.numServiceTax.DecimalPlaces = 2;
            this.numServiceTax.Maximum = 100;

            // Peak Multiplier
            this.lblPeakMultiplier.AutoSize = true;
            this.lblPeakMultiplier.Font = labelFont;
            this.lblPeakMultiplier.ForeColor = lblColor;
            this.lblPeakMultiplier.Location = new System.Drawing.Point(18, 67);
            this.lblPeakMultiplier.Text = "Peak Season Multiplier";
            this.numPeakMultiplier.Font = textFont;
            this.numPeakMultiplier.ForeColor = System.Drawing.Color.Black;
            this.numPeakMultiplier.Location = new System.Drawing.Point(190, 64);
            this.numPeakMultiplier.Size = new System.Drawing.Size(90, 25);
            this.numPeakMultiplier.DecimalPlaces = 2;
            this.numPeakMultiplier.Maximum = 10;
            this.numPeakMultiplier.Minimum = 0;
            this.numPeakMultiplier.Increment = 0.1m;

            // Peak Season Dates
            this.lblPeakDates.AutoSize = true;
            this.lblPeakDates.Font = labelFont;
            this.lblPeakDates.ForeColor = lblColor;
            this.lblPeakDates.Location = new System.Drawing.Point(350, 67);
            this.lblPeakDates.Text = "Peak Dates";
            this.dtpPeakStart.Font = labelFont;
            this.dtpPeakStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeakStart.Location = new System.Drawing.Point(440, 64);
            this.dtpPeakStart.Size = new System.Drawing.Size(110, 25);
            this.lblPeakTo.AutoSize = true;
            this.lblPeakTo.Font = labelFont;
            this.lblPeakTo.ForeColor = lblColor;
            this.lblPeakTo.Location = new System.Drawing.Point(555, 67);
            this.lblPeakTo.Text = "to";
            this.dtpPeakEnd.Font = labelFont;
            this.dtpPeakEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeakEnd.Location = new System.Drawing.Point(578, 64);
            this.dtpPeakEnd.Size = new System.Drawing.Size(110, 25);

            // Off-Season Multiplier
            this.lblOffMultiplier.AutoSize = true;
            this.lblOffMultiplier.Font = labelFont;
            this.lblOffMultiplier.ForeColor = lblColor;
            this.lblOffMultiplier.Location = new System.Drawing.Point(18, 102);
            this.lblOffMultiplier.Text = "Off-Season Multiplier";
            this.numOffMultiplier.Font = textFont;
            this.numOffMultiplier.ForeColor = System.Drawing.Color.Black;
            this.numOffMultiplier.Location = new System.Drawing.Point(190, 99);
            this.numOffMultiplier.Size = new System.Drawing.Size(90, 25);
            this.numOffMultiplier.DecimalPlaces = 2;
            this.numOffMultiplier.Maximum = 10;
            this.numOffMultiplier.Minimum = 0;
            this.numOffMultiplier.Increment = 0.1m;

            // Off-Season Dates
            this.lblOffDates.AutoSize = true;
            this.lblOffDates.Font = labelFont;
            this.lblOffDates.ForeColor = lblColor;
            this.lblOffDates.Location = new System.Drawing.Point(350, 102);
            this.lblOffDates.Text = "Off-Season Dates";
            this.dtpOffStart.Font = labelFont;
            this.dtpOffStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOffStart.Location = new System.Drawing.Point(490, 99);
            this.dtpOffStart.Size = new System.Drawing.Size(110, 25);
            this.lblOffTo.AutoSize = true;
            this.lblOffTo.Font = labelFont;
            this.lblOffTo.ForeColor = lblColor;
            this.lblOffTo.Location = new System.Drawing.Point(605, 102);
            this.lblOffTo.Text = "to";
            this.dtpOffEnd.Font = labelFont;
            this.dtpOffEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOffEnd.Location = new System.Drawing.Point(625, 99);
            this.dtpOffEnd.Size = new System.Drawing.Size(100, 25);

            // ==================== BACKUP & RESTORE ====================
            this.grpBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBackup.ForeColor = System.Drawing.Color.SeaGreen;
            this.grpBackup.Location = new System.Drawing.Point(15, 630);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpBackup.Size = new System.Drawing.Size(750, 450);
            this.grpBackup.Text = "Backup && Restore";
            this.grpBackup.Controls.Add(this.flowTableExports);
            this.grpBackup.Controls.Add(this.lblTableExports);
            this.grpBackup.Controls.Add(this.btnImportData);
            this.grpBackup.Controls.Add(this.btnExportAll);

            // btnExportAll
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            this.btnExportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportAll.FlatAppearance.BorderSize = 0;
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportAll.ForeColor = System.Drawing.Color.White;
            this.btnExportAll.Location = new System.Drawing.Point(18, 32);
            this.btnExportAll.Size = new System.Drawing.Size(712, 40);
            this.btnExportAll.Text = "EXPORT ALL DATA (CSV ZIP)";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.BtnExportAll_Click);

            // btnImportData
            this.btnImportData.BackColor = System.Drawing.Color.FromArgb(36, 129, 77);
            this.btnImportData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportData.FlatAppearance.BorderSize = 0;
            this.btnImportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportData.ForeColor = System.Drawing.Color.White;
            this.btnImportData.Location = new System.Drawing.Point(18, 80);
            this.btnImportData.Size = new System.Drawing.Size(712, 40);
            this.btnImportData.Text = "IMPORT DATA (ZIP / JSON)";
            this.btnImportData.UseVisualStyleBackColor = false;
            this.btnImportData.Click += new System.EventHandler(this.BtnImportData_Click);

            // lblTableExports
            this.lblTableExports.AutoSize = true;
            this.lblTableExports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTableExports.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTableExports.Location = new System.Drawing.Point(18, 132);
            this.lblTableExports.Text = "Individual Table Exports:";

            // flowTableExports
            this.flowTableExports.Location = new System.Drawing.Point(18, 158);
            this.flowTableExports.Size = new System.Drawing.Size(712, 280);
            this.flowTableExports.AutoScroll = true;

            // Create the 15 table export buttons
            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 9F);
            System.Drawing.Size btnSize = new System.Drawing.Size(135, 36);
            System.Drawing.Color btnBg = System.Drawing.Color.FromArgb(230, 244, 234);
            System.Drawing.Color btnFg = System.Drawing.Color.FromArgb(46, 139, 87);

            // Rooms
            this.btnExportRooms.BackColor = btnBg;
            this.btnExportRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportRooms.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportRooms.Font = btnFont;
            this.btnExportRooms.ForeColor = btnFg;
            this.btnExportRooms.Size = btnSize;
            this.btnExportRooms.Text = "Rooms";
            this.btnExportRooms.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportRooms.Click += new System.EventHandler(this.BtnExportRooms_Click);
            this.flowTableExports.Controls.Add(this.btnExportRooms);

            // Guests
            this.btnExportGuests.BackColor = btnBg;
            this.btnExportGuests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportGuests.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportGuests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportGuests.Font = btnFont;
            this.btnExportGuests.ForeColor = btnFg;
            this.btnExportGuests.Size = btnSize;
            this.btnExportGuests.Text = "Guests";
            this.btnExportGuests.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportGuests.Click += new System.EventHandler(this.BtnExportGuests_Click);
            this.flowTableExports.Controls.Add(this.btnExportGuests);

            // Bookings
            this.btnExportBookings.BackColor = btnBg;
            this.btnExportBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportBookings.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportBookings.Font = btnFont;
            this.btnExportBookings.ForeColor = btnFg;
            this.btnExportBookings.Size = btnSize;
            this.btnExportBookings.Text = "Bookings";
            this.btnExportBookings.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportBookings.Click += new System.EventHandler(this.BtnExportBookings_Click);
            this.flowTableExports.Controls.Add(this.btnExportBookings);

            // Services
            this.btnExportServices.BackColor = btnBg;
            this.btnExportServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportServices.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportServices.Font = btnFont;
            this.btnExportServices.ForeColor = btnFg;
            this.btnExportServices.Size = btnSize;
            this.btnExportServices.Text = "Services";
            this.btnExportServices.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportServices.Click += new System.EventHandler(this.BtnExportServices_Click);
            this.flowTableExports.Controls.Add(this.btnExportServices);

            // Invoices
            this.btnExportInvoices.BackColor = btnBg;
            this.btnExportInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportInvoices.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInvoices.Font = btnFont;
            this.btnExportInvoices.ForeColor = btnFg;
            this.btnExportInvoices.Size = btnSize;
            this.btnExportInvoices.Text = "Invoices";
            this.btnExportInvoices.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportInvoices.Click += new System.EventHandler(this.BtnExportInvoices_Click);
            this.flowTableExports.Controls.Add(this.btnExportInvoices);

            // Inventory
            this.btnExportInventory.BackColor = btnBg;
            this.btnExportInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportInventory.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInventory.Font = btnFont;
            this.btnExportInventory.ForeColor = btnFg;
            this.btnExportInventory.Size = btnSize;
            this.btnExportInventory.Text = "Inventory";
            this.btnExportInventory.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportInventory.Click += new System.EventHandler(this.BtnExportInventory_Click);
            this.flowTableExports.Controls.Add(this.btnExportInventory);

            // Menu
            this.btnExportMenu.BackColor = btnBg;
            this.btnExportMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportMenu.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMenu.Font = btnFont;
            this.btnExportMenu.ForeColor = btnFg;
            this.btnExportMenu.Size = btnSize;
            this.btnExportMenu.Text = "Menu";
            this.btnExportMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportMenu.Click += new System.EventHandler(this.BtnExportMenu_Click);
            this.flowTableExports.Controls.Add(this.btnExportMenu);

            // Store
            this.btnExportStore.BackColor = btnBg;
            this.btnExportStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportStore.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportStore.Font = btnFont;
            this.btnExportStore.ForeColor = btnFg;
            this.btnExportStore.Size = btnSize;
            this.btnExportStore.Text = "Store";
            this.btnExportStore.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportStore.Click += new System.EventHandler(this.BtnExportStore_Click);
            this.flowTableExports.Controls.Add(this.btnExportStore);

            // Tickets
            this.btnExportTickets.BackColor = btnBg;
            this.btnExportTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportTickets.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTickets.Font = btnFont;
            this.btnExportTickets.ForeColor = btnFg;
            this.btnExportTickets.Size = btnSize;
            this.btnExportTickets.Text = "Tickets";
            this.btnExportTickets.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportTickets.Click += new System.EventHandler(this.BtnExportTickets_Click);
            this.flowTableExports.Controls.Add(this.btnExportTickets);

            // Accounts
            this.btnExportAccounts.BackColor = btnBg;
            this.btnExportAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportAccounts.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAccounts.Font = btnFont;
            this.btnExportAccounts.ForeColor = btnFg;
            this.btnExportAccounts.Size = btnSize;
            this.btnExportAccounts.Text = "Accounts";
            this.btnExportAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportAccounts.Click += new System.EventHandler(this.BtnExportAccounts_Click);
            this.flowTableExports.Controls.Add(this.btnExportAccounts);

            // Transactions
            this.btnExportTransactions.BackColor = btnBg;
            this.btnExportTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportTransactions.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTransactions.Font = btnFont;
            this.btnExportTransactions.ForeColor = btnFg;
            this.btnExportTransactions.Size = btnSize;
            this.btnExportTransactions.Text = "Transactions";
            this.btnExportTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportTransactions.Click += new System.EventHandler(this.BtnExportTransactions_Click);
            this.flowTableExports.Controls.Add(this.btnExportTransactions);

            // POS Sales
            this.btnExportPOSSales.BackColor = btnBg;
            this.btnExportPOSSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPOSSales.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportPOSSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPOSSales.Font = btnFont;
            this.btnExportPOSSales.ForeColor = btnFg;
            this.btnExportPOSSales.Size = btnSize;
            this.btnExportPOSSales.Text = "POS Sales";
            this.btnExportPOSSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportPOSSales.Click += new System.EventHandler(this.BtnExportPOSSales_Click);
            this.flowTableExports.Controls.Add(this.btnExportPOSSales);

            // Restaurant
            this.btnExportRestaurant.BackColor = btnBg;
            this.btnExportRestaurant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportRestaurant.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportRestaurant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportRestaurant.Font = btnFont;
            this.btnExportRestaurant.ForeColor = btnFg;
            this.btnExportRestaurant.Size = btnSize;
            this.btnExportRestaurant.Text = "Restaurant";
            this.btnExportRestaurant.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportRestaurant.Click += new System.EventHandler(this.BtnExportRestaurant_Click);
            this.flowTableExports.Controls.Add(this.btnExportRestaurant);

            // Svc Requests
            this.btnExportSvcRequests.BackColor = btnBg;
            this.btnExportSvcRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportSvcRequests.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportSvcRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSvcRequests.Font = btnFont;
            this.btnExportSvcRequests.ForeColor = btnFg;
            this.btnExportSvcRequests.Size = btnSize;
            this.btnExportSvcRequests.Text = "Svc Requests";
            this.btnExportSvcRequests.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportSvcRequests.Click += new System.EventHandler(this.BtnExportSvcRequests_Click);
            this.flowTableExports.Controls.Add(this.btnExportSvcRequests);

            // Messages
            this.btnExportMessages.BackColor = btnBg;
            this.btnExportMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportMessages.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMessages.Font = btnFont;
            this.btnExportMessages.ForeColor = btnFg;
            this.btnExportMessages.Size = btnSize;
            this.btnExportMessages.Text = "Messages";
            this.btnExportMessages.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportMessages.Click += new System.EventHandler(this.BtnExportMessages_Click);
            this.flowTableExports.Controls.Add(this.btnExportMessages);

            // ==================== FORM ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings & Configuration";

            ((System.ComponentModel.ISupportInitialize)(this.numMaxGuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSurchargeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServiceTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPeakMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffMultiplier)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.grpHotelSettings.ResumeLayout(false);
            this.grpHotelSettings.PerformLayout();
            this.grpRegulations.ResumeLayout(false);
            this.grpRegulations.PerformLayout();
            this.grpSysConfig.ResumeLayout(false);
            this.grpSysConfig.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.flowTableExports.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;

        // Hotel Settings
        private System.Windows.Forms.GroupBox grpHotelSettings;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.TextBox txbHotelName;
        private System.Windows.Forms.Label lblHotelEmail;
        private System.Windows.Forms.TextBox txbHotelEmail;
        private System.Windows.Forms.Label lblHotelPhone;
        private System.Windows.Forms.TextBox txbHotelPhone;
        private System.Windows.Forms.Label lblHotelCurrency;
        private System.Windows.Forms.TextBox txbHotelCurrency;
        private System.Windows.Forms.Label lblHotelAddress;
        private System.Windows.Forms.TextBox txbHotelAddress;

        // Regulations
        private System.Windows.Forms.GroupBox grpRegulations;
        private System.Windows.Forms.Label lblMaxGuests;
        private System.Windows.Forms.NumericUpDown numMaxGuests;
        private System.Windows.Forms.Label lblSurchargeRate;
        private System.Windows.Forms.NumericUpDown numSurchargeRate;
        private System.Windows.Forms.Label lblCheckInTime;
        private System.Windows.Forms.TextBox txbCheckInTime;
        private System.Windows.Forms.Label lblCheckOutTime;
        private System.Windows.Forms.TextBox txbCheckOutTime;

        private System.Windows.Forms.Button btnSaveSettings;

        // System Configuration
        private System.Windows.Forms.GroupBox grpSysConfig;
        private System.Windows.Forms.Label lblDefaultTax;
        private System.Windows.Forms.NumericUpDown numDefaultTax;
        private System.Windows.Forms.Label lblServiceTax;
        private System.Windows.Forms.NumericUpDown numServiceTax;
        private System.Windows.Forms.Label lblPeakMultiplier;
        private System.Windows.Forms.NumericUpDown numPeakMultiplier;
        private System.Windows.Forms.Label lblPeakDates;
        private System.Windows.Forms.DateTimePicker dtpPeakStart;
        private System.Windows.Forms.Label lblPeakTo;
        private System.Windows.Forms.DateTimePicker dtpPeakEnd;
        private System.Windows.Forms.Label lblOffMultiplier;
        private System.Windows.Forms.NumericUpDown numOffMultiplier;
        private System.Windows.Forms.Label lblOffDates;
        private System.Windows.Forms.DateTimePicker dtpOffStart;
        private System.Windows.Forms.Label lblOffTo;
        private System.Windows.Forms.DateTimePicker dtpOffEnd;

        // Backup & Restore
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Label lblTableExports;
        private System.Windows.Forms.FlowLayoutPanel flowTableExports;
        private System.Windows.Forms.Button btnExportRooms;
        private System.Windows.Forms.Button btnExportGuests;
        private System.Windows.Forms.Button btnExportBookings;
        private System.Windows.Forms.Button btnExportServices;
        private System.Windows.Forms.Button btnExportInvoices;
        private System.Windows.Forms.Button btnExportInventory;
        private System.Windows.Forms.Button btnExportMenu;
        private System.Windows.Forms.Button btnExportStore;
        private System.Windows.Forms.Button btnExportTickets;
        private System.Windows.Forms.Button btnExportAccounts;
        private System.Windows.Forms.Button btnExportTransactions;
        private System.Windows.Forms.Button btnExportPOSSales;
        private System.Windows.Forms.Button btnExportRestaurant;
        private System.Windows.Forms.Button btnExportSvcRequests;
        private System.Windows.Forms.Button btnExportMessages;
    }
}
