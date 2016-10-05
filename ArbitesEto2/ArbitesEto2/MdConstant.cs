using System;
using Eto.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class MdConstant
    {
        public static Size MenuItemSize = new Size(64, 64);
        public static char psep = System.IO.Path.DirectorySeparatorChar;

        public static string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        public static string N_PERSISTENT_DATA = "persistent-data.arb2pd";
        public static string N_CONFIG = "config.arb2cfg";
        public static string N_ICON = "favicon.ico";

        public static string D_KEYBOARD = "keyboard-type";
        public static string D_KEYGROUP = "keygroup";
        public static string D_INPUT_METHOD = "input-method";


        public static string E_KEYGROUP = ".arb2kg";
        public static string E_KEYBOARD = ".arb2kt";
        public static string E_INPUT_METHOD = ".arb2im";


    }
}
