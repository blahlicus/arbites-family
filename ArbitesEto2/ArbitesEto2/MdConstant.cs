using System.IO;
using System.Reflection;
using Eto.Drawing;

namespace ArbitesEto2
{
    public class MdConstant
    {
        public static Size MenuItemSize = new Size(64, 64);
        // ReSharper disable once InconsistentNaming
        public static char psep = Path.DirectorySeparatorChar;

        // ReSharper disable once InconsistentNaming
        public static string root = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        // AVRDUDE location, does not require write access
        public static string windowsAvrdudeLocation = Path.Combine(root, "avrdude");

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
