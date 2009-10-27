using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Gma.UserActivityMonitor;
using ManagedWinapi.Hooks;
using ManagedWinapi.Windows;

namespace WinMoreNSnap
{
    public partial class TrayApp : Form
    {
        private OptionsManager optionsManager;

        private LowLevelMouseHook mouse;
        private LowLevelKeyboardHook keyboard;

        public TrayApp()
        {
            InitializeComponent();

            // The options manager
            optionsManager = new OptionsManager();

            // Set up the hooks
            keyboard = new LowLevelKeyboardHook();
            keyboard.MessageIntercepted += Hook.KeyboardHook;
            keyboard.StartHook();

            mouse = new LowLevelMouseHook();
            mouse.MessageIntercepted += Hook.MouseHook;
            //mouse.StartHook();
        }

        private void TrayApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            // UnHook mouse and keyboard
            if (mouse.Hooked)
                mouse.Unhook();

            if (keyboard.Hooked)
                keyboard.Unhook();
        }

        public void GetOptions()
        {
            ///
            /// Get move options
            /// 
            optionsManager.MoveOptions = new OptionsManager.KBMOptions();

            // Mouse key modifier
            if (cbMoveKeyAlt.Checked)
                optionsManager.MoveOptions.keyModifier |= Keys.Alt;
            if (cbMoveKeyCtrl.Checked)
                optionsManager.MoveOptions.keyModifier |= Keys.Control;
            if (cbMoveKeyShift.Checked)
                optionsManager.MoveOptions.keyModifier |= Keys.Shift;

            // Mouse button
            if (rbMoveMouseLeft.Checked)
                optionsManager.MoveOptions.mouseButton |= MouseButtons.Left;
            if (rbMoveMouseRight.Checked)
                optionsManager.MoveOptions.mouseButton |= MouseButtons.Right;

            ///
            ///  Get resize options
            /// 
            optionsManager.ResizeOptions = new OptionsManager.KBMOptions();

            // Resize key modifier
            if (cbResizeKeyAlt.Checked)
                optionsManager.ResizeOptions.keyModifier |= Keys.Alt;
            if (cbResizeKeyCtrl.Checked)
                optionsManager.ResizeOptions.keyModifier |= Keys.Control;
            if (cbResizeKeyShift.Checked)
                optionsManager.ResizeOptions.keyModifier |= Keys.Shift;

            // Resize button
            if (rbResizeMouseLeft.Checked)
                optionsManager.ResizeOptions.mouseButton |= MouseButtons.Left;
            if (rbResizeMouseRight.Checked)
                optionsManager.ResizeOptions.mouseButton |= MouseButtons.Right;

            ///
            /// Get snap options
            /// 
            optionsManager.SnapOptions = new OptionsManager.SnapingOptions();

            optionsManager.SnapOptions.TopDistance = int.Parse(tbSnapDistTop.Text);
            optionsManager.SnapOptions.LeftDistance = int.Parse(tbSnapDistLeft.Text);
            optionsManager.SnapOptions.RightDistance = int.Parse(tbSnapDistRight.Text);
            optionsManager.SnapOptions.BottomDistance = int.Parse(tbSnapDistBottom.Text);
        }

        #region Keyboard hook

        private bool isMoveKeyModifier;
        private bool isResizeKeyModifier;
        private void globalHookEventProvider_KeyDown(object sender, KeyEventArgs e)
        {
            isMoveKeyModifier = optionsManager.MoveOptions.TestKeyModifier(e.Modifiers);//e.Alt;
            isResizeKeyModifier = optionsManager.ResizeOptions.TestKeyModifier(e.Modifiers);
        }

        private void globalHookEventProvider_KeyUp(object sender, KeyEventArgs e)
        {
            isMoveKeyModifier = isResizeKeyModifier = false;
        }

        #endregion

        #region Move and resize

        private SystemWindow currentWindow;
        private bool isMoving, isResizing;
        private Point previousPoint;
        private WND_QUARTER clickedQuarter;
        private void globalHookEventProvider_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMoveKeyModifier && optionsManager.MoveOptions.TestMouseButton(e.Button))
            {
                // Now we are moving...
                isMoving = true;

                //... this window...
                currentWindow = GetTopLevel(SystemWindow.FromPoint(e.X, e.Y));

                //... from here to somewhere.
                previousPoint = new Point(e.X, e.Y);

                // Prevent event to be forwarded
                ((MouseEventExtArgs)e).Handled = true;
            }
            else if (isResizeKeyModifier && optionsManager.ResizeOptions.TestMouseButton(e.Button))
            {
                // Now we are resizing...
                isResizing = true;

                //... this window...
                currentWindow = GetTopLevel(SystemWindow.FromPoint(e.X, e.Y));

                //... from this point/quarter.
                previousPoint = new Point(e.X, e.Y);
                clickedQuarter = GetQuarterFromPoint(currentWindow, e.X, e.Y);

                // Prevent event to be forwarded
                ((MouseEventExtArgs)e).Handled = true;
            }
        }

        private SystemWindow GetTopLevel(SystemWindow window)
        {
            if (window.ParentSymmetric == null)
                return window;
            return GetTopLevel(window.ParentSymmetric);
        }

        enum WND_QUARTER { DIR_NONE, DIR_NE, DIR_NW, DIR_SE, DIR_SW };

        private WND_QUARTER GetQuarterFromPoint(SystemWindow window, int x, int y)
        {
            WND_QUARTER[,] dirs = {{WND_QUARTER.DIR_NW, WND_QUARTER.DIR_SW},
                                   {WND_QUARTER.DIR_NE, WND_QUARTER.DIR_SE}};

            RECT rect = window.Rectangle;

            int horiz = (Math.Abs(x - rect.Left) < Math.Abs(x - rect.Right)) ? 0 : 1;
            int vert = (Math.Abs(y - rect.Top) < Math.Abs(y - rect.Bottom)) ? 0 : 1;

            return dirs[horiz, vert];

        }

        private void globalHookEventProvider_MouseUp(object sender, MouseEventArgs e)
        {
            if (optionsManager.MoveOptions.TestMouseButton(e.Button))
            {
                if (isMoving)
                {
                    // Prevent event to be forwarded
                    ((MouseEventExtArgs)e).Handled = true;
                }
                isMoving = false;
            }
            else if (optionsManager.ResizeOptions.TestMouseButton(e.Button))
            {
                if (isResizing)
                {
                    // Prevent event to be forwarded
                    ((MouseEventExtArgs)e).Handled = true;
                }
                isResizing = false;
            }
        }

        private Dictionary<SystemWindow, RECT> snapedWindows = new Dictionary<SystemWindow, RECT>();
        private void globalHookEventProvider_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            if (isMoving)
            {
                int dx = e.X - previousPoint.X;
                int dy = e.Y - previousPoint.Y;

                // Only move not snaped window
                if (!snapedWindows.ContainsKey(currentWindow))
                    MoveWindow(currentWindow, dx, dy);

                previousPoint = new Point(e.X, e.Y);

                // Try to snap
                Snap(new Point(e.X, e.Y));

                // Prevent event to be forwarded
                //e.Handled = true;
            }
            else if (isResizing)
            {
                int dx = e.X - previousPoint.X;
                int dy = e.Y - previousPoint.Y;

                ResizeWindow(currentWindow, dx, dy);

                previousPoint = new Point(e.X, e.Y);

                // Prevent event to be forwarded
                //e.Handled = true;
            }
        }

        private void Snap(Point point)
        {


            ///
            ///  Snap/unsnap to top (maximize)
            /// 
            if (optionsManager.SnapOptions.TestTopDistance(point))
            {
                if (currentWindow.WindowState == FormWindowState.Normal)
                {
                    currentWindow.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                if (currentWindow.WindowState == FormWindowState.Maximized)
                {
                    currentWindow.WindowState = FormWindowState.Normal;
                }
            }

            ///
            /// Snap/unsnap on left side
            /// 
            if (optionsManager.SnapOptions.TestLeftDistance(point))
            {
                if (!snapedWindows.ContainsKey(currentWindow))
                {
                    // Keep currentWindow position
                    snapedWindows.Add(currentWindow, currentWindow.Position);

                    // Snap currentWindow
                    currentWindow.Position = new RECT(SystemWindow.DesktopWindow.Location.X,
                                                      SystemWindow.DesktopWindow.Location.Y,
                                                      SystemWindow.DesktopWindow.Size.Width / 2,
                                                      SystemWindow.DesktopWindow.Size.Height);
                }
            }

            ///
            /// Snap/unsnap on right side
            /// 
            else if (optionsManager.SnapOptions.TestRightDistance(point))
            {
                if (!snapedWindows.ContainsKey(currentWindow))
                {
                    // Keep currentWindow position
                    snapedWindows.Add(currentWindow, currentWindow.Position);

                    // Snap currentWindow
                    currentWindow.Position = new RECT(SystemWindow.DesktopWindow.Size.Width / 2,
                                                      SystemWindow.DesktopWindow.Location.Y,
                                                      SystemWindow.DesktopWindow.Size.Width,
                                                      SystemWindow.DesktopWindow.Size.Height);
                }
            }
            else if (snapedWindows.ContainsKey(currentWindow))
            {
                // Restore currentWindow position
                currentWindow.Position = snapedWindows[currentWindow];
                snapedWindows.Remove(currentWindow);
            }
        }

        private void MoveWindow(SystemWindow window, int dx, int dy)
        {
            // Do nothing on a maximized window
            if ((window.Style & WindowStyleFlags.MAXIMIZE) != 0)
                return;

            // Move
            Point oldLocation = window.Location;
            window.Location = new Point(oldLocation.X + dx, oldLocation.Y + dy);
        }

        private void ResizeWindow(SystemWindow window, int dx, int dy)
        {
            // Do nothing on a maximized window
            if ((window.Style & WindowStyleFlags.MAXIMIZE) != 0)
                return;

            RECT rect = window.Rectangle;
            int x, y, xsz, ysz;

            switch (clickedQuarter)
            {
                case WND_QUARTER.DIR_SW:
                    dx = -dx;
                    x = rect.Left - dx;
                    y = rect.Top;
                    break;
                case WND_QUARTER.DIR_NW:
                    dx = -dx;
                    dy = -dy;
                    x = rect.Left - dx;
                    y = rect.Top - dy;
                    break;
                case WND_QUARTER.DIR_NE:
                    dy = -dy;
                    x = rect.Left;
                    y = rect.Top - dy;
                    break;
                case WND_QUARTER.DIR_SE:
                default:
                    x = rect.Left;
                    y = rect.Top;
                    break;
            }

            xsz = rect.Right - rect.Left + dx;
            ysz = rect.Bottom - rect.Top + dy;

            // Resize
            window.Location = new Point(x, y);
            window.Size = new Size(xsz, ysz);
        }

        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //  Get move options
            GetOptions();

            // Disable save button
            buttonSave.Enabled = false;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void TrayApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void TrayApp_Load(object sender, EventArgs e)
        {
            Visible = false;

            // Get default options
            GetOptions();
        }

        private void activeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Link activeToolStripMenuItem and checkBoxActive checked states
            checkBoxActive.Checked = activeToolStripMenuItem.Checked;

            // Change trayIcon.Icon
            ChangeTrayIconOnActiveStateChange();
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            // Link activeToolStripMenuItem and checkBoxActive checked states
            activeToolStripMenuItem.Checked = checkBoxActive.Checked;

            // Change trayIcon.Icon
            ChangeTrayIconOnActiveStateChange();
        }

        private void ChangeTrayIconOnActiveStateChange()
        {
            if (activeToolStripMenuItem.Checked)
            {
                trayIcon.Icon = new Icon("Resources/trayon.ico");
            }
            else
            {
                trayIcon.Icon = new Icon("Resources/trayoff.ico");
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbCheckedChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

    }
}
