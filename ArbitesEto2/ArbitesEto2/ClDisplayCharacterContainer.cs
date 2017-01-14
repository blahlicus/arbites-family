using System;
using System.Collections.Generic;
using Eto.Forms;


namespace ArbitesEto2
{

    public class ClDisplayCharacterContainer
    {

        public string Name { get; set; }
        public List<string> Display { get; set; }
        public List<int> Index { get; set; }
        public List<int> GroupIndex { get; set; }
        public List<string> Groups { get; set; }

        public ClDisplayCharacterContainer()
        {
            this.Name = "Unknown Input Method";
            this.Display = new List<string>();
            this.Index = new List<int>();
            this.Groups = new List<string>();
            this.GroupIndex = new List<int>();
        }

        public ClDisplayCharacterContainer(ClDisplayCharacterContainer input) : this()
        {
            this.Name = input.Name;
            for (var i = 0; i < input.Display.Count; i++)
            {
                this.Display.Add(input.Display[i]);
                this.Index.Add(input.Index[i]);
                this.GroupIndex.Add(input.GroupIndex[i]);
            }

            foreach (var str in input.Groups)
            {
                this.Groups.Add(str);
            }
        }

        public string GetDisplay(int input)
        {
            var output = "Unknown Key";
            for (var i = 0; i < this.Display.Count; i++)
            {
                if (this.Index[i] == input)
                {
                    output = this.Display[i];
                }
            }
            return output;
        }

        public void AddKey(int key, string value, int groupIndex)
        {
            var keyIsNew = true;
            for (var i = 0; i < this.Display.Count; i++)
            {
                if (this.Index[i] == key)
                {
                    this.Display[i] = value;
                    keyIsNew = false;
                }
            }

            if (keyIsNew)
            {
                this.Index.Add(key);
                this.Display.Add(value);
                this.GroupIndex.Add(groupIndex);
            }
        }


        public static ClDisplayCharacterContainer GenerateTestOther()
        {
            var dcc = new ClDisplayCharacterContainer(GenerateUSASCII());

            dcc.Display[4] = "TestChanged A";

            return dcc;
        }

        public static void AddHIDSubGroup(ClDisplayCharacterContainer dcc, int startID, int groupID, string suffix, string postfix)
        {



            for (int i = 0; i < dcc.Index.Count; i++)
            {
                if (dcc.Index[i] >= 0 && dcc.Index[i] < 300)
                {
                    int sid = startID * 100 + dcc.Index[i];
                    string dis = suffix + dcc.Display[i] + postfix;
                    dcc.AddKey(sid, dis, groupID);
                }
            }


        }

        public static ClDisplayCharacterContainer GenerateUSASCII()
        {
            var dcc = new ClDisplayCharacterContainer();

            dcc.Groups.Add("Alphabets"); //0
            dcc.Groups.Add("Numbers"); //1
            dcc.Groups.Add("Symbols"); //2
            dcc.Groups.Add("Numpad"); //3
            dcc.Groups.Add("Controls"); //4
            dcc.Groups.Add("Specials"); //5
            dcc.Groups.Add("Shifted"); //6
            dcc.Groups.Add("Ctrl'd"); //7
            dcc.Groups.Add("Alt'd"); //8
            dcc.Groups.Add("AltGr'd"); //9
            dcc.Groups.Add("Ctrl Shift'd"); //10
            dcc.Groups.Add("Ctrl Shift Alt'd"); //11
            dcc.Groups.Add("Ctrl Alt'd"); //12
            dcc.Groups.Add("Shift Alt'd"); //13
            dcc.Groups.Add("2Role Ctrl"); //14
            dcc.Groups.Add("2Role Shift"); //15
            dcc.Groups.Add("2Role Alt"); //16
            dcc.Groups.Add("2Role AltGr"); //17
            dcc.Groups.Add("2Role FN"); //18
            dcc.Groups.Add("2Role FN2"); //19
            dcc.Groups.Add("2Role FN3"); //20
            dcc.Groups.Add("2Role FN4"); //21
            dcc.Groups.Add("2Role FN5"); //22
            dcc.Groups.Add("2Role FN6"); //23
            dcc.Groups.Add("Sticky"); //24
            dcc.Groups.Add("Others"); //25

            // keyboard HID codes
            dcc.Name = "US ANSI";
            dcc.AddKey(0, "-Scncde 0", 25);
            dcc.AddKey(1, "-Scncde 1", 25);
            dcc.AddKey(2, "-Scncde 2", 25);
            dcc.AddKey(3, "-Scncde 3", 25);
            dcc.AddKey(4, "a", 0);
            dcc.AddKey(5, "b", 0);
            dcc.AddKey(6, "c", 0);
            dcc.AddKey(7, "d", 0);
            dcc.AddKey(8, "e", 0);
            dcc.AddKey(9, "f", 0);
            dcc.AddKey(10, "g", 0);
            dcc.AddKey(11, "h", 0);
            dcc.AddKey(12, "i", 0);
            dcc.AddKey(13, "j", 0);
            dcc.AddKey(14, "k", 0);
            dcc.AddKey(15, "l", 0);
            dcc.AddKey(16, "m", 0);
            dcc.AddKey(17, "n", 0);
            dcc.AddKey(18, "o", 0);
            dcc.AddKey(19, "p", 0);
            dcc.AddKey(20, "q", 0);
            dcc.AddKey(21, "r", 0);
            dcc.AddKey(22, "s", 0);
            dcc.AddKey(23, "t", 0);
            dcc.AddKey(24, "u", 0);
            dcc.AddKey(25, "v", 0);
            dcc.AddKey(26, "w", 0);
            dcc.AddKey(27, "x", 0);
            dcc.AddKey(28, "y", 0);
            dcc.AddKey(29, "z", 0);
            dcc.AddKey(30, "1 !", 1);
            dcc.AddKey(31, "2 @", 1);
            dcc.AddKey(32, "3 #", 1);
            dcc.AddKey(33, "4 $", 1);
            dcc.AddKey(34, "5 %", 1);
            dcc.AddKey(35, "6 ^", 1);
            dcc.AddKey(36, "7 &", 1);
            dcc.AddKey(37, "8 *", 1);
            dcc.AddKey(38, "9 (", 1);
            dcc.AddKey(39, "0 )", 1);
            dcc.AddKey(40, "Enter", 4);
            dcc.AddKey(41, "Esc", 4);
            dcc.AddKey(42, "Backspace", 4);
            dcc.AddKey(43, "Tab", 4);
            dcc.AddKey(44, "Space", 4);
            dcc.AddKey(45, "- _", 2);
            dcc.AddKey(46, "= +", 2);
            dcc.AddKey(47, "[ {", 2);
            dcc.AddKey(48, "] }", 2);
            dcc.AddKey(49, @"\ |", 2);
            dcc.AddKey(50, "Non-US # ~", 25);
            dcc.AddKey(51, "; :", 2);
            dcc.AddKey(52, @"' """, 2);
            dcc.AddKey(53, "` ~", 2);
            dcc.AddKey(54, ", <", 2);
            dcc.AddKey(55, ". >", 2);
            dcc.AddKey(56, "/ ?", 2);
            dcc.AddKey(57, "Capslock", 4);
            dcc.AddKey(58, "F1", 4);
            dcc.AddKey(59, "F2", 4);
            dcc.AddKey(60, "F3", 4);
            dcc.AddKey(61, "F4", 4);
            dcc.AddKey(62, "F5", 4);
            dcc.AddKey(63, "F6", 4);
            dcc.AddKey(64, "F7", 4);
            dcc.AddKey(65, "F8", 4);
            dcc.AddKey(66, "F9", 4);
            dcc.AddKey(67, "F10", 4);
            dcc.AddKey(68, "F11", 4);
            dcc.AddKey(69, "F12", 4);
            dcc.AddKey(70, "PrntScn", 4);
            dcc.AddKey(71, "ScrlLck", 4);
            dcc.AddKey(72, "Pause", 4);
            dcc.AddKey(73, "Insert", 4);
            dcc.AddKey(74, "Home", 4);
            dcc.AddKey(75, "Page Up", 4);
            dcc.AddKey(76, "Delete", 4);
            dcc.AddKey(77, "End", 4);
            dcc.AddKey(78, "Page Down", 4);
            dcc.AddKey(79, "Right", 4);
            dcc.AddKey(80, "Left", 4);
            dcc.AddKey(81, "Down", 4);
            dcc.AddKey(82, "Up", 4);
            dcc.AddKey(83, "NumLock", 4);
            dcc.AddKey(84, "Num /", 3);
            dcc.AddKey(85, "Num *", 3);
            dcc.AddKey(86, "Num -", 3);
            dcc.AddKey(87, "Num +", 3);
            dcc.AddKey(88, "Num Enter", 3);
            dcc.AddKey(89, "Num 1", 3);
            dcc.AddKey(90, "Num 2", 3);
            dcc.AddKey(91, "Num 3", 3);
            dcc.AddKey(92, "Num 4", 3);
            dcc.AddKey(93, "Num 5", 3);
            dcc.AddKey(94, "Num 6", 3);
            dcc.AddKey(95, "Num 7", 3);
            dcc.AddKey(96, "Num 8", 3);
            dcc.AddKey(97, "Num 9", 3);
            dcc.AddKey(98, "Num 0", 3);
            dcc.AddKey(99, "Num .", 3);
            dcc.AddKey(100, @"Non-US \ |", 25);
            dcc.AddKey(101, "App", 4);
            dcc.AddKey(102, "Power Off", 25);
            dcc.AddKey(103, "Num =", 25);
            dcc.AddKey(104, "F13", 25);
            dcc.AddKey(105, "F14", 25);
            dcc.AddKey(106, "F15", 25);
            dcc.AddKey(107, "F16", 25);
            dcc.AddKey(108, "F17", 25);
            dcc.AddKey(109, "F18", 25);
            dcc.AddKey(110, "F19", 25);
            dcc.AddKey(111, "F20", 25);
            dcc.AddKey(112, "F21", 25);
            dcc.AddKey(113, "F22", 25);
            dcc.AddKey(114, "F23", 25);
            dcc.AddKey(115, "F24", 25);
            dcc.AddKey(116, "-Scncde 116", 25);
            dcc.AddKey(117, "KB Help", 25);
            dcc.AddKey(118, "Menu", 4);
            dcc.AddKey(119, "KB Select", 25);
            dcc.AddKey(120, "KB Stop", 25);
            dcc.AddKey(121, "KB Again", 25);
            dcc.AddKey(122, "KB Undo", 25);
            dcc.AddKey(123, "KB Cut", 25);
            dcc.AddKey(124, "KB Copy", 25);
            dcc.AddKey(125, "KB Paste", 25);
            dcc.AddKey(126, "KB Find", 25);
            dcc.AddKey(127, "KB Mute", 25);
            dcc.AddKey(128, "KB Vol Up", 25);
            dcc.AddKey(129, "KB Vol Dn", 25);
            dcc.AddKey(224, "L Ctrl", 4);
            dcc.AddKey(225, "L Shift", 4);
            dcc.AddKey(226, "L Alt", 4);
            dcc.AddKey(227, "L Win", 4);
            dcc.AddKey(228, "R Ctrl", 4);
            dcc.AddKey(229, "R Shift", 4);
            dcc.AddKey(230, "R Alt", 4);
            dcc.AddKey(231, "R Win", 4);
            dcc.AddKey(300, "Null", 5);
            dcc.AddKey(301, "Fn", 5);
            dcc.AddKey(302, "Fn2", 5);
            dcc.AddKey(303, "Fn3", 5);
            dcc.AddKey(304, "Fn4", 5);
            dcc.AddKey(305, "Fn5", 5);
            dcc.AddKey(306, "Fn6", 5);
            dcc.AddKey(307, "Fn7", 5);
            dcc.AddKey(308, "Fn8", 5);
            dcc.AddKey(309, "Fn9", 5);
            dcc.AddKey(310, "Fn10", 5);
            dcc.AddKey(311, "Fn11", 5);
            dcc.AddKey(312, "Fn12", 5);
            dcc.AddKey(313, "Fn13", 5);
            dcc.AddKey(314, "Fn14", 5);
            dcc.AddKey(315, "Fn15", 5);
            dcc.AddKey(316, "Fn16", 5);
            dcc.AddKey(317, "Fn17", 5);
            dcc.AddKey(318, "Fn18", 5);
            dcc.AddKey(319, "Fn19", 5);
            dcc.AddKey(321, "spaceFn", 5);
            dcc.AddKey(322, "spaceFn2", 5);
            dcc.AddKey(323, "spaceFn3", 5);
            dcc.AddKey(324, "spaceFn4", 5);
            dcc.AddKey(325, "spaceFn5", 5);
            dcc.AddKey(326, "spaceFn6", 5);
            dcc.AddKey(327, "spaceFn7", 5);
            dcc.AddKey(328, "spaceFn8", 5);
            dcc.AddKey(329, "spaceFn9", 5);
            dcc.AddKey(330, "spaceFn10", 5);
            dcc.AddKey(331, "spaceFn11", 5);
            dcc.AddKey(332, "spaceFn12", 5);
            dcc.AddKey(333, "spaceFn13", 5);
            dcc.AddKey(334, "spaceFn14", 5);
            dcc.AddKey(335, "spaceFn15", 5);
            dcc.AddKey(336, "spaceFn16", 5);
            dcc.AddKey(337, "spaceFn17", 5);
            dcc.AddKey(338, "spaceFn18", 5);
            dcc.AddKey(339, "spaceFn19", 5);
            dcc.AddKey(341, "toggleFn", 5);
            dcc.AddKey(342, "toggleFn2", 5);
            dcc.AddKey(343, "toggleFn3", 5);
            dcc.AddKey(344, "toggleFn4", 5);
            dcc.AddKey(345, "toggleFn5", 5);
            dcc.AddKey(346, "toggleFn6", 5);
            dcc.AddKey(347, "toggleFn7", 5);
            dcc.AddKey(348, "toggleFn8", 5);
            dcc.AddKey(349, "toggleFn9", 5);
            dcc.AddKey(350, "toggleFn10", 5);
            dcc.AddKey(351, "toggleFn11", 5);
            dcc.AddKey(352, "toggleFn12", 5);
            dcc.AddKey(353, "toggleFn13", 5);
            dcc.AddKey(354, "toggleFn14", 5);
            dcc.AddKey(355, "toggleFn15", 5);
            dcc.AddKey(356, "toggleFn16", 5);
            dcc.AddKey(357, "toggleFn17", 5);
            dcc.AddKey(358, "toggleFn18", 5);
            dcc.AddKey(359, "toggleFn19", 5);
            dcc.AddKey(360, "Vol Up", 5);
            dcc.AddKey(361, "Vol Dn", 5);
            dcc.AddKey(362, "Mute", 5);
            dcc.AddKey(363, "M Play", 5);
            dcc.AddKey(364, "M Pause", 5);
            dcc.AddKey(365, "M Next", 5);
            dcc.AddKey(366, "M Back", 5);
            dcc.AddKey(370, "Set 6KRO", 5);
            dcc.AddKey(371, "Win NKRO", 5);
            dcc.AddKey(372, "UNIX NKRO", 5);
            dcc.AddKey(380, "LED Off", 5);
            dcc.AddKey(381, "LED--", 5);
            dcc.AddKey(382, "LED-", 5);
            dcc.AddKey(383, "LED+", 5);
            dcc.AddKey(384, "LED++", 5);
            dcc.AddKey(390, "macro0", 5);
            dcc.AddKey(391, "macro1", 5);
            dcc.AddKey(392, "macro2", 5);
            dcc.AddKey(393, "macro3", 5);
            dcc.AddKey(394, "macro4", 5);
            dcc.AddKey(395, "macro5", 5);
            dcc.AddKey(396, "macro6", 5);
            dcc.AddKey(397, "macro7", 5);
            dcc.AddKey(398, "macro8", 5);
            dcc.AddKey(399, "macro9", 5);


            dcc.AddKey(400, "tapDance0", 5);
            dcc.AddKey(401, "tapDance1", 5);
            dcc.AddKey(402, "tapDance2", 5);
            dcc.AddKey(403, "tapDance3", 5);
            dcc.AddKey(404, "tapDance4", 5);
            dcc.AddKey(405, "tapDance5", 5);
            dcc.AddKey(406, "tapDance6", 5);
            dcc.AddKey(407, "tapDance7", 5);
            dcc.AddKey(408, "tapDance8", 5);
            dcc.AddKey(409, "tapDance9", 5);

            dcc.AddKey(410, "tapDance10", 5);
            dcc.AddKey(411, "tapDance11", 5);
            dcc.AddKey(412, "tapDance12", 5);
            dcc.AddKey(413, "tapDance13", 5);
            dcc.AddKey(414, "tapDance14", 5);
            dcc.AddKey(415, "tapDance15", 5);
            dcc.AddKey(416, "tapDance16", 5);
            dcc.AddKey(417, "tapDance17", 5);
            dcc.AddKey(418, "tapDance18", 5);
            dcc.AddKey(419, "tapDance19", 5);

            AddHIDSubGroup(dcc, 5, 6, "", " + Shift");
            AddHIDSubGroup(dcc, 8, 7, "", " + Ctrl");
            AddHIDSubGroup(dcc, 11, 8, "", " + Alt");
            AddHIDSubGroup(dcc, 14, 9, "", " + AltGr");

            AddHIDSubGroup(dcc, 17, 14, "", " || Ctrl");
            AddHIDSubGroup(dcc, 20, 15, "", " || Shift");
            AddHIDSubGroup(dcc, 23, 16, "", " || Alt");
            AddHIDSubGroup(dcc, 26, 17, "", " || AltGr");
            AddHIDSubGroup(dcc, 29, 18, "", " || FN");
            AddHIDSubGroup(dcc, 32, 19, "", " || FN2");
            AddHIDSubGroup(dcc, 35, 20, "", " || FN3");
            AddHIDSubGroup(dcc, 38, 21, "", " || FN4");
            AddHIDSubGroup(dcc, 41, 22, "", " || FN5");
            AddHIDSubGroup(dcc, 44, 23, "", " || FN6");


            AddHIDSubGroup(dcc, 47, 10, "", " + Ctrl + Shift");
            AddHIDSubGroup(dcc, 50, 11, "", " + Ctrl + Shift + Alt");
            AddHIDSubGroup(dcc, 53, 12, "", " + Ctrl + Alt");
            AddHIDSubGroup(dcc, 56, 13, "", " + Shift + Alt");


            // stickyctrl
            dcc.AddKey(5900, "StickyCtrl", 24);
            dcc.AddKey(5901, "StickyShift", 24);
            dcc.AddKey(5902, "StickyAlt", 24);
            dcc.AddKey(5903, "StickyAltGr", 24);


            int ctr = 1;
            for (int i = 5904; i < 5914; i++)
            {
                dcc.AddKey(i, "StickyFN" + Convert.ToString(ctr), 24);
                ctr++;
            }

            return dcc;
        }

    }

}
