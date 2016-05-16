using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    public class ClKey
    {
        public Byte val { get; set; }
        public Byte ktype { get; set; }
        public string display { get; set; }
        public bool allLayers { get; set; }

        public ClKey()
        {
            val = 0;
            display = "Null";
            ktype = 255;
            allLayers = false;
        }

        public ClKey(byte val, Byte ktype, string display, bool allLayers)
        {
            this.val = val;
            this.ktype = ktype;
            this.display = display;
            this.allLayers = allLayers;
        }
        /*
        public static List<ClKey> dKeys { get; set; }
        public static List<ClKey> alpha { get; set; }
        public static List<ClKey> numeric { get; set; }
        public static List<ClKey> symbol { get; set; }
        public static List<ClKey> numpad { get; set; }
        public static List<ClKey> special { get; set; }
        //*/
        public static List<ClKeyGroup> lists { get; set; }
        public static List<ClKey> dKeys { get; set; }
        public static void iniList()
        {
            lists = new List<ClKeyGroup>();
            dKeys = new List<ClKey>();
            List<string> files = System.IO.Directory.GetFiles(MdConstants.keygroups, MdConstants.eKeygroups).ToList<string>();

            foreach (string file in files)
            {
                
                var kg = MdCore.Deserialize<ClKeyGroup>(file);
                lists.Add(kg);
                dKeys.AddRange(kg.key);
            }
            dKeys = dKeys.Distinct().ToList();
            lists = lists.OrderBy(kg => kg.priority).ToList();



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
