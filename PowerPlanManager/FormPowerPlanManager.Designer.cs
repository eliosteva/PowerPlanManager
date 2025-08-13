
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
			this.toggleManualHibernate = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.hibernateTimeout = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.sleepTimeout = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.displayTimeout = new System.Windows.Forms.NumericUpDown();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.buttonApplyBalancedPowerMode = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hibernateTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.Location = new System.Drawing.Point(6, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(219, 21);
			this.label4.TabIndex = 6;
			this.label4.Text = "Idle from Screensaver:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.Location = new System.Drawing.Point(231, 97);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(21, 21);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = false;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.Control;
			this.label6.Location = new System.Drawing.Point(6, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(219, 21);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.Control;
			this.label8.Location = new System.Drawing.Point(6, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(219, 21);
			this.label8.TabIndex = 18;
			this.label8.Text = "Idle from user input:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.Control;
			this.label9.Location = new System.Drawing.Point(6, 232);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(219, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Location = new System.Drawing.Point(231, 232);
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
			this.toggleIdleOnTimeout.Location = new System.Drawing.Point(231, 124);
			this.toggleIdleOnTimeout.Name = "toggleIdleOnTimeout";
			this.toggleIdleOnTimeout.Size = new System.Drawing.Size(21, 21);
			this.toggleIdleOnTimeout.TabIndex = 23;
			this.toggleIdleOnTimeout.UseVisualStyleBackColor = true;
			this.toggleIdleOnTimeout.CheckedChanged += new System.EventHandler(this.toggleIdleOnTimeout_CheckedChanged);
			// 
			// toggleIdleOnScreensaver
			// 
			this.toggleIdleOnScreensaver.Location = new System.Drawing.Point(231, 151);
			this.toggleIdleOnScreensaver.Name = "toggleIdleOnScreensaver";
			this.toggleIdleOnScreensaver.Size = new System.Drawing.Size(21, 21);
			this.toggleIdleOnScreensaver.TabIndex = 24;
			this.toggleIdleOnScreensaver.UseVisualStyleBackColor = true;
			this.toggleIdleOnScreensaver.CheckedChanged += new System.EventHandler(this.toggleIdleOnScreensaver_CheckedChanged);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.Location = new System.Drawing.Point(6, 205);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(219, 21);
			this.label5.TabIndex = 28;
			this.label5.Text = "Polling interval (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pollingInterval
			// 
			this.pollingInterval.Location = new System.Drawing.Point(231, 205);
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
			this.buttonRefreshPowerModes.Location = new System.Drawing.Point(659, 38);
			this.buttonRefreshPowerModes.Name = "buttonRefreshPowerModes";
			this.buttonRefreshPowerModes.Size = new System.Drawing.Size(94, 20);
			this.buttonRefreshPowerModes.TabIndex = 43;
			this.buttonRefreshPowerModes.Text = "Refresh";
			this.buttonRefreshPowerModes.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerModes.Click += new System.EventHandler(this.buttonRefreshPowerModes_Click);
			// 
			// buttonQuit
			// 
			this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonQuit.Location = new System.Drawing.Point(659, 12);
			this.buttonQuit.Name = "buttonQuit";
			this.buttonQuit.Size = new System.Drawing.Size(94, 20);
			this.buttonQuit.TabIndex = 37;
			this.buttonQuit.Text = "Quit";
			this.buttonQuit.UseVisualStyleBackColor = true;
			this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
			// 
			// toggleManualHibernate
			// 
			this.toggleManualHibernate.Location = new System.Drawing.Point(231, 178);
			this.toggleManualHibernate.Name = "toggleManualHibernate";
			this.toggleManualHibernate.Size = new System.Drawing.Size(21, 21);
			this.toggleManualHibernate.TabIndex = 37;
			this.toggleManualHibernate.UseVisualStyleBackColor = true;
			this.toggleManualHibernate.CheckedChanged += new System.EventHandler(this.toggleManualHibernate_CheckedChanged);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.Control;
			this.label7.Location = new System.Drawing.Point(6, 178);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(219, 21);
			this.label7.TabIndex = 36;
			this.label7.Text = "Force Hibernation:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// hibernateTimeout
			// 
			this.hibernateTimeout.Location = new System.Drawing.Point(231, 310);
			this.hibernateTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.hibernateTimeout.Name = "hibernateTimeout";
			this.hibernateTimeout.Size = new System.Drawing.Size(76, 20);
			this.hibernateTimeout.TabIndex = 35;
			this.hibernateTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.hibernateTimeout.ValueChanged += new System.EventHandler(this.hibernateTimeout_ValueChanged);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(6, 313);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(219, 20);
			this.label3.TabIndex = 34;
			this.label3.Text = "Hibernate timeout (min):";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sleepTimeout
			// 
			this.sleepTimeout.Location = new System.Drawing.Point(231, 284);
			this.sleepTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.sleepTimeout.Name = "sleepTimeout";
			this.sleepTimeout.Size = new System.Drawing.Size(76, 20);
			this.sleepTimeout.TabIndex = 33;
			this.sleepTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.sleepTimeout.ValueChanged += new System.EventHandler(this.sleepTimeout_ValueChanged);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(6, 286);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(219, 20);
			this.label2.TabIndex = 32;
			this.label2.Text = "Sleep timeout (min):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// displayTimeout
			// 
			this.displayTimeout.Location = new System.Drawing.Point(231, 258);
			this.displayTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.displayTimeout.Name = "displayTimeout";
			this.displayTimeout.Size = new System.Drawing.Size(76, 20);
			this.displayTimeout.TabIndex = 31;
			this.displayTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.displayTimeout.ValueChanged += new System.EventHandler(this.displayTimeout_ValueChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(6, 259);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(219, 20);
			this.label1.TabIndex = 30;
			this.label1.Text = "Display timeout (min):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.Location = new System.Drawing.Point(148, 115);
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
			this.pictureBoxStatus.Location = new System.Drawing.Point(122, 115);
			this.pictureBoxStatus.Name = "pictureBoxStatus";
			this.pictureBoxStatus.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStatus.TabIndex = 45;
			this.pictureBoxStatus.TabStop = false;
			// 
			// listBoxBalanced
			// 
			this.listBoxBalanced.FormattingEnabled = true;
			this.listBoxBalanced.Location = new System.Drawing.Point(274, 14);
			this.listBoxBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxBalanced.Name = "listBoxBalanced";
			this.listBoxBalanced.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxBalanced.Size = new System.Drawing.Size(216, 290);
			this.listBoxBalanced.TabIndex = 46;
			// 
			// listBoxPerformance
			// 
			this.listBoxPerformance.FormattingEnabled = true;
			this.listBoxPerformance.Location = new System.Drawing.Point(535, 14);
			this.listBoxPerformance.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxPerformance.Name = "listBoxPerformance";
			this.listBoxPerformance.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxPerformance.Size = new System.Drawing.Size(216, 290);
			this.listBoxPerformance.TabIndex = 46;
			// 
			// listBoxIdle
			// 
			this.listBoxIdle.FormattingEnabled = true;
			this.listBoxIdle.Location = new System.Drawing.Point(11, 14);
			this.listBoxIdle.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxIdle.Name = "listBoxIdle";
			this.listBoxIdle.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxIdle.Size = new System.Drawing.Size(218, 290);
			this.listBoxIdle.TabIndex = 46;
			// 
			// buttonIdleToBalanced
			// 
			this.buttonIdleToBalanced.Location = new System.Drawing.Point(233, 14);
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
			this.buttonBalancedToIdle.Location = new System.Drawing.Point(233, 215);
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
			this.buttonBalancedToPerf.Location = new System.Drawing.Point(494, 14);
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
			this.buttonPerfToBalanced.Location = new System.Drawing.Point(494, 215);
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
			this.cmbPowerPlanPerformance.FormattingEnabled = true;
			this.cmbPowerPlanPerformance.Location = new System.Drawing.Point(231, 70);
			this.cmbPowerPlanPerformance.Name = "cmbPowerPlanPerformance";
			this.cmbPowerPlanPerformance.Size = new System.Drawing.Size(218, 21);
			this.cmbPowerPlanPerformance.TabIndex = 58;
			this.cmbPowerPlanPerformance.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanPerformance_SelectedIndexChanged);
			// 
			// cmbPowerPlanBalanced
			// 
			this.cmbPowerPlanBalanced.FormattingEnabled = true;
			this.cmbPowerPlanBalanced.Location = new System.Drawing.Point(231, 43);
			this.cmbPowerPlanBalanced.Name = "cmbPowerPlanBalanced";
			this.cmbPowerPlanBalanced.Size = new System.Drawing.Size(218, 21);
			this.cmbPowerPlanBalanced.TabIndex = 57;
			this.cmbPowerPlanBalanced.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanBalanced_SelectedIndexChanged);
			// 
			// cmbPowerPlanIdle
			// 
			this.cmbPowerPlanIdle.FormattingEnabled = true;
			this.cmbPowerPlanIdle.Location = new System.Drawing.Point(231, 16);
			this.cmbPowerPlanIdle.Name = "cmbPowerPlanIdle";
			this.cmbPowerPlanIdle.Size = new System.Drawing.Size(218, 21);
			this.cmbPowerPlanIdle.TabIndex = 56;
			this.cmbPowerPlanIdle.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanIdle_SelectedIndexChanged);
			// 
			// buttonAuto
			// 
			this.buttonAuto.BackColor = System.Drawing.SystemColors.Highlight;
			this.buttonAuto.Location = new System.Drawing.Point(12, 12);
			this.buttonAuto.Name = "buttonAuto";
			this.buttonAuto.Size = new System.Drawing.Size(100, 100);
			this.buttonAuto.TabIndex = 53;
			this.buttonAuto.Text = "Auto";
			this.buttonAuto.UseVisualStyleBackColor = false;
			this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
			// 
			// buttonPowerSaver
			// 
			this.buttonPowerSaver.Location = new System.Drawing.Point(118, 12);
			this.buttonPowerSaver.Name = "buttonPowerSaver";
			this.buttonPowerSaver.Size = new System.Drawing.Size(100, 100);
			this.buttonPowerSaver.TabIndex = 54;
			this.buttonPowerSaver.Text = "PowerSaver";
			this.buttonPowerSaver.UseVisualStyleBackColor = true;
			this.buttonPowerSaver.Click += new System.EventHandler(this.buttonPowerSaver_Click);
			// 
			// buttonBalanced
			// 
			this.buttonBalanced.Location = new System.Drawing.Point(224, 12);
			this.buttonBalanced.Name = "buttonBalanced";
			this.buttonBalanced.Size = new System.Drawing.Size(100, 100);
			this.buttonBalanced.TabIndex = 55;
			this.buttonBalanced.Text = "Balanced";
			this.buttonBalanced.UseVisualStyleBackColor = true;
			this.buttonBalanced.Click += new System.EventHandler(this.buttonBalanced_Click);
			// 
			// buttonPerformance
			// 
			this.buttonPerformance.Location = new System.Drawing.Point(330, 12);
			this.buttonPerformance.Name = "buttonPerformance";
			this.buttonPerformance.Size = new System.Drawing.Size(100, 100);
			this.buttonPerformance.TabIndex = 56;
			this.buttonPerformance.Text = "Performance";
			this.buttonPerformance.UseVisualStyleBackColor = true;
			this.buttonPerformance.Click += new System.EventHandler(this.buttonPerformance_Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(12, 115);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 20);
			this.label11.TabIndex = 61;
			this.label11.Text = "Current status:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel1.Controls.Add(this.listBoxIdle);
			this.panel1.Controls.Add(this.listBoxBalanced);
			this.panel1.Controls.Add(this.listBoxPerformance);
			this.panel1.Controls.Add(this.buttonIdleToBalanced);
			this.panel1.Controls.Add(this.buttonBalancedToIdle);
			this.panel1.Controls.Add(this.buttonBalancedToPerf);
			this.panel1.Controls.Add(this.buttonPerfToBalanced);
			this.panel1.Location = new System.Drawing.Point(0, 145);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(765, 321);
			this.panel1.TabIndex = 62;
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.SystemColors.Control;
			this.label10.Location = new System.Drawing.Point(6, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(219, 21);
			this.label10.TabIndex = 63;
			this.label10.Text = "PowerPlan for PowerSaver:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.toggleManualHibernate);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.displayTimeout);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.hibernateTimeout);
			this.groupBox1.Controls.Add(this.pollingInterval);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.inputTimeout);
			this.groupBox1.Controls.Add(this.cmbPowerPlanIdle);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbPowerPlanBalanced);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbPowerPlanPerformance);
			this.groupBox1.Controls.Add(this.sleepTimeout);
			this.groupBox1.Controls.Add(this.toggleAutoStart);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.toggleIdleOnTimeout);
			this.groupBox1.Controls.Add(this.toggleIdleOnScreensaver);
			this.groupBox1.Location = new System.Drawing.Point(12, 476);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(741, 346);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.Control;
			this.label13.Location = new System.Drawing.Point(6, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(219, 21);
			this.label13.TabIndex = 65;
			this.label13.Text = "PowerPlan for Performance:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.SystemColors.Control;
			this.label12.Location = new System.Drawing.Point(6, 43);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(219, 21);
			this.label12.TabIndex = 64;
			this.label12.Text = "PowerPlan for Balanced:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyBalancedPowerMode
			// 
			this.buttonApplyBalancedPowerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApplyBalancedPowerMode.Location = new System.Drawing.Point(630, 115);
			this.buttonApplyBalancedPowerMode.Name = "buttonApplyBalancedPowerMode";
			this.buttonApplyBalancedPowerMode.Size = new System.Drawing.Size(123, 20);
			this.buttonApplyBalancedPowerMode.TabIndex = 65;
			this.buttonApplyBalancedPowerMode.Text = "Reset Power Mode";
			this.buttonApplyBalancedPowerMode.UseVisualStyleBackColor = true;
			this.buttonApplyBalancedPowerMode.Click += new System.EventHandler(this.buttonApplyBalancedPowerMode_Click);
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(765, 834);
			this.Controls.Add(this.buttonApplyBalancedPowerMode);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.buttonQuit);
			this.Controls.Add(this.buttonPerformance);
			this.Controls.Add(this.buttonBalanced);
			this.Controls.Add(this.buttonPowerSaver);
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
			((System.ComponentModel.ISupportInitialize)(this.hibernateTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
		private System.Windows.Forms.NumericUpDown displayTimeout;
		private System.Windows.Forms.NumericUpDown sleepTimeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown hibernateTimeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox toggleManualHibernate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbPowerPlanPerformance;
		private System.Windows.Forms.ComboBox cmbPowerPlanBalanced;
		private System.Windows.Forms.ComboBox cmbPowerPlanIdle;
		private System.Windows.Forms.Button buttonAuto;
		private System.Windows.Forms.Button buttonPowerSaver;
		private System.Windows.Forms.Button buttonBalanced;
		private System.Windows.Forms.Button buttonPerformance;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button buttonApplyBalancedPowerMode;
	}
}

