
namespace PowerPlanManager
{
	partial class FormPowerPlanManager
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPowerPlanManager));
			this.comboBalancedPP = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboIdlePP = new System.Windows.Forms.ComboBox();
			this.labelCurrentPowerPlan = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboPerfPP = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.buttonRefreshPowerPlans = new System.Windows.Forms.Button();
			this.checkBoxUserPowerPlans = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonApplyPerformanceMode = new System.Windows.Forms.Button();
			this.buttonRefreshPowerModes = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.buttonApplyBalancedMode = new System.Windows.Forms.Button();
			this.labelCurrentPowerMode = new System.Windows.Forms.Label();
			this.buttonApplyPowerSaverMode = new System.Windows.Forms.Button();
			this.checkBoxUsePowerModes = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBoxOptions = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
			this.listBoxBalanced = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.listBoxPerformance = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.buttonRefreshPrcesses = new System.Windows.Forms.Button();
			this.listBoxIdle = new System.Windows.Forms.ListBox();
			this.buttonIdleToBalanced = new System.Windows.Forms.Button();
			this.buttonBalancedToIdle = new System.Windows.Forms.Button();
			this.buttonBalancedToPerf = new System.Windows.Forms.Button();
			this.buttonPerfToBalanced = new System.Windows.Forms.Button();
			this.buttonResetForced = new System.Windows.Forms.Button();
			this.buttonForceIdle = new System.Windows.Forms.Button();
			this.buttonForceBalanced = new System.Windows.Forms.Button();
			this.buttonForcePerformance = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBoxOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBalancedPP
			// 
			this.comboBalancedPP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBalancedPP.FormattingEnabled = true;
			this.comboBalancedPP.Location = new System.Drawing.Point(278, 84);
			this.comboBalancedPP.Name = "comboBalancedPP";
			this.comboBalancedPP.Size = new System.Drawing.Size(216, 21);
			this.comboBalancedPP.TabIndex = 0;
			this.comboBalancedPP.SelectedIndexChanged += new System.EventHandler(this.comboBalancedPP_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(275, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(217, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Balanced PowerPlan:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(216, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Idle power plan:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboIdlePP
			// 
			this.comboIdlePP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboIdlePP.FormattingEnabled = true;
			this.comboIdlePP.Location = new System.Drawing.Point(5, 84);
			this.comboIdlePP.Name = "comboIdlePP";
			this.comboIdlePP.Size = new System.Drawing.Size(216, 21);
			this.comboIdlePP.TabIndex = 3;
			this.comboIdlePP.SelectedIndexChanged += new System.EventHandler(this.comboIdlePP_SelectedIndexChanged);
			// 
			// labelCurrentPowerPlan
			// 
			this.labelCurrentPowerPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerPlan.Location = new System.Drawing.Point(226, 37);
			this.labelCurrentPowerPlan.Name = "labelCurrentPowerPlan";
			this.labelCurrentPowerPlan.Size = new System.Drawing.Size(538, 20);
			this.labelCurrentPowerPlan.TabIndex = 4;
			this.labelCurrentPowerPlan.Text = "--";
			this.labelCurrentPowerPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label3.Location = new System.Drawing.Point(6, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(214, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Current PowerPlan:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label4.Location = new System.Drawing.Point(6, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(214, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Set Idle if Screensaver is running:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.BackColor = System.Drawing.SystemColors.ControlLight;
			this.toggleAutoStart.Location = new System.Drawing.Point(226, 17);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(20, 20);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = false;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(214, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label8.Location = new System.Drawing.Point(6, 82);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(214, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "Set Idle if no user input detected:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label9.Location = new System.Drawing.Point(6, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(214, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Location = new System.Drawing.Point(226, 106);
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
			this.inputTimeout.Size = new System.Drawing.Size(82, 20);
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
			this.toggleIdleOnTimeout.Location = new System.Drawing.Point(226, 82);
			this.toggleIdleOnTimeout.Name = "toggleIdleOnTimeout";
			this.toggleIdleOnTimeout.Size = new System.Drawing.Size(20, 20);
			this.toggleIdleOnTimeout.TabIndex = 23;
			this.toggleIdleOnTimeout.UseVisualStyleBackColor = true;
			this.toggleIdleOnTimeout.CheckedChanged += new System.EventHandler(this.toggleIdleOnTimeout_CheckedChanged);
			// 
			// toggleIdleOnScreensaver
			// 
			this.toggleIdleOnScreensaver.Location = new System.Drawing.Point(226, 60);
			this.toggleIdleOnScreensaver.Name = "toggleIdleOnScreensaver";
			this.toggleIdleOnScreensaver.Size = new System.Drawing.Size(20, 20);
			this.toggleIdleOnScreensaver.TabIndex = 24;
			this.toggleIdleOnScreensaver.UseVisualStyleBackColor = true;
			this.toggleIdleOnScreensaver.CheckedChanged += new System.EventHandler(this.toggleIdleOnScreensaver_CheckedChanged);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label5.Location = new System.Drawing.Point(6, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(214, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "Check status every (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pollingInterval
			// 
			this.pollingInterval.Location = new System.Drawing.Point(226, 40);
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
			this.pollingInterval.Size = new System.Drawing.Size(82, 20);
			this.pollingInterval.TabIndex = 29;
			this.pollingInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.pollingInterval.ValueChanged += new System.EventHandler(this.pollingInterval_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox1.Controls.Add(this.comboPerfPP);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.buttonRefreshPowerPlans);
			this.groupBox1.Controls.Add(this.checkBoxUserPowerPlans);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.labelCurrentPowerPlan);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBalancedPP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboIdlePP);
			this.groupBox1.Location = new System.Drawing.Point(10, 282);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(770, 111);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PowerPlan (Legacy Win7 Power management)";
			// 
			// comboPerfPP
			// 
			this.comboPerfPP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboPerfPP.FormattingEnabled = true;
			this.comboPerfPP.Location = new System.Drawing.Point(550, 84);
			this.comboPerfPP.Name = "comboPerfPP";
			this.comboPerfPP.Size = new System.Drawing.Size(216, 21);
			this.comboPerfPP.TabIndex = 44;
			this.comboPerfPP.SelectedIndexChanged += new System.EventHandler(this.comboPerfPP_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(548, 61);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(215, 20);
			this.label16.TabIndex = 43;
			this.label16.Text = "Performance PowerPlan:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonRefreshPowerPlans
			// 
			this.buttonRefreshPowerPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerPlans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRefreshPowerPlans.Location = new System.Drawing.Point(695, 0);
			this.buttonRefreshPowerPlans.Name = "buttonRefreshPowerPlans";
			this.buttonRefreshPowerPlans.Size = new System.Drawing.Size(75, 26);
			this.buttonRefreshPowerPlans.TabIndex = 42;
			this.buttonRefreshPowerPlans.Text = "Reset";
			this.buttonRefreshPowerPlans.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerPlans.Click += new System.EventHandler(this.buttonRefreshPowerPlans_Click);
			// 
			// checkBoxUserPowerPlans
			// 
			this.checkBoxUserPowerPlans.Location = new System.Drawing.Point(226, 16);
			this.checkBoxUserPowerPlans.Name = "checkBoxUserPowerPlans";
			this.checkBoxUserPowerPlans.Size = new System.Drawing.Size(20, 20);
			this.checkBoxUserPowerPlans.TabIndex = 32;
			this.checkBoxUserPowerPlans.UseVisualStyleBackColor = true;
			this.checkBoxUserPowerPlans.CheckedChanged += new System.EventHandler(this.checkBoxUserPowerPlans_CheckedChanged);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label7.Location = new System.Drawing.Point(6, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(214, 20);
			this.label7.TabIndex = 31;
			this.label7.Text = "Use PowerPlans:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox2.Controls.Add(this.buttonApplyPerformanceMode);
			this.groupBox2.Controls.Add(this.buttonRefreshPowerModes);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.buttonApplyBalancedMode);
			this.groupBox2.Controls.Add(this.labelCurrentPowerMode);
			this.groupBox2.Controls.Add(this.buttonApplyPowerSaverMode);
			this.groupBox2.Controls.Add(this.checkBoxUsePowerModes);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Location = new System.Drawing.Point(10, 399);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(770, 101);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "PowerMode (New Win10/11 power management)";
			// 
			// buttonApplyPerformanceMode
			// 
			this.buttonApplyPerformanceMode.Location = new System.Drawing.Point(550, 70);
			this.buttonApplyPerformanceMode.Name = "buttonApplyPerformanceMode";
			this.buttonApplyPerformanceMode.Size = new System.Drawing.Size(213, 20);
			this.buttonApplyPerformanceMode.TabIndex = 44;
			this.buttonApplyPerformanceMode.Text = "Apply Performance";
			this.buttonApplyPerformanceMode.UseVisualStyleBackColor = true;
			this.buttonApplyPerformanceMode.Click += new System.EventHandler(this.buttonApplyPerformanceMode_Click);
			// 
			// buttonRefreshPowerModes
			// 
			this.buttonRefreshPowerModes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerModes.Location = new System.Drawing.Point(695, 0);
			this.buttonRefreshPowerModes.Name = "buttonRefreshPowerModes";
			this.buttonRefreshPowerModes.Size = new System.Drawing.Size(75, 26);
			this.buttonRefreshPowerModes.TabIndex = 43;
			this.buttonRefreshPowerModes.Text = "Reset";
			this.buttonRefreshPowerModes.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerModes.Click += new System.EventHandler(this.buttonRefreshPowerModes_Click);
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label12.Location = new System.Drawing.Point(6, 37);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(214, 20);
			this.label12.TabIndex = 34;
			this.label12.Text = "Current PowerMode:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyBalancedMode
			// 
			this.buttonApplyBalancedMode.Location = new System.Drawing.Point(278, 70);
			this.buttonApplyBalancedMode.Name = "buttonApplyBalancedMode";
			this.buttonApplyBalancedMode.Size = new System.Drawing.Size(214, 20);
			this.buttonApplyBalancedMode.TabIndex = 36;
			this.buttonApplyBalancedMode.Text = "Apply Balanced";
			this.buttonApplyBalancedMode.UseVisualStyleBackColor = true;
			this.buttonApplyBalancedMode.Click += new System.EventHandler(this.button2_Click);
			// 
			// labelCurrentPowerMode
			// 
			this.labelCurrentPowerMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerMode.Location = new System.Drawing.Point(224, 37);
			this.labelCurrentPowerMode.Name = "labelCurrentPowerMode";
			this.labelCurrentPowerMode.Size = new System.Drawing.Size(539, 20);
			this.labelCurrentPowerMode.TabIndex = 33;
			this.labelCurrentPowerMode.Text = "--";
			this.labelCurrentPowerMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyPowerSaverMode
			// 
			this.buttonApplyPowerSaverMode.Location = new System.Drawing.Point(7, 67);
			this.buttonApplyPowerSaverMode.Name = "buttonApplyPowerSaverMode";
			this.buttonApplyPowerSaverMode.Size = new System.Drawing.Size(213, 20);
			this.buttonApplyPowerSaverMode.TabIndex = 35;
			this.buttonApplyPowerSaverMode.Text = "Apply PowerSaver";
			this.buttonApplyPowerSaverMode.UseVisualStyleBackColor = true;
			this.buttonApplyPowerSaverMode.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBoxUsePowerModes
			// 
			this.checkBoxUsePowerModes.Location = new System.Drawing.Point(226, 16);
			this.checkBoxUsePowerModes.Name = "checkBoxUsePowerModes";
			this.checkBoxUsePowerModes.Size = new System.Drawing.Size(20, 20);
			this.checkBoxUsePowerModes.TabIndex = 34;
			this.checkBoxUsePowerModes.UseVisualStyleBackColor = true;
			this.checkBoxUsePowerModes.CheckedChanged += new System.EventHandler(this.checkBoxUsePowerModes_CheckedChanged);
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label11.Location = new System.Drawing.Point(6, 15);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(214, 20);
			this.label11.TabIndex = 33;
			this.label11.Text = "Use PowerModes:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(683, 653);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(94, 20);
			this.button3.TabIndex = 37;
			this.button3.Text = "Quit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBoxOptions
			// 
			this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxOptions.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBoxOptions.Controls.Add(this.label6);
			this.groupBoxOptions.Controls.Add(this.toggleAutoStart);
			this.groupBoxOptions.Controls.Add(this.inputTimeout);
			this.groupBoxOptions.Controls.Add(this.label5);
			this.groupBoxOptions.Controls.Add(this.label9);
			this.groupBoxOptions.Controls.Add(this.pollingInterval);
			this.groupBoxOptions.Controls.Add(this.toggleIdleOnTimeout);
			this.groupBoxOptions.Controls.Add(this.label4);
			this.groupBoxOptions.Controls.Add(this.toggleIdleOnScreensaver);
			this.groupBoxOptions.Controls.Add(this.label8);
			this.groupBoxOptions.Location = new System.Drawing.Point(10, 507);
			this.groupBoxOptions.Name = "groupBoxOptions";
			this.groupBoxOptions.Size = new System.Drawing.Size(770, 136);
			this.groupBoxOptions.TabIndex = 43;
			this.groupBoxOptions.TabStop = false;
			this.groupBoxOptions.Text = "Options";
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label13.Location = new System.Drawing.Point(10, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(220, 20);
			this.label13.TabIndex = 30;
			this.label13.Text = "Current status:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.Location = new System.Drawing.Point(262, 40);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(488, 20);
			this.labelStatus.TabIndex = 44;
			this.labelStatus.Text = "IDLE";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxStatus
			// 
			this.pictureBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
			this.pictureBoxStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.InitialImage")));
			this.pictureBoxStatus.Location = new System.Drawing.Point(236, 40);
			this.pictureBoxStatus.Name = "pictureBoxStatus";
			this.pictureBoxStatus.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStatus.TabIndex = 45;
			this.pictureBoxStatus.TabStop = false;
			// 
			// listBoxBalanced
			// 
			this.listBoxBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxBalanced.FormattingEnabled = true;
			this.listBoxBalanced.Location = new System.Drawing.Point(5, 32);
			this.listBoxBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxBalanced.Name = "listBoxBalanced";
			this.listBoxBalanced.Size = new System.Drawing.Size(216, 173);
			this.listBoxBalanced.TabIndex = 46;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox3.Controls.Add(this.listBoxBalanced);
			this.groupBox3.Location = new System.Drawing.Point(282, 65);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(225, 210);
			this.groupBox3.TabIndex = 44;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Balanced";
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox4.Controls.Add(this.listBoxPerformance);
			this.groupBox4.Location = new System.Drawing.Point(554, 65);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(225, 210);
			this.groupBox4.TabIndex = 47;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Performance";
			// 
			// listBoxPerformance
			// 
			this.listBoxPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxPerformance.FormattingEnabled = true;
			this.listBoxPerformance.Location = new System.Drawing.Point(5, 32);
			this.listBoxPerformance.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxPerformance.Name = "listBoxPerformance";
			this.listBoxPerformance.Size = new System.Drawing.Size(216, 173);
			this.listBoxPerformance.TabIndex = 46;
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox5.Controls.Add(this.buttonRefreshPrcesses);
			this.groupBox5.Controls.Add(this.listBoxIdle);
			this.groupBox5.Location = new System.Drawing.Point(10, 65);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(225, 210);
			this.groupBox5.TabIndex = 47;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Idle";
			// 
			// buttonRefreshPrcesses
			// 
			this.buttonRefreshPrcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPrcesses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRefreshPrcesses.Location = new System.Drawing.Point(150, 0);
			this.buttonRefreshPrcesses.Name = "buttonRefreshPrcesses";
			this.buttonRefreshPrcesses.Size = new System.Drawing.Size(75, 26);
			this.buttonRefreshPrcesses.TabIndex = 45;
			this.buttonRefreshPrcesses.Text = "Reset";
			this.buttonRefreshPrcesses.UseVisualStyleBackColor = true;
			this.buttonRefreshPrcesses.Click += new System.EventHandler(this.buttonRefreshPrcesses_Click);
			// 
			// listBoxIdle
			// 
			this.listBoxIdle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxIdle.FormattingEnabled = true;
			this.listBoxIdle.Location = new System.Drawing.Point(5, 32);
			this.listBoxIdle.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxIdle.Name = "listBoxIdle";
			this.listBoxIdle.Size = new System.Drawing.Size(216, 173);
			this.listBoxIdle.TabIndex = 46;
			// 
			// buttonIdleToBalanced
			// 
			this.buttonIdleToBalanced.Location = new System.Drawing.Point(240, 126);
			this.buttonIdleToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonIdleToBalanced.Name = "buttonIdleToBalanced";
			this.buttonIdleToBalanced.Size = new System.Drawing.Size(37, 72);
			this.buttonIdleToBalanced.TabIndex = 48;
			this.buttonIdleToBalanced.Text = ">";
			this.buttonIdleToBalanced.UseVisualStyleBackColor = true;
			this.buttonIdleToBalanced.Click += new System.EventHandler(this.buttonIdleToBalanced_Click);
			// 
			// buttonBalancedToIdle
			// 
			this.buttonBalancedToIdle.Location = new System.Drawing.Point(240, 203);
			this.buttonBalancedToIdle.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToIdle.Name = "buttonBalancedToIdle";
			this.buttonBalancedToIdle.Size = new System.Drawing.Size(37, 72);
			this.buttonBalancedToIdle.TabIndex = 49;
			this.buttonBalancedToIdle.Text = "<";
			this.buttonBalancedToIdle.UseVisualStyleBackColor = true;
			this.buttonBalancedToIdle.Click += new System.EventHandler(this.buttonBalancedToIdle_Click);
			// 
			// buttonBalancedToPerf
			// 
			this.buttonBalancedToPerf.Location = new System.Drawing.Point(512, 126);
			this.buttonBalancedToPerf.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToPerf.Name = "buttonBalancedToPerf";
			this.buttonBalancedToPerf.Size = new System.Drawing.Size(37, 72);
			this.buttonBalancedToPerf.TabIndex = 50;
			this.buttonBalancedToPerf.Text = ">";
			this.buttonBalancedToPerf.UseVisualStyleBackColor = true;
			this.buttonBalancedToPerf.Click += new System.EventHandler(this.buttonBalancedToPerf_Click);
			// 
			// buttonPerfToBalanced
			// 
			this.buttonPerfToBalanced.Location = new System.Drawing.Point(512, 203);
			this.buttonPerfToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonPerfToBalanced.Name = "buttonPerfToBalanced";
			this.buttonPerfToBalanced.Size = new System.Drawing.Size(37, 72);
			this.buttonPerfToBalanced.TabIndex = 51;
			this.buttonPerfToBalanced.Text = "<";
			this.buttonPerfToBalanced.UseVisualStyleBackColor = true;
			this.buttonPerfToBalanced.Click += new System.EventHandler(this.buttonPerfToBalanced_Click);
			// 
			// buttonResetForced
			// 
			this.buttonResetForced.Location = new System.Drawing.Point(10, 12);
			this.buttonResetForced.Name = "buttonResetForced";
			this.buttonResetForced.Size = new System.Drawing.Size(94, 20);
			this.buttonResetForced.TabIndex = 52;
			this.buttonResetForced.Text = "Reset";
			this.buttonResetForced.UseVisualStyleBackColor = true;
			this.buttonResetForced.Click += new System.EventHandler(this.buttonResetForced_Click);
			// 
			// buttonForceIdle
			// 
			this.buttonForceIdle.Location = new System.Drawing.Point(110, 12);
			this.buttonForceIdle.Name = "buttonForceIdle";
			this.buttonForceIdle.Size = new System.Drawing.Size(147, 20);
			this.buttonForceIdle.TabIndex = 53;
			this.buttonForceIdle.Text = "Force Idle";
			this.buttonForceIdle.UseVisualStyleBackColor = true;
			this.buttonForceIdle.Click += new System.EventHandler(this.buttonForceIdle_Click);
			// 
			// buttonForceBalanced
			// 
			this.buttonForceBalanced.Location = new System.Drawing.Point(263, 12);
			this.buttonForceBalanced.Name = "buttonForceBalanced";
			this.buttonForceBalanced.Size = new System.Drawing.Size(147, 20);
			this.buttonForceBalanced.TabIndex = 54;
			this.buttonForceBalanced.Text = "Force Balanced";
			this.buttonForceBalanced.UseVisualStyleBackColor = true;
			this.buttonForceBalanced.Click += new System.EventHandler(this.buttonForceBalanced_Click);
			// 
			// buttonForcePerformance
			// 
			this.buttonForcePerformance.Location = new System.Drawing.Point(416, 12);
			this.buttonForcePerformance.Name = "buttonForcePerformance";
			this.buttonForcePerformance.Size = new System.Drawing.Size(147, 20);
			this.buttonForcePerformance.TabIndex = 55;
			this.buttonForcePerformance.Text = "Force Performance";
			this.buttonForcePerformance.UseVisualStyleBackColor = true;
			this.buttonForcePerformance.Click += new System.EventHandler(this.buttonForcePerformance_Click);
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 684);
			this.Controls.Add(this.buttonForcePerformance);
			this.Controls.Add(this.buttonForceBalanced);
			this.Controls.Add(this.buttonForceIdle);
			this.Controls.Add(this.buttonResetForced);
			this.Controls.Add(this.buttonPerfToBalanced);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonBalancedToPerf);
			this.Controls.Add(this.buttonBalancedToIdle);
			this.Controls.Add(this.buttonIdleToBalanced);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.pictureBoxStatus);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.groupBoxOptions);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPowerPlanManager";
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBoxOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBalancedPP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboIdlePP;
		private System.Windows.Forms.Label labelCurrentPowerPlan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox toggleAutoStart;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown inputTimeout;
		private System.Windows.Forms.CheckBox toggleIdleOnTimeout;
		private System.Windows.Forms.CheckBox toggleIdleOnScreensaver;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown pollingInterval;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBoxUserPowerPlans;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBoxUsePowerModes;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button buttonApplyPowerSaverMode;
		private System.Windows.Forms.Button buttonApplyBalancedMode;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label labelCurrentPowerMode;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button buttonRefreshPowerPlans;
		private System.Windows.Forms.Button buttonRefreshPowerModes;
		private System.Windows.Forms.Button buttonApplyPerformanceMode;
		private System.Windows.Forms.GroupBox groupBoxOptions;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.PictureBox pictureBoxStatus;
		private System.Windows.Forms.ListBox listBoxBalanced;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ListBox listBoxPerformance;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ListBox listBoxIdle;
		private System.Windows.Forms.Button buttonIdleToBalanced;
		private System.Windows.Forms.Button buttonBalancedToIdle;
		private System.Windows.Forms.Button buttonBalancedToPerf;
		private System.Windows.Forms.Button buttonPerfToBalanced;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox comboPerfPP;
		private System.Windows.Forms.Button buttonRefreshPrcesses;
		private System.Windows.Forms.Button buttonResetForced;
		private System.Windows.Forms.Button buttonForceIdle;
		private System.Windows.Forms.Button buttonForceBalanced;
		private System.Windows.Forms.Button buttonForcePerformance;
	}
}

