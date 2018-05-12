using System;
using System.IO;

namespace ArbitesEto2
{
    public class MdPersistentData
    {
        public static MdPersistentData Main { get; set; }
        public bool IsPortable { get; set; }

        public static string ConfigPath
        {
            get
            {
                return MdConstant.root;
            }
        }

        public MdPersistentData()
        {
            this.IsPortable = true;
        }

        public static void Init()
        {
        }

        public static string GetPath(string input)
        {
            var output = Path.Combine(ConfigPath, input);
            return output;
        }
    }
}
