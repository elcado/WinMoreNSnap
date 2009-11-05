using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using ManagedWinapi.Hooks;

namespace WinMoreNSnap
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ///
            /// Prevent move or resize without any key modifiers
            /// 
            if (!(cbMoveKeyAlt.Checked || cbMoveKeyCtrl.Checked || cbMoveKeyShift.Checked)
                || !(cbResizeKeyAlt.Checked || cbResizeKeyCtrl.Checked || cbResizeKeyShift.Checked))
            {
                MessageBox.Show(this,
                                "You have to specify at least one key modifier for the move and/or resize functionality",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonSave.Enabled = false;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void OnActiveStateChange(object sender, EventArgs e)
        {
            Actions.ChangeActiveState(sender, e);
        }

        private void cbCheckedChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }

        /// <summary>
        /// Set up the settings form with the provided options
        /// </summary>
        public void Configure(OptionsManager options)
        {
            
        }

        /// <summary>
        /// Get the options configured in the form
        /// </summary>
        public OptionsManager GetOptions()
        {
            OptionsManager newOptions = new OptionsManager();

            ///
            /// Move options
            /// 
            newOptions.MoveOptions = new OptionsManager.KBMOptions();

            // Mouse key modifier
            if (cbMoveKeyAlt.Checked)
                newOptions.MoveOptions.keyModifier |= Keys.Alt;
            if (cbMoveKeyCtrl.Checked)
                newOptions.MoveOptions.keyModifier |= Keys.Control;
            if (cbMoveKeyShift.Checked)
                newOptions.MoveOptions.keyModifier |= Keys.Shift;

            // Mouse button
            if (rbMoveMouseLeft.Checked)
                newOptions.MoveOptions.mouseButton |= MouseButtons.Left;
            if (rbMoveMouseRight.Checked)
                newOptions.MoveOptions.mouseButton |= MouseButtons.Right;

            ///
            ///  Resize options
            /// 
            newOptions.ResizeOptions = new OptionsManager.KBMOptions();

            // Resize key modifier
            if (cbResizeKeyAlt.Checked)
                newOptions.ResizeOptions.keyModifier |= Keys.Alt;
            if (cbResizeKeyCtrl.Checked)
                newOptions.ResizeOptions.keyModifier |= Keys.Control;
            if (cbResizeKeyShift.Checked)
                newOptions.ResizeOptions.keyModifier |= Keys.Shift;

            // Resize button
            if (rbResizeMouseLeft.Checked)
                newOptions.ResizeOptions.mouseButton |= MouseButtons.Left;
            if (rbResizeMouseRight.Checked)
                newOptions.ResizeOptions.mouseButton |= MouseButtons.Right;

            ///
            /// Snap options
            /// 
            newOptions.SnapOptions = new OptionsManager.SnapingOptions
            {
                TopDistance = int.Parse(tbSnapDistTop.Text),
                LeftDistance = int.Parse(tbSnapDistLeft.Text),
                RightDistance = int.Parse(tbSnapDistRight.Text),
                BottomDistance = int.Parse(tbSnapDistBottom.Text)
            };

            return newOptions;
        }
    }
}
