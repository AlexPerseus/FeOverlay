using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace FeOverlay
{
    public class Log
    {
        string _path;
        public Log(string path)
        {
            _path = path;
        }
        public string Error(string msg, object var = null)
        {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            StreamWriter streamWriter = new StreamWriter(_path, true);
            var str = DateTime.Now.ToString("[hh:mm:ss] ",
                System.Globalization.DateTimeFormatInfo.InvariantInfo) +
                msg + ((var != null) ? " : " + var.ToString() : "");
            Console.WriteLine(str);
            streamWriter.WriteLine("[ERROR]" + str);
            streamWriter.Close();
            streamWriter.Dispose();
            SystemSounds.Hand.Play();
            Console.ForegroundColor = col;
            return str;
        }
        public string Msg(string msg, object var = null)
        {
            ConsoleColor col = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            var str = DateTime.Now.ToString("[hh:mm:ss] ",
    System.Globalization.DateTimeFormatInfo.InvariantInfo) +
    msg + ((var != null) ? " : " + var.ToString() : "");
            Console.WriteLine(str);
#if DEBUG
            StreamWriter streamWriter = new StreamWriter(_path, true);
            streamWriter.WriteLine("[MSG]" + str);
            streamWriter.Close();
            streamWriter.Dispose();
#endif
            Console.ForegroundColor = col;
            return str;
            
        }
    }
}
