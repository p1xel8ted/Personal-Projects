using System.Windows.Forms;
using LockCursorInMonitor.Interop;
using Point = System.Drawing.Point;

namespace LockCursorInMonitor
{
    class CursorLock
    {
        private static bool _locked;

        public static bool Locked 
        { 
            get => _locked;
            set 
            {
                _locked = value; 
            } 
        }

        public static void LockCursor()
        {
            var bounds = GetCursorBounds();
            // Confine the cursor to that monitor.
            Native.ClipCursor(bounds);
            Locked = true;
        }

        public static void UnlockCursor()
        {
            Native.ClipCursor(null);
            Locked = false;
        }

        public static Rect GetCursorBounds()
        {
            // Get the position of the cursor.
            Point mousePoint = Native.GetCursorPos();
            // Get the bounds of the screen that the cursor is on.
            return Screen.GetBounds(mousePoint);
        }
    }
}
