
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
			this.comboDefault = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboIdle = new System.Windows.Forms.ComboBox();
			this.labelCurrentPowerPlan = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboMode = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonShowLog = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// comboDefault
			// 
			this.comboDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboDefault.FormattingEnabled = true;
			this.comboDefault.Location = new System.Drawing.Point(171, 32);
			this.comboDefault.Name = "comboDefault";
			this.comboDefault.Size = new System.Drawing.Size(437, 23);
			this.comboDefault.TabIndex = 0;
			this.comboDefault.SelectedIndexChanged += new System.EventHandler(this.cbPowerPlan_default_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "In use power plan:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Idle power plan:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboIdle
			// 
			this.comboIdle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboIdle.FormattingEnabled = true;
			this.comboIdle.Location = new System.Drawing.Point(171, 61);
			this.comboIdle.Name = "comboIdle";
			this.comboIdle.Size = new System.Drawing.Size(437, 23);
			this.comboIdle.TabIndex = 3;
			this.comboIdle.SelectedIndexChanged += new System.EventHandler(this.cbPowerPlan_idle_SelectedIndexChanged);
			// 
			// labelCurrentPowerPlan
			// 
			this.labelCurrentPowerPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPowerPlan.Location = new System.Drawing.Point(171, 9);
			this.labelCurrentPowerPlan.Name = "labelCurrentPowerPlan";
			this.labelCurrentPowerPlan.Size = new System.Drawing.Size(437, 23);
			this.labelCurrentPowerPlan.TabIndex = 4;
			this.labelCurrentPowerPlan.Text = "--";
			this.labelCurrentPowerPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Current power plan:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboMode
			// 
			this.comboMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboMode.FormattingEnabled = true;
			this.comboMode.Location = new System.Drawing.Point(171, 112);
			this.comboMode.Name = "comboMode";
			this.comboMode.Size = new System.Drawing.Size(437, 23);
			this.comboMode.TabIndex = 7;
			this.comboMode.SelectedIndexChanged += new System.EventHandler(this.comboMode_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Idle mode:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 141);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(153, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Timeout (sec):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDown
			// 
			this.numericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown.Location = new System.Drawing.Point(171, 141);
			this.numericUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.numericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(437, 23);
			this.numericUpDown.TabIndex = 10;
			this.numericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// checkBoxAutoStart
			// 
			this.checkBoxAutoStart.AutoSize = true;
			this.checkBoxAutoStart.Location = new System.Drawing.Point(171, 172);
			this.checkBoxAutoStart.Name = "checkBoxAutoStart";
			this.checkBoxAutoStart.Size = new System.Drawing.Size(15, 14);
			this.checkBoxAutoStart.TabIndex = 11;
			this.checkBoxAutoStart.UseVisualStyleBackColor = true;
			this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.checkBoxAutoStart_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 172);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 15);
			this.label6.TabIndex = 12;
			this.label6.Text = "Autostart:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonShowLog
			// 
			this.buttonShowLog.Location = new System.Drawing.Point(533, 209);
			this.buttonShowLog.Name = "buttonShowLog";
			this.buttonShowLog.Size = new System.Drawing.Size(75, 23);
			this.buttonShowLog.TabIndex = 13;
			this.buttonShowLog.Text = "LOG";
			this.buttonShowLog.UseVisualStyleBackColor = true;
			this.buttonShowLog.Click += new System.EventHandler(this.buttonShowLog_Click);
			// 
			// FormPowerPlanManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 244);
			this.Controls.Add(this.buttonShowLog);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.checkBoxAutoStart);
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboMode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelCurrentPowerPlan);
			this.Controls.Add(this.comboIdle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboDefault);
			this.Name = "FormPowerPlanManager";
			this.Text = "PowerPlanManager";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboDefault;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboIdle;
		private System.Windows.Forms.Label labelCurrentPowerPlan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboMode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown;
		private System.Windows.Forms.CheckBox checkBoxAutoStart;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonShowLog;
	}
}

