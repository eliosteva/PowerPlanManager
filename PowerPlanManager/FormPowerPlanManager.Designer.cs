
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
			this.comboInUsePP = new System.Windows.Forms.ComboBox();
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
			this.label10 = new System.Windows.Forms.Label();
			this.inputTimeout = new System.Windows.Forms.NumericUpDown();
			this.toggleIdleOnTimeout = new System.Windows.Forms.CheckBox();
			this.toggleIdleOnScreensaver = new System.Windows.Forms.CheckBox();
			this.toggleDisableWithProcesses = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pollingInterval = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBoxUserPowerPlans = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.buttonApplyBalancedMode = new System.Windows.Forms.Button();
			this.labelCurrentPowerMode = new System.Windows.Forms.Label();
			this.buttonApplyPowerSaverMode = new System.Windows.Forms.Button();
			this.checkBoxUsePowerModes = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.listBoxRunningProcesses = new System.Windows.Forms.ListBox();
			this.textBoxSearchRunningProcesses = new System.Windows.Forms.TextBox();
			this.listBoxDisableProcesses = new System.Windows.Forms.ListBox();
			this.buttonRefreshPowerPlans = new System.Windows.Forms.Button();
			this.buttonRefreshPowerModes = new System.Windows.Forms.Button();
			this.buttonApplyPerformanceMode = new System.Windows.Forms.Button();
			this.groupBoxProcesses = new System.Windows.Forms.GroupBox();
			this.groupBoxOptions = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBoxProcesses.SuspendLayout();
			this.groupBoxOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// comboInUsePP
			// 
			this.comboInUsePP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboInUsePP.FormattingEnabled = true;
			this.comboInUsePP.Location = new System.Drawing.Point(138, 91);
			this.comboInUsePP.Name = "comboInUsePP";
			this.comboInUsePP.Size = new System.Drawing.Size(513, 21);
			this.comboInUsePP.TabIndex = 0;
			this.comboInUsePP.SelectedIndexChanged += new System.EventHandler(this.comboInUsePP_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "In use power plan:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Idle power plan:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboIdlePP
			// 
			this.comboIdlePP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboIdlePP.FormattingEnabled = true;
			this.comboIdlePP.Location = new System.Drawing.Point(138, 116);
			this.comboIdlePP.Name = "comboIdlePP";
			this.comboIdlePP.Size = new System.Drawing.Size(513, 21);
			this.comboIdlePP.TabIndex = 3;
			this.comboIdlePP.SelectedIndexChanged += new System.EventHandler(this.comboIdlePP_SelectedIndexChanged);
			// 
			// labelCurrentPowerPlan
			// 
			this.labelCurrentPowerPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerPlan.Location = new System.Drawing.Point(138, 68);
			this.labelCurrentPowerPlan.Name = "labelCurrentPowerPlan";
			this.labelCurrentPowerPlan.Size = new System.Drawing.Size(513, 20);
			this.labelCurrentPowerPlan.TabIndex = 4;
			this.labelCurrentPowerPlan.Text = "--";
			this.labelCurrentPowerPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Current power plan:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(288, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Set Idle if Screensaver is running:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.Location = new System.Drawing.Point(300, 21);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(20, 20);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = true;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(288, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(288, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "Set Idle if no user input detected:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 123);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(288, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(172, 46);
			this.label10.TabIndex = 21;
			this.label10.Text = "Disable when these processes are running:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Location = new System.Drawing.Point(300, 125);
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
			this.toggleIdleOnTimeout.Location = new System.Drawing.Point(300, 99);
			this.toggleIdleOnTimeout.Name = "toggleIdleOnTimeout";
			this.toggleIdleOnTimeout.Size = new System.Drawing.Size(20, 20);
			this.toggleIdleOnTimeout.TabIndex = 23;
			this.toggleIdleOnTimeout.UseVisualStyleBackColor = true;
			this.toggleIdleOnTimeout.CheckedChanged += new System.EventHandler(this.toggleIdleOnTimeout_CheckedChanged);
			// 
			// toggleIdleOnScreensaver
			// 
			this.toggleIdleOnScreensaver.Location = new System.Drawing.Point(300, 73);
			this.toggleIdleOnScreensaver.Name = "toggleIdleOnScreensaver";
			this.toggleIdleOnScreensaver.Size = new System.Drawing.Size(20, 20);
			this.toggleIdleOnScreensaver.TabIndex = 24;
			this.toggleIdleOnScreensaver.UseVisualStyleBackColor = true;
			this.toggleIdleOnScreensaver.CheckedChanged += new System.EventHandler(this.toggleIdleOnScreensaver_CheckedChanged);
			// 
			// toggleDisableWithProcesses
			// 
			this.toggleDisableWithProcesses.Location = new System.Drawing.Point(184, 19);
			this.toggleDisableWithProcesses.Name = "toggleDisableWithProcesses";
			this.toggleDisableWithProcesses.Size = new System.Drawing.Size(20, 20);
			this.toggleDisableWithProcesses.TabIndex = 25;
			this.toggleDisableWithProcesses.UseVisualStyleBackColor = true;
			this.toggleDisableWithProcesses.CheckedChanged += new System.EventHandler(this.toggleDisableWithProcesses_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(288, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "Check status every (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pollingInterval
			// 
			this.pollingInterval.Location = new System.Drawing.Point(300, 47);
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
			this.groupBox1.Controls.Add(this.buttonRefreshPowerPlans);
			this.groupBox1.Controls.Add(this.checkBoxUserPowerPlans);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.labelCurrentPowerPlan);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboInUsePP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboIdlePP);
			this.groupBox1.Location = new System.Drawing.Point(12, 197);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(657, 149);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PowerPlan (Legacy Win7 Power management)";
			// 
			// checkBoxUserPowerPlans
			// 
			this.checkBoxUserPowerPlans.Location = new System.Drawing.Point(138, 45);
			this.checkBoxUserPowerPlans.Name = "checkBoxUserPowerPlans";
			this.checkBoxUserPowerPlans.Size = new System.Drawing.Size(20, 20);
			this.checkBoxUserPowerPlans.TabIndex = 32;
			this.checkBoxUserPowerPlans.UseVisualStyleBackColor = true;
			this.checkBoxUserPowerPlans.CheckedChanged += new System.EventHandler(this.checkBoxUserPowerPlans_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(129, 20);
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
			this.groupBox2.Location = new System.Drawing.Point(12, 352);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(657, 117);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "PowerMode (New Win10/11 power management)";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(7, 65);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(129, 20);
			this.label12.TabIndex = 34;
			this.label12.Text = "Current PowerMode:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyBalancedMode
			// 
			this.buttonApplyBalancedMode.Location = new System.Drawing.Point(181, 88);
			this.buttonApplyBalancedMode.Name = "buttonApplyBalancedMode";
			this.buttonApplyBalancedMode.Size = new System.Drawing.Size(169, 20);
			this.buttonApplyBalancedMode.TabIndex = 36;
			this.buttonApplyBalancedMode.Text = "Apply Balanced";
			this.buttonApplyBalancedMode.UseVisualStyleBackColor = true;
			this.buttonApplyBalancedMode.Click += new System.EventHandler(this.button2_Click);
			// 
			// labelCurrentPowerMode
			// 
			this.labelCurrentPowerMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerMode.Location = new System.Drawing.Point(141, 65);
			this.labelCurrentPowerMode.Name = "labelCurrentPowerMode";
			this.labelCurrentPowerMode.Size = new System.Drawing.Size(510, 20);
			this.labelCurrentPowerMode.TabIndex = 33;
			this.labelCurrentPowerMode.Text = "--";
			this.labelCurrentPowerMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyPowerSaverMode
			// 
			this.buttonApplyPowerSaverMode.Location = new System.Drawing.Point(7, 88);
			this.buttonApplyPowerSaverMode.Name = "buttonApplyPowerSaverMode";
			this.buttonApplyPowerSaverMode.Size = new System.Drawing.Size(168, 20);
			this.buttonApplyPowerSaverMode.TabIndex = 35;
			this.buttonApplyPowerSaverMode.Text = "Apply PowerSaver";
			this.buttonApplyPowerSaverMode.UseVisualStyleBackColor = true;
			this.buttonApplyPowerSaverMode.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBoxUsePowerModes
			// 
			this.checkBoxUsePowerModes.Location = new System.Drawing.Point(140, 45);
			this.checkBoxUsePowerModes.Name = "checkBoxUsePowerModes";
			this.checkBoxUsePowerModes.Size = new System.Drawing.Size(20, 20);
			this.checkBoxUsePowerModes.TabIndex = 34;
			this.checkBoxUsePowerModes.UseVisualStyleBackColor = true;
			this.checkBoxUsePowerModes.CheckedChanged += new System.EventHandler(this.checkBoxUsePowerModes_CheckedChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 45);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(129, 20);
			this.label11.TabIndex = 33;
			this.label11.Text = "Use PowerModes:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(576, 719);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(94, 20);
			this.button3.TabIndex = 37;
			this.button3.Text = "Quit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBoxRunningProcesses
			// 
			this.listBoxRunningProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxRunningProcesses.FormattingEnabled = true;
			this.listBoxRunningProcesses.Location = new System.Drawing.Point(210, 68);
			this.listBoxRunningProcesses.Name = "listBoxRunningProcesses";
			this.listBoxRunningProcesses.Size = new System.Drawing.Size(441, 160);
			this.listBoxRunningProcesses.TabIndex = 39;
			this.listBoxRunningProcesses.DoubleClick += new System.EventHandler(this.listBoxRunningProcesses_DoubleClick);
			// 
			// textBoxSearchRunningProcesses
			// 
			this.textBoxSearchRunningProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearchRunningProcesses.Location = new System.Drawing.Point(270, 42);
			this.textBoxSearchRunningProcesses.Name = "textBoxSearchRunningProcesses";
			this.textBoxSearchRunningProcesses.Size = new System.Drawing.Size(381, 20);
			this.textBoxSearchRunningProcesses.TabIndex = 40;
			this.textBoxSearchRunningProcesses.TextChanged += new System.EventHandler(this.textBoxSearchRunningProcesses_TextChanged);
			// 
			// listBoxDisableProcesses
			// 
			this.listBoxDisableProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxDisableProcesses.FormattingEnabled = true;
			this.listBoxDisableProcesses.Location = new System.Drawing.Point(10, 65);
			this.listBoxDisableProcesses.Name = "listBoxDisableProcesses";
			this.listBoxDisableProcesses.Size = new System.Drawing.Size(194, 160);
			this.listBoxDisableProcesses.TabIndex = 41;
			this.listBoxDisableProcesses.DoubleClick += new System.EventHandler(this.listBoxDisableProcesses_DoubleClick);
			// 
			// buttonRefreshPowerPlans
			// 
			this.buttonRefreshPowerPlans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerPlans.Location = new System.Drawing.Point(7, 19);
			this.buttonRefreshPowerPlans.Name = "buttonRefreshPowerPlans";
			this.buttonRefreshPowerPlans.Size = new System.Drawing.Size(644, 23);
			this.buttonRefreshPowerPlans.TabIndex = 42;
			this.buttonRefreshPowerPlans.Text = "Refresh PowerPlans";
			this.buttonRefreshPowerPlans.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerPlans.Click += new System.EventHandler(this.buttonRefreshPowerPlans_Click);
			// 
			// buttonRefreshPowerModes
			// 
			this.buttonRefreshPowerModes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerModes.Location = new System.Drawing.Point(6, 19);
			this.buttonRefreshPowerModes.Name = "buttonRefreshPowerModes";
			this.buttonRefreshPowerModes.Size = new System.Drawing.Size(645, 23);
			this.buttonRefreshPowerModes.TabIndex = 43;
			this.buttonRefreshPowerModes.Text = "Refresh PowerModes";
			this.buttonRefreshPowerModes.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerModes.Click += new System.EventHandler(this.buttonRefreshPowerModes_Click);
			// 
			// buttonApplyPerformanceMode
			// 
			this.buttonApplyPerformanceMode.Location = new System.Drawing.Point(356, 88);
			this.buttonApplyPerformanceMode.Name = "buttonApplyPerformanceMode";
			this.buttonApplyPerformanceMode.Size = new System.Drawing.Size(169, 20);
			this.buttonApplyPerformanceMode.TabIndex = 44;
			this.buttonApplyPerformanceMode.Text = "Apply Performance";
			this.buttonApplyPerformanceMode.UseVisualStyleBackColor = true;
			this.buttonApplyPerformanceMode.Click += new System.EventHandler(this.buttonApplyPerformanceMode_Click);
			// 
			// groupBoxProcesses
			// 
			this.groupBoxProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxProcesses.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBoxProcesses.Controls.Add(this.label15);
			this.groupBoxProcesses.Controls.Add(this.label14);
			this.groupBoxProcesses.Controls.Add(this.label10);
			this.groupBoxProcesses.Controls.Add(this.toggleDisableWithProcesses);
			this.groupBoxProcesses.Controls.Add(this.listBoxDisableProcesses);
			this.groupBoxProcesses.Controls.Add(this.textBoxSearchRunningProcesses);
			this.groupBoxProcesses.Controls.Add(this.listBoxRunningProcesses);
			this.groupBoxProcesses.Location = new System.Drawing.Point(12, 475);
			this.groupBoxProcesses.Name = "groupBoxProcesses";
			this.groupBoxProcesses.Size = new System.Drawing.Size(657, 238);
			this.groupBoxProcesses.TabIndex = 42;
			this.groupBoxProcesses.TabStop = false;
			this.groupBoxProcesses.Text = "Processes";
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
			this.groupBoxOptions.Location = new System.Drawing.Point(12, 35);
			this.groupBoxOptions.Name = "groupBoxOptions";
			this.groupBoxOptions.Size = new System.Drawing.Size(657, 156);
			this.groupBoxOptions.TabIndex = 43;
			this.groupBoxOptions.TabStop = false;
			this.groupBoxOptions.Text = "Options";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(12, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(294, 20);
			this.label13.TabIndex = 30;
			this.label13.Text = "Current status:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.Location = new System.Drawing.Point(312, 9);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(331, 20);
			this.labelStatus.TabIndex = 44;
			this.labelStatus.Text = "IDLE";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxStatus
			// 
			this.pictureBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
			this.pictureBoxStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.InitialImage")));
			this.pictureBoxStatus.Location = new System.Drawing.Point(649, 9);
			this.pictureBoxStatus.Name = "pictureBoxStatus";
			this.pictureBoxStatus.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStatus.TabIndex = 45;
			this.pictureBoxStatus.TabStop = false;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(210, 42);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(54, 20);
			this.label14.TabIndex = 42;
			this.label14.Text = "Search:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(210, 18);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(441, 20);
			this.label15.TabIndex = 43;
			this.label15.Text = "Running Processes:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 751);
			this.Controls.Add(this.pictureBoxStatus);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.groupBoxOptions);
			this.Controls.Add(this.groupBoxProcesses);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPowerPlanManager";
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBoxProcesses.ResumeLayout(false);
			this.groupBoxProcesses.PerformLayout();
			this.groupBoxOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboInUsePP;
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
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown inputTimeout;
		private System.Windows.Forms.CheckBox toggleIdleOnTimeout;
		private System.Windows.Forms.CheckBox toggleIdleOnScreensaver;
		private System.Windows.Forms.CheckBox toggleDisableWithProcesses;
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
		private System.Windows.Forms.ListBox listBoxRunningProcesses;
		private System.Windows.Forms.TextBox textBoxSearchRunningProcesses;
		private System.Windows.Forms.ListBox listBoxDisableProcesses;
		private System.Windows.Forms.Button buttonRefreshPowerPlans;
		private System.Windows.Forms.Button buttonRefreshPowerModes;
		private System.Windows.Forms.Button buttonApplyPerformanceMode;
		private System.Windows.Forms.GroupBox groupBoxProcesses;
		private System.Windows.Forms.GroupBox groupBoxOptions;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.PictureBox pictureBoxStatus;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
	}
}

