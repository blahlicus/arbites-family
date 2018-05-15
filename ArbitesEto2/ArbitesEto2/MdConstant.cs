using System.IO;
using System.Reflection;
using Eto.Drawing;

namespace ArbitesEto2
{
    public class MdConstant
    {
        public static Size MenuItemSize = new Size(64, 64);

        public static char PathSeparator = Path.DirectorySeparatorChar;

        public static string Root => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        // AVRDUDE location, does not require write access
        public static string WindowsAvrdudeLocation => Path.Combine(Root, "avrdude");

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
