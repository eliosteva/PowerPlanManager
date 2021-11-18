
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pollingInterval = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// comboInUsePP
			// 
			this.comboInUsePP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboInUsePP.FormattingEnabled = true;
			this.comboInUsePP.Location = new System.Drawing.Point(168, 90);
			this.comboInUsePP.Name = "comboInUsePP";
			this.comboInUsePP.Size = new System.Drawing.Size(314, 23);
			this.comboInUsePP.TabIndex = 0;
			this.comboInUsePP.SelectedIndexChanged += new System.EventHandler(this.comboInUsePP_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "In use power plan:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Idle power plan:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboIdlePP
			// 
			this.comboIdlePP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboIdlePP.FormattingEnabled = true;
			this.comboIdlePP.Location = new System.Drawing.Point(168, 119);
			this.comboIdlePP.Name = "comboIdlePP";
			this.comboIdlePP.Size = new System.Drawing.Size(314, 23);
			this.comboIdlePP.TabIndex = 3;
			this.comboIdlePP.SelectedIndexChanged += new System.EventHandler(this.comboIdlePP_SelectedIndexChanged);
			// 
			// labelCurrentPowerPlan
			// 
			this.labelCurrentPowerPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerPlan.Location = new System.Drawing.Point(168, 64);
			this.labelCurrentPowerPlan.Name = "labelCurrentPowerPlan";
			this.labelCurrentPowerPlan.Size = new System.Drawing.Size(314, 23);
			this.labelCurrentPowerPlan.TabIndex = 4;
			this.labelCurrentPowerPlan.Text = "--";
			this.labelCurrentPowerPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Current power plan:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Idle on Screensaver:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toggleAutoStart
			// 
			this.toggleAutoStart.Location = new System.Drawing.Point(168, 9);
			this.toggleAutoStart.Name = "toggleAutoStart";
			this.toggleAutoStart.Size = new System.Drawing.Size(23, 23);
			this.toggleAutoStart.TabIndex = 11;
			this.toggleAutoStart.UseVisualStyleBackColor = true;
			this.toggleAutoStart.CheckedChanged += new System.EventHandler(this.toggleAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(150, 23);
			this.label6.TabIndex = 16;
			this.label6.Text = "Start with windows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 177);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 23);
			this.label8.TabIndex = 18;
			this.label8.Text = "Idle on no user input:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 206);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(150, 23);
			this.label9.TabIndex = 19;
			this.label9.Text = "User input timeout (sec):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(12, 235);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(150, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "Disable with processes:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputTimeout
			// 
			this.inputTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputTimeout.Location = new System.Drawing.Point(168, 206);
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
			this.inputTimeout.Size = new System.Drawing.Size(314, 23);
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
			this.toggleIdleOnTimeout.Location = new System.Drawing.Point(168, 177);
			this.toggleIdleOnTimeout.Name = "toggleIdleOnTimeout";
			this.toggleIdleOnTimeout.Size = new System.Drawing.Size(23, 23);
			this.toggleIdleOnTimeout.TabIndex = 23;
			this.toggleIdleOnTimeout.UseVisualStyleBackColor = true;
			this.toggleIdleOnTimeout.CheckedChanged += new System.EventHandler(this.toggleIdleOnTimeout_CheckedChanged);
			// 
			// toggleIdleOnScreensaver
			// 
			this.toggleIdleOnScreensaver.Location = new System.Drawing.Point(168, 147);
			this.toggleIdleOnScreensaver.Name = "toggleIdleOnScreensaver";
			this.toggleIdleOnScreensaver.Size = new System.Drawing.Size(23, 23);
			this.toggleIdleOnScreensaver.TabIndex = 24;
			this.toggleIdleOnScreensaver.UseVisualStyleBackColor = true;
			this.toggleIdleOnScreensaver.CheckedChanged += new System.EventHandler(this.toggleIdleOnScreensaver_CheckedChanged);
			// 
			// toggleDisableWithProcesses
			// 
			this.toggleDisableWithProcesses.Location = new System.Drawing.Point(168, 235);
			this.toggleDisableWithProcesses.Name = "toggleDisableWithProcesses";
			this.toggleDisableWithProcesses.Size = new System.Drawing.Size(23, 23);
			this.toggleDisableWithProcesses.TabIndex = 25;
			this.toggleDisableWithProcesses.UseVisualStyleBackColor = true;
			this.toggleDisableWithProcesses.CheckedChanged += new System.EventHandler(this.toggleDisableWithProcesses_CheckedChanged);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 264);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(470, 82);
			this.richTextBox1.TabIndex = 26;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(150, 23);
			this.label5.TabIndex = 28;
			this.label5.Text = "Polling interval (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pollingInterval
			// 
			this.pollingInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pollingInterval.Location = new System.Drawing.Point(168, 38);
			this.pollingInterval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.pollingInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.pollingInterval.Name = "pollingInterval";
			this.pollingInterval.Size = new System.Drawing.Size(314, 23);
			this.pollingInterval.TabIndex = 29;
			this.pollingInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.pollingInterval.ValueChanged += new System.EventHandler(this.pollingInterval_ValueChanged);
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 358);
			this.Controls.Add(this.pollingInterval);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.toggleDisableWithProcesses);
			this.Controls.Add(this.toggleIdleOnScreensaver);
			this.Controls.Add(this.toggleIdleOnTimeout);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.toggleAutoStart);
			this.Controls.Add(this.inputTimeout);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelCurrentPowerPlan);
			this.Controls.Add(this.comboIdlePP);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboInUsePP);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPowerPlanManager";
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.inputTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pollingInterval)).EndInit();
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
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown pollingInterval;
	}
}

