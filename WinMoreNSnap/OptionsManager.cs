using System.Windows.Forms;

namespace WinMoreNSnap
{
    public class OptionsManager
    {
        public bool IsActive;
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
        }
    }
}
