using System;
using System.Collections.Generic;
using System.Linq;


namespace ArbitesEto2
{

    public class ClKeyGroup
    {

        public List<ClKey> Keys { get; set; }

        public ClKeyGroup()
        {
            this.Keys = new List<ClKey>();
        }

        public static ClKey GetKeyFromDisplayId(int id)
        {
            return new ClKey(MdSessionData.KeyGroup.Keys.Find(ele => ele.DisplayID == id));
        }


        public static List<ClKey> GenereateSubHIDSet(ClKeyGroup kg, int first2Digits, byte keyType, bool overrideAllLayers = false)
        {
            var dat = kg.Keys.Where(ele => ele.DisplayID >= 0 && ele.DisplayID < 300).ToList();
            var output = new List<ClKey>();
            foreach (var ele in dat)
            {
                int sid = first2Digits * 100 + ele.DisplayID;
                var key = new ClKey(ele);
                key.DisplayID = sid;
                key.KeyType = keyType;
                if (overrideAllLayers)
                {
                    key.AllLayers = overrideAllLayers;
                }
                output.Add(key);
            }
            return output;
        }

        public static ClKeyGroup GenerateDefault()
        {
            var kg = new ClKeyGroup();


            kg.Keys.Add(new ClKey(0, 0, 0, 0, false, false));
            kg.Keys.Add(new ClKey(1, 0, 1, 0, false, false));
            kg.Keys.Add(new ClKey(2, 0, 2, 0, false, false));
            kg.Keys.Add(new ClKey(3, 0, 3, 0, false, false));
            kg.Keys.Add(new ClKey(4, 97, 4, 0, false, true));
            kg.Keys.Add(new ClKey(5, 98, 5, 0, false, true));
            kg.Keys.Add(new ClKey(6, 99, 6, 0, false, true));
            kg.Keys.Add(new ClKey(7, 100, 7, 0, false, true));
            kg.Keys.Add(new ClKey(8, 101, 8, 0, false, true));
            kg.Keys.Add(new ClKey(9, 102, 9, 0, false, true));
            kg.Keys.Add(new ClKey(10, 103, 10, 0, false, true));
            kg.Keys.Add(new ClKey(11, 104, 11, 0, false, true));
            kg.Keys.Add(new ClKey(12, 105, 12, 0, false, true));
            kg.Keys.Add(new ClKey(13, 106, 13, 0, false, true));
            kg.Keys.Add(new ClKey(14, 107, 14, 0, false, true));
            kg.Keys.Add(new ClKey(15, 108, 15, 0, false, true));
            kg.Keys.Add(new ClKey(16, 109, 16, 0, false, true));
            kg.Keys.Add(new ClKey(17, 110, 17, 0, false, true));
            kg.Keys.Add(new ClKey(18, 111, 18, 0, false, true));
            kg.Keys.Add(new ClKey(19, 112, 19, 0, false, true));
            kg.Keys.Add(new ClKey(20, 113, 20, 0, false, true));
            kg.Keys.Add(new ClKey(21, 114, 21, 0, false, true));
            kg.Keys.Add(new ClKey(22, 115, 22, 0, false, true));
            kg.Keys.Add(new ClKey(23, 116, 23, 0, false, true));
            kg.Keys.Add(new ClKey(24, 117, 24, 0, false, true));
            kg.Keys.Add(new ClKey(25, 118, 25, 0, false, true));
            kg.Keys.Add(new ClKey(26, 119, 26, 0, false, true));
            kg.Keys.Add(new ClKey(27, 120, 27, 0, false, true));
            kg.Keys.Add(new ClKey(28, 121, 28, 0, false, true));
            kg.Keys.Add(new ClKey(29, 122, 29, 0, false, true));
            kg.Keys.Add(new ClKey(30, 49, 30, 0, false, true));
            kg.Keys.Add(new ClKey(31, 50, 31, 0, false, true));
            kg.Keys.Add(new ClKey(32, 51, 32, 0, false, true));
            kg.Keys.Add(new ClKey(33, 52, 33, 0, false, true));
            kg.Keys.Add(new ClKey(34, 53, 34, 0, false, true));
            kg.Keys.Add(new ClKey(35, 54, 35, 0, false, true));
            kg.Keys.Add(new ClKey(36, 55, 36, 0, false, true));
            kg.Keys.Add(new ClKey(37, 56, 37, 0, false, true));
            kg.Keys.Add(new ClKey(38, 57, 38, 0, false, true));
            kg.Keys.Add(new ClKey(39, 48, 39, 0, false, true));
            kg.Keys.Add(new ClKey(40, 176, 40, 0, false, true));
            kg.Keys.Add(new ClKey(41, 177, 41, 0, false, true));
            kg.Keys.Add(new ClKey(42, 212, 42, 0, false, true));
            kg.Keys.Add(new ClKey(43, 179, 43, 0, false, true));
            kg.Keys.Add(new ClKey(44, 32, 44, 0, false, true));
            kg.Keys.Add(new ClKey(45, 45, 45, 0, false, true));
            kg.Keys.Add(new ClKey(46, 61, 46, 0, false, true));
            kg.Keys.Add(new ClKey(47, 91, 47, 0, false, true));
            kg.Keys.Add(new ClKey(48, 93, 48, 0, false, true));
            kg.Keys.Add(new ClKey(49, 92, 49, 0, false, true));
            kg.Keys.Add(new ClKey(50, 0, 50, 0, false, false));
            kg.Keys.Add(new ClKey(51, 59, 51, 0, false, true));
            kg.Keys.Add(new ClKey(52, 39, 52, 0, false, true));
            kg.Keys.Add(new ClKey(53, 96, 53, 0, false, true));
            kg.Keys.Add(new ClKey(54, 44, 54, 0, false, true));
            kg.Keys.Add(new ClKey(55, 46, 55, 0, false, true));
            kg.Keys.Add(new ClKey(56, 47, 56, 0, false, true));
            kg.Keys.Add(new ClKey(57, 193, 57, 0, false, true));
            kg.Keys.Add(new ClKey(58, 194, 58, 0, false, true));
            kg.Keys.Add(new ClKey(59, 195, 59, 0, false, true));
            kg.Keys.Add(new ClKey(60, 196, 60, 0, false, true));
            kg.Keys.Add(new ClKey(61, 197, 61, 0, false, true));
            kg.Keys.Add(new ClKey(62, 198, 62, 0, false, true));
            kg.Keys.Add(new ClKey(63, 199, 63, 0, false, true));
            kg.Keys.Add(new ClKey(64, 200, 64, 0, false, true));
            kg.Keys.Add(new ClKey(65, 201, 65, 0, false, true));
            kg.Keys.Add(new ClKey(66, 202, 66, 0, false, true));
            kg.Keys.Add(new ClKey(67, 203, 67, 0, false, true));
            kg.Keys.Add(new ClKey(68, 204, 68, 0, false, true));
            kg.Keys.Add(new ClKey(69, 205, 69, 0, false, true));
            kg.Keys.Add(new ClKey(70, 206, 70, 0, false, true));
            kg.Keys.Add(new ClKey(71, 207, 71, 0, false, true));
            kg.Keys.Add(new ClKey(72, 208, 72, 0, false, true));
            kg.Keys.Add(new ClKey(73, 209, 73, 0, false, true));
            kg.Keys.Add(new ClKey(74, 210, 74, 0, false, true));
            kg.Keys.Add(new ClKey(75, 211, 75, 0, false, true));
            kg.Keys.Add(new ClKey(76, 212, 76, 0, false, false));
            kg.Keys.Add(new ClKey(77, 213, 77, 0, false, true));
            kg.Keys.Add(new ClKey(78, 214, 78, 0, false, true));
            kg.Keys.Add(new ClKey(79, 215, 79, 0, false, true));
            kg.Keys.Add(new ClKey(80, 216, 80, 0, false, true));
            kg.Keys.Add(new ClKey(81, 217, 81, 0, false, true));
            kg.Keys.Add(new ClKey(82, 211, 82, 0, false, true));
            kg.Keys.Add(new ClKey(83, 219, 83, 0, false, true));
            kg.Keys.Add(new ClKey(84, 220, 84, 0, false, true));
            kg.Keys.Add(new ClKey(85, 221, 85, 0, false, true));
            kg.Keys.Add(new ClKey(86, 222, 86, 0, false, true));
            kg.Keys.Add(new ClKey(87, 223, 87, 0, false, true));
            kg.Keys.Add(new ClKey(88, 224, 88, 0, false, true));
            kg.Keys.Add(new ClKey(89, 225, 89, 0, false, true));
            kg.Keys.Add(new ClKey(90, 226, 90, 0, false, true));
            kg.Keys.Add(new ClKey(91, 227, 91, 0, false, true));
            kg.Keys.Add(new ClKey(92, 228, 92, 0, false, true));
            kg.Keys.Add(new ClKey(93, 229, 93, 0, false, true));
            kg.Keys.Add(new ClKey(94, 230, 94, 0, false, true));
            kg.Keys.Add(new ClKey(95, 231, 95, 0, false, true));
            kg.Keys.Add(new ClKey(96, 232, 96, 0, false, true));
            kg.Keys.Add(new ClKey(97, 233, 97, 0, false, true));
            kg.Keys.Add(new ClKey(98, 234, 98, 0, false, true));
            kg.Keys.Add(new ClKey(99, 235, 99, 0, false, true));
            kg.Keys.Add(new ClKey(100, 0, 100, 0, false, false));
            kg.Keys.Add(new ClKey(101, 0, 101, 0, false, false));
            kg.Keys.Add(new ClKey(102, 0, 102, 0, false, false));
            kg.Keys.Add(new ClKey(103, 0, 103, 0, false, false));
            kg.Keys.Add(new ClKey(104, 0, 104, 0, false, false));
            kg.Keys.Add(new ClKey(105, 0, 105, 0, false, false));
            kg.Keys.Add(new ClKey(106, 0, 106, 0, false, false));
            kg.Keys.Add(new ClKey(107, 0, 107, 0, false, false));
            kg.Keys.Add(new ClKey(108, 0, 108, 0, false, false));
            kg.Keys.Add(new ClKey(109, 0, 109, 0, false, false));
            kg.Keys.Add(new ClKey(110, 0, 110, 0, false, false));
            kg.Keys.Add(new ClKey(111, 0, 111, 0, false, false));
            kg.Keys.Add(new ClKey(112, 0, 112, 0, false, false));
            kg.Keys.Add(new ClKey(113, 0, 113, 0, false, false));
            kg.Keys.Add(new ClKey(114, 0, 114, 0, false, false));
            kg.Keys.Add(new ClKey(115, 0, 115, 0, false, false));
            kg.Keys.Add(new ClKey(116, 0, 116, 0, false, false));
            kg.Keys.Add(new ClKey(117, 0, 116, 0, false, false));
            kg.Keys.Add(new ClKey(118, 0, 118, 0, false, false));
            kg.Keys.Add(new ClKey(119, 0, 119, 0, false, false));
            kg.Keys.Add(new ClKey(120, 0, 120, 0, false, false));
            kg.Keys.Add(new ClKey(121, 0, 121, 0, false, false));
            kg.Keys.Add(new ClKey(122, 0, 122, 0, false, false));
            kg.Keys.Add(new ClKey(123, 0, 123, 0, false, false));
            kg.Keys.Add(new ClKey(124, 0, 124, 0, false, false));
            kg.Keys.Add(new ClKey(125, 0, 125, 0, false, false));
            kg.Keys.Add(new ClKey(126, 0, 126, 0, false, false));
            kg.Keys.Add(new ClKey(127, 0, 127, 0, false, false));
            kg.Keys.Add(new ClKey(128, 0, 128, 0, false, false));
            kg.Keys.Add(new ClKey(129, 0, 129, 0, false, false));
            kg.Keys.Add(new ClKey(224, 128, 224, 0, false, true));
            kg.Keys.Add(new ClKey(225, 129, 225, 0, false, true));
            kg.Keys.Add(new ClKey(226, 130, 226, 0, false, true));
            kg.Keys.Add(new ClKey(227, 131, 227, 0, false, true));
            kg.Keys.Add(new ClKey(228, 132, 228, 0, false, true));
            kg.Keys.Add(new ClKey(229, 133, 229, 0, false, true));
            kg.Keys.Add(new ClKey(230, 134, 230, 0, false, true));
            kg.Keys.Add(new ClKey(231, 135, 231, 0, false, true));
            kg.Keys.Add(new ClKey(300, 0, 0, 255, false, true));
            kg.Keys.Add(new ClKey(301, 1, 1, 1, true, true));
            kg.Keys.Add(new ClKey(302, 2, 2, 1, true, true));
            kg.Keys.Add(new ClKey(303, 3, 3, 1, true, true));
            kg.Keys.Add(new ClKey(304, 4, 4, 1, true, true));
            kg.Keys.Add(new ClKey(305, 5, 5, 1, true, true));
            kg.Keys.Add(new ClKey(306, 6, 6, 1, true, true));
            kg.Keys.Add(new ClKey(307, 7, 7, 1, true, true));
            kg.Keys.Add(new ClKey(308, 8, 8, 1, true, true));
            kg.Keys.Add(new ClKey(309, 9, 9, 1, true, true));
            kg.Keys.Add(new ClKey(310, 10, 10, 1, true, true));
            kg.Keys.Add(new ClKey(311, 11, 11, 1, true, true));
            kg.Keys.Add(new ClKey(312, 12, 12, 1, true, true));
            kg.Keys.Add(new ClKey(313, 13, 13, 1, true, true));
            kg.Keys.Add(new ClKey(314, 14, 14, 1, true, true));
            kg.Keys.Add(new ClKey(315, 15, 15, 1, true, true));
            kg.Keys.Add(new ClKey(316, 16, 16, 1, true, true));
            kg.Keys.Add(new ClKey(317, 17, 17, 1, true, true));
            kg.Keys.Add(new ClKey(318, 18, 18, 1, true, true));
            kg.Keys.Add(new ClKey(319, 19, 19, 1, true, true));
            kg.Keys.Add(new ClKey(321, 1, 1, 2, true, true));
            kg.Keys.Add(new ClKey(322, 2, 2, 2, true, true));
            kg.Keys.Add(new ClKey(323, 3, 3, 2, true, true));
            kg.Keys.Add(new ClKey(324, 4, 4, 2, true, true));
            kg.Keys.Add(new ClKey(325, 5, 5, 2, true, true));
            kg.Keys.Add(new ClKey(326, 6, 6, 2, true, true));
            kg.Keys.Add(new ClKey(327, 7, 7, 2, true, true));
            kg.Keys.Add(new ClKey(328, 8, 8, 2, true, true));
            kg.Keys.Add(new ClKey(329, 9, 9, 2, true, true));
            kg.Keys.Add(new ClKey(330, 10, 10, 2, true, true));
            kg.Keys.Add(new ClKey(331, 11, 11, 2, true, true));
            kg.Keys.Add(new ClKey(332, 12, 12, 2, true, true));
            kg.Keys.Add(new ClKey(333, 13, 13, 2, true, true));
            kg.Keys.Add(new ClKey(334, 14, 14, 2, true, true));
            kg.Keys.Add(new ClKey(335, 15, 15, 2, true, true));
            kg.Keys.Add(new ClKey(336, 16, 16, 2, true, true));
            kg.Keys.Add(new ClKey(337, 17, 17, 2, true, true));
            kg.Keys.Add(new ClKey(338, 18, 18, 2, true, true));
            kg.Keys.Add(new ClKey(339, 19, 19, 2, true, true));
            kg.Keys.Add(new ClKey(341, 1, 1, 5, true, true));
            kg.Keys.Add(new ClKey(342, 2, 2, 5, true, true));
            kg.Keys.Add(new ClKey(343, 3, 3, 5, true, true));
            kg.Keys.Add(new ClKey(344, 4, 4, 5, true, true));
            kg.Keys.Add(new ClKey(345, 5, 5, 5, true, true));
            kg.Keys.Add(new ClKey(346, 6, 6, 5, true, true));
            kg.Keys.Add(new ClKey(347, 7, 7, 5, true, true));
            kg.Keys.Add(new ClKey(348, 8, 8, 5, true, true));
            kg.Keys.Add(new ClKey(349, 9, 9, 5, true, true));
            kg.Keys.Add(new ClKey(350, 10, 10, 5, true, true));
            kg.Keys.Add(new ClKey(351, 11, 11, 5, true, true));
            kg.Keys.Add(new ClKey(352, 12, 12, 5, true, true));
            kg.Keys.Add(new ClKey(353, 13, 13, 5, true, true));
            kg.Keys.Add(new ClKey(354, 14, 14, 5, true, true));
            kg.Keys.Add(new ClKey(355, 15, 15, 5, true, true));
            kg.Keys.Add(new ClKey(356, 16, 16, 5, true, true));
            kg.Keys.Add(new ClKey(357, 17, 17, 5, true, true));
            kg.Keys.Add(new ClKey(358, 18, 18, 5, true, true));
            kg.Keys.Add(new ClKey(359, 19, 19, 5, true, true));
            kg.Keys.Add(new ClKey(360, 0, 0, 4, false, true));
            kg.Keys.Add(new ClKey(361, 1, 1, 4, false, true));
            kg.Keys.Add(new ClKey(362, 2, 2, 4, false, true));
            kg.Keys.Add(new ClKey(363, 3, 3, 4, false, true));
            kg.Keys.Add(new ClKey(364, 4, 4, 4, false, true));
            kg.Keys.Add(new ClKey(365, 5, 5, 4, false, true));
            kg.Keys.Add(new ClKey(366, 6, 6, 4, false, true));
            kg.Keys.Add(new ClKey(370, 0, 0, 6, false, true));
            kg.Keys.Add(new ClKey(371, 1, 1, 6, false, true));
            kg.Keys.Add(new ClKey(372, 2, 2, 6, false, true));
            kg.Keys.Add(new ClKey(380, 101, 101, 10, false, true));
            kg.Keys.Add(new ClKey(381, 236, 236, 10, false, true));
            kg.Keys.Add(new ClKey(382, 246, 246, 10, false, true));
            kg.Keys.Add(new ClKey(383, 10, 10, 10, false, true));
            kg.Keys.Add(new ClKey(384, 20, 20, 10, false, true));


            kg.Keys.Add(new ClKey(390, 0, 0, 7, false, true));
            kg.Keys.Add(new ClKey(391, 1, 1, 7, false, true));
            kg.Keys.Add(new ClKey(392, 2, 2, 7, false, true));
            kg.Keys.Add(new ClKey(393, 3, 3, 7, false, true));
            kg.Keys.Add(new ClKey(394, 4, 4, 7, false, true));
            kg.Keys.Add(new ClKey(395, 5, 5, 7, false, true));
            kg.Keys.Add(new ClKey(396, 6, 6, 7, false, true));
            kg.Keys.Add(new ClKey(397, 7, 7, 7, false, true));
            kg.Keys.Add(new ClKey(398, 8, 8, 7, false, true));
            kg.Keys.Add(new ClKey(399, 9, 9, 7, false, true));



            kg.Keys.Add(new ClKey(400, 0, 0, 19, false, true));
            kg.Keys.Add(new ClKey(401, 1, 1, 19, false, true));
            kg.Keys.Add(new ClKey(402, 2, 2, 19, false, true));
            kg.Keys.Add(new ClKey(403, 3, 3, 19, false, true));
            kg.Keys.Add(new ClKey(404, 4, 4, 19, false, true));
            kg.Keys.Add(new ClKey(405, 5, 5, 19, false, true));
            kg.Keys.Add(new ClKey(406, 6, 6, 19, false, true));
            kg.Keys.Add(new ClKey(407, 7, 7, 19, false, true));
            kg.Keys.Add(new ClKey(408, 8, 8, 19, false, true));
            kg.Keys.Add(new ClKey(409, 9, 9, 19, false, true));
            kg.Keys.Add(new ClKey(410, 10, 10, 19, false, true));
            kg.Keys.Add(new ClKey(411, 11, 11, 19, false, true));
            kg.Keys.Add(new ClKey(412, 12, 12, 19, false, true));
            kg.Keys.Add(new ClKey(413, 13, 13, 19, false, true));
            kg.Keys.Add(new ClKey(414, 14, 14, 19, false, true));
            kg.Keys.Add(new ClKey(415, 15, 15, 19, false, true));
            kg.Keys.Add(new ClKey(416, 16, 16, 19, false, true));
            kg.Keys.Add(new ClKey(417, 17, 17, 19, false, true));
            kg.Keys.Add(new ClKey(418, 18, 18, 19, false, true));
            kg.Keys.Add(new ClKey(419, 19, 19, 19, false, true)); 

            // pressed shift ctrl alt altgr
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 5, 11));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 8, 12));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 11, 13));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 14, 14));

            // dual roles ctrl shift alt altgr
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 17, 20));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 20, 21));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 23, 22));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 26, 23));
            // dual roles fn1
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 29, 24, true));
            // dual roles fn2
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 32, 25, true));
            // dual roles fn3
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 35, 26, true));
            // dual roles fn4
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 38, 27, true));
            // dual roles fn5
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 41, 28, true));
            // dual roles fn6
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 44, 29, true));

            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 47, 15));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 50, 16));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 53, 17));
            kg.Keys.AddRange(ClKeyGroup.GenereateSubHIDSet(kg, 56, 18));


            // stickyctrl
            kg.Keys.Add(new ClKey(5900, 0, 0, 30, false, false));
            // stickyctrl
            kg.Keys.Add(new ClKey(5901, 0, 1, 30, false, false));
            // stickyctrl
            kg.Keys.Add(new ClKey(5902, 0, 2, 30, false, false));
            // stickyctrl
            kg.Keys.Add(new ClKey(5903, 0, 3, 30, false, false));

            byte ctr = 4;
            for (int i = 5904; i < 5914; i++)
            {

                kg.Keys.Add(new ClKey(i, 0, ctr, 30, true, false));
                ctr++;
            }


            return kg;
        }

    }

}
