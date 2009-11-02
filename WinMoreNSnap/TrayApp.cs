using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using ManagedWinapi.Hooks;

namespace WinMoreNSnap
{
    public partial class TrayApp : Form
    {
        private readonly LowLevelMouseHook _mouse;
        private readonly LowLevelKeyboardHook _keyboard;

        public TrayApp()
        {
            InitializeComponent();

            // Init the options manager w/ default options
            GetOptions();

            // Set up the hooks
            _keyboard = new LowLevelKeyboardHook();
            _keyboard.MessageIntercepted += Hook.KeyboardHook;
            _keyboard.StartHook();

            _mouse = new LowLevelMouseHook();
            _mouse.MessageIntercepted += Hook.MouseHook;
            _mouse.StartHook();
        }

        private void TrayApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            // UnHook mouse and keyboard
            if (_mouse.Hooked)
                _mouse.Unhook();

            if (_keyboard.Hooked)
                _keyboard.Unhook();
        }

        private void GetOptions()
        {
            ///
            /// Get move options
            /// 
            OptionsManager.MoveOptions = new OptionsManager.KBMOptions();

            // Mouse key modifier
            if (cbMoveKeyAlt.Checked)
                OptionsManager.MoveOptions.keyModifier |= Keys.Alt;
            if (cbMoveKeyCtrl.Checked)
                OptionsManager.MoveOptions.keyModifier |= Keys.Control;
            if (cbMoveKeyShift.Checked)
                OptionsManager.MoveOptions.keyModifier |= Keys.Shift;

            // Mouse button
            if (rbMoveMouseLeft.Checked)
                OptionsManager.MoveOptions.mouseButton |= MouseButtons.Left;
            if (rbMoveMouseRight.Checked)
                OptionsManager.MoveOptions.mouseButton |= MouseButtons.Right;

            ///
            ///  Get resize options
            /// 
            OptionsManager.ResizeOptions = new OptionsManager.KBMOptions();

            // Resize key modifier
            if (cbResizeKeyAlt.Checked)
                OptionsManager.ResizeOptions.keyModifier |= Keys.Alt;
            if (cbResizeKeyCtrl.Checked)
                OptionsManager.ResizeOptions.keyModifier |= Keys.Control;
            if (cbResizeKeyShift.Checked)
                OptionsManager.ResizeOptions.keyModifier |= Keys.Shift;

            // Resize button
            if (rbResizeMouseLeft.Checked)
                OptionsManager.ResizeOptions.mouseButton |= MouseButtons.Left;
            if (rbResizeMouseRight.Checked)
                OptionsManager.ResizeOptions.mouseButton |= MouseButtons.Right;

            ///
            /// Get snap options
            /// 
            OptionsManager.SnapOptions = new OptionsManager.SnapingOptions();

            OptionsManager.SnapOptions.TopDistance = int.Parse(tbSnapDistTop.Text);
            OptionsManager.SnapOptions.LeftDistance = int.Parse(tbSnapDistLeft.Text);
            OptionsManager.SnapOptions.RightDistance = int.Parse(tbSnapDistRight.Text);
            OptionsManager.SnapOptions.BottomDistance = int.Parse(tbSnapDistBottom.Text);
        }

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
            this.TopMost = true;
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
        }

        private void OnActiveStateChange(object sender, EventArgs e)
        {
            // Link activeToolStripMenuItem and checkBoxActive checked states
            if (sender is ToolStripMenuItem)
                checkBoxActive.Checked = (sender as ToolStripMenuItem).Checked;
            else if (sender is CheckBox)
                checkBoxActive.Checked = (sender as CheckBox).Checked;

            // Change trayIcon.Icon
            ChangeTrayIconOnActiveStateChange();

            // Hook/unhook
            if (checkBoxActive.Checked)
            {
                if (!_mouse.Hooked)
                    _mouse.StartHook();
                if (!_keyboard.Hooked)
                    _keyboard.StartHook();
            }
            else
            {
                if (_mouse.Hooked)
                    _mouse.Unhook();
                if (_keyboard.Hooked)
                    _keyboard.Unhook();
            }
        }

        private void ChangeTrayIconOnActiveStateChange()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            trayIcon.Icon = activeToolStripMenuItem.Checked ? new Icon(assembly.GetManifestResourceStream("WinMoreNSnap.icon.ico"))
                                                            : new Icon(assembly.GetManifestResourceStream("WinMoreNSnap.icon_off.ico"));
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
