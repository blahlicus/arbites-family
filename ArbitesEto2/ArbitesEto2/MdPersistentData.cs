using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class MdPersistentData
    {
        public static MdPersistentData Main { get; set; }
        public bool IsPortable { get; set; }



        private static string _ConfigPath;

	    public static string ConfigPath
	    {
		    get
            {
                if (Main.IsPortable)
                {
                    return MdConstant.root;
                }
                else
                {
                    return _ConfigPath;
                }
            }
		    set { _ConfigPath = value;}
	    }
	

        public MdPersistentData()
        {
            IsPortable = true;
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
