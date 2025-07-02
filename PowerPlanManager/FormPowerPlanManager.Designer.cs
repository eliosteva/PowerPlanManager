
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonApplyPerformanceMode = new System.Windows.Forms.Button();
			this.buttonRefreshPowerModes = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.buttonApplyBalancedMode = new System.Windows.Forms.Button();
			this.labelCurrentPowerMode = new System.Windows.Forms.Label();
			this.buttonApplyPowerSaverMode = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBoxOptions = new System.Windows.Forms.GroupBox();
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.listBoxPerformance = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.listBoxIdle = new System.Windows.Forms.ListBox();
			this.buttonRefreshPrcesses = new System.Windows.Forms.Button();
			this.buttonIdleToBalanced = new System.Windows.Forms.Button();
			this.buttonBalancedToIdle = new System.Windows.Forms.Button();
			this.buttonBalancedToPerf = new System.Windows.Forms.Button();
			this.buttonPerfToBalanced = new System.Windows.Forms.Button();
			this.buttonResetForced = new System.Windows.Forms.Button();
			this.buttonForceIdle = new System.Windows.Forms.Button();
			this.buttonForceBalanced = new System.Windows.Forms.Button();
			this.buttonForcePerformance = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbPowerPlanPerformance = new System.Windows.Forms.ComboBox();
			this.cmbPowerPlanBalanced = new System.Windows.Forms.ComboBox();
			this.cmbPowerPlanIdle = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBoxOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.hibernateTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(214, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Set Idle if Screensaver is running:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.Location = new System.Drawing.Point(226, 17);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(20, 20);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = false;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(214, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 82);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(214, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "Set Idle if no user input detected:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(325, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(214, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Location = new System.Drawing.Point(545, 16);
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
			this.label5.Location = new System.Drawing.Point(6, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(214, 20);
			this.label5.TabIndex = 28;
			this.label5.Text = "Polling interval (sec):";
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonApplyPerformanceMode);
			this.groupBox2.Controls.Add(this.buttonRefreshPowerModes);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.buttonApplyBalancedMode);
			this.groupBox2.Controls.Add(this.labelCurrentPowerMode);
			this.groupBox2.Controls.Add(this.buttonApplyPowerSaverMode);
			this.groupBox2.Location = new System.Drawing.Point(12, 421);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(898, 79);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "PowerMode (New Win10/11 power management)";
			// 
			// buttonApplyPerformanceMode
			// 
			this.buttonApplyPerformanceMode.Location = new System.Drawing.Point(662, 46);
			this.buttonApplyPerformanceMode.Name = "buttonApplyPerformanceMode";
			this.buttonApplyPerformanceMode.Size = new System.Drawing.Size(225, 20);
			this.buttonApplyPerformanceMode.TabIndex = 44;
			this.buttonApplyPerformanceMode.Text = "Apply Performance";
			this.buttonApplyPerformanceMode.UseVisualStyleBackColor = true;
			this.buttonApplyPerformanceMode.Click += new System.EventHandler(this.buttonApplyPerformanceMode_Click);
			// 
			// buttonRefreshPowerModes
			// 
			this.buttonRefreshPowerModes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshPowerModes.Location = new System.Drawing.Point(9, 46);
			this.buttonRefreshPowerModes.Name = "buttonRefreshPowerModes";
			this.buttonRefreshPowerModes.Size = new System.Drawing.Size(101, 20);
			this.buttonRefreshPowerModes.TabIndex = 43;
			this.buttonRefreshPowerModes.Text = "Refresh";
			this.buttonRefreshPowerModes.UseVisualStyleBackColor = true;
			this.buttonRefreshPowerModes.Click += new System.EventHandler(this.buttonRefreshPowerModes_Click);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(111, 20);
			this.label12.TabIndex = 34;
			this.label12.Text = "Current PowerMode:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyBalancedMode
			// 
			this.buttonApplyBalancedMode.Location = new System.Drawing.Point(390, 46);
			this.buttonApplyBalancedMode.Name = "buttonApplyBalancedMode";
			this.buttonApplyBalancedMode.Size = new System.Drawing.Size(267, 20);
			this.buttonApplyBalancedMode.TabIndex = 36;
			this.buttonApplyBalancedMode.Text = "Apply Balanced";
			this.buttonApplyBalancedMode.UseVisualStyleBackColor = true;
			this.buttonApplyBalancedMode.Click += new System.EventHandler(this.button2_Click);
			// 
			// labelCurrentPowerMode
			// 
			this.labelCurrentPowerMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerMode.Location = new System.Drawing.Point(116, 16);
			this.labelCurrentPowerMode.Name = "labelCurrentPowerMode";
			this.labelCurrentPowerMode.Size = new System.Drawing.Size(771, 20);
			this.labelCurrentPowerMode.TabIndex = 33;
			this.labelCurrentPowerMode.Text = "--";
			this.labelCurrentPowerMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyPowerSaverMode
			// 
			this.buttonApplyPowerSaverMode.Location = new System.Drawing.Point(116, 46);
			this.buttonApplyPowerSaverMode.Name = "buttonApplyPowerSaverMode";
			this.buttonApplyPowerSaverMode.Size = new System.Drawing.Size(269, 20);
			this.buttonApplyPowerSaverMode.TabIndex = 35;
			this.buttonApplyPowerSaverMode.Text = "Apply PowerSaver";
			this.buttonApplyPowerSaverMode.UseVisualStyleBackColor = true;
			this.buttonApplyPowerSaverMode.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(817, 647);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(94, 20);
			this.button3.TabIndex = 37;
			this.button3.Text = "Quit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBoxOptions
			// 
			this.groupBoxOptions.Controls.Add(this.toggleManualHibernate);
			this.groupBoxOptions.Controls.Add(this.label7);
			this.groupBoxOptions.Controls.Add(this.hibernateTimeout);
			this.groupBoxOptions.Controls.Add(this.label3);
			this.groupBoxOptions.Controls.Add(this.sleepTimeout);
			this.groupBoxOptions.Controls.Add(this.label2);
			this.groupBoxOptions.Controls.Add(this.displayTimeout);
			this.groupBoxOptions.Controls.Add(this.label1);
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
			this.groupBoxOptions.Location = new System.Drawing.Point(12, 506);
			this.groupBoxOptions.Name = "groupBoxOptions";
			this.groupBoxOptions.Size = new System.Drawing.Size(898, 130);
			this.groupBoxOptions.TabIndex = 43;
			this.groupBoxOptions.TabStop = false;
			this.groupBoxOptions.Text = "Options";
			// 
			// toggleManualHibernate
			// 
			this.toggleManualHibernate.Location = new System.Drawing.Point(226, 104);
			this.toggleManualHibernate.Name = "toggleManualHibernate";
			this.toggleManualHibernate.Size = new System.Drawing.Size(20, 20);
			this.toggleManualHibernate.TabIndex = 37;
			this.toggleManualHibernate.UseVisualStyleBackColor = true;
			this.toggleManualHibernate.CheckedChanged += new System.EventHandler(this.toggleManualHibernate_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(214, 20);
			this.label7.TabIndex = 36;
			this.label7.Text = "Manually start hibernation:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// hibernateTimeout
			// 
			this.hibernateTimeout.Location = new System.Drawing.Point(545, 82);
			this.hibernateTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.hibernateTimeout.Name = "hibernateTimeout";
			this.hibernateTimeout.Size = new System.Drawing.Size(82, 20);
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
			this.label3.Location = new System.Drawing.Point(325, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(214, 20);
			this.label3.TabIndex = 34;
			this.label3.Text = "Hibernate timeout (min):";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sleepTimeout
			// 
			this.sleepTimeout.Location = new System.Drawing.Point(545, 60);
			this.sleepTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.sleepTimeout.Name = "sleepTimeout";
			this.sleepTimeout.Size = new System.Drawing.Size(82, 20);
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
			this.label2.Location = new System.Drawing.Point(325, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(214, 20);
			this.label2.TabIndex = 32;
			this.label2.Text = "Sleep timeout (min):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// displayTimeout
			// 
			this.displayTimeout.Location = new System.Drawing.Point(545, 38);
			this.displayTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.displayTimeout.Name = "displayTimeout";
			this.displayTimeout.Size = new System.Drawing.Size(82, 20);
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
			this.label1.Location = new System.Drawing.Point(325, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(214, 20);
			this.label1.TabIndex = 30;
			this.label1.Text = "Display timeout (min):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.Location = new System.Drawing.Point(142, 16);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(745, 20);
			this.labelStatus.TabIndex = 44;
			this.labelStatus.Text = "IDLE";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxStatus
			// 
			this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
			this.pictureBoxStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.InitialImage")));
			this.pictureBoxStatus.Location = new System.Drawing.Point(116, 16);
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
			this.listBoxBalanced.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxBalanced.Size = new System.Drawing.Size(216, 251);
			this.listBoxBalanced.TabIndex = 46;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox3.Controls.Add(this.listBoxBalanced);
			this.groupBox3.Location = new System.Drawing.Point(390, 92);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(225, 300);
			this.groupBox3.TabIndex = 44;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Balanced";
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox4.Controls.Add(this.listBoxPerformance);
			this.groupBox4.Location = new System.Drawing.Point(662, 92);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(225, 300);
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
			this.listBoxPerformance.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxPerformance.Size = new System.Drawing.Size(216, 251);
			this.listBoxPerformance.TabIndex = 46;
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox5.Controls.Add(this.listBoxIdle);
			this.groupBox5.Location = new System.Drawing.Point(116, 92);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(227, 300);
			this.groupBox5.TabIndex = 47;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Idle";
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
			this.listBoxIdle.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxIdle.Size = new System.Drawing.Size(218, 251);
			this.listBoxIdle.TabIndex = 46;
			// 
			// buttonRefreshPrcesses
			// 
			this.buttonRefreshPrcesses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRefreshPrcesses.Location = new System.Drawing.Point(6, 92);
			this.buttonRefreshPrcesses.Name = "buttonRefreshPrcesses";
			this.buttonRefreshPrcesses.Size = new System.Drawing.Size(104, 40);
			this.buttonRefreshPrcesses.TabIndex = 45;
			this.buttonRefreshPrcesses.Text = "Refresh Process List";
			this.buttonRefreshPrcesses.UseVisualStyleBackColor = true;
			this.buttonRefreshPrcesses.Click += new System.EventHandler(this.buttonRefreshPrcesses_Click);
			// 
			// buttonIdleToBalanced
			// 
			this.buttonIdleToBalanced.Location = new System.Drawing.Point(348, 92);
			this.buttonIdleToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonIdleToBalanced.Name = "buttonIdleToBalanced";
			this.buttonIdleToBalanced.Size = new System.Drawing.Size(37, 150);
			this.buttonIdleToBalanced.TabIndex = 48;
			this.buttonIdleToBalanced.Text = ">";
			this.buttonIdleToBalanced.UseVisualStyleBackColor = true;
			this.buttonIdleToBalanced.Click += new System.EventHandler(this.buttonIdleToBalanced_Click);
			// 
			// buttonBalancedToIdle
			// 
			this.buttonBalancedToIdle.Location = new System.Drawing.Point(348, 242);
			this.buttonBalancedToIdle.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToIdle.Name = "buttonBalancedToIdle";
			this.buttonBalancedToIdle.Size = new System.Drawing.Size(37, 150);
			this.buttonBalancedToIdle.TabIndex = 49;
			this.buttonBalancedToIdle.Text = "<";
			this.buttonBalancedToIdle.UseVisualStyleBackColor = true;
			this.buttonBalancedToIdle.Click += new System.EventHandler(this.buttonBalancedToIdle_Click);
			// 
			// buttonBalancedToPerf
			// 
			this.buttonBalancedToPerf.Location = new System.Drawing.Point(620, 92);
			this.buttonBalancedToPerf.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBalancedToPerf.Name = "buttonBalancedToPerf";
			this.buttonBalancedToPerf.Size = new System.Drawing.Size(37, 150);
			this.buttonBalancedToPerf.TabIndex = 50;
			this.buttonBalancedToPerf.Text = ">";
			this.buttonBalancedToPerf.UseVisualStyleBackColor = true;
			this.buttonBalancedToPerf.Click += new System.EventHandler(this.buttonBalancedToPerf_Click);
			// 
			// buttonPerfToBalanced
			// 
			this.buttonPerfToBalanced.Location = new System.Drawing.Point(620, 242);
			this.buttonPerfToBalanced.Margin = new System.Windows.Forms.Padding(2);
			this.buttonPerfToBalanced.Name = "buttonPerfToBalanced";
			this.buttonPerfToBalanced.Size = new System.Drawing.Size(37, 150);
			this.buttonPerfToBalanced.TabIndex = 51;
			this.buttonPerfToBalanced.Text = "<";
			this.buttonPerfToBalanced.UseVisualStyleBackColor = true;
			this.buttonPerfToBalanced.Click += new System.EventHandler(this.buttonPerfToBalanced_Click);
			// 
			// buttonResetForced
			// 
			this.buttonResetForced.Location = new System.Drawing.Point(6, 66);
			this.buttonResetForced.Name = "buttonResetForced";
			this.buttonResetForced.Size = new System.Drawing.Size(104, 20);
			this.buttonResetForced.TabIndex = 52;
			this.buttonResetForced.Text = "Default";
			this.buttonResetForced.UseVisualStyleBackColor = true;
			this.buttonResetForced.Click += new System.EventHandler(this.buttonResetForced_Click);
			// 
			// buttonForceIdle
			// 
			this.buttonForceIdle.Location = new System.Drawing.Point(116, 66);
			this.buttonForceIdle.Name = "buttonForceIdle";
			this.buttonForceIdle.Size = new System.Drawing.Size(227, 20);
			this.buttonForceIdle.TabIndex = 53;
			this.buttonForceIdle.Text = "Force PowerSaver";
			this.buttonForceIdle.UseVisualStyleBackColor = true;
			this.buttonForceIdle.Click += new System.EventHandler(this.buttonForceIdle_Click);
			// 
			// buttonForceBalanced
			// 
			this.buttonForceBalanced.Location = new System.Drawing.Point(390, 66);
			this.buttonForceBalanced.Name = "buttonForceBalanced";
			this.buttonForceBalanced.Size = new System.Drawing.Size(225, 20);
			this.buttonForceBalanced.TabIndex = 54;
			this.buttonForceBalanced.Text = "Force Balanced";
			this.buttonForceBalanced.UseVisualStyleBackColor = true;
			this.buttonForceBalanced.Click += new System.EventHandler(this.buttonForceBalanced_Click);
			// 
			// buttonForcePerformance
			// 
			this.buttonForcePerformance.Location = new System.Drawing.Point(662, 66);
			this.buttonForcePerformance.Name = "buttonForcePerformance";
			this.buttonForcePerformance.Size = new System.Drawing.Size(225, 20);
			this.buttonForcePerformance.TabIndex = 55;
			this.buttonForcePerformance.Text = "Force Performance";
			this.buttonForcePerformance.UseVisualStyleBackColor = true;
			this.buttonForcePerformance.Click += new System.EventHandler(this.buttonForcePerformance_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.buttonRefreshPrcesses);
			this.groupBox1.Controls.Add(this.buttonResetForced);
			this.groupBox1.Controls.Add(this.buttonPerfToBalanced);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.buttonBalancedToPerf);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.buttonBalancedToIdle);
			this.groupBox1.Controls.Add(this.cmbPowerPlanPerformance);
			this.groupBox1.Controls.Add(this.buttonIdleToBalanced);
			this.groupBox1.Controls.Add(this.cmbPowerPlanBalanced);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.cmbPowerPlanIdle);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.buttonForceIdle);
			this.groupBox1.Controls.Add(this.buttonForcePerformance);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.buttonForceBalanced);
			this.groupBox1.Controls.Add(this.pictureBoxStatus);
			this.groupBox1.Controls.Add(this.labelStatus);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(898, 403);
			this.groupBox1.TabIndex = 52;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PowerPlan";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 20);
			this.label10.TabIndex = 59;
			this.label10.Text = "Power Plans:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbPowerPlanPerformance
			// 
			this.cmbPowerPlanPerformance.FormattingEnabled = true;
			this.cmbPowerPlanPerformance.Location = new System.Drawing.Point(662, 39);
			this.cmbPowerPlanPerformance.Name = "cmbPowerPlanPerformance";
			this.cmbPowerPlanPerformance.Size = new System.Drawing.Size(225, 21);
			this.cmbPowerPlanPerformance.TabIndex = 58;
			this.cmbPowerPlanPerformance.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanPerformance_SelectedIndexChanged);
			// 
			// cmbPowerPlanBalanced
			// 
			this.cmbPowerPlanBalanced.FormattingEnabled = true;
			this.cmbPowerPlanBalanced.Location = new System.Drawing.Point(390, 39);
			this.cmbPowerPlanBalanced.Name = "cmbPowerPlanBalanced";
			this.cmbPowerPlanBalanced.Size = new System.Drawing.Size(225, 21);
			this.cmbPowerPlanBalanced.TabIndex = 57;
			this.cmbPowerPlanBalanced.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanBalanced_SelectedIndexChanged);
			// 
			// cmbPowerPlanIdle
			// 
			this.cmbPowerPlanIdle.FormattingEnabled = true;
			this.cmbPowerPlanIdle.Location = new System.Drawing.Point(116, 39);
			this.cmbPowerPlanIdle.Name = "cmbPowerPlanIdle";
			this.cmbPowerPlanIdle.Size = new System.Drawing.Size(227, 21);
			this.cmbPowerPlanIdle.TabIndex = 56;
			this.cmbPowerPlanIdle.SelectedIndexChanged += new System.EventHandler(this.cmbPowerPlanIdle_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 20);
			this.label11.TabIndex = 47;
			this.label11.Text = "Current Status:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(922, 678);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBoxOptions);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormPowerPlanManager";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBoxOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.hibernateTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sleepTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.displayTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
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
		System.Windows.Forms.GroupBox groupBox2;
		System.Windows.Forms.Button buttonApplyPowerSaverMode;
		System.Windows.Forms.Button buttonApplyBalancedMode;
		System.Windows.Forms.Label label12;
		System.Windows.Forms.Label labelCurrentPowerMode;
		System.Windows.Forms.Button button3;
		System.Windows.Forms.Button buttonRefreshPowerModes;
		System.Windows.Forms.Button buttonApplyPerformanceMode;
		System.Windows.Forms.GroupBox groupBoxOptions;
		System.Windows.Forms.Label labelStatus;
		System.Windows.Forms.PictureBox pictureBoxStatus;
		System.Windows.Forms.ListBox listBoxBalanced;
		System.Windows.Forms.GroupBox groupBox3;
		System.Windows.Forms.GroupBox groupBox4;
		System.Windows.Forms.ListBox listBoxPerformance;
		System.Windows.Forms.GroupBox groupBox5;
		System.Windows.Forms.ListBox listBoxIdle;
		System.Windows.Forms.Button buttonIdleToBalanced;
		System.Windows.Forms.Button buttonBalancedToIdle;
		System.Windows.Forms.Button buttonBalancedToPerf;
		System.Windows.Forms.Button buttonPerfToBalanced;
		System.Windows.Forms.Button buttonRefreshPrcesses;
		System.Windows.Forms.Button buttonResetForced;
		System.Windows.Forms.Button buttonForceIdle;
		System.Windows.Forms.Button buttonForceBalanced;
		System.Windows.Forms.Button buttonForcePerformance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown displayTimeout;
		private System.Windows.Forms.NumericUpDown sleepTimeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown hibernateTimeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox toggleManualHibernate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbPowerPlanPerformance;
		private System.Windows.Forms.ComboBox cmbPowerPlanBalanced;
		private System.Windows.Forms.ComboBox cmbPowerPlanIdle;
	}
}

