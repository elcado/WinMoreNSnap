using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace WinMoreNSnap
{
    class OptionsManager
    {
        public KBMOptions MoveOptions;
        public KBMOptions ResizeOptions;
        public SnapingOptions SnapOptions;

        /// <summary>
        /// Keyboard and mouse options
        /// </summary>
        public struct KBMOptions
        {
            public Keys keyModifier;
            public MouseButtons mouseButton;

            public bool TestKeyModifier(Keys key)
            {
                // Check if options modifiers and key are identical
                return (((keyModifier & Keys.Alt) == Keys.Alt) == ((key & Keys.Alt) == Keys.Alt))
                    && (((keyModifier & Keys.Shift) == Keys.Shift) == ((key & Keys.Shift) == Keys.Shift))
                    && (((keyModifier & Keys.Control) == Keys.Control) == ((key & Keys.Control) == Keys.Control));
            }
            public bool TestMouseButton(MouseButtons button)
            {
                // Check if options modifiers and key are identical
                return (((mouseButton & MouseButtons.Left) == MouseButtons.Left) == ((button & MouseButtons.Left) == MouseButtons.Left))
                    && (((mouseButton & MouseButtons.Right) == MouseButtons.Right) == ((button & MouseButtons.Right) == MouseButtons.Right));
            }
        }

        /// <summary>
        /// Snaping options
        /// </summary>
        public struct SnapingOptions
        {
            public int TopDistance;
            public int LeftDistance;
            public int RightDistance;
            public int BottomDistance;

            public bool TestTopDistance(Point point)
            {
                return point.Y < SystemWindow.DesktopWindow.Rectangle.Top + TopDistance;
            }
            public bool TestLeftDistance(Point point)
            {
                return point.X < SystemWindow.DesktopWindow.Rectangle.Left + LeftDistance;
            }
            public bool TestRightDistance(Point point)
            {
                return point.X > SystemWindow.DesktopWindow.Rectangle.Right - RightDistance;
            }
            public bool TestBottomDistance(Point point)
            {
                return point.Y > SystemWindow.DesktopWindow.Rectangle.Bottom - BottomDistance;
            }
        }
    }
}
