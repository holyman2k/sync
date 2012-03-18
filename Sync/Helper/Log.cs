using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sync.Helper
{
    class Log
    {
        public static void log(string message, params object[] objects)
        {
            Console.WriteLine(message, objects);
        }

        public static void trace(string message, params object[] objects)
        {
            if (CurrentMode.LogMode == Mode.Verbose)
                Console.WriteLine(message, objects);
        }
    }
}
