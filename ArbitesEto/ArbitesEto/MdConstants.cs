using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    class MdConstants
    {
        public static char pseparator = System.IO.Path.DirectorySeparatorChar;
        public static string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        public static string keyboards = root + pseparator+ @"keyboards";
        public static string keygroups = root + pseparator + @"keygroups";


        public static string eKeyboards = @"*.uktb";
        public static string eKeygroups = @"*.ukkg";
    }
}
