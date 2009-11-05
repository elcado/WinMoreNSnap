using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinMoreNSnap
{
    class Actions
    {
        /// <summary>
        /// Change the active state of the hook
        /// </summary>
        public static void ChangeActiveState(object sender, EventArgs e)
        {
            // Modify option IsActive
            if (sender is ToolStripMenuItem)
                Program.Options.IsActive = (sender as ToolStripMenuItem).Checked;
            else if (sender is CheckBox)
                Program.Options.IsActive = (sender as CheckBox).Checked;

            // Change trayIcon.Icon
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Program.NotifyIcon.Icon = Program.Options.IsActive ? new Icon(assembly.GetManifestResourceStream("WinMoreNSnap.icon.ico"))
                                                               : new Icon(assembly.GetManifestResourceStream("WinMoreNSnap.icon_off.ico"));

            // Hook/unhook
            if (Program.Options.IsActive)
            {
                if (!Program.MouseHook.Hooked)
                    Program.MouseHook.StartHook();
                if (!Program.KeyboardHook.Hooked)
                    Program.KeyboardHook.StartHook();
            }
            else
            {
                if (Program.MouseHook.Hooked)
                    Program.MouseHook.Unhook();
                if (Program.KeyboardHook.Hooked)
                    Program.KeyboardHook.Unhook();
            }
        }

        /// <summary>
        /// Show the settings form
        /// </summary>
        public static void ShowSettingsForm(object sender, EventArgs e)
        {
            // Build a form
            Settings settingsForm = new Settings();
            settingsForm.TopMost = true;

            // Get the current options
            settingsForm.Configure(Program.Options);

            // Show the dialog
            DialogResult result = settingsForm.ShowDialog();

            // Update the current options
            if (result == DialogResult.OK)
                Program.Options = settingsForm.GetOptions();
        }

        /// <summary>
        /// Show about form
        /// </summary>
        public static void ShowAboutform(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.TopMost = true;
            box.ShowDialog();
        }

        /// <summary>
        /// Simply quit the application
        /// </summary>
        public static void QuitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Unhook functions before the exit of the application
        /// </summary>
        public static void OnApplicationExit(object sender, EventArgs e)
        {
            // UnHook mouse and keyboard
            if (Program.MouseHook.Hooked)
                Program.MouseHook.Unhook();

            if (Program.KeyboardHook.Hooked)
                Program.KeyboardHook.Unhook();
        }
    }
}
