using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ManagedWinapi.Hooks;

namespace WinMoreNSnap
{
    static class Program
    {
        // The hooks
        public static LowLevelMouseHook MouseHook;
        public static LowLevelKeyboardHook KeyboardHook;

        // The notify icon and menu
        public static NotifyIcon NotifyIcon;

        // For the options
        public static OptionsManager Options;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Prevent multiple instance
            using (Mutex singleInstance = new Mutex(false, "SingleInstance WinMoreNSnap"))
            {
                if (singleInstance.WaitOne(0, false))
                {
                    // EnableVisualStyles
                    EnableVisualStyles();

                    //TODO: Load default options
                    InitializeOptions();

                    // Init the tray icon
                    InitializeNotifyIcon();

                    // Set up the hooks
                    KeyboardHook = new LowLevelKeyboardHook();
                    KeyboardHook.MessageIntercepted += Hook.KeyboardHook;
                    KeyboardHook.StartHook();

                    MouseHook = new LowLevelMouseHook();
                    MouseHook.MessageIntercepted += Hook.MouseHook;
                    MouseHook.StartHook();

                    // Add session ended handler
                    Microsoft.Win32.SystemEvents.SessionEnded += Actions.QuitApplication;

                    // Run the application
                    Application.ApplicationExit += Actions.OnApplicationExit;
                    Application.Run();
                }
            }
        }

        /// <summary>
        /// Initialize the application options
        /// </summary>
        private static void InitializeOptions()
        {
            Options = new OptionsManager();

            ///
            /// IsActive options
            /// 
            Options.IsActive = true;

            ///
            /// Move options
            /// 
            Options.MoveOptions = new OptionsManager.KBMOptions
                                      {
                                          keyModifier = Keys.Alt,
                                          mouseButton = MouseButtons.Left
                                      };

            ///
            /// Resize options
            /// 
            Options.ResizeOptions = new OptionsManager.KBMOptions
                                        {
                                          keyModifier = Keys.Alt,
                                          mouseButton = MouseButtons.Right
                                        };

            ///
            /// Snap options
            /// 
            Options.SnapOptions = new OptionsManager.SnapingOptions
                                      {
                                          TopDistance = 10,
                                          LeftDistance = 10,
                                          RightDistance = 10,
                                          BottomDistance = 10
                                      };
        }

        /// <summary>
        /// Initialize the notify icon.
        /// </summary>
        private static void InitializeNotifyIcon()
        {
            NotifyIcon = new NotifyIcon();

            // Display inf
            Assembly assembly = Assembly.GetExecutingAssembly();
            NotifyIcon.Icon = new Icon(assembly.GetManifestResourceStream("WinMoreNSnap.icon.ico"));
            //NotifyIcon.Icon = new Icon("icon.ico");
            NotifyIcon.Text = "WinMoreNSnap";
            NotifyIcon.Visible = true;

            // Tray menu
            ContextMenuStrip _trayMenu = InitializeTrayMenu();
            NotifyIcon.ContextMenuStrip = _trayMenu;

            // Events
            NotifyIcon.DoubleClick += Actions.ShowSettingsForm;
        }

        /// <summary>
        /// Initialize the tray menu.
        /// </summary>
        private static ContextMenuStrip InitializeTrayMenu()
        {
            ContextMenuStrip _trayMenu = new ContextMenuStrip();

            // 
            // 'Active' menu item
            // 
            ToolStripMenuItem activeToolStripMenuItem = new ToolStripMenuItem
                                                            {
                                                                Checked = true,
                                                                CheckOnClick = true,
                                                                CheckState = CheckState.Checked,
                                                                Text = "Active"
                                                            };
            activeToolStripMenuItem.CheckedChanged += Actions.ChangeActiveState;

            // 
            // 'Settings' menu item
            // 
            ToolStripMenuItem settingsToolStripMenuItem = new ToolStripMenuItem
                                                              {
                                                                  Font = new Font("Tahoma", 8.25F, FontStyle.Bold),
                                                                  Text = "Settings..."
                                                              };
            settingsToolStripMenuItem.Click += Actions.ShowSettingsForm;

            //
            // 'About' menu item
            //
            ToolStripMenuItem aboutToolStripMenuItem = new ToolStripMenuItem
                                                           {
                                                               Text = "About..."
                                                           };
            aboutToolStripMenuItem.Click += Actions.ShowAboutform;

            // 
            // 'Quit' menu item
            // 
            ToolStripMenuItem quitToolStripMenuItem = new ToolStripMenuItem
                                                          {
                                                              Text = "Quit"
                                                          };
            quitToolStripMenuItem.Click += Actions.QuitApplication;

            // 
            // Set up the menu
            // 
            _trayMenu.Items.AddRange(new ToolStripItem[] {
                activeToolStripMenuItem,
                new ToolStripSeparator(),
                settingsToolStripMenuItem,
                new ToolStripSeparator(),
                aboutToolStripMenuItem,
                quitToolStripMenuItem});

            return _trayMenu;
        }

        /// <summary>
        /// Initialize Windows XP Theme support.
        /// </summary>
        private static void EnableVisualStyles()
        {
            if (((Environment.OSVersion.Platform == PlatformID.Win32NT) &&
                 (Environment.OSVersion.Version.Major >= 5)) && (Environment.OSVersion.Version.Minor > 0))
                if (OSFeature.Feature.IsPresent(OSFeature.Themes))
                    Application.EnableVisualStyles();
            Application.DoEvents();
        }
    }
}
