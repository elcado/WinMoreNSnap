using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using ManagedWinapi.Hooks;
using ManagedWinapi.Windows;

namespace WinMoreNSnap
{
    class Hook
    {
        #region MouseState, KeyboardMessage, VirtualKeys and WindowsQuarter enums

        private enum MouseState
        {
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDOWN = 0x207,
            WM_MBUTTONUP = 0x208,
            WM_MBUTTONDBLCLK = 0x209,
            WM_MOUSEWHEEL = 0x20A,
            WM_MOUSEHWHEEL = 0x20E
        }

        private enum KeyboardMessage
        {
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105
        }

        private enum VirtualKeys: ushort
        {
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local
            /// <summary></summary>
            LeftButton = 0x01,
            /// <summary></summary>
            RightButton = 0x02,
            /// <summary></summary>
            Cancel = 0x03,
            /// <summary></summary>
            MiddleButton = 0x04,
            /// <summary></summary>
            ExtraButton1 = 0x05,
            /// <summary></summary>
            ExtraButton2 = 0x06,
            /// <summary></summary>
            Back = 0x08,
            /// <summary></summary>
            Tab = 0x09,
            /// <summary></summary>
            Clear = 0x0C,
            /// <summary></summary>
            Return = 0x0D,
            /// <summary></summary>
            Shift = 0x10,
            /// <summary></summary>
            Control = 0x11,
            /// <summary></summary>
            Menu = 0x12,
            /// <summary></summary>
            Pause = 0x13,
            /// <summary></summary>
            Kana = 0x15,
            /// <summary></summary>
            Hangeul = 0x15,
            /// <summary></summary>
            Hangul = 0x15,
            /// <summary></summary>
            Junja = 0x17,
            /// <summary></summary>
            Final = 0x18,
            /// <summary></summary>
            Hanja = 0x19,
            /// <summary></summary>
            Kanji = 0x19,
            /// <summary></summary>
            Escape = 0x1B,
            /// <summary></summary>
            Convert = 0x1C,
            /// <summary></summary>
            NonConvert = 0x1D,
            /// <summary></summary>
            Accept = 0x1E,
            /// <summary></summary>
            ModeChange = 0x1F,
            /// <summary></summary>
            Space = 0x20,
            /// <summary></summary>
            Prior = 0x21,
            /// <summary></summary>
            Next = 0x22,
            /// <summary></summary>
            End = 0x23,
            /// <summary></summary>
            Home = 0x24,
            /// <summary></summary>
            Left = 0x25,
            /// <summary></summary>
            Up = 0x26,
            /// <summary></summary>
            Right = 0x27,
            /// <summary></summary>
            Down = 0x28,
            /// <summary></summary>
            Select = 0x29,
            /// <summary></summary>
            Print = 0x2A,
            /// <summary></summary>
            Execute = 0x2B,
            /// <summary></summary>
            Snapshot = 0x2C,
            /// <summary></summary>
            Insert = 0x2D,
            /// <summary></summary>
            Delete = 0x2E,
            /// <summary></summary>
            Help = 0x2F,
            /// <summary></summary>
            N0 = 0x30,
            /// <summary></summary>
            N1 = 0x31,
            /// <summary></summary>
            N2 = 0x32,
            /// <summary></summary>
            N3 = 0x33,
            /// <summary></summary>
            N4 = 0x34,
            /// <summary></summary>
            N5 = 0x35,
            /// <summary></summary>
            N6 = 0x36,
            /// <summary></summary>
            N7 = 0x37,
            /// <summary></summary>
            N8 = 0x38,
            /// <summary></summary>
            N9 = 0x39,
            /// <summary></summary>
            A = 0x41,
            /// <summary></summary>
            B = 0x42,
            /// <summary></summary>
            C = 0x43,
            /// <summary></summary>
            D = 0x44,
            /// <summary></summary>
            E = 0x45,
            /// <summary></summary>
            F = 0x46,
            /// <summary></summary>
            G = 0x47,
            /// <summary></summary>
            H = 0x48,
            /// <summary></summary>
            I = 0x49,
            /// <summary></summary>
            J = 0x4A,
            /// <summary></summary>
            K = 0x4B,
            /// <summary></summary>
            L = 0x4C,
            /// <summary></summary>
            M = 0x4D,
            /// <summary></summary>
            N = 0x4E,
            /// <summary></summary>
            O = 0x4F,
            /// <summary></summary>
            P = 0x50,
            /// <summary></summary>
            Q = 0x51,
            /// <summary></summary>
            R = 0x52,
            /// <summary></summary>
            S = 0x53,
            /// <summary></summary>
            T = 0x54,
            /// <summary></summary>
            U = 0x55,
            /// <summary></summary>
            V = 0x56,
            /// <summary></summary>
            W = 0x57,
            /// <summary></summary>
            X = 0x58,
            /// <summary></summary>
            Y = 0x59,
            /// <summary></summary>
            Z = 0x5A,
            /// <summary></summary>
            LeftWindows = 0x5B,
            /// <summary></summary>
            RightWindows = 0x5C,
            /// <summary></summary>
            Application = 0x5D,
            /// <summary></summary>
            Sleep = 0x5F,
            /// <summary></summary>
            Numpad0 = 0x60,
            /// <summary></summary>
            Numpad1 = 0x61,
            /// <summary></summary>
            Numpad2 = 0x62,
            /// <summary></summary>
            Numpad3 = 0x63,
            /// <summary></summary>
            Numpad4 = 0x64,
            /// <summary></summary>
            Numpad5 = 0x65,
            /// <summary></summary>
            Numpad6 = 0x66,
            /// <summary></summary>
            Numpad7 = 0x67,
            /// <summary></summary>
            Numpad8 = 0x68,
            /// <summary></summary>
            Numpad9 = 0x69,
            /// <summary></summary>
            Multiply = 0x6A,
            /// <summary></summary>
            Add = 0x6B,
            /// <summary></summary>
            Separator = 0x6C,
            /// <summary></summary>
            Subtract = 0x6D,
            /// <summary></summary>
            Decimal = 0x6E,
            /// <summary></summary>
            Divide = 0x6F,
            /// <summary></summary>
            F1 = 0x70,
            /// <summary></summary>
            F2 = 0x71,
            /// <summary></summary>
            F3 = 0x72,
            /// <summary></summary>
            F4 = 0x73,
            /// <summary></summary>
            F5 = 0x74,
            /// <summary></summary>
            F6 = 0x75,
            /// <summary></summary>
            F7 = 0x76,
            /// <summary></summary>
            F8 = 0x77,
            /// <summary></summary>
            F9 = 0x78,
            /// <summary></summary>
            F10 = 0x79,
            /// <summary></summary>
            F11 = 0x7A,
            /// <summary></summary>
            F12 = 0x7B,
            /// <summary></summary>
            F13 = 0x7C,
            /// <summary></summary>
            F14 = 0x7D,
            /// <summary></summary>
            F15 = 0x7E,
            /// <summary></summary>
            F16 = 0x7F,
            /// <summary></summary>
            F17 = 0x80,
            /// <summary></summary>
            F18 = 0x81,
            /// <summary></summary>
            F19 = 0x82,
            /// <summary></summary>
            F20 = 0x83,
            /// <summary></summary>
            F21 = 0x84,
            /// <summary></summary>
            F22 = 0x85,
            /// <summary></summary>
            F23 = 0x86,
            /// <summary></summary>
            F24 = 0x87,
            /// <summary></summary>
            NumLock = 0x90,
            /// <summary></summary>
            ScrollLock = 0x91,
            /// <summary></summary>
            NEC_Equal = 0x92,
            /// <summary></summary>
            Fujitsu_Jisho = 0x92,
            /// <summary></summary>
            Fujitsu_Masshou = 0x93,
            /// <summary></summary>
            Fujitsu_Touroku = 0x94,
            /// <summary></summary>
            Fujitsu_Loya = 0x95,
            /// <summary></summary>
            Fujitsu_Roya = 0x96,
            /// <summary></summary>
            LeftShift = 0xA0,
            /// <summary></summary>
            RightShift = 0xA1,
            /// <summary></summary>
            LeftControl = 0xA2,
            /// <summary></summary>
            RightControl = 0xA3,
            /// <summary></summary>
            LeftMenu = 0xA4,
            /// <summary></summary>
            RightMenu = 0xA5,
            /// <summary></summary>
            BrowserBack = 0xA6,
            /// <summary></summary>
            BrowserForward = 0xA7,
            /// <summary></summary>
            BrowserRefresh = 0xA8,
            /// <summary></summary>
            BrowserStop = 0xA9,
            /// <summary></summary>
            BrowserSearch = 0xAA,
            /// <summary></summary>
            BrowserFavorites = 0xAB,
            /// <summary></summary>
            BrowserHome = 0xAC,
            /// <summary></summary>
            VolumeMute = 0xAD,
            /// <summary></summary>
            VolumeDown = 0xAE,
            /// <summary></summary>
            VolumeUp = 0xAF,
            /// <summary></summary>
            MediaNextTrack = 0xB0,
            /// <summary></summary>
            MediaPrevTrack = 0xB1,
            /// <summary></summary>
            MediaStop = 0xB2,
            /// <summary></summary>
            MediaPlayPause = 0xB3,
            /// <summary></summary>
            LaunchMail = 0xB4,
            /// <summary></summary>
            LaunchMediaSelect = 0xB5,
            /// <summary></summary>
            LaunchApplication1 = 0xB6,
            /// <summary></summary>
            LaunchApplication2 = 0xB7,
            /// <summary></summary>
            OEM1 = 0xBA,
            /// <summary></summary>
            OEMPlus = 0xBB,
            /// <summary></summary>
            OEMComma = 0xBC,
            /// <summary></summary>
            OEMMinus = 0xBD,
            /// <summary></summary>
            OEMPeriod = 0xBE,
            /// <summary></summary>
            OEM2 = 0xBF,
            /// <summary></summary>
            OEM3 = 0xC0,
            /// <summary></summary>
            OEM4 = 0xDB,
            /// <summary></summary>
            OEM5 = 0xDC,
            /// <summary></summary>
            OEM6 = 0xDD,
            /// <summary></summary>
            OEM7 = 0xDE,
            /// <summary></summary>
            OEM8 = 0xDF,
            /// <summary></summary>
            OEMAX = 0xE1,
            /// <summary></summary>
            OEM102 = 0xE2,
            /// <summary></summary>
            ICOHelp = 0xE3,
            /// <summary></summary>
            ICO00 = 0xE4,
            /// <summary></summary>
            ProcessKey = 0xE5,
            /// <summary></summary>
            ICOClear = 0xE6,
            /// <summary></summary>
            Packet = 0xE7,
            /// <summary></summary>
            OEMReset = 0xE9,
            /// <summary></summary>
            OEMJump = 0xEA,
            /// <summary></summary>
            OEMPA1 = 0xEB,
            /// <summary></summary>
            OEMPA2 = 0xEC,
            /// <summary></summary>
            OEMPA3 = 0xED,
            /// <summary></summary>
            OEMWSCtrl = 0xEE,
            /// <summary></summary>
            OEMCUSel = 0xEF,
            /// <summary></summary>
            OEMATTN = 0xF0,
            /// <summary></summary>
            OEMFinish = 0xF1,
            /// <summary></summary>
            OEMCopy = 0xF2,
            /// <summary></summary>
            OEMAuto = 0xF3,
            /// <summary></summary>
            OEMENLW = 0xF4,
            /// <summary></summary>
            OEMBackTab = 0xF5,
            /// <summary></summary>
            ATTN = 0xF6,
            /// <summary></summary>
            CRSel = 0xF7,
            /// <summary></summary>
            EXSel = 0xF8,
            /// <summary></summary>
            EREOF = 0xF9,
            /// <summary></summary>
            Play = 0xFA,
            /// <summary></summary>
            Zoom = 0xFB,
            /// <summary></summary>
            Noname = 0xFC,
            /// <summary></summary>
            PA1 = 0xFD,
            /// <summary></summary>
            OEMClear = 0xFE
// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local
        }

        internal enum WindowsQuarter { DIR_NONE, DIR_NE, DIR_NW, DIR_SE, DIR_SW };

        #endregion

        #region Keyboard hook

        private static LowLevelKeyboardMessage _lastKeyboardMessage;

        private static bool _isAltDown;
        private static bool _isShiftDown;
        private static bool _isControlDown;

        public static void KeyboardHook(LowLevelMessage evt, ref bool handled)
        {
            LowLevelKeyboardMessage kevt = evt as LowLevelKeyboardMessage;

            // Prevent further code execution when the key stroke hasn't changed
            if (_lastKeyboardMessage != null)
            {
                bool notchanged = (kevt.Message == _lastKeyboardMessage.Message)
                                  && (kevt.VirtualKeyCode == _lastKeyboardMessage.VirtualKeyCode)
                                  && (kevt.KeyboardEventFlags == _lastKeyboardMessage.KeyboardEventFlags)
                                  && (kevt.ExtraInfo == _lastKeyboardMessage.ExtraInfo);
                    
                if (notchanged)
                    return;
            }
            _lastKeyboardMessage = kevt;

            // Get keyboard state
            switch ((KeyboardMessage)kevt.Message)
            {
                case KeyboardMessage.WM_KEYDOWN:
                case KeyboardMessage.WM_SYSKEYDOWN:
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftMenu) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightMenu))
                        _isAltDown = true;
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftShift) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightShift))
                        _isShiftDown = true;
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftControl) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightControl))
                        _isControlDown = true;
                    break;
                case KeyboardMessage.WM_KEYUP:
                case KeyboardMessage.WM_SYSKEYUP:
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftMenu) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightMenu))
                        _isAltDown = false;
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftShift) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightShift))
                        _isShiftDown = false;
                    if (((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.LeftControl) || ((VirtualKeys)kevt.VirtualKeyCode == VirtualKeys.RightControl))
                        _isControlDown = false;
                    break;
            }
        }

        #endregion

        #region Mouse hook

        private static SystemWindow _currentWindow;
        private static bool _isMoving, _isResizing;
        private static Point _previousPoint;
        private static WindowsQuarter _clickedQuarter;
        private static Dictionary<SystemWindow, RECT> _leftSnapedWindows = new Dictionary<SystemWindow, RECT>();
        private static Dictionary<SystemWindow, RECT> _rightSnapedWindows = new Dictionary<SystemWindow, RECT>();

        public static void MouseHook(LowLevelMessage evt, ref bool handled)
        {
            LowLevelMouseMessage mevt = evt as LowLevelMouseMessage;
            if (mevt != null)
            {
                MouseButtons moveMouseState = Program.Options.MoveOptions.mouseButton;
                MouseButtons resizeMouseState = Program.Options.ResizeOptions.mouseButton;

                switch ((MouseState)mevt.Message)
                {
                    case MouseState.WM_LBUTTONDOWN:
                    case MouseState.WM_RBUTTONDOWN:
                    case MouseState.WM_MBUTTONDOWN:
                        // Get the window to move or resize
                        _currentWindow = GetTopLevel(SystemWindow.FromPoint(mevt.Point.X, mevt.Point.Y));

                        if (TestMoveKeyModifier() && TestMoveMouseState(mevt))
                        {
                            // Now we are moving...
                            _isMoving = true;

                            //... from here to somewhere.
                            _previousPoint = mevt.Point;

                            // Set cursor
                            SystemCursor.SetSystemCursor(Cursors.SizeAll);

                            // Prevent event to be forwarded
                            handled = true;
                        }
                        // Check that:
                        // - we are allowed to resize
                        // - we are not moving
                        // - keys and mouse buttons respect the options
                        else if (_currentWindow.Resizable && !_isMoving && TestResizeKeyModifier() && TestResizeMouseState(mevt))
                        {
                            // Now we are resizing...
                            _isResizing = true;

                            //... from this point/quarter.
                            _previousPoint = mevt.Point;
                            _clickedQuarter = GetQuarterFromPoint(_currentWindow, mevt.Point);

                            // Set cursor
                            if ((_clickedQuarter == WindowsQuarter.DIR_NW) || (_clickedQuarter == WindowsQuarter.DIR_SE))
                                SystemCursor.SetSystemCursor(Cursors.SizeNWSE);
                            else if ((_clickedQuarter == WindowsQuarter.DIR_NE) || (_clickedQuarter == WindowsQuarter.DIR_SW))
                                SystemCursor.SetSystemCursor(Cursors.SizeNESW);

                            // Prevent event to be forwarded
                            handled = true;
                        }
                        break;

                    case MouseState.WM_MOUSEMOVE:
                        if (_isMoving)
                        {
                            int dx = mevt.Point.X - _previousPoint.X;
                            int dy = mevt.Point.Y - _previousPoint.Y;

                            // Only move not left/right snaped window
                            if (!_leftSnapedWindows.ContainsKey(_currentWindow) && !_rightSnapedWindows.ContainsKey(_currentWindow))
                                MoveWindow(_currentWindow, dx, dy);

                            _previousPoint = mevt.Point;

                            // Snap/Unsnap
                            SnapTo(_currentWindow, mevt.Point);
                        }
                        else if (_isResizing)
                        {
                            int dx = mevt.Point.X - _previousPoint.X;
                            int dy = mevt.Point.Y - _previousPoint.Y;

                            // Resize current window
                            ResizeWindow(_currentWindow, dx, dy);

                            _previousPoint = mevt.Point;
                        }
                        break;

                    case MouseState.WM_LBUTTONUP:
                    case MouseState.WM_RBUTTONUP:
                    case MouseState.WM_MBUTTONUP:
                        if (TestMoveMouseState(mevt))
                        {
                            if (_isMoving)
                            {
                                // Prevent event to be forwarded
                                handled = true;

                                // Restore cursor
                                SystemCursor.RestoreSystemCursor();
                            }
                            _isMoving = false;
                        }
                        else if (TestResizeMouseState(mevt))
                        {
                            if (_isResizing)
                            {
                                // Prevent event to be forwarded
                                handled = true;

                                // Restore cursor
                                SystemCursor.RestoreSystemCursor();
                            }
                            _isResizing = false;
                        }

                        break;

                    case MouseState.WM_LBUTTONDBLCLK:
                    case MouseState.WM_RBUTTONDBLCLK:
                    case MouseState.WM_MBUTTONDBLCLK:
                        break;

                    case MouseState.WM_MOUSEWHEEL:
                    case MouseState.WM_MOUSEHWHEEL:
                        break;
                }

                //if (message.Length != 0)
                //    Console.WriteLine("[Mouse] msg:" + message
                //                      + " pt:" + "(" + mevt.Point.X + "," + mevt.Point.Y + ")"
                //                      + " mouseData:" + mevt.MouseData
                //                      + " time:" + mevt.Time
                //                      + " dwExtraInfo:" + mevt.ExtraInfo);
            }
        }

        private static bool TestMoveKeyModifier()
        {
            Keys moveKeyModifier = Program.Options.MoveOptions.keyModifier;

            return (((moveKeyModifier & Keys.Alt) == Keys.Alt) == _isAltDown)
                && (((moveKeyModifier & Keys.Shift) == Keys.Shift) == _isShiftDown)
                && (((moveKeyModifier & Keys.Control) == Keys.Control) == _isControlDown);
            //return (moveKeyModifier & TrayApp.ModifierKeys) == moveKeyModifier;
        }

        private static bool TestMoveMouseState(LowLevelMouseMessage mevt)
        {
            MouseButtons mouseButton = MouseButtons.None;
            switch ((MouseState)mevt.Message)
            {
                case MouseState.WM_LBUTTONDOWN:
                case MouseState.WM_LBUTTONUP:
                    mouseButton = MouseButtons.Left;
                    break;
                case MouseState.WM_MBUTTONDOWN:
                case MouseState.WM_MBUTTONUP:
                    mouseButton = MouseButtons.Middle;
                    break;
                case MouseState.WM_RBUTTONDOWN:
                case MouseState.WM_RBUTTONUP:
                    mouseButton = MouseButtons.Right;
                    break;
            }

            return (Program.Options.MoveOptions.mouseButton == mouseButton);
        }

        private static bool TestResizeKeyModifier()
        {
            Keys resizeKeyModifier = Program.Options.ResizeOptions.keyModifier;

            return (((resizeKeyModifier & Keys.Alt) == Keys.Alt) == _isAltDown)
                && (((resizeKeyModifier & Keys.Shift) == Keys.Shift) == _isShiftDown)
                && (((resizeKeyModifier & Keys.Control) == Keys.Control) == _isControlDown);
            //return (resizeKeyModifier & TrayApp.ModifierKeys) == resizeKeyModifier;
        }

        private static bool TestResizeMouseState(LowLevelMouseMessage mevt)
        {
            MouseButtons mouseButton = MouseButtons.None;
            switch ((MouseState)mevt.Message)
            {
                case MouseState.WM_LBUTTONDOWN:
                case MouseState.WM_LBUTTONUP:
                    mouseButton = MouseButtons.Left;
                    break;
                case MouseState.WM_MBUTTONDOWN:
                case MouseState.WM_MBUTTONUP:
                    mouseButton = MouseButtons.Middle;
                    break;
                case MouseState.WM_RBUTTONDOWN:
                case MouseState.WM_RBUTTONUP:
                    mouseButton = MouseButtons.Right;
                    break;
            }

            return (Program.Options.ResizeOptions.mouseButton == mouseButton);
        }

        private static WindowsQuarter GetQuarterFromPoint(SystemWindow window, Point point)
        {
            WindowsQuarter[,] dirs = {{WindowsQuarter.DIR_NW, WindowsQuarter.DIR_SW},
                                      {WindowsQuarter.DIR_NE, WindowsQuarter.DIR_SE}};

            RECT rect = window.Rectangle;

            int horiz = (Math.Abs(point.X - rect.Left) < Math.Abs(point.X - rect.Right)) ? 0 : 1;
            int vert = (Math.Abs(point.Y - rect.Top) < Math.Abs(point.Y - rect.Bottom)) ? 0 : 1;

            return dirs[horiz, vert];
        }

        private static SystemWindow GetTopLevel(SystemWindow window)
        {
            if (window.ParentSymmetric == null)
                return window;
            return GetTopLevel(window.ParentSymmetric);
        }

        private static void MoveWindow(SystemWindow window, int dx, int dy)
        {
            // Do nothing on a maximized window
            if ((window.Style & WindowStyleFlags.MAXIMIZE) != 0)
                return;

            // Move
            Point oldLocation = window.Location;
            window.Location = new Point(oldLocation.X + dx, oldLocation.Y + dy);
        }

        private static void ResizeWindow(SystemWindow window, int dx, int dy)
        {
            // Do nothing on a maximized window
            if ((window.Style & WindowStyleFlags.MAXIMIZE) != 0)
                return;

            RECT rect = window.Rectangle;
            int x, y, xsz, ysz;

            switch (_clickedQuarter)
            {
                case WindowsQuarter.DIR_SW:
                    dx = -dx;
                    x = rect.Left - dx;
                    y = rect.Top;
                    break;
                case WindowsQuarter.DIR_NW:
                    dx = -dx;
                    dy = -dy;
                    x = rect.Left - dx;
                    y = rect.Top - dy;
                    break;
                case WindowsQuarter.DIR_NE:
                    dy = -dy;
                    x = rect.Left;
                    y = rect.Top - dy;
                    break;
                case WindowsQuarter.DIR_SE:
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

        private static void SnapTo(SystemWindow window, Point point)
        {
            ///
            /// Get curent monitor working area
            /// 
            Rectangle workRect = Screen.FromPoint(point).WorkingArea;

            ///
            ///  Snap/unsnap to top (maximize)
            ///
            if (point.Y < workRect.Top + Program.Options.SnapOptions.TopDistance)
            {
                if (window.WindowState == FormWindowState.Normal)
                {
                    // Highligh the snap point
                    AnimateCursorOnWindow(window, point);

                    // Maximize
                    window.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                // Unsnap from maximized and center window on mouse
                if (window.WindowState == FormWindowState.Maximized)
                {
                    window.WindowState = FormWindowState.Normal;
                    window.Location = new Point(point.X - window.Size.Width / 2, point.Y - window.Size.Height / 2);
                }
            }

            ///
            /// Snap/unsnap on left side
            /// 
            if (point.X < workRect.Left + Program.Options.SnapOptions.LeftDistance)
            {
                // Only snap window that are not already snaped
                if (!_leftSnapedWindows.ContainsKey(window) && !_rightSnapedWindows.ContainsKey(window))
                {
                    // Highligh the snap point
                    AnimateCursorOnWindow(window, point);

                    // Keep currentWindow position
                    _leftSnapedWindows.Add(window, window.Position);

                    // Snap currentWindow
                    window.Location = workRect.Location;
                    window.Size = new Size(workRect.Size.Width / 2,
                                           workRect.Size.Height);
                }
            }

            ///
            /// Snap/unsnap on right side
            /// 
            else if (point.X > workRect.Right - Program.Options.SnapOptions.RightDistance)
            {
                // Only snap window that are not already snaped
                if (!_rightSnapedWindows.ContainsKey(window) && !_leftSnapedWindows.ContainsKey(window))
                {
                    // Highligh the snap point
                    AnimateCursorOnWindow(window, point);

                    // Keep currentWindow position
                    _rightSnapedWindows.Add(window, window.Position);

                    // Snap currentWindow
                    window.Location = new Point(workRect.Location.X + workRect.Size.Width / 2,
                                                workRect.Location.Y);
                    window.Size = new Size(workRect.Size.Width / 2,
                                           workRect.Size.Height);
                }
            }

            ///
            /// Try to restore from left or right snap zones
            else if (_leftSnapedWindows.ContainsKey(window))
            {
                // Restore currentWindow size and center window on mouse
                window.Size = _leftSnapedWindows[window].Size;
                window.Location = new Point(point.X - window.Size.Width / 2, point.Y - window.Size.Height / 2);

                _leftSnapedWindows.Remove(window);
            }
            else if (_rightSnapedWindows.ContainsKey(window))
            {
                // Restore currentWindow size and center window on mouse
                window.Size = _rightSnapedWindows[window].Size;
                window.Location = new Point(point.X - window.Size.Width / 2, point.Y - window.Size.Height / 2);

                _rightSnapedWindows.Remove(window);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport("gdi32.dll")]
        static extern bool DeleteDC(IntPtr hdc);

        private static void AnimateCursorOnWindow(SystemWindow window, Point point)
        {
            new Thread(new ThreadStart(delegate
                                           {
                                               // Create a device context that cover the whole display (all monitors)
                                               IntPtr hDC = CreateDC("DISPLAY", "", "", IntPtr.Zero);

                                               // Get a graphics
                                               using (Graphics g = Graphics.FromHdc(hDC))
                                               {
                                                   const int radius = 30;

                                                   g.SmoothingMode = SmoothingMode.AntiAlias;
                                                   g.CompositingMode = CompositingMode.SourceOver;
                                                   g.Clip = new Region(new Rectangle(point.X - (radius + 10) / 2, point.Y - (radius + 10) / 2,
                                                                                     radius + 10, radius + 10));

                                                   // Draw a growing circle upon the cursor
                                                   Brush trans = Brushes.Transparent;
                                                   Pen penGr = new Pen(Color.LightGray, 1);
                                                   Pen penDG = new Pen(Color.DimGray, 1);
                                                   Pen penLG = new Pen(Color.LightGray, 1);

                                                   for (int j = 0; j < 2; j++)
                                                   {
                                                       for (int i = 0; i < radius; i+=2)
                                                       {
                                                           Rectangle ellRect = new Rectangle(point.X - i / 2, point.Y - i / 2, i, i);

                                                           g.FillEllipse(trans, ellRect);
                                                           ellRect.Inflate(1, 1);
                                                           g.DrawEllipse(penGr, ellRect);
                                                           ellRect.Inflate(1, 1);
                                                           g.DrawEllipse(penDG, ellRect);
                                                           ellRect.Inflate(1, 1);
                                                           g.DrawEllipse(penLG, ellRect);

                                                           //g.Clear(Color.Transparent);

                                                           window.Refresh();
                                                       }

                                                       window.Refresh();
                                                   }
                                               }

                                               // Delete the device context
                                               DeleteDC(hDC);
                                           }
                           )).Start();
        }

        #endregion

        #region Native imports

        internal enum MonitorFromPointFlag : uint
        {
            MONITOR_DEFAULTTONULL     =  0x00000000,
            MONITOR_DEFAULTTOPRIMARY  =  0x00000001,
            MONITOR_DEFAULTTONEAREST  =  0x00000002
        }

        [DllImport("user32.dll")]
        static extern IntPtr MonitorFromPoint(Point pt, uint dwFlags);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct MonitorInfoEx
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx lpmi);

        #endregion
    }
}
 