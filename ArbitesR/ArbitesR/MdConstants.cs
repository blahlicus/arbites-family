using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    class MdConstants
    {
        public static char pseparator = System.IO.Path.DirectorySeparatorChar;
        public static string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public static string keyboards = root + pseparator+ @"keyboards";


        public static string eKeyboards = @"*.uktb";
    }
}
