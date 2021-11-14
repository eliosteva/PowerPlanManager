﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlanManager
{
	internal class TrayIconManager
	{

		const int notificationSeconds = 10;

		SelfInstaller si;
		NotifyIcon trayIcon;
		FormPowerPlanManager form;
		PowerPlanManager ppm;
		IdleManager im;
		DataManager dm;

		internal TrayIconManager(SelfInstaller si, ControlContainer container, PowerPlanManager ppm, IdleManager im, DataManager dm)
		{
			this.si = si;
			this.ppm = ppm;
			this.im = im;
			this.dm = dm;

			// context menu strip
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Size = new System.Drawing.Size(104, 48);
			contextMenuStrip.SuspendLayout();

			// context menu item
			ToolStripMenuItem menuItemShow = new ToolStripMenuItem();
			menuItemShow.Size = new System.Drawing.Size(104, 48);
			menuItemShow.Name = "Open";
			menuItemShow.Text = "Open";
			menuItemShow.Click += ShowForm;
			contextMenuStrip.Items.Add(menuItemShow);

			// context menu item
			ToolStripMenuItem menuItemBrowse = new ToolStripMenuItem();
			menuItemBrowse.Size = new System.Drawing.Size(104, 48);
			menuItemBrowse.Name = "Browse";
			menuItemBrowse.Text = "Browse";
			menuItemBrowse.Click += ShowFolder;
			contextMenuStrip.Items.Add(menuItemBrowse);

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

			try
			{
				//trayIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon("penguin.ico");
				trayIcon.Icon = Resources.penguin;
			}
			catch (System.Exception ex)
			{
				Debug.LogError("failed to get icon");
			}

			contextMenuStrip.ResumeLayout(false);
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
				form = new FormPowerPlanManager(si, ppm, im, dm);
			}

			Debug.Log("showing form");
			form.Show();
		}


	}
}
