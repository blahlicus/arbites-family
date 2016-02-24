using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    class MdGlobals
    {
        public static string SERIAL_SET_LAYER_COMMAND { get; set; }
        public static UCBoard board { get; set; }
        public static ClKeyboard boardType { get; set; }

        public static void Initiate()
        {
            SERIAL_SET_LAYER_COMMAND = "uniqueksetlayer";
        }
    }
}
