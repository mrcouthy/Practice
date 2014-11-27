using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SystemTrayApp.Properties;

namespace SystemTrayApp
{
    /// <summary>
    /// 
    /// </summary>
    class ProcessIcon : IDisposable
    {
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
        }
        Timer lookAwayTimer;
        Timer walkTimer;
        int lookAwayIntervalMins = 1;
        int walkIntervalMins = 3;
        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.SystemTrayApp;
            ni.Text = "Health Program";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = new ContextMenus().Create();

            lookAwayTimer = new Timer();
            lookAwayTimer.Tick += lookAway_Tick;
            lookAwayTimer.Interval = lookAwayIntervalMins * 1000 * 60;
            lookAwayTimer.Enabled = true;

            walkTimer = new Timer();
            walkTimer.Tick += walkAway_Tick;
            walkTimer.Interval = walkIntervalMins * 100 * 60;
            walkTimer.Enabled = true;
        }

        DateTime dtLook = DateTime.Now;
        void lookAway_Tick(object sender, EventArgs e)
        {
            var interval = dtLook - DateTime.Now;
            dtLook = DateTime.Now;
            ni.Icon = SystemIcons.Exclamation;
            ni.Visible = true;
            ni.BalloonTipTitle = "Blink";
            ni.BalloonTipText = string .Format ("Straight. {0} mins",interval.TotalMinutes );
            ni.BalloonTipIcon = ToolTipIcon.Info;
            ni.ShowBalloonTip(500);
        }

        DateTime dtWalk = DateTime.Now;
        void walkAway_Tick(object sender, EventArgs e)
        {
            var interval = dtWalk - DateTime.Now;
            dtWalk = DateTime.Now;
            ni.Icon = SystemIcons.Hand;
            ni.Visible = true;
            ni.BalloonTipTitle = "Move on";
            ni.BalloonTipText = string.Format("From Lower area. {0} mins", interval.TotalMinutes);
            ni.BalloonTipIcon = ToolTipIcon.Warning;
            ni.ShowBalloonTip(500);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
                Process.Start("explorer", null);
            }
        }
    }
}