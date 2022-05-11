using System.Drawing;
using System.Runtime.InteropServices;

namespace LockCursorInMonitor.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public class Rect
    {
        #region Variables.
        /// <summary>
        /// Left position of the rectangle.
        /// </summary>
        public int Left;
        /// <summary>
        /// Top position of the rectangle.
        /// </summary>
        public int Top;
        /// <summary>
        /// Right position of the rectangle.
        /// </summary>
        public int Right;
        /// <summary>
        /// Bottom position of the rectangle.
        /// </summary>
        public int Bottom;
        #endregion

        #region Operators.
        /// <summary>
        /// Operator to convert a RECT to Drawing.Rectangle.
        /// </summary>
        /// <param name="rect">Rectangle to convert.</param>
        /// <returns>A Drawing.Rectangle</returns>
        public static implicit operator Rectangle(Rect rect)
        {
            return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Operator to convert Drawing.Rectangle to a RECT.
        /// </summary>
        /// <param name="rect">Rectangle to convert.</param>
        /// <returns>RECT rectangle.</returns>
        public static implicit operator Rect(Rectangle rect)
        {
            return new Rect(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Operator to convert a RECT to RectStruct.
        /// </summary>
        /// <param name="rect">RectStruct to convert.</param>
        /// <returns>RECT rectangle.</returns>
        public static implicit operator Rect(RectStruct rect)
        {
            return new Rect(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
        #endregion

        #region Constructor.
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="left">Horizontal position.</param>
        /// <param name="top">Vertical position.</param>
        /// <param name="right">Right most side.</param>
        /// <param name="bottom">Bottom most side.</param>
        public Rect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public Rect(System.Windows.Rect rect)
        {
            Left = (int)rect.Left;
            Top = (int)rect.Top;
            Right = (int)rect.Right;
            Bottom = (int)rect.Bottom;
        }

        public Rect()
        {
            Left = 0;
            Top = 0;
            Right = 0;
            Bottom = 0;
        }
        #endregion

        public bool Equals(Rect obj)
        {
            return obj.Left == Left && obj.Top == Top && obj.Right == Right && obj.Bottom == Bottom;
        }
    }
}
