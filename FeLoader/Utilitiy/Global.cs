using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FeOverlay
{
    public static  class Global
    {
        //Initialization of log
        public static Log Log = new Log("FeOverlay.txt");

        //Declaring rendering
        public static Rendering Render = new Rendering();

        //Declaring hooking
        public static class Hooks
        {
            public static KeyboardHook Keyboard = new KeyboardHook();
            public static ExplorerHook Explorer  = new ExplorerHook();
        }
    }
}
