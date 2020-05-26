using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeOverlay
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern void Sleep(UInt32 dwMilieconds);
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        //Simple usage of the rendering
        static void RenderTest()
        {
            while (true)
            {
                Global.Render.DrawRectangle(400, 400, 100, 150, Color.Red);
                Global.Render.FillRectangle(401, 401, 100 - 2, 20 - 2, Color.Black);
                Global.Render.DrawText(425, 405, "Terrorist", Color.White);
            }
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                //Dispose hooks
                Global.Log.Msg("Program exiting, disposing of all hooks");
                Global.Render.Dispose();
                Global.Log.Msg("Rendering", "Disposed");
                Global.Hooks.Keyboard.Dispose();
                Global.Log.Msg("Keyboard Hook", "Disposed");
                Global.Hooks.Explorer.Dispose();
                Global.Log.Msg("Explorer Hook", "Disposed");
            }
            return false;
        }

        static ConsoleEventDelegate handler;

        static void Main(string[] args)
        {
            //Set console title
            Console.Title = "FeOverlay";
            Global.Log.Msg("Initializing");

            //Create event handler of onclosing
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            //Hook keyboard // key sup
            if (Global.Hooks.Keyboard.Hook())
                Global.Log.Msg("Keyboard Hook", "Hooked");
            else
                Global.Log.Error("Keyboard Hook", "Hooking Failed");

            //Hook taskbar hide and start menu hide
            if (Global.Hooks.Explorer.Hook())
                Global.Log.Msg("Explorer Hook", "Hooked");
            else
                Global.Log.Error("Explorer Hook", "Hooking Failed");
            
            //Start render thread
            new Thread(RenderTest).Start();
            Global.Log.Msg("Rendering thread has been started");

            //Display base address
            Global.Log.Msg("Initialized", "0x" + Process.GetCurrentProcess().MainModule.BaseAddress);

            //Stop app from closing
            Console.Read();
        }
    }
}