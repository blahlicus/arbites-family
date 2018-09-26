using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace ArbitesEto2
{
    [XmlType("ClKeyGroup")]
    public class KeyGroup
    {
        public List<Key> Keys { get; set; }

        public KeyGroup()
        {
            this.Keys = new List<Key>();
        }

        public static Key GetKeyFromDisplayId(int id)
        {
            return new Key(MdSessionData.KeyGroup.Keys.Find(ele => ele.DisplayID == id));
        }

        public static List<Key> GenereateSubHIDSet(KeyGroup kg, int first2Digits, byte keyType, bool overrideAllLayers = false)
        {
            var dat = kg.Keys.Where(ele => ele.DisplayID >= 0 && ele.DisplayID < 300).ToList();
            var output = new List<Key>();
            foreach (var ele in dat)
            {
                int sid = first2Digits * 100 + ele.DisplayID;
                var key = new Key(ele);
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

        public static KeyGroup GenerateDefault()
        {
            var kg = new KeyGroup();

            kg.Keys.Add(new Key(0, 0, 0, 0, false, false));
            kg.Keys.Add(new Key(1, 0, 1, 0, false, false));
            kg.Keys.Add(new Key(2, 0, 2, 0, false, false));
            kg.Keys.Add(new Key(3, 0, 3, 0, false, false));
            kg.Keys.Add(new Key(4, 97, 4, 0, false, true));
            kg.Keys.Add(new Key(5, 98, 5, 0, false, true));
            kg.Keys.Add(new Key(6, 99, 6, 0, false, true));
            kg.Keys.Add(new Key(7, 100, 7, 0, false, true));
            kg.Keys.Add(new Key(8, 101, 8, 0, false, true));
            kg.Keys.Add(new Key(9, 102, 9, 0, false, true));
            kg.Keys.Add(new Key(10, 103, 10, 0, false, true));
            kg.Keys.Add(new Key(11, 104, 11, 0, false, true));
            kg.Keys.Add(new Key(12, 105, 12, 0, false, true));
            kg.Keys.Add(new Key(13, 106, 13, 0, false, true));
            kg.Keys.Add(new Key(14, 107, 14, 0, false, true));
            kg.Keys.Add(new Key(15, 108, 15, 0, false, true));
            kg.Keys.Add(new Key(16, 109, 16, 0, false, true));
            kg.Keys.Add(new Key(17, 110, 17, 0, false, true));
            kg.Keys.Add(new Key(18, 111, 18, 0, false, true));
            kg.Keys.Add(new Key(19, 112, 19, 0, false, true));
            kg.Keys.Add(new Key(20, 113, 20, 0, false, true));
            kg.Keys.Add(new Key(21, 114, 21, 0, false, true));
            kg.Keys.Add(new Key(22, 115, 22, 0, false, true));
            kg.Keys.Add(new Key(23, 116, 23, 0, false, true));
            kg.Keys.Add(new Key(24, 117, 24, 0, false, true));
            kg.Keys.Add(new Key(25, 118, 25, 0, false, true));
            kg.Keys.Add(new Key(26, 119, 26, 0, false, true));
            kg.Keys.Add(new Key(27, 120, 27, 0, false, true));
            kg.Keys.Add(new Key(28, 121, 28, 0, false, true));
            kg.Keys.Add(new Key(29, 122, 29, 0, false, true));
            kg.Keys.Add(new Key(30, 49, 30, 0, false, true));
            kg.Keys.Add(new Key(31, 50, 31, 0, false, true));
            kg.Keys.Add(new Key(32, 51, 32, 0, false, true));
            kg.Keys.Add(new Key(33, 52, 33, 0, false, true));
            kg.Keys.Add(new Key(34, 53, 34, 0, false, true));
            kg.Keys.Add(new Key(35, 54, 35, 0, false, true));
            kg.Keys.Add(new Key(36, 55, 36, 0, false, true));
            kg.Keys.Add(new Key(37, 56, 37, 0, false, true));
            kg.Keys.Add(new Key(38, 57, 38, 0, false, true));
            kg.Keys.Add(new Key(39, 48, 39, 0, false, true));
            kg.Keys.Add(new Key(40, 176, 40, 0, false, true));
            kg.Keys.Add(new Key(41, 177, 41, 0, false, true));
            kg.Keys.Add(new Key(42, 212, 42, 0, false, true));
            kg.Keys.Add(new Key(43, 179, 43, 0, false, true));
            kg.Keys.Add(new Key(44, 32, 44, 0, false, true));
            kg.Keys.Add(new Key(45, 45, 45, 0, false, true));
            kg.Keys.Add(new Key(46, 61, 46, 0, false, true));
            kg.Keys.Add(new Key(47, 91, 47, 0, false, true));
            kg.Keys.Add(new Key(48, 93, 48, 0, false, true));
            kg.Keys.Add(new Key(49, 92, 49, 0, false, true));
            kg.Keys.Add(new Key(50, 0, 50, 0, false, false));
            kg.Keys.Add(new Key(51, 59, 51, 0, false, true));
            kg.Keys.Add(new Key(52, 39, 52, 0, false, true));
            kg.Keys.Add(new Key(53, 96, 53, 0, false, true));
            kg.Keys.Add(new Key(54, 44, 54, 0, false, true));
            kg.Keys.Add(new Key(55, 46, 55, 0, false, true));
            kg.Keys.Add(new Key(56, 47, 56, 0, false, true));
            kg.Keys.Add(new Key(57, 193, 57, 0, false, true));
            kg.Keys.Add(new Key(58, 194, 58, 0, false, true));
            kg.Keys.Add(new Key(59, 195, 59, 0, false, true));
            kg.Keys.Add(new Key(60, 196, 60, 0, false, true));
            kg.Keys.Add(new Key(61, 197, 61, 0, false, true));
            kg.Keys.Add(new Key(62, 198, 62, 0, false, true));
            kg.Keys.Add(new Key(63, 199, 63, 0, false, true));
            kg.Keys.Add(new Key(64, 200, 64, 0, false, true));
            kg.Keys.Add(new Key(65, 201, 65, 0, false, true));
            kg.Keys.Add(new Key(66, 202, 66, 0, false, true));
            kg.Keys.Add(new Key(67, 203, 67, 0, false, true));
            kg.Keys.Add(new Key(68, 204, 68, 0, false, true));
            kg.Keys.Add(new Key(69, 205, 69, 0, false, true));
            kg.Keys.Add(new Key(70, 206, 70, 0, false, true));
            kg.Keys.Add(new Key(71, 207, 71, 0, false, true));
            kg.Keys.Add(new Key(72, 208, 72, 0, false, true));
            kg.Keys.Add(new Key(73, 209, 73, 0, false, true));
            kg.Keys.Add(new Key(74, 210, 74, 0, false, true));
            kg.Keys.Add(new Key(75, 211, 75, 0, false, true));
            kg.Keys.Add(new Key(76, 212, 76, 0, false, false));
            kg.Keys.Add(new Key(77, 213, 77, 0, false, true));
            kg.Keys.Add(new Key(78, 214, 78, 0, false, true));
            kg.Keys.Add(new Key(79, 215, 79, 0, false, true));
            kg.Keys.Add(new Key(80, 216, 80, 0, false, true));
            kg.Keys.Add(new Key(81, 217, 81, 0, false, true));
            kg.Keys.Add(new Key(82, 211, 82, 0, false, true));
            kg.Keys.Add(new Key(83, 219, 83, 0, false, true));
            kg.Keys.Add(new Key(84, 220, 84, 0, false, true));
            kg.Keys.Add(new Key(85, 221, 85, 0, false, true));
            kg.Keys.Add(new Key(86, 222, 86, 0, false, true));
            kg.Keys.Add(new Key(87, 223, 87, 0, false, true));
            kg.Keys.Add(new Key(88, 224, 88, 0, false, true));
            kg.Keys.Add(new Key(89, 225, 89, 0, false, true));
            kg.Keys.Add(new Key(90, 226, 90, 0, false, true));
            kg.Keys.Add(new Key(91, 227, 91, 0, false, true));
            kg.Keys.Add(new Key(92, 228, 92, 0, false, true));
            kg.Keys.Add(new Key(93, 229, 93, 0, false, true));
            kg.Keys.Add(new Key(94, 230, 94, 0, false, true));
            kg.Keys.Add(new Key(95, 231, 95, 0, false, true));
            kg.Keys.Add(new Key(96, 232, 96, 0, false, true));
            kg.Keys.Add(new Key(97, 233, 97, 0, false, true));
            kg.Keys.Add(new Key(98, 234, 98, 0, false, true));
            kg.Keys.Add(new Key(99, 235, 99, 0, false, true));
            kg.Keys.Add(new Key(100, 0, 100, 0, false, false));
            kg.Keys.Add(new Key(101, 0, 101, 0, false, false));
            kg.Keys.Add(new Key(102, 0, 102, 0, false, false));
            kg.Keys.Add(new Key(103, 0, 103, 0, false, false));
            kg.Keys.Add(new Key(104, 0, 104, 0, false, false));
            kg.Keys.Add(new Key(105, 0, 105, 0, false, false));
            kg.Keys.Add(new Key(106, 0, 106, 0, false, false));
            kg.Keys.Add(new Key(107, 0, 107, 0, false, false));
            kg.Keys.Add(new Key(108, 0, 108, 0, false, false));
            kg.Keys.Add(new Key(109, 0, 109, 0, false, false));
            kg.Keys.Add(new Key(110, 0, 110, 0, false, false));
            kg.Keys.Add(new Key(111, 0, 111, 0, false, false));
            kg.Keys.Add(new Key(112, 0, 112, 0, false, false));
            kg.Keys.Add(new Key(113, 0, 113, 0, false, false));
            kg.Keys.Add(new Key(114, 0, 114, 0, false, false));
            kg.Keys.Add(new Key(115, 0, 115, 0, false, false));
            kg.Keys.Add(new Key(116, 0, 116, 0, false, false));
            kg.Keys.Add(new Key(117, 0, 116, 0, false, false));
            kg.Keys.Add(new Key(118, 0, 118, 0, false, false));
            kg.Keys.Add(new Key(119, 0, 119, 0, false, false));
            kg.Keys.Add(new Key(120, 0, 120, 0, false, false));
            kg.Keys.Add(new Key(121, 0, 121, 0, false, false));
            kg.Keys.Add(new Key(122, 0, 122, 0, false, false));
            kg.Keys.Add(new Key(123, 0, 123, 0, false, false));
            kg.Keys.Add(new Key(124, 0, 124, 0, false, false));
            kg.Keys.Add(new Key(125, 0, 125, 0, false, false));
            kg.Keys.Add(new Key(126, 0, 126, 0, false, false));
            kg.Keys.Add(new Key(127, 0, 127, 0, false, false));
            kg.Keys.Add(new Key(128, 0, 128, 0, false, false));
            kg.Keys.Add(new Key(129, 0, 129, 0, false, false));
            kg.Keys.Add(new Key(224, 128, 224, 0, false, true));
            kg.Keys.Add(new Key(225, 129, 225, 0, false, true));
            kg.Keys.Add(new Key(226, 130, 226, 0, false, true));
            kg.Keys.Add(new Key(227, 131, 227, 0, false, true));
            kg.Keys.Add(new Key(228, 132, 228, 0, false, true));
            kg.Keys.Add(new Key(229, 133, 229, 0, false, true));
            kg.Keys.Add(new Key(230, 134, 230, 0, false, true));
            kg.Keys.Add(new Key(231, 135, 231, 0, false, true));
            kg.Keys.Add(new Key(300, 0, 0, 255, false, true));
            kg.Keys.Add(new Key(301, 1, 1, 1, true, true));
            kg.Keys.Add(new Key(302, 2, 2, 1, true, true));
            kg.Keys.Add(new Key(303, 3, 3, 1, true, true));
            kg.Keys.Add(new Key(304, 4, 4, 1, true, true));
            kg.Keys.Add(new Key(305, 5, 5, 1, true, true));
            kg.Keys.Add(new Key(306, 6, 6, 1, true, true));
            kg.Keys.Add(new Key(307, 7, 7, 1, true, true));
            kg.Keys.Add(new Key(308, 8, 8, 1, true, true));
            kg.Keys.Add(new Key(309, 9, 9, 1, true, true));
            kg.Keys.Add(new Key(310, 10, 10, 1, true, true));
            kg.Keys.Add(new Key(311, 11, 11, 1, true, true));
            kg.Keys.Add(new Key(312, 12, 12, 1, true, true));
            kg.Keys.Add(new Key(313, 13, 13, 1, true, true));
            kg.Keys.Add(new Key(314, 14, 14, 1, true, true));
            kg.Keys.Add(new Key(315, 15, 15, 1, true, true));
            kg.Keys.Add(new Key(316, 16, 16, 1, true, true));
            kg.Keys.Add(new Key(317, 17, 17, 1, true, true));
            kg.Keys.Add(new Key(318, 18, 18, 1, true, true));
            kg.Keys.Add(new Key(319, 19, 19, 1, true, true));
            kg.Keys.Add(new Key(321, 44, 1, 24, true, true));
            kg.Keys.Add(new Key(322, 44, 2, 23, true, true));
            kg.Keys.Add(new Key(323, 44, 3, 26, true, true));
            kg.Keys.Add(new Key(324, 44, 4, 27, true, true));
            kg.Keys.Add(new Key(325, 44, 5, 28, true, true));
            kg.Keys.Add(new Key(326, 44, 6, 29, true, true));
            kg.Keys.Add(new Key(327, 7, 7, 2, true, true));
            kg.Keys.Add(new Key(328, 8, 8, 2, true, true));
            kg.Keys.Add(new Key(329, 9, 9, 2, true, true));
            kg.Keys.Add(new Key(330, 10, 10, 2, true, true));
            kg.Keys.Add(new Key(331, 11, 11, 2, true, true));
            kg.Keys.Add(new Key(332, 12, 12, 2, true, true));
            kg.Keys.Add(new Key(333, 13, 13, 2, true, true));
            kg.Keys.Add(new Key(334, 14, 14, 2, true, true));
            kg.Keys.Add(new Key(335, 15, 15, 2, true, true));
            kg.Keys.Add(new Key(336, 16, 16, 2, true, true));
            kg.Keys.Add(new Key(337, 17, 17, 2, true, true));
            kg.Keys.Add(new Key(338, 18, 18, 2, true, true));
            kg.Keys.Add(new Key(339, 19, 19, 2, true, true));
            kg.Keys.Add(new Key(341, 1, 1, 3, true, true));
            kg.Keys.Add(new Key(342, 2, 2, 3, true, true));
            kg.Keys.Add(new Key(343, 3, 3, 3, true, true));
            kg.Keys.Add(new Key(344, 4, 4, 3, true, true));
            kg.Keys.Add(new Key(345, 5, 5, 3, true, true));
            kg.Keys.Add(new Key(346, 6, 6, 3, true, true));
            kg.Keys.Add(new Key(347, 7, 7, 3, true, true));
            kg.Keys.Add(new Key(348, 8, 8, 3, true, true));
            kg.Keys.Add(new Key(349, 9, 9, 3, true, true));
            kg.Keys.Add(new Key(350, 10, 10, 3, true, true));
            kg.Keys.Add(new Key(351, 11, 11, 3, true, true));
            kg.Keys.Add(new Key(352, 12, 12, 3, true, true));
            kg.Keys.Add(new Key(353, 13, 13, 3, true, true));
            kg.Keys.Add(new Key(354, 14, 14, 3, true, true));
            kg.Keys.Add(new Key(355, 15, 15, 3, true, true));
            kg.Keys.Add(new Key(356, 16, 16, 3, true, true));
            kg.Keys.Add(new Key(357, 17, 17, 3, true, true));
            kg.Keys.Add(new Key(358, 18, 18, 3, true, true));
            kg.Keys.Add(new Key(359, 19, 19, 3, true, true));
            kg.Keys.Add(new Key(360, 0, 0, 31, false, true));
            kg.Keys.Add(new Key(361, 1, 1, 31, false, true));
            kg.Keys.Add(new Key(362, 2, 2, 31, false, true));
            kg.Keys.Add(new Key(363, 3, 3, 31, false, true));
            kg.Keys.Add(new Key(364, 4, 4, 31, false, true));
            kg.Keys.Add(new Key(365, 5, 5, 31, false, true));
            kg.Keys.Add(new Key(366, 6, 6, 31, false, true));
            kg.Keys.Add(new Key(370, 0, 0, 6, false, true));
            kg.Keys.Add(new Key(371, 1, 1, 6, false, true));
            kg.Keys.Add(new Key(372, 2, 2, 6, false, true));
            kg.Keys.Add(new Key(380, 101, 101, 38, false, true));
            kg.Keys.Add(new Key(381, 236, 236, 38, false, true));
            kg.Keys.Add(new Key(382, 246, 246, 38, false, true));
            kg.Keys.Add(new Key(383, 10, 10, 38, false, true));
            kg.Keys.Add(new Key(384, 20, 20, 38, false, true));

            kg.Keys.Add(new Key(390, 0, 0, 32, false, true));
            kg.Keys.Add(new Key(391, 1, 1, 32, false, true));
            kg.Keys.Add(new Key(392, 2, 2, 32, false, true));
            kg.Keys.Add(new Key(393, 3, 3, 32, false, true));
            kg.Keys.Add(new Key(394, 4, 4, 32, false, true));
            kg.Keys.Add(new Key(395, 5, 5, 32, false, true));
            kg.Keys.Add(new Key(396, 6, 6, 32, false, true));
            kg.Keys.Add(new Key(397, 7, 7, 32, false, true));
            kg.Keys.Add(new Key(398, 8, 8, 32, false, true));
            kg.Keys.Add(new Key(399, 9, 9, 32, false, true));

            kg.Keys.Add(new Key(400, 0, 0, 33, false, true));
            kg.Keys.Add(new Key(401, 1, 1, 33, false, true));
            kg.Keys.Add(new Key(402, 2, 2, 33, false, true));
            kg.Keys.Add(new Key(403, 3, 3, 33, false, true));
            kg.Keys.Add(new Key(404, 4, 4, 33, false, true));
            kg.Keys.Add(new Key(405, 5, 5, 33, false, true));
            kg.Keys.Add(new Key(406, 6, 6, 33, false, true));
            kg.Keys.Add(new Key(407, 7, 7, 33, false, true));
            kg.Keys.Add(new Key(408, 8, 8, 33, false, true));
            kg.Keys.Add(new Key(409, 9, 9, 33, false, true));
            kg.Keys.Add(new Key(410, 10, 10, 33, false, true));
            kg.Keys.Add(new Key(411, 11, 11, 33, false, true));
            kg.Keys.Add(new Key(412, 12, 12, 33, false, true));
            kg.Keys.Add(new Key(413, 13, 13, 33, false, true));
            kg.Keys.Add(new Key(414, 14, 14, 33, false, true));
            kg.Keys.Add(new Key(415, 15, 15, 33, false, true));
            kg.Keys.Add(new Key(416, 16, 16, 33, false, true));
            kg.Keys.Add(new Key(417, 17, 17, 33, false, true));
            kg.Keys.Add(new Key(418, 18, 18, 33, false, true));
            kg.Keys.Add(new Key(419, 19, 19, 33, false, true));

            // mouse options
            kg.Keys.Add(new Key(450, 127, 127, 34, false, true));
            kg.Keys.Add(new Key(451, 126, 126, 34, false, true));
            kg.Keys.Add(new Key(452, 125, 125, 34, false, true));
            kg.Keys.Add(new Key(453, 129, 129, 34, false, true));
            kg.Keys.Add(new Key(454, 130, 130, 34, false, true));
            kg.Keys.Add(new Key(455, 131, 131, 34, false, true));
            kg.Keys.Add(new Key(456, 127, 127, 35, false, true));
            kg.Keys.Add(new Key(457, 126, 126, 35, false, true));
            kg.Keys.Add(new Key(458, 125, 125, 35, false, true));
            kg.Keys.Add(new Key(459, 129, 129, 35, false, true));
            kg.Keys.Add(new Key(460, 130, 130, 35, false, true));
            kg.Keys.Add(new Key(461, 131, 131, 35, false, true));
            kg.Keys.Add(new Key(462, 129, 129, 36, false, true));
            kg.Keys.Add(new Key(463, 127, 127, 36, false, true));
            kg.Keys.Add(new Key(464, 1, 1, 37, false, true));
            kg.Keys.Add(new Key(465, 2, 2, 37, false, true));
            kg.Keys.Add(new Key(466, 3, 3, 37, false, true));
            kg.Keys.Add(new Key(467, 4, 4, 37, false, true));
            kg.Keys.Add(new Key(468, 5, 5, 37, false, true));

            // pressed shift ctrl alt altgr
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 5, 5));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 8, 4));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 11, 6));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 14, 6));// REMARK this does not work

            // dual roles ctrl shift alt altgr win
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 17, 20));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 20, 21));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 23, 22));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 26, 23));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 60, 21)); // REMARK this does not work
            // dual roles fn1
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 29, 25, true));
            // dual roles fn2
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 32, 26, true));
            // dual roles fn3
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 35, 27, true));
            // dual roles fn4
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 38, 28, true));
            // dual roles fn5
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 41, 29, true));
            // dual roles fn6
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 44, 25, true)); //REMARK this does not work

            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 47, 8));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 50, 14));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 53, 9));
            kg.Keys.AddRange(KeyGroup.GenereateSubHIDSet(kg, 56, 11));

            // stickyctrls
            kg.Keys.Add(new Key(5900, 0, 0, 30, false, false));
            kg.Keys.Add(new Key(5901, 0, 1, 30, false, false));
            kg.Keys.Add(new Key(5902, 0, 2, 30, false, false));
            kg.Keys.Add(new Key(5903, 0, 3, 30, false, false));

            byte ctr = 4;
            for (int i = 5904; i < 5914; i++)
            {
                kg.Keys.Add(new Key(i, 0, ctr, 30, true, false));
                ctr++;
            }

            return kg;
        }
    }
}
