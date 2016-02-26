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
        public static List<ClKey> alpha { get; set; }
        public static List<ClKey> numeric { get; set; }
        public static List<ClKey> symbol { get; set; }
        public static List<ClKey> numpad { get; set; }
        public static List<ClKey> control { get; set; }
        public static List<ClKey> special { get; set; }
        public static List<List<ClKey>> lists { get; set; }
        public static void iniList()
        {

            dKeys = new List<ClKey>();
            alpha = new List<ClKey>();
            numeric = new List<ClKey>();
            symbol = new List<ClKey>();
            numpad = new List<ClKey>();
            control = new List<ClKey>();
            special = new List<ClKey>();
            lists = new List<List<ClKey>>();
            lists.Add(dKeys);
            lists.Add(alpha);
            lists.Add(numeric);
            lists.Add(symbol);
            lists.Add(numpad);
            lists.Add(control);
            lists.Add(special);

            // alphas

            alpha.Add(new ClKey(Convert.ToByte('a'), 0, "a"));
            alpha.Add(new ClKey(Convert.ToByte('b'), 0, "b"));
            alpha.Add(new ClKey(Convert.ToByte('c'), 0, "c"));
            alpha.Add(new ClKey(Convert.ToByte('d'), 0, "d"));
            alpha.Add(new ClKey(Convert.ToByte('e'), 0, "e"));
            alpha.Add(new ClKey(Convert.ToByte('f'), 0, "f"));
            alpha.Add(new ClKey(Convert.ToByte('g'), 0, "g"));
            alpha.Add(new ClKey(Convert.ToByte('h'), 0, "h"));
            alpha.Add(new ClKey(Convert.ToByte('i'), 0, "i"));
            alpha.Add(new ClKey(Convert.ToByte('j'), 0, "j"));
            alpha.Add(new ClKey(Convert.ToByte('k'), 0, "k"));
            alpha.Add(new ClKey(Convert.ToByte('l'), 0, "l"));
            alpha.Add(new ClKey(Convert.ToByte('m'), 0, "m"));
            alpha.Add(new ClKey(Convert.ToByte('n'), 0, "n"));
            alpha.Add(new ClKey(Convert.ToByte('o'), 0, "o"));
            alpha.Add(new ClKey(Convert.ToByte('p'), 0, "p"));
            alpha.Add(new ClKey(Convert.ToByte('q'), 0, "q"));
            alpha.Add(new ClKey(Convert.ToByte('r'), 0, "r"));
            alpha.Add(new ClKey(Convert.ToByte('s'), 0, "s"));
            alpha.Add(new ClKey(Convert.ToByte('t'), 0, "t"));
            alpha.Add(new ClKey(Convert.ToByte('u'), 0, "u"));
            alpha.Add(new ClKey(Convert.ToByte('v'), 0, "v"));
            alpha.Add(new ClKey(Convert.ToByte('w'), 0, "w"));
            alpha.Add(new ClKey(Convert.ToByte('x'), 0, "x"));
            alpha.Add(new ClKey(Convert.ToByte('y'), 0, "y"));
            alpha.Add(new ClKey(Convert.ToByte('z'), 0, "z"));

            // numeric

            numeric.Add(new ClKey(Convert.ToByte('0'), 0, "0"));
            numeric.Add(new ClKey(Convert.ToByte('1'), 0, "1"));
            numeric.Add(new ClKey(Convert.ToByte('2'), 0, "2"));
            numeric.Add(new ClKey(Convert.ToByte('3'), 0, "3"));
            numeric.Add(new ClKey(Convert.ToByte('4'), 0, "4"));
            numeric.Add(new ClKey(Convert.ToByte('5'), 0, "5"));
            numeric.Add(new ClKey(Convert.ToByte('6'), 0, "6"));
            numeric.Add(new ClKey(Convert.ToByte('7'), 0, "7"));
            numeric.Add(new ClKey(Convert.ToByte('8'), 0, "8"));
            numeric.Add(new ClKey(Convert.ToByte('9'), 0, "9"));


            // npad

            numpad.Add(new ClKey(220, 0, "NPad /")); /* numpad / */
            numpad.Add(new ClKey(221, 0, "NPad *")); /* numpad * */
            numpad.Add(new ClKey(222, 0, "NPad -")); /* numpad - */
            numpad.Add(new ClKey(223, 0, "NPad +")); /* numpad + */
            numpad.Add(new ClKey(224, 0, "NPad Enter")); /* numpad enter */
            numpad.Add(new ClKey(225, 0, "NPad 1")); /* numpad 1 */
            numpad.Add(new ClKey(226, 0, "NPad 2")); /* numpad 2 */
            numpad.Add(new ClKey(227, 0, "NPad 3")); /* numpad 3 */
            numpad.Add(new ClKey(228, 0, "NPad 4")); /* numpad 4 */
            numpad.Add(new ClKey(229, 0, "NPad 5")); /* numpad 5 */
            numpad.Add(new ClKey(230, 0, "NPad 6")); /* numpad 6 */
            numpad.Add(new ClKey(231, 0, "NPad 7")); /* numpad 7 */
            numpad.Add(new ClKey(232, 0, "NPad 8")); /* numpad 8 */
            numpad.Add(new ClKey(233, 0, "NPad 9")); /* numpad 9 */
            numpad.Add(new ClKey(234, 0, "NPad 0")); /* numpad 0 */
            numpad.Add(new ClKey(235, 0, "NPad .")); /* numpad . */

            // control
            control.Add(new ClKey(194, 0, "F1")); control.Add(new ClKey(128, 0, "L Ctrl"));
            control.Add(new ClKey(195, 0, "F2")); control.Add(new ClKey(132, 0, "R Ctrl"));
            control.Add(new ClKey(196, 0, "F3")); control.Add(new ClKey(129, 0, "L Shift"));
            control.Add(new ClKey(197, 0, "F4")); control.Add(new ClKey(133, 0, "R Shift"));
            control.Add(new ClKey(198, 0, "F5")); control.Add(new ClKey(130, 0, "L Alt"));
            control.Add(new ClKey(199, 0, "F6")); control.Add(new ClKey(134, 0, "R Alt"));
            control.Add(new ClKey(200, 0, "F7")); control.Add(new ClKey(131, 0, "L Super"));
            control.Add(new ClKey(201, 0, "F8")); control.Add(new ClKey(135, 0, "R Super"));
            control.Add(new ClKey(202, 0, "F9")); control.Add(new ClKey(218, 0, "Up"));
            control.Add(new ClKey(203, 0, "F10")); control.Add(new ClKey(217, 0, "Down"));
            control.Add(new ClKey(204, 0, "F11")); control.Add(new ClKey(216, 0, "Left"));
            control.Add(new ClKey(205, 0, "F12")); control.Add(new ClKey(215, 0, "Right"));
            control.Add(new ClKey(178, 0, "BkSpace")); control.Add(new ClKey((136 + 71), 0, "ScrlLck"));
            control.Add(new ClKey(179, 0, "Tab")); control.Add(new ClKey((136 + 70), 0, "PrtSc"));
            control.Add(new ClKey(176, 0, "Enter")); control.Add(new ClKey((136 + 72), 0, "PsBrk"));
            control.Add(new ClKey(177, 0, "Esc")); control.Add(new ClKey((136 + 83), 0, "NumLock"));
            control.Add(new ClKey(209, 0, "Insert"));
            control.Add(new ClKey(212, 0, "Delete"));
            control.Add(new ClKey(211, 0, "Pg Up"));
            control.Add(new ClKey(214, 0, "Pg Dn"));
            control.Add(new ClKey(210, 0, "Home"));
            control.Add(new ClKey(213, 0, "End"));
            control.Add(new ClKey(193, 0, "Capslock"));
            control.Add(new ClKey(32, 0, "Space"));

            // symbols

            symbol.Add(new ClKey(91, 0, "[ {")); /* [ { */
            symbol.Add(new ClKey(93, 0, "] }")); /* ] } */
            symbol.Add(new ClKey(92, 0, @"\ |")); /* \ | */
            symbol.Add(new ClKey(59, 0, "); :")); /* ); : */
            symbol.Add(new ClKey(39, 0, "' \"")); /* ' " */
            symbol.Add(new ClKey(45, 0, "- _")); /* - _ */
            symbol.Add(new ClKey(61, 0, "= +")); /*(+ */
            symbol.Add(new ClKey(47, 0, "/ ?")); /* / ? */
            symbol.Add(new ClKey(96, 0, "` ~")); /* ` ~ */
            symbol.Add(new ClKey(44, 0, ", <")); /* , < */
            symbol.Add(new ClKey(46, 0, ". >")); /* . > */


            // specials

            special.Add(new ClKey(1, 1, "Fn"));
            special.Add(new ClKey(2, 1, "Fn2"));
            special.Add(new ClKey(3, 1, "Fn3"));
            special.Add(new ClKey(4, 1, "Fn4"));
            special.Add(new ClKey(5, 1, "Fn5"));
            special.Add(new ClKey(6, 1, "Fn6"));
            special.Add(new ClKey(1, 2, "spaceFn"));
            special.Add(new ClKey(2, 2, "spaceFn2"));
            special.Add(new ClKey(3, 2, "spaceFn3"));
            special.Add(new ClKey(4, 2, "spaceFn4"));
            special.Add(new ClKey(5, 2, "spaceFn5"));
            special.Add(new ClKey(6, 2, "spaceFn6"));

            special.Add(new ClKey(0, 3, "Layer Dn"));
            special.Add(new ClKey(1, 3, "Layer Up"));
            special.Add(new ClKey(0, 4, "Vol Up"));
            special.Add(new ClKey(1, 4, "Vol Dn"));
            special.Add(new ClKey(2, 4, "Mute"));
            special.Add(new ClKey(3, 4, "M Play"));
            special.Add(new ClKey(4, 4, "M Pause"));
            special.Add(new ClKey(5, 4, "M Next"));
            special.Add(new ClKey(6, 4, "M Back"));
            special.Add(new ClKey(1, 5, "toggleFn"));
            special.Add(new ClKey(2, 5, "toggleFn2"));
            special.Add(new ClKey(3, 5, "toggleFn3"));
            special.Add(new ClKey(4, 5, "toggleFn4"));
            special.Add(new ClKey(5, 5, "toggleFn5"));
            special.Add(new ClKey(6, 5, "toggleFn6"));

            special.Add(new ClKey(0, 6, "Set 6KRO"));
            special.Add(new ClKey(1, 6, "Win NKRO"));
            special.Add(new ClKey(2, 6, "UNIX Nkro"));


            special.Add(new ClKey(0, 255, "Null"));


            // all list

            dKeys.AddRange(alpha);
            dKeys.AddRange(numeric);
            dKeys.AddRange(numpad);
            dKeys.AddRange(symbol);
            dKeys.AddRange(control);
            dKeys.AddRange(special);
            


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
            ClKey cky = dKeys.Find(k => (k.ktype == 0 && k.val == Convert.ToByte(input)));
            if (cky != null)
            {
                return cky;
            }
            return new ClKey();
        }
    }
}
