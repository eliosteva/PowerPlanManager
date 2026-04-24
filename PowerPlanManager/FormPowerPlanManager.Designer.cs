
namespace PowerPlanManager
{
	partial class FormPowerPlanManager
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPowerPlanManager));
			this.label4 = new System.Windows.Forms.Label();
			this.toggleAutoStart = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.inputTimeout = new System.Windows.Forms.NumericUpDown();
			this.toggleIdleOnTimeout = new System.Windows.Forms.CheckBox();
			this.toggleIdleOnScreensaver = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pollingInterval = new System.Windows.Forms.NumericUpDown();
			this.buttonRefreshPowerModes = new System.Windows.Forms.Button();
			this.buttonQuit = new System.Windows.Forms.Button();
			this.sleepTimeoutIdle = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.displayTimeoutIdle = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
			this.listBoxBalanced = new System.Windows.Forms.ListBox();
			this.listBoxPerformance = new System.Windows.Forms.ListBox();
			this.listBoxIdle = new System.Windows.Forms.ListBox();
			this.buttonIdleToBalanced = new System.Windows.Forms.Button();
			this.buttonBalancedToIdle = new System.Windows.Forms.Button();
			this.buttonBalancedToPerf = new System.Windows.Forms.Button();
			this.buttonPerfToBalanced = new System.Windows.Forms.Button();
			this.cmbPowerPlanPerformance = new System.Windows.Forms.ComboBox();
			this.cmbPowerPlanBalanced = new System.Windows.Forms.ComboBox();
			this.cmbPowerPlanIdle = new System.Windows.Forms.ComboBox();
			this.buttonAuto = new System.Windows.Forms.Button();
			this.buttonPowerSaver = new System.Windows.Forms.Button();
			this.buttonBalanced = new System.Windows.Forms.Button();
			this.buttonPerformance = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonApplyBalancedPowerMode = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.sleepTimeoutBalanced = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.displayTimeoutBalanced = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.sleepTimeoutBoost = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.displayTimeoutBoost = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutIdle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutIdle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutBalanced)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutBalanced)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutBoost)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutBoost)).BeginInit();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.Location = new System.Drawing.Point(6, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(219, 21);
			this.label4.TabIndex = 6;
			this.label4.Text = "Idle from Screensaver:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.Location = new System.Drawing.Point(231, 16);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(21, 21);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = false;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.Control;
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(219, 21);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.Control;
			this.label8.Location = new System.Drawing.Point(6, 101);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(219, 21);
			this.label8.TabIndex = 18;
			this.label8.Text = "Idle from user input:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.Control;
			this.label9.Location = new System.Drawing.Point(6, 67);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(219, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Location = new System.Drawing.Point(231, 67);
			this.inputTimeout.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.inputTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.inputTimeout.Name = "inputTimeout";
			this.inputTimeout.Size = new System.Drawing.Size(76, 20);
			this.inputTimeout.TabIndex = 10;
			this.inputTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.inputTimeout.ValueChanged += new System.EventHandler(this.inputTimeout_ValueChanged);
			// 
			// toggleIdleOnTimeout
			// 
			this.toggleIdleOnTimeout.Location = new System.Drawing.Point(231, 101);
			this.toggleIdleOnTimeout.Name = "toggleIdleOnTimeout";
			this.toggleIdleOnTimeout.Size = new System.Drawing.Size(21, 21);
			this.toggleIdleOnTimeout.TabIndex = 23;
			this.toggleIdleOnTimeout.UseVisualStyleBackColor = true;
			this.toggleIdleOnTimeout.CheckedChanged += new System.EventHandler(this.toggleIdleOnTimeout_CheckedChanged);
			// 
			// toggleIdleOnScreensaver
			// 
			this.toggleIdleOnScreensaver.Location = new System.Drawing.Point(231, 128);
			this.toggleIdleOnScreensaver.Name = "toggleIdleOnScreensaver";
			this.toggleIdleOnScreensaver.Size = new System.Drawing.Size(21, 21);
			this.toggleIdleOnScreensaver.TabIndex = 24;
			this.toggleIdleOnScreensaver.UseVisualStyleBackColor = true;
			this.toggleIdleOnScreensaver.CheckedChanged += new System.EventHandler(this.toggleIdleOnScreensaver_CheckedChanged);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.Location = new System.Drawing.Point(6, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(219, 21);
			this.label5.TabIndex = 28;
			this.label5.Text = "Polling interval (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pollingInterval
			// 
			this.pollingInterval.Location = new System.Drawing.Point(231, 40);
			this.pollingInterval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.pollingInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.pollingInterval.Name = "pollingInterval";
			this.pollingInterval.Size = new System.Drawing.Size(76, 20);
			this.pollingInterval.TabIndex = 29;
			this.pollingInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.pollingInterval.ValueChanged += new System.EventHandler(this.pollingInterval_ValueChanged);
			// 
			// buttonRefreshPowerModes
			// 
			this.buttonRefreshPowerModes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerModes.Location = new System.Drawing.Point(772, 12);
			this.buttonRefreshPowerModes.Name = "buttonRefreshPowerModes";
			this.buttonRefreshPowerModes.Size = new System.Drawing.Size(94, 30);
			this.buttonRefreshPowerModes.TabIndex = 43;
			this.buttonRefreshPowerModes.Text = "Refresh";
			this.buttonRefreshPowerModes.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerModes.Click += new System.EventHandler(this.buttonRefreshPowerModes_Click);
			// 
			// buttonQuit
			// 
			this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonQuit.Location = new System.Drawing.Point(872, 12);
			this.buttonQuit.Name = "buttonQuit";
			this.buttonQuit.Size = new System.Drawing.Size(94, 30);
			this.buttonQuit.TabIndex = 37;
			this.buttonQuit.Text = "Quit";
			this.buttonQuit.UseVisualStyleBackColor = true;
			this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
			// 
			// sleepTimeoutIdle
			// 
			this.sleepTimeoutIdle.Location = new System.Drawing.Point(231, 435);
			this.sleepTimeoutIdle.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.sleepTimeoutIdle.Name = "sleepTimeoutIdle";
			this.sleepTimeoutIdle.Size = new System.Drawing.Size(48, 20);
			this.sleepTimeoutIdle.TabIndex = 33;
			this.sleepTimeoutIdle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.sleepTimeoutIdle.ValueChanged += new System.EventHandler(this.sleepTimeoutIdle_ValueChanged);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(6, 437);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 20);
			this.label2.TabIndex = 32;
			this.label2.Text = "Sleep timeout (min):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// displayTimeoutIdle
			// 
			this.displayTimeoutIdle.Location = new System.Drawing.Point(231, 409);
			this.displayTimeoutIdle.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.displayTimeoutIdle.Name = "displayTimeoutIdle";
			this.displayTimeoutIdle.Size = new System.Drawing.Size(48, 20);
			this.displayTimeoutIdle.TabIndex = 31;
			this.displayTimeoutIdle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.displayTimeoutIdle.ValueChanged += new System.EventHandler(this.displayTimeout_ValueChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(6, 409);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(219, 20);
			this.label1.TabIndex = 30;
			this.label1.Text = "Display timeout (min):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.Location = new System.Drawing.Point(303, 17);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(476, 20);
			this.labelStatus.TabIndex = 44;
			this.labelStatus.Text = "IDLE";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxStatus
			// 
			this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
			this.pictureBoxStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.InitialImage")));
			this.pictureBoxStatus.Location = new System.Drawing.Point(277, 17);
			this.pictureBoxStatus.Name = "pictureBoxStatus";
			this.pictureBoxStatus.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStatus.TabIndex = 45;
			this.pictureBoxStatus.TabStop = false;
			// 
			// listBoxBalanced
			// 
			this.listBoxBalanced.FormattingEnabled = true;
			this.listBoxBalanced.Location = new System.Drawing.Point(6, 65);
			this.listBoxBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxBalanced.Name = "listBoxBalanced";
			this.listBoxBalanced.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxBalanced.Size = new System.Drawing.Size(273, 290);
			this.listBoxBalanced.TabIndex = 46;
			// 
			// listBoxPerformance
			// 
			this.listBoxPerformance.FormattingEnabled = true;
			this.listBoxPerformance.Location = new System.Drawing.Point(6, 65);
			this.listBoxPerformance.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxPerformance.Name = "listBoxPerformance";
			this.listBoxPerformance.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxPerformance.Size = new System.Drawing.Size(273, 290);
			this.listBoxPerformance.TabIndex = 46;
			// 
			// listBoxIdle
			// 
			this.listBoxIdle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxIdle.FormattingEnabled = true;
			this.listBoxIdle.Location = new System.Drawing.Point(5, 65);
			this.listBoxIdle.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxIdle.Name = "listBoxIdle";
			this.listBoxIdle.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxIdle.Size = new System.Drawing.Size(274, 290);
			this.listBoxIdle.TabIndex = 46;
			// 
			// buttonIdleToBalanced
			// 
			this.buttonIdleToBalanced.Location = new System.Drawing.Point(306, 113);
			this.buttonIdleToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonIdleToBalanced.Name = "buttonIdleToBalanced";
			this.buttonIdleToBalanced.Size = new System.Drawing.Size(37, 83);
			this.buttonIdleToBalanced.TabIndex = 48;
			this.buttonIdleToBalanced.Text = ">";
			this.buttonIdleToBalanced.UseVisualStyleBackColor = true;
			this.buttonIdleToBalanced.Click += new System.EventHandler(this.buttonIdleToBalanced_Click);
			// 
			// buttonBalancedToIdle
			// 
			this.buttonBalancedToIdle.Location = new System.Drawing.Point(306, 310);
			this.buttonBalancedToIdle.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToIdle.Name = "buttonBalancedToIdle";
			this.buttonBalancedToIdle.Size = new System.Drawing.Size(37, 89);
			this.buttonBalancedToIdle.TabIndex = 49;
			this.buttonBalancedToIdle.Text = "<";
			this.buttonBalancedToIdle.UseVisualStyleBackColor = true;
			this.buttonBalancedToIdle.Click += new System.EventHandler(this.buttonBalancedToIdle_Click);
			// 
			// buttonBalancedToPerf
			// 
			this.buttonBalancedToPerf.Location = new System.Drawing.Point(638, 113);
			this.buttonBalancedToPerf.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToPerf.Name = "buttonBalancedToPerf";
			this.buttonBalancedToPerf.Size = new System.Drawing.Size(37, 83);
			this.buttonBalancedToPerf.TabIndex = 50;
			this.buttonBalancedToPerf.Text = ">";
			this.buttonBalancedToPerf.UseVisualStyleBackColor = true;
			this.buttonBalancedToPerf.Click += new System.EventHandler(this.buttonBalancedToPerf_Click);
			// 
			// buttonPerfToBalanced
			// 
			this.buttonPerfToBalanced.Location = new System.Drawing.Point(638, 314);
			this.buttonPerfToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonPerfToBalanced.Name = "buttonPerfToBalanced";
			this.buttonPerfToBalanced.Size = new System.Drawing.Size(37, 89);
			this.buttonPerfToBalanced.TabIndex = 51;
			this.buttonPerfToBalanced.Text = "<";
			this.buttonPerfToBalanced.UseVisualStyleBackColor = true;
			this.buttonPerfToBalanced.Click += new System.EventHandler(this.buttonPerfToBalanced_Click);
			// 
			// cmbPowerPlanPerformance
			// 
			this.cmbPowerPlanPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPowerPlanPerformance.FormattingEnabled = true;
			this.cmbPowerPlanPerformance.Location = new System.Drawing.Point(6, 384);
			this.cmbPowerPlanPerformance.Name = "cmbPowerPlanPerformance";
			this.cmbPowerPlanPerformance.Size = new System.Drawing.Size(273, 21);
			this.cmbPowerPlanPerformance.TabIndex = 58;
			this.cmbPowerPlanPerformance.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanPerformance_SelectedIndexChanged);
			// 
			// cmbPowerPlanBalanced
			// 
			this.cmbPowerPlanBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPowerPlanBalanced.FormattingEnabled = true;
			this.cmbPowerPlanBalanced.Location = new System.Drawing.Point(9, 384);
			this.cmbPowerPlanBalanced.Name = "cmbPowerPlanBalanced";
			this.cmbPowerPlanBalanced.Size = new System.Drawing.Size(270, 21);
			this.cmbPowerPlanBalanced.TabIndex = 57;
			this.cmbPowerPlanBalanced.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanBalanced_SelectedIndexChanged);
			// 
			// cmbPowerPlanIdle
			// 
			this.cmbPowerPlanIdle.FormattingEnabled = true;
			this.cmbPowerPlanIdle.Location = new System.Drawing.Point(6, 384);
			this.cmbPowerPlanIdle.Name = "cmbPowerPlanIdle";
			this.cmbPowerPlanIdle.Size = new System.Drawing.Size(274, 21);
			this.cmbPowerPlanIdle.TabIndex = 56;
			this.cmbPowerPlanIdle.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanIdle_SelectedIndexChanged);
			// 
			// buttonAuto
			// 
			this.buttonAuto.BackColor = System.Drawing.SystemColors.Highlight;
			this.buttonAuto.Location = new System.Drawing.Point(12, 12);
			this.buttonAuto.Name = "buttonAuto";
			this.buttonAuto.Size = new System.Drawing.Size(149, 30);
			this.buttonAuto.TabIndex = 53;
			this.buttonAuto.Text = "Auto";
			this.buttonAuto.UseVisualStyleBackColor = false;
			this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
			// 
			// buttonPowerSaver
			// 
			this.buttonPowerSaver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPowerSaver.Location = new System.Drawing.Point(6, 19);
			this.buttonPowerSaver.Name = "buttonPowerSaver";
			this.buttonPowerSaver.Size = new System.Drawing.Size(273, 41);
			this.buttonPowerSaver.TabIndex = 54;
			this.buttonPowerSaver.Text = "Force Idle";
			this.buttonPowerSaver.UseVisualStyleBackColor = true;
			this.buttonPowerSaver.Click += new System.EventHandler(this.buttonPowerSaver_Click);
			// 
			// buttonBalanced
			// 
			this.buttonBalanced.Location = new System.Drawing.Point(6, 19);
			this.buttonBalanced.Name = "buttonBalanced";
			this.buttonBalanced.Size = new System.Drawing.Size(273, 41);
			this.buttonBalanced.TabIndex = 55;
			this.buttonBalanced.Text = "Force Balanced";
			this.buttonBalanced.UseVisualStyleBackColor = true;
			this.buttonBalanced.Click += new System.EventHandler(this.buttonBalanced_Click);
			// 
			// buttonPerformance
			// 
			this.buttonPerformance.Location = new System.Drawing.Point(6, 19);
			this.buttonPerformance.Name = "buttonPerformance";
			this.buttonPerformance.Size = new System.Drawing.Size(273, 41);
			this.buttonPerformance.TabIndex = 56;
			this.buttonPerformance.Text = "Force Performance";
			this.buttonPerformance.UseVisualStyleBackColor = true;
			this.buttonPerformance.Click += new System.EventHandler(this.buttonPerformance_Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(167, 17);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 20);
			this.label11.TabIndex = 61;
			this.label11.Text = "Current status:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.SystemColors.Control;
			this.label10.Location = new System.Drawing.Point(6, 357);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(219, 21);
			this.label10.TabIndex = 63;
			this.label10.Text = "Idle PowerPlan:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.pollingInterval);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.toggleIdleOnScreensaver);
			this.groupBox1.Controls.Add(this.inputTimeout);
			this.groupBox1.Controls.Add(this.toggleIdleOnTimeout);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.toggleAutoStart);
			this.groupBox1.Location = new System.Drawing.Point(12, 521);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(954, 162);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// buttonApplyBalancedPowerMode
			// 
			this.buttonApplyBalancedPowerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApplyBalancedPowerMode.Location = new System.Drawing.Point(643, 12);
			this.buttonApplyBalancedPowerMode.Name = "buttonApplyBalancedPowerMode";
			this.buttonApplyBalancedPowerMode.Size = new System.Drawing.Size(123, 30);
			this.buttonApplyBalancedPowerMode.TabIndex = 65;
			this.buttonApplyBalancedPowerMode.Text = "Reset Power Mode";
			this.buttonApplyBalancedPowerMode.UseVisualStyleBackColor = true;
			this.buttonApplyBalancedPowerMode.Click += new System.EventHandler(this.buttonApplyBalancedPowerMode_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBoxIdle);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.buttonPowerSaver);
			this.groupBox2.Controls.Add(this.displayTimeoutIdle);
			this.groupBox2.Controls.Add(this.cmbPowerPlanIdle);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.sleepTimeoutIdle);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(285, 467);
			this.groupBox2.TabIndex = 66;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Idle";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.sleepTimeoutBalanced);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.displayTimeoutBalanced);
			this.groupBox3.Controls.Add(this.listBoxBalanced);
			this.groupBox3.Controls.Add(this.buttonBalanced);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.cmbPowerPlanBalanced);
			this.groupBox3.Location = new System.Drawing.Point(348, 48);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(285, 467);
			this.groupBox3.TabIndex = 67;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Balanced";
			// 
			// sleepTimeoutBalanced
			// 
			this.sleepTimeoutBalanced.Location = new System.Drawing.Point(231, 435);
			this.sleepTimeoutBalanced.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.sleepTimeoutBalanced.Name = "sleepTimeoutBalanced";
			this.sleepTimeoutBalanced.Size = new System.Drawing.Size(48, 20);
			this.sleepTimeoutBalanced.TabIndex = 65;
			this.sleepTimeoutBalanced.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.sleepTimeoutBalanced.ValueChanged += new System.EventHandler(this.sleepTimeoutBalanced_ValueChanged);
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.SystemColors.Control;
			this.label16.Location = new System.Drawing.Point(6, 437);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(219, 20);
			this.label16.TabIndex = 64;
			this.label16.Text = "Sleep timeout (min):";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.SystemColors.Control;
			this.label12.Location = new System.Drawing.Point(6, 409);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(219, 20);
			this.label12.TabIndex = 64;
			this.label12.Text = "Display timeout (min):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// displayTimeoutBalanced
			// 
			this.displayTimeoutBalanced.Location = new System.Drawing.Point(231, 409);
			this.displayTimeoutBalanced.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.displayTimeoutBalanced.Name = "displayTimeoutBalanced";
			this.displayTimeoutBalanced.Size = new System.Drawing.Size(48, 20);
			this.displayTimeoutBalanced.TabIndex = 65;
			this.displayTimeoutBalanced.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.displayTimeoutBalanced.ValueChanged += new System.EventHandler(this.displayTimeoutBalanced_ValueChanged);
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.SystemColors.Control;
			this.label14.Location = new System.Drawing.Point(6, 357);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(219, 21);
			this.label14.TabIndex = 63;
			this.label14.Text = "Balanced PowerPlan:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.sleepTimeoutBoost);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.displayTimeoutBoost);
			this.groupBox4.Controls.Add(this.listBoxPerformance);
			this.groupBox4.Controls.Add(this.buttonPerformance);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.cmbPowerPlanPerformance);
			this.groupBox4.Location = new System.Drawing.Point(680, 48);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(285, 467);
			this.groupBox4.TabIndex = 68;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Performance";
			// 
			// sleepTimeoutBoost
			// 
			this.sleepTimeoutBoost.Location = new System.Drawing.Point(231, 435);
			this.sleepTimeoutBoost.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.sleepTimeoutBoost.Name = "sleepTimeoutBoost";
			this.sleepTimeoutBoost.Size = new System.Drawing.Size(48, 20);
			this.sleepTimeoutBoost.TabIndex = 67;
			this.sleepTimeoutBoost.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.sleepTimeoutBoost.ValueChanged += new System.EventHandler(this.sleepTimeoutBoost_ValueChanged);
			// 
			// label17
			// 
			this.label17.BackColor = System.Drawing.SystemColors.Control;
			this.label17.Location = new System.Drawing.Point(6, 437);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(219, 20);
			this.label17.TabIndex = 66;
			this.label17.Text = "Sleep timeout (min):";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.Control;
			this.label13.Location = new System.Drawing.Point(6, 409);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(219, 20);
			this.label13.TabIndex = 66;
			this.label13.Text = "Display timeout (min):";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// displayTimeoutBoost
			// 
			this.displayTimeoutBoost.Location = new System.Drawing.Point(231, 409);
			this.displayTimeoutBoost.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.displayTimeoutBoost.Name = "displayTimeoutBoost";
			this.displayTimeoutBoost.Size = new System.Drawing.Size(48, 20);
			this.displayTimeoutBoost.TabIndex = 67;
			this.displayTimeoutBoost.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.displayTimeoutBoost.ValueChanged += new System.EventHandler(this.displayTimeoutBoost_ValueChanged);
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.SystemColors.Control;
			this.label15.Location = new System.Drawing.Point(6, 357);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(219, 21);
			this.label15.TabIndex = 63;
			this.label15.Text = "Performance PowerPlan:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(978, 696);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonPerfToBalanced);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonBalancedToPerf);
			this.Controls.Add(this.buttonApplyBalancedPowerMode);
			this.Controls.Add(this.buttonIdleToBalanced);
			this.Controls.Add(this.buttonBalancedToIdle);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.buttonQuit);
			this.Controls.Add(this.buttonRefreshPowerModes);
			this.Controls.Add(this.buttonAuto);
			this.Controls.Add(this.pictureBoxStatus);
			this.Controls.Add(this.labelStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPowerPlanManager";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutIdle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutIdle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutBalanced)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutBalanced)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeoutBoost)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeoutBoost)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		System.Windows.Forms.Label label4;
		System.Windows.Forms.CheckBox toggleAutoStart;
		System.Windows.Forms.Label label6;
		System.Windows.Forms.Label label8;
		System.Windows.Forms.Label label9;
		System.Windows.Forms.NumericUpDown inputTimeout;
		System.Windows.Forms.CheckBox toggleIdleOnTimeout;
		System.Windows.Forms.CheckBox toggleIdleOnScreensaver;
		System.Windows.Forms.Label label5;
		System.Windows.Forms.NumericUpDown pollingInterval;
		System.Windows.Forms.Button buttonQuit;
		System.Windows.Forms.Button buttonRefreshPowerModes;
		System.Windows.Forms.Label labelStatus;
		System.Windows.Forms.PictureBox pictureBoxStatus;
		System.Windows.Forms.ListBox listBoxBalanced;
		System.Windows.Forms.ListBox listBoxPerformance;
		System.Windows.Forms.ListBox listBoxIdle;
		System.Windows.Forms.Button buttonIdleToBalanced;
		System.Windows.Forms.Button buttonBalancedToIdle;
		System.Windows.Forms.Button buttonBalancedToPerf;
		System.Windows.Forms.Button buttonPerfToBalanced;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown displayTimeoutIdle;
		private System.Windows.Forms.NumericUpDown sleepTimeoutIdle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbPowerPlanPerformance;
		private System.Windows.Forms.ComboBox cmbPowerPlanBalanced;
		private System.Windows.Forms.ComboBox cmbPowerPlanIdle;
		private System.Windows.Forms.Button buttonAuto;
		private System.Windows.Forms.Button buttonPowerSaver;
		private System.Windows.Forms.Button buttonBalanced;
		private System.Windows.Forms.Button buttonPerformance;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonApplyBalancedPowerMode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown displayTimeoutBalanced;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown displayTimeoutBoost;
		private System.Windows.Forms.NumericUpDown sleepTimeoutBalanced;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.NumericUpDown sleepTimeoutBoost;
		private System.Windows.Forms.Label label17;
	}
}

