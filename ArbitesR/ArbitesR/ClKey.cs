using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClKey
    {
        public Byte val { get; set; }
        public Byte ktype { get; set; }
        public string display { get; set; }

        public ClKey()
        {
            val = 0;
            display = "Null";
            ktype = 255;
        }

        public ClKey(byte val, Byte ktype, string display)
        {
            this.val = val;
            this.ktype = ktype;
            this.display = display;
        }

        public static List<ClKey> dKeys { get; set; }

        public static void iniList()
        {
            dKeys = new List<ClKey>();
            dKeys.Add(new ClKey(Convert.ToByte('a'), 0, "a")); dKeys.Add(new ClKey(194, 0, "F1")); dKeys.Add(new ClKey(128, 0, "L Ctrl"));
            dKeys.Add(new ClKey(Convert.ToByte('b'), 0, "b")); dKeys.Add(new ClKey(195, 0, "F2")); dKeys.Add(new ClKey(132, 0, "R Ctrl"));
            dKeys.Add(new ClKey(Convert.ToByte('c'), 0, "c")); dKeys.Add(new ClKey(196, 0, "F3")); dKeys.Add(new ClKey(129, 0, "L Shift"));
            dKeys.Add(new ClKey(Convert.ToByte('d'), 0, "d")); dKeys.Add(new ClKey(197, 0, "F4")); dKeys.Add(new ClKey(133, 0, "R Shift"));
            dKeys.Add(new ClKey(Convert.ToByte('e'), 0, "e")); dKeys.Add(new ClKey(198, 0, "F5")); dKeys.Add(new ClKey(130, 0, "L Alt"));
            dKeys.Add(new ClKey(Convert.ToByte('f'), 0, "f")); dKeys.Add(new ClKey(199, 0, "F6")); dKeys.Add(new ClKey(134, 0, "R Alt"));
            dKeys.Add(new ClKey(Convert.ToByte('g'), 0, "g")); dKeys.Add(new ClKey(200, 0, "F7")); dKeys.Add(new ClKey(131, 0, "L Super"));
            dKeys.Add(new ClKey(Convert.ToByte('h'), 0, "h")); dKeys.Add(new ClKey(201, 0, "F8")); dKeys.Add(new ClKey(135, 0, "R Super"));
            dKeys.Add(new ClKey(Convert.ToByte('i'), 0, "i")); dKeys.Add(new ClKey(202, 0, "F9")); dKeys.Add(new ClKey(218, 0, "Up"));
            dKeys.Add(new ClKey(Convert.ToByte('j'), 0, "j")); dKeys.Add(new ClKey(203, 0, "F10")); dKeys.Add(new ClKey(217, 0, "Down"));
            dKeys.Add(new ClKey(Convert.ToByte('k'), 0, "k")); dKeys.Add(new ClKey(204, 0, "F11")); dKeys.Add(new ClKey(216, 0, "Left"));
            dKeys.Add(new ClKey(Convert.ToByte('l'), 0, "l")); dKeys.Add(new ClKey(205, 0, "F12")); dKeys.Add(new ClKey(215, 0, "Right"));
            dKeys.Add(new ClKey(Convert.ToByte('m'), 0, "m")); dKeys.Add(new ClKey(178, 0, "BkSpace")); dKeys.Add(new ClKey((136 + 71), 0, "ScrlLck"));
            dKeys.Add(new ClKey(Convert.ToByte('n'), 0, "n")); dKeys.Add(new ClKey(179, 0, "Tab")); dKeys.Add(new ClKey((136 + 70), 0, "PrtSc"));
            dKeys.Add(new ClKey(Convert.ToByte('o'), 0, "o")); dKeys.Add(new ClKey(176, 0, "Enter")); dKeys.Add(new ClKey((136 + 72), 0, "PsBrk"));
            dKeys.Add(new ClKey(Convert.ToByte('p'), 0, "p")); dKeys.Add(new ClKey(177, 0, "Esc"));
            dKeys.Add(new ClKey(Convert.ToByte('q'), 0, "q")); dKeys.Add(new ClKey(209, 0, "Insert"));
            dKeys.Add(new ClKey(Convert.ToByte('r'), 0, "r")); dKeys.Add(new ClKey(212, 0, "Delete"));
            dKeys.Add(new ClKey(Convert.ToByte('s'), 0, "s")); dKeys.Add(new ClKey(211, 0, "Pg Up"));
            dKeys.Add(new ClKey(Convert.ToByte('t'), 0, "t")); dKeys.Add(new ClKey(214, 0, "Pg Dn"));
            dKeys.Add(new ClKey(Convert.ToByte('u'), 0, "u")); dKeys.Add(new ClKey(210, 0, "Home"));
            dKeys.Add(new ClKey(Convert.ToByte('v'), 0, "v")); dKeys.Add(new ClKey(213, 0, "End"));
            dKeys.Add(new ClKey(Convert.ToByte('w'), 0, "w")); dKeys.Add(new ClKey(193, 0, "Capslock"));
            dKeys.Add(new ClKey(Convert.ToByte('x'), 0, "x"));
            dKeys.Add(new ClKey(Convert.ToByte('y'), 0, "y"));
            dKeys.Add(new ClKey(Convert.ToByte('z'), 0, "z"));
            dKeys.Add(new ClKey(32, 0, "Space"));
            // symbols
            dKeys.Add(new ClKey(91, 0, "[ {")); /* [ { */
            dKeys.Add(new ClKey(93, 0, "] }")); /* ] } */
            dKeys.Add(new ClKey(92, 0, @"\ |")); /* \ | */
            dKeys.Add(new ClKey(59, 0, "); :")); /* ); : */
            dKeys.Add(new ClKey(39, 0, "' \"")); /* ' " */
            dKeys.Add(new ClKey(45, 0, "- _")); /* - _ */
            dKeys.Add(new ClKey(61, 0, "= +")); /*(+ */
            dKeys.Add(new ClKey(47, 0, "/ ?")); /* / ? */
            dKeys.Add(new ClKey(96, 0, "` ~")); /* ` ~ */
            dKeys.Add(new ClKey(44, 0, ", <")); /* , < */
            dKeys.Add(new ClKey(46, 0, ". >")); /* . > */

            // numbers
            dKeys.Add(new ClKey(Convert.ToByte('0'), 0, "0"));
            dKeys.Add(new ClKey(Convert.ToByte('1'), 0, "1"));
            dKeys.Add(new ClKey(Convert.ToByte('2'), 0, "2"));
            dKeys.Add(new ClKey(Convert.ToByte('3'), 0, "3"));
            dKeys.Add(new ClKey(Convert.ToByte('4'), 0, "4"));
            dKeys.Add(new ClKey(Convert.ToByte('5'), 0, "5"));
            dKeys.Add(new ClKey(Convert.ToByte('6'), 0, "6"));
            dKeys.Add(new ClKey(Convert.ToByte('7'), 0, "7"));
            dKeys.Add(new ClKey(Convert.ToByte('8'), 0, "8"));
            dKeys.Add(new ClKey(Convert.ToByte('9'), 0, "9"));

            // numpad
            dKeys.Add(new ClKey(220, 0, "NPad /")); /* numpad / */
            dKeys.Add(new ClKey(221, 0, "NPad *")); /* numpad * */
            dKeys.Add(new ClKey(222, 0, "NPad -")); /* numpad - */
            dKeys.Add(new ClKey(223, 0, "NPad +")); /* numpad + */
            dKeys.Add(new ClKey(224, 0, "NPad Enter")); /* numpad enter */
            dKeys.Add(new ClKey(225, 0, "NPad 1")); /* numpad 1 */
            dKeys.Add(new ClKey(226, 0, "NPad 2")); /* numpad 2 */
            dKeys.Add(new ClKey(227, 0, "NPad 3")); /* numpad 3 */
            dKeys.Add(new ClKey(228, 0, "NPad 4")); /* numpad 4 */
            dKeys.Add(new ClKey(229, 0, "NPad 5")); /* numpad 5 */
            dKeys.Add(new ClKey(230, 0, "NPad 6")); /* numpad 6 */
            dKeys.Add(new ClKey(231, 0, "NPad 7")); /* numpad 7 */
            dKeys.Add(new ClKey(232, 0, "NPad 8")); /* numpad 8 */
            dKeys.Add(new ClKey(233, 0, "NPad 9")); /* numpad 9 */
            dKeys.Add(new ClKey(234, 0, "NPad 0")); /* numpad 0 */
            dKeys.Add(new ClKey(235, 0, "NPad .")); /* numpad . */

            // special keys
            /*   INDEX
            1 fn (x) x = layer
            2 space fn (x) x = layer
            3 layer operation (x) x = up or down
            4 media keys (x) x = options
              0 vol up
              1 vol down
              2 vol mute
              3 med play
              4 med stop
              5 med next
              6 med back

            255 null
            */
            dKeys.Add(new ClKey(1, 1, "Fn"));
            dKeys.Add(new ClKey(2, 1, "Fn2"));
            dKeys.Add(new ClKey(3, 1, "Fn3"));
            dKeys.Add(new ClKey(4, 1, "Fn4"));
            dKeys.Add(new ClKey(5, 1, "Fn5"));
            dKeys.Add(new ClKey(6, 1, "Fn6"));
            dKeys.Add(new ClKey(1, 2, "spaceFn"));
            dKeys.Add(new ClKey(2, 2, "spaceFn2"));
            dKeys.Add(new ClKey(3, 2, "spaceFn3"));
            dKeys.Add(new ClKey(4, 2, "spaceFn4"));
            dKeys.Add(new ClKey(5, 2, "spaceFn5"));
            dKeys.Add(new ClKey(6, 2, "spaceFn6"));

            dKeys.Add(new ClKey(0, 3, "Layer Dn"));
            dKeys.Add(new ClKey(1, 3, "Layer Up"));
            dKeys.Add(new ClKey(0, 4, "Vol Up"));
            dKeys.Add(new ClKey(1, 4, "Vol Dn"));
            dKeys.Add(new ClKey(2, 4, "Mute"));
            dKeys.Add(new ClKey(3, 4, "M Play"));
            dKeys.Add(new ClKey(4, 4, "M Pause"));
            dKeys.Add(new ClKey(5, 4, "M Next"));
            dKeys.Add(new ClKey(6, 4, "M Back"));
            dKeys.Add(new ClKey(1, 5, "toggleFn"));
            dKeys.Add(new ClKey(2, 5, "toggleFn2"));
            dKeys.Add(new ClKey(3, 5, "toggleFn3"));
            dKeys.Add(new ClKey(4, 5, "toggleFn4"));
            dKeys.Add(new ClKey(5, 5, "toggleFn5"));
            dKeys.Add(new ClKey(6, 5, "toggleFn6"));


            dKeys.Add(new ClKey(0, 255, "Null"));
        }

        public static string GetDisplayFromChar(char input)
        {
            if (dKeys.Find(k => k.val == Convert.ToByte(input)) != null && dKeys.Find(k => k.val == Convert.ToByte(input)).ktype == 0)
            {
                return dKeys.Find(k => k.val == Convert.ToByte(input)).display;
            }
            return "";
        }

        public static ClKey GetKeyFromChar(char input)
        {
            if (dKeys.Find(k => k.val == Convert.ToByte(input)) != null && dKeys.Find(k => k.val == Convert.ToByte(input)).ktype == 0)
            {
                return dKeys.Find(k => k.val == Convert.ToByte(input));
            }
            return new ClKey();
        }
    }
}
