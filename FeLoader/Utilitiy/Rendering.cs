using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeOverlay
{

    public class Rendering
    {
        private const int DCX_WINDOW = 0x00000001;
        private const int DCX_CACHE = 0x00000002;
        private const int DCX_LOCKWINDOWUPDATE = 0x00000400;
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgn, uint flags);
        bool firsttime = true;
        IntPtr hdc;
        
        //Return a gdi+ graphics variable
        public Graphics Get()
        {
            if (firsttime) 
            hdc = GetDCEx(GetDesktopWindow(),
                        IntPtr.Zero,
                        DCX_WINDOW | 0x00000004 | DCX_LOCKWINDOWUPDATE);
            firsttime = false;
            return Graphics.FromHdc(hdc);
        }

        //Very basic but decent example of a rendering function
        public void DrawRectangle(int x, int y, int w, int h, Color color)
        {
            var bmpScreenshot = new Bitmap(w,
                h,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(y + 1,
                        x + 1,
                        w - 1,
                        h - 1,
                        Screen.PrimaryScreen.Bounds.Size,
                        CopyPixelOperation.SourceCopy);
            Global.Render.Get().DrawRectangle(new Pen(color), new Rectangle(x, y, w, h));
        }
        public void FillRectangle(int x, int y, int w, int h, Color color)
        {
            Global.Render.Get().FillRectangle(new SolidBrush(color), new Rectangle(x, y, w, h));
        }
        public void DrawText(int x, int y, string str, Color color)
        {
            int w, h;
            w = (int)Global.Render.Get().MeasureString(str, SystemFonts.MessageBoxFont).Width;
            h = (int)Global.Render.Get().MeasureString(str, SystemFonts.MessageBoxFont).Height;
            var bmpScreenshot = new Bitmap(w,
    h,
    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(y + 1,
                        x + 1,
                        w - 1,
                        h - 1,
                        Screen.PrimaryScreen.Bounds.Size,
                        CopyPixelOperation.SourceCopy);
            Global.Render.Get().DrawString(str, SystemFonts.MessageBoxFont,
                new SolidBrush(color), new Point(x, y));
        }
        //Disposing resources used by rendering not needed for personal use but greatly influenced
        public void Dispose()
        {
            Get().Dispose();
        }
    }
}
