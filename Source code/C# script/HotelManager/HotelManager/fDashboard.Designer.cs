namespace HotelManager
{
    partial class fDashboard
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseTop = new System.Windows.Forms.PictureBox();
            this.panelArrivals = new System.Windows.Forms.Panel();
            this.lblArrivalsCaption = new System.Windows.Forms.Label();
            this.lblArrivals = new System.Windows.Forms.Label();
            this.panelDepartures = new System.Windows.Forms.Panel();
            this.lblDeparturesCaption = new System.Windows.Forms.Label();
            this.lblDepartures = new System.Windows.Forms.Label();
            this.panelOccupancy = new System.Windows.Forms.Panel();
            this.lblOccupancyCaption = new System.Windows.Forms.Label();
            this.lblOccupancy = new System.Windows.Forms.Label();
            this.progressOccupancy = new System.Windows.Forms.ProgressBar();
            this.panelRevPAR = new System.Windows.Forms.Panel();
            this.lblRevPARCaption = new System.Windows.Forms.Label();
            this.lblRevPAR = new System.Windows.Forms.Label();
            this.panelRoomOverview = new System.Windows.Forms.Panel();
            this.lblRoomOverviewTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOccupied = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.panelPricing = new System.Windows.Forms.Panel();
            this.lblPricingTitle = new System.Windows.Forms.Label();
            this.lblPricing = new System.Windows.Forms.Label();
            this.panelHousekeeping = new System.Windows.Forms.Panel();
            this.lblHousekeepingTitle = new System.Windows.Forms.Label();
            this.dgvDirtyRooms = new System.Windows.Forms.DataGridView();
            this.btnRefreshDirty = new System.Windows.Forms.Button();
            this.grpAICheckIn = new System.Windows.Forms.GroupBox();
            this.txtEmailInput = new System.Windows.Forms.TextBox();
            this.btnParseEmail = new System.Windows.Forms.Button();
            this.lblParsedName = new System.Windows.Forms.Label();
            this.lblParsedCheckIn = new System.Windows.Forms.Label();
            this.lblParsedCheckOut = new System.Windows.Forms.Label();
            this.lblParsedPrice = new System.Windows.Forms.Label();
            this.grpSentiment = new System.Windows.Forms.GroupBox();
            this.txtGuestNotes = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblSentiment = new System.Windows.Forms.Label();
            this.btnCloseDashboard = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseTop)).BeginInit();
            this.panelArrivals.SuspendLayout();
            this.panelDepartures.SuspendLayout();
            this.panelOccupancy.SuspendLayout();
            this.panelRevPAR.SuspendLayout();
            this.panelRoomOverview.SuspendLayout();
            this.panelPricing.SuspendLayout();
            this.panelHousekeeping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirtyRooms)).BeginInit();
            this.grpAICheckIn.SuspendLayout();
            this.grpSentiment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnCloseTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1366, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manager Dashboard";
            // 
            // btnCloseTop
            // 
            this.btnCloseTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnCloseTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseTop.Location = new System.Drawing.Point(1320, 12);
            this.btnCloseTop.Name = "btnCloseTop";
            this.btnCloseTop.Size = new System.Drawing.Size(32, 32);
            this.btnCloseTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCloseTop.TabIndex = 1;
            this.btnCloseTop.TabStop = false;
            this.btnCloseTop.Click += new System.EventHandler(this.BtnCloseTop_Click);
            // 
            // panelArrivals
            // 
            this.panelArrivals.BackColor = System.Drawing.Color.White;
            this.panelArrivals.Controls.Add(this.lblArrivalsCaption);
            this.panelArrivals.Controls.Add(this.lblArrivals);
            this.panelArrivals.Location = new System.Drawing.Point(30, 80);
            this.panelArrivals.Name = "panelArrivals";
            this.panelArrivals.Size = new System.Drawing.Size(300, 120);
            this.panelArrivals.TabIndex = 1;
            // 
            // lblArrivalsCaption
            // 
            this.lblArrivalsCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArrivalsCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(106)))));
            this.lblArrivalsCaption.Location = new System.Drawing.Point(15, 15);
            this.lblArrivalsCaption.Name = "lblArrivalsCaption";
            this.lblArrivalsCaption.Size = new System.Drawing.Size(270, 25);
            this.lblArrivalsCaption.TabIndex = 0;
            this.lblArrivalsCaption.Text = "Today\'s Arrivals";
            // 
            // lblArrivals
            // 
            this.lblArrivals.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblArrivals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblArrivals.Location = new System.Drawing.Point(15, 45);
            this.lblArrivals.Name = "lblArrivals";
            this.lblArrivals.Size = new System.Drawing.Size(270, 60);
            this.lblArrivals.TabIndex = 1;
            this.lblArrivals.Text = "0";
            // 
            // panelDepartures
            // 
            this.panelDepartures.BackColor = System.Drawing.Color.White;
            this.panelDepartures.Controls.Add(this.lblDeparturesCaption);
            this.panelDepartures.Controls.Add(this.lblDepartures);
            this.panelDepartures.Location = new System.Drawing.Point(350, 80);
            this.panelDepartures.Name = "panelDepartures";
            this.panelDepartures.Size = new System.Drawing.Size(300, 120);
            this.panelDepartures.TabIndex = 2;
            // 
            // lblDeparturesCaption
            // 
            this.lblDeparturesCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeparturesCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(106)))));
            this.lblDeparturesCaption.Location = new System.Drawing.Point(15, 15);
            this.lblDeparturesCaption.Name = "lblDeparturesCaption";
            this.lblDeparturesCaption.Size = new System.Drawing.Size(270, 25);
            this.lblDeparturesCaption.TabIndex = 0;
            this.lblDeparturesCaption.Text = "Today\'s Departures";
            // 
            // lblDepartures
            // 
            this.lblDepartures.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDepartures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblDepartures.Location = new System.Drawing.Point(15, 45);
            this.lblDepartures.Name = "lblDepartures";
            this.lblDepartures.Size = new System.Drawing.Size(270, 60);
            this.lblDepartures.TabIndex = 1;
            this.lblDepartures.Text = "0";
            // 
            // panelOccupancy
            // 
            this.panelOccupancy.BackColor = System.Drawing.Color.White;
            this.panelOccupancy.Controls.Add(this.lblOccupancyCaption);
            this.panelOccupancy.Controls.Add(this.lblOccupancy);
            this.panelOccupancy.Controls.Add(this.progressOccupancy);
            this.panelOccupancy.Location = new System.Drawing.Point(670, 80);
            this.panelOccupancy.Name = "panelOccupancy";
            this.panelOccupancy.Size = new System.Drawing.Size(300, 120);
            this.panelOccupancy.TabIndex = 3;
            // 
            // lblOccupancyCaption
            // 
            this.lblOccupancyCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOccupancyCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(106)))));
            this.lblOccupancyCaption.Location = new System.Drawing.Point(15, 15);
            this.lblOccupancyCaption.Name = "lblOccupancyCaption";
            this.lblOccupancyCaption.Size = new System.Drawing.Size(270, 25);
            this.lblOccupancyCaption.TabIndex = 0;
            this.lblOccupancyCaption.Text = "Occupancy";
            // 
            // lblOccupancy
            // 
            this.lblOccupancy.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblOccupancy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblOccupancy.Location = new System.Drawing.Point(15, 42);
            this.lblOccupancy.Name = "lblOccupancy";
            this.lblOccupancy.Size = new System.Drawing.Size(270, 35);
            this.lblOccupancy.TabIndex = 1;
            this.lblOccupancy.Text = "0%";
            // 
            // progressOccupancy
            // 
            this.progressOccupancy.Location = new System.Drawing.Point(15, 85);
            this.progressOccupancy.Name = "progressOccupancy";
            this.progressOccupancy.Size = new System.Drawing.Size(270, 18);
            this.progressOccupancy.TabIndex = 2;
            // 
            // panelRevPAR
            // 
            this.panelRevPAR.BackColor = System.Drawing.Color.White;
            this.panelRevPAR.Controls.Add(this.lblRevPARCaption);
            this.panelRevPAR.Controls.Add(this.lblRevPAR);
            this.panelRevPAR.Location = new System.Drawing.Point(990, 80);
            this.panelRevPAR.Name = "panelRevPAR";
            this.panelRevPAR.Size = new System.Drawing.Size(300, 120);
            this.panelRevPAR.TabIndex = 4;
            // 
            // lblRevPARCaption
            // 
            this.lblRevPARCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRevPARCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(106)))));
            this.lblRevPARCaption.Location = new System.Drawing.Point(15, 15);
            this.lblRevPARCaption.Name = "lblRevPARCaption";
            this.lblRevPARCaption.Size = new System.Drawing.Size(270, 25);
            this.lblRevPARCaption.TabIndex = 0;
            this.lblRevPARCaption.Text = "RevPAR";
            // 
            // lblRevPAR
            // 
            this.lblRevPAR.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblRevPAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblRevPAR.Location = new System.Drawing.Point(15, 45);
            this.lblRevPAR.Name = "lblRevPAR";
            this.lblRevPAR.Size = new System.Drawing.Size(270, 60);
            this.lblRevPAR.TabIndex = 1;
            this.lblRevPAR.Text = "$0";
            // 
            // panelRoomOverview
            // 
            this.panelRoomOverview.BackColor = System.Drawing.Color.White;
            this.panelRoomOverview.Controls.Add(this.lblRoomOverviewTitle);
            this.panelRoomOverview.Controls.Add(this.lblTotal);
            this.panelRoomOverview.Controls.Add(this.lblOccupied);
            this.panelRoomOverview.Controls.Add(this.lblAvailable);
            this.panelRoomOverview.Location = new System.Drawing.Point(30, 230);
            this.panelRoomOverview.Name = "panelRoomOverview";
            this.panelRoomOverview.Size = new System.Drawing.Size(400, 170);
            this.panelRoomOverview.TabIndex = 5;
            // 
            // lblRoomOverviewTitle
            // 
            this.lblRoomOverviewTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoomOverviewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblRoomOverviewTitle.Location = new System.Drawing.Point(15, 12);
            this.lblRoomOverviewTitle.Name = "lblRoomOverviewTitle";
            this.lblRoomOverviewTitle.Size = new System.Drawing.Size(370, 25);
            this.lblRoomOverviewTitle.TabIndex = 0;
            this.lblRoomOverviewTitle.Text = "Room Overview";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTotal.Location = new System.Drawing.Point(15, 50);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(370, 30);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total Rooms: 0";
            // 
            // lblOccupied
            // 
            this.lblOccupied.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOccupied.Location = new System.Drawing.Point(15, 85);
            this.lblOccupied.Name = "lblOccupied";
            this.lblOccupied.Size = new System.Drawing.Size(370, 30);
            this.lblOccupied.TabIndex = 2;
            this.lblOccupied.Text = "Occupied: 0";
            // 
            // lblAvailable
            // 
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAvailable.Location = new System.Drawing.Point(15, 120);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(370, 30);
            this.lblAvailable.TabIndex = 3;
            this.lblAvailable.Text = "Available: 0";
            // 
            // panelPricing
            // 
            this.panelPricing.BackColor = System.Drawing.Color.White;
            this.panelPricing.Controls.Add(this.lblPricingTitle);
            this.panelPricing.Controls.Add(this.lblPricing);
            this.panelPricing.Location = new System.Drawing.Point(450, 230);
            this.panelPricing.Name = "panelPricing";
            this.panelPricing.Size = new System.Drawing.Size(400, 170);
            this.panelPricing.TabIndex = 6;
            // 
            // lblPricingTitle
            // 
            this.lblPricingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPricingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblPricingTitle.Location = new System.Drawing.Point(15, 12);
            this.lblPricingTitle.Name = "lblPricingTitle";
            this.lblPricingTitle.Size = new System.Drawing.Size(370, 25);
            this.lblPricingTitle.TabIndex = 0;
            this.lblPricingTitle.Text = "Dynamic Pricing";
            // 
            // lblPricing
            // 
            this.lblPricing.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPricing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPricing.Location = new System.Drawing.Point(15, 50);
            this.lblPricing.Name = "lblPricing";
            this.lblPricing.Size = new System.Drawing.Size(370, 100);
            this.lblPricing.TabIndex = 1;
            this.lblPricing.Text = "Loading...";
            // 
            // panelHousekeeping
            // 
            this.panelHousekeeping.BackColor = System.Drawing.Color.White;
            this.panelHousekeeping.Controls.Add(this.lblHousekeepingTitle);
            this.panelHousekeeping.Controls.Add(this.dgvDirtyRooms);
            this.panelHousekeeping.Controls.Add(this.btnRefreshDirty);
            this.panelHousekeeping.Location = new System.Drawing.Point(870, 230);
            this.panelHousekeeping.Name = "panelHousekeeping";
            this.panelHousekeeping.Size = new System.Drawing.Size(420, 170);
            this.panelHousekeeping.TabIndex = 7;
            // 
            // lblHousekeepingTitle
            // 
            this.lblHousekeepingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHousekeepingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblHousekeepingTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHousekeepingTitle.Name = "lblHousekeepingTitle";
            this.lblHousekeepingTitle.Size = new System.Drawing.Size(200, 25);
            this.lblHousekeepingTitle.TabIndex = 0;
            this.lblHousekeepingTitle.Text = "Housekeeping";
            // 
            // dgvDirtyRooms
            // 
            this.dgvDirtyRooms.AllowUserToAddRows = false;
            this.dgvDirtyRooms.AllowUserToDeleteRows = false;
            this.dgvDirtyRooms.BackgroundColor = System.Drawing.Color.White;
            this.dgvDirtyRooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDirtyRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirtyRooms.Location = new System.Drawing.Point(15, 42);
            this.dgvDirtyRooms.Name = "dgvDirtyRooms";
            this.dgvDirtyRooms.ReadOnly = true;
            this.dgvDirtyRooms.RowHeadersVisible = false;
            this.dgvDirtyRooms.Size = new System.Drawing.Size(295, 115);
            this.dgvDirtyRooms.TabIndex = 1;
            // 
            // btnRefreshDirty
            // 
            this.btnRefreshDirty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnRefreshDirty.FlatAppearance.BorderSize = 0;
            this.btnRefreshDirty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDirty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshDirty.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDirty.Location = new System.Drawing.Point(320, 42);
            this.btnRefreshDirty.Name = "btnRefreshDirty";
            this.btnRefreshDirty.Size = new System.Drawing.Size(85, 35);
            this.btnRefreshDirty.TabIndex = 2;
            this.btnRefreshDirty.Text = "Refresh";
            this.btnRefreshDirty.UseVisualStyleBackColor = false;
            this.btnRefreshDirty.Click += new System.EventHandler(this.BtnRefreshDirty_Click);
            // 
            // grpAICheckIn
            // 
            this.grpAICheckIn.BackColor = System.Drawing.Color.White;
            this.grpAICheckIn.Controls.Add(this.txtEmailInput);
            this.grpAICheckIn.Controls.Add(this.btnParseEmail);
            this.grpAICheckIn.Controls.Add(this.lblParsedName);
            this.grpAICheckIn.Controls.Add(this.lblParsedCheckIn);
            this.grpAICheckIn.Controls.Add(this.lblParsedCheckOut);
            this.grpAICheckIn.Controls.Add(this.lblParsedPrice);
            this.grpAICheckIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpAICheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.grpAICheckIn.Location = new System.Drawing.Point(30, 430);
            this.grpAICheckIn.Name = "grpAICheckIn";
            this.grpAICheckIn.Size = new System.Drawing.Size(620, 230);
            this.grpAICheckIn.TabIndex = 8;
            this.grpAICheckIn.TabStop = false;
            this.grpAICheckIn.Text = "AI Smart Check-In";
            // 
            // txtEmailInput
            // 
            this.txtEmailInput.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmailInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtEmailInput.Location = new System.Drawing.Point(15, 30);
            this.txtEmailInput.Multiline = true;
            this.txtEmailInput.Name = "txtEmailInput";
            this.txtEmailInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailInput.Size = new System.Drawing.Size(440, 80);
            this.txtEmailInput.TabIndex = 0;
            // 
            // btnParseEmail
            // 
            this.btnParseEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnParseEmail.FlatAppearance.BorderSize = 0;
            this.btnParseEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParseEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnParseEmail.ForeColor = System.Drawing.Color.White;
            this.btnParseEmail.Location = new System.Drawing.Point(470, 30);
            this.btnParseEmail.Name = "btnParseEmail";
            this.btnParseEmail.Size = new System.Drawing.Size(130, 35);
            this.btnParseEmail.TabIndex = 1;
            this.btnParseEmail.Text = "Parse Booking";
            this.btnParseEmail.UseVisualStyleBackColor = false;
            this.btnParseEmail.Click += new System.EventHandler(this.BtnParseEmail_Click);
            // 
            // lblParsedName
            // 
            this.lblParsedName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParsedName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblParsedName.Location = new System.Drawing.Point(15, 125);
            this.lblParsedName.Name = "lblParsedName";
            this.lblParsedName.Size = new System.Drawing.Size(580, 22);
            this.lblParsedName.TabIndex = 2;
            this.lblParsedName.Text = "Name: --";
            // 
            // lblParsedCheckIn
            // 
            this.lblParsedCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParsedCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblParsedCheckIn.Location = new System.Drawing.Point(15, 150);
            this.lblParsedCheckIn.Name = "lblParsedCheckIn";
            this.lblParsedCheckIn.Size = new System.Drawing.Size(580, 22);
            this.lblParsedCheckIn.TabIndex = 3;
            this.lblParsedCheckIn.Text = "Check-In: --";
            // 
            // lblParsedCheckOut
            // 
            this.lblParsedCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParsedCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblParsedCheckOut.Location = new System.Drawing.Point(15, 175);
            this.lblParsedCheckOut.Name = "lblParsedCheckOut";
            this.lblParsedCheckOut.Size = new System.Drawing.Size(580, 22);
            this.lblParsedCheckOut.TabIndex = 4;
            this.lblParsedCheckOut.Text = "Check-Out: --";
            // 
            // lblParsedPrice
            // 
            this.lblParsedPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParsedPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblParsedPrice.Location = new System.Drawing.Point(15, 200);
            this.lblParsedPrice.Name = "lblParsedPrice";
            this.lblParsedPrice.Size = new System.Drawing.Size(580, 22);
            this.lblParsedPrice.TabIndex = 5;
            this.lblParsedPrice.Text = "Price: --";
            // 
            // grpSentiment
            // 
            this.grpSentiment.BackColor = System.Drawing.Color.White;
            this.grpSentiment.Controls.Add(this.txtGuestNotes);
            this.grpSentiment.Controls.Add(this.btnAnalyze);
            this.grpSentiment.Controls.Add(this.lblSentiment);
            this.grpSentiment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSentiment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.grpSentiment.Location = new System.Drawing.Point(670, 430);
            this.grpSentiment.Name = "grpSentiment";
            this.grpSentiment.Size = new System.Drawing.Size(620, 230);
            this.grpSentiment.TabIndex = 9;
            this.grpSentiment.TabStop = false;
            this.grpSentiment.Text = "Guest Sentiment Analysis";
            // 
            // txtGuestNotes
            // 
            this.txtGuestNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGuestNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtGuestNotes.Location = new System.Drawing.Point(15, 30);
            this.txtGuestNotes.Multiline = true;
            this.txtGuestNotes.Name = "txtGuestNotes";
            this.txtGuestNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGuestNotes.Size = new System.Drawing.Size(440, 60);
            this.txtGuestNotes.TabIndex = 0;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnAnalyze.FlatAppearance.BorderSize = 0;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAnalyze.ForeColor = System.Drawing.Color.White;
            this.btnAnalyze.Location = new System.Drawing.Point(470, 30);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(130, 35);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);
            // 
            // lblSentiment
            // 
            this.lblSentiment.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSentiment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSentiment.Location = new System.Drawing.Point(15, 110);
            this.lblSentiment.Name = "lblSentiment";
            this.lblSentiment.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblSentiment.Size = new System.Drawing.Size(580, 45);
            this.lblSentiment.TabIndex = 2;
            this.lblSentiment.Text = "Sentiment: --";
            this.lblSentiment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseDashboard
            // 
            this.btnCloseDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCloseDashboard.FlatAppearance.BorderSize = 0;
            this.btnCloseDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseDashboard.ForeColor = System.Drawing.Color.White;
            this.btnCloseDashboard.Location = new System.Drawing.Point(1190, 690);
            this.btnCloseDashboard.Name = "btnCloseDashboard";
            this.btnCloseDashboard.Size = new System.Drawing.Size(120, 40);
            this.btnCloseDashboard.TabIndex = 10;
            this.btnCloseDashboard.Text = "Close";
            this.btnCloseDashboard.UseVisualStyleBackColor = false;
            this.btnCloseDashboard.Click += new System.EventHandler(this.BtnCloseDashboard_Click);
            // 
            // fDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.btnCloseDashboard);
            this.Controls.Add(this.grpSentiment);
            this.Controls.Add(this.grpAICheckIn);
            this.Controls.Add(this.panelHousekeeping);
            this.Controls.Add(this.panelPricing);
            this.Controls.Add(this.panelRoomOverview);
            this.Controls.Add(this.panelRevPAR);
            this.Controls.Add(this.panelOccupancy);
            this.Controls.Add(this.panelDepartures);
            this.Controls.Add(this.panelArrivals);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseTop)).EndInit();
            this.panelArrivals.ResumeLayout(false);
            this.panelDepartures.ResumeLayout(false);
            this.panelOccupancy.ResumeLayout(false);
            this.panelRevPAR.ResumeLayout(false);
            this.panelRoomOverview.ResumeLayout(false);
            this.panelPricing.ResumeLayout(false);
            this.panelHousekeeping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirtyRooms)).EndInit();
            this.grpAICheckIn.ResumeLayout(false);
            this.grpAICheckIn.PerformLayout();
            this.grpSentiment.ResumeLayout(false);
            this.grpSentiment.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox btnCloseTop;
        private System.Windows.Forms.Panel panelArrivals;
        private System.Windows.Forms.Label lblArrivalsCaption;
        private System.Windows.Forms.Label lblArrivals;
        private System.Windows.Forms.Panel panelDepartures;
        private System.Windows.Forms.Label lblDeparturesCaption;
        private System.Windows.Forms.Label lblDepartures;
        private System.Windows.Forms.Panel panelOccupancy;
        private System.Windows.Forms.Label lblOccupancyCaption;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.ProgressBar progressOccupancy;
        private System.Windows.Forms.Panel panelRevPAR;
        private System.Windows.Forms.Label lblRevPARCaption;
        private System.Windows.Forms.Label lblRevPAR;
        private System.Windows.Forms.Panel panelRoomOverview;
        private System.Windows.Forms.Label lblRoomOverviewTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOccupied;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Panel panelPricing;
        private System.Windows.Forms.Label lblPricingTitle;
        private System.Windows.Forms.Label lblPricing;
        private System.Windows.Forms.Panel panelHousekeeping;
        private System.Windows.Forms.Label lblHousekeepingTitle;
        private System.Windows.Forms.DataGridView dgvDirtyRooms;
        private System.Windows.Forms.Button btnRefreshDirty;
        private System.Windows.Forms.GroupBox grpAICheckIn;
        private System.Windows.Forms.TextBox txtEmailInput;
        private System.Windows.Forms.Button btnParseEmail;
        private System.Windows.Forms.Label lblParsedName;
        private System.Windows.Forms.Label lblParsedCheckIn;
        private System.Windows.Forms.Label lblParsedCheckOut;
        private System.Windows.Forms.Label lblParsedPrice;
        private System.Windows.Forms.GroupBox grpSentiment;
        private System.Windows.Forms.TextBox txtGuestNotes;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblSentiment;
        private System.Windows.Forms.Button btnCloseDashboard;
    }
}
