using System;
using System.IO;


namespace ArbitesEto2
{

    public class MdPersistentData
    {

        public static MdPersistentData Main { get; set; }
        public bool IsPortable { get; set; }


        private static string _configPath;

        public static string ConfigPath
        {
            get
            {
                if (Main.IsPortable)
                {
                    return MdConstant.root;
                }
                return _configPath;
            }
            set { _configPath = value; }
        }


        public MdPersistentData()
        {
            this.IsPortable = true;
        }

        public static void Init()
        {
            Main = MdCore.Deserialize<MdPersistentData>(MdConstant.N_PERSISTENT_DATA);
            ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ArbitesData");
        }

        public static string GetPath(string input)
        {
            var output = Path.Combine(ConfigPath, input);
            return output;
        }

    }

}
