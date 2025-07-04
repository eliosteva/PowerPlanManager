﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PowerPlanManager.IdleManager;

namespace PowerPlanManager
{
	internal class TrayIconManager
	{

		const int notificationSeconds = 10;

		SelfInstaller si;
		NotifyIcon trayIcon;
		FormPowerPlanManager form;
		PowerPlanManager ppm;
		PowerModeManager pmm;
		IdleManager im;
		DataManager dm;

		internal TrayIconManager(SelfInstaller si, ControlContainer container, PowerPlanManager ppm, PowerModeManager pmm, IdleManager im, DataManager dm)
		{
			this.si = si;
			this.ppm = ppm;
			this.pmm = pmm;
			this.im = im;
			this.dm = dm;

			// context menu strip
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Size = new System.Drawing.Size(104, 48);
			contextMenuStrip.SuspendLayout();

			// context menu item
			ToolStripMenuItem menuItemShow = new ToolStripMenuItem();
			menuItemShow.Size = new System.Drawing.Size(104, 48);
			menuItemShow.Name = "Show";
			menuItemShow.Text = "Show";
			menuItemShow.Click += ShowForm;
			contextMenuStrip.Items.Add(menuItemShow);

			// context menu item
			ToolStripMenuItem menuItemBrowse = new ToolStripMenuItem();
			menuItemBrowse.Size = new System.Drawing.Size(104, 48);
			menuItemBrowse.Name = "Browse";
			menuItemBrowse.Text = "Browse";
			menuItemBrowse.Click += ShowFolder;
			contextMenuStrip.Items.Add(menuItemBrowse);

			contextMenuStrip.Items.Add("-");
			{
				// context menu item
				ToolStripMenuItem menuItemForceDefault = new ToolStripMenuItem();
				menuItemForceDefault.Size = new System.Drawing.Size(104, 48);
				menuItemForceDefault.Name = "Reset";
				menuItemForceDefault.Text = "Reset";
				menuItemForceDefault.Click += ResetToDefault;
				contextMenuStrip.Items.Add(menuItemForceDefault);

				// context menu item
				ToolStripMenuItem menuItemForceIdle = new ToolStripMenuItem();
				menuItemForceIdle.Size = new System.Drawing.Size(104, 48);
				menuItemForceIdle.Name = "ForceIdle";
				menuItemForceIdle.Text = "Force Idle";
				menuItemForceIdle.Click += ForceIdle;
				contextMenuStrip.Items.Add(menuItemForceIdle);

				// context menu item
				ToolStripMenuItem menuItemForceBalanced = new ToolStripMenuItem();
				menuItemForceBalanced.Size = new System.Drawing.Size(104, 48);
				menuItemForceBalanced.Name = "ForceBalanced";
				menuItemForceBalanced.Text = "Force Balanced";
				menuItemForceBalanced.Click += ForceBalanced;
				contextMenuStrip.Items.Add(menuItemForceBalanced);

				// context menu item
				ToolStripMenuItem menuItemForcePerformance = new ToolStripMenuItem();
				menuItemForcePerformance.Size = new System.Drawing.Size(104, 48);
				menuItemForcePerformance.Name = "ForcePerformance";
				menuItemForcePerformance.Text = "Force Performance";
				menuItemForcePerformance.Click += ForcePerformance;
				contextMenuStrip.Items.Add(menuItemForcePerformance);
			}
			contextMenuStrip.Items.Add("-");

			/*
			// context menu item
			ToolStripMenuItem menuItemForce = new ToolStripMenuItem();
			menuItemForce.Size = new System.Drawing.Size(104, 48);
			menuItemForce.Name = "Force";
			menuItemForce.Text = "Force";
			//menuItemForce.Click += ShowFolder;
			contextMenuStrip.Items.Add(menuItemForce);
			{
				// context menu item
				ToolStripMenuItem menuItemForceDefault = new ToolStripMenuItem();
				menuItemForceDefault.Size = new System.Drawing.Size(104, 48);
				menuItemForceDefault.Name = "Reset";
				menuItemForceDefault.Text = "Reset";
				menuItemForceDefault.Click += ResetToDefault;
				menuItemForce.DropDownItems.Add(menuItemForceDefault);

				// context menu item
				ToolStripMenuItem menuItemForceIdle = new ToolStripMenuItem();
				menuItemForceIdle.Size = new System.Drawing.Size(104, 48);
				menuItemForceIdle.Name = "Idle";
				menuItemForceIdle.Text = "Idle";
				menuItemForceIdle.Click += ForceIdle;
				menuItemForce.DropDownItems.Add(menuItemForceIdle);

				// context menu item
				ToolStripMenuItem menuItemForceBalanced = new ToolStripMenuItem();
				menuItemForceBalanced.Size = new System.Drawing.Size(104, 48);
				menuItemForceBalanced.Name = "Balanced";
				menuItemForceBalanced.Text = "Balanced";
				menuItemForceBalanced.Click += ForceBalanced;
				menuItemForce.DropDownItems.Add(menuItemForceBalanced);

				// context menu item
				ToolStripMenuItem menuItemForcePerformance = new ToolStripMenuItem();
				menuItemForcePerformance.Size = new System.Drawing.Size(104, 48);
				menuItemForcePerformance.Name = "Performance";
				menuItemForcePerformance.Text = "Performance";
				menuItemForcePerformance.Click += ForcePerformance;
				menuItemForce.DropDownItems.Add(menuItemForcePerformance);
			}
			*/

			// context menu item
			ToolStripMenuItem menuItemExit = new ToolStripMenuItem();
			menuItemExit.Size = new System.Drawing.Size(104, 48);
			menuItemExit.Name = "Exit";
			menuItemExit.Text = "Exit";
			menuItemExit.Click += ExitApp;
			contextMenuStrip.Items.Add(menuItemExit);

			// Initialize Tray Icon
			trayIcon = new NotifyIcon(container);
			trayIcon.Visible = true;
			trayIcon.ContextMenuStrip = contextMenuStrip;
			trayIcon.MouseDoubleClick += OnDoubleClick;

			// register with idle manager events
			im.ModeAppliedEvent += OnIdleModeAppliedEvent;
			contextMenuStrip.ResumeLayout(false);

			// show icon
			OnIdleModeAppliedEvent();
		}

		void OnIdleModeAppliedEvent()
		{
			try
			{
				switch (im.CurrentMode)
				{
					case Status.idle:
						trayIcon.Icon = Resources.idle;
						break;
					case Status.balanced:
						trayIcon.Icon = Resources.balanced;
						break;
					case Status.performance:
						trayIcon.Icon = Resources.performance;
						break;
				}
			}
			catch (System.Exception ex)
			{
				Debug.LogError("failed to set icon");
			}
		}

		void OnDoubleClick(object sender, MouseEventArgs e)
		{
			ShowForm();
		}

		void ShowForm(object sender, EventArgs e)
		{
			ShowForm();
		}

		void ShowFolder(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(si.AppDataDirPath);
		}

		void ResetToDefault(object sender, EventArgs e)
		{
			im.ResetForced();
		}
		
		void ForceIdle(object sender, EventArgs e)
		{
			im.ForceStatus(Status.idle);
		}
		
		void ForceBalanced(object sender, EventArgs e)
		{
			im.ForceStatus(Status.balanced);
		}
		
		void ForcePerformance(object sender, EventArgs e)
		{
			im.ForceStatus(Status.performance);
		}

		void ExitApp(object sender, EventArgs e)
		{
			// Hide tray icon, otherwise it will remain shown until user mouses over it
			trayIcon.Visible = false;
			Application.Exit();
		}



		internal void SetText(string text)
		{
			if (trayIcon != null)
			{
				trayIcon.Text = text;
			}
		}

		internal void ShowNotification(string title, string text, ToolTipIcon icon = ToolTipIcon.Info)
		{
			trayIcon.ShowBalloonTip(notificationSeconds, title, text, icon);
		}

		internal void ShowForm()
		{
			if (form == null || form.IsDisposed)
			{
				form = new FormPowerPlanManager(si, ppm, pmm, im, dm);
			}

			Debug.Log("showing form");
			form.Show();
		}

	}
}
