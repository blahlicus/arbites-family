using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    class MdGlobals
    {
        public static string SERIAL_SET_LAYER_COMMAND { get; set; }
        public static UCBoard board { get; set; }
        public static FmKeySelector kselect { get; set; }
        public static ClKeyboard boardType { get; set; }
        public static bool selectedSpecial { get; set; }
        public static ClKey selectedKey { get; set; }
        public static FmMain mainForm { get; set; }

        public static void Initiate()
        {
            SERIAL_SET_LAYER_COMMAND = "uniqueksetlayer";
            selectedSpecial = false;
            selectedKey = new ClKey();
            kselect = new FmKeySelector();
            kselect.Topmost = true;
        }
    }
}
