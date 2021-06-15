using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace listView_Test
{
    class GDI32
    {
        public enum DrawingMode
        {
            R2_NOTXORPEN = 10
        }

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll")]
        public static extern int SetROP2(IntPtr hDC, int fnDrawMode);

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hDC, int x, int y, ref Point p);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObj);

        static private Point nullPoint = new Point(0, 0);

        // Convert the Argb from .NET to a gdi32 RGB
        static private int ArgbToRGB(int rgb)
        {
            return ((rgb >> 16 & 0x0000FF) | (rgb & 0x00FF00) | (rgb << 16 & 0xFF0000));
        }
        static public void DrawXORRectangle(Graphics graphics, Pen pen, Rectangle rectangle)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)DrawingMode.R2_NOTXORPEN);
            Rectangle(hDC, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }

        static public void DrawXORLine(Graphics graphics, Pen pen, int x1, int y1, int x2, int y2)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)DrawingMode.R2_NOTXORPEN);
            MoveToEx(hDC, x1, y1, ref nullPoint);
            LineTo(hDC, x2, y2);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }
    }
}
