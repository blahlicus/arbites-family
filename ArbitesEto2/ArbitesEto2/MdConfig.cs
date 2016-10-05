using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class MdConfig
    {
        public static MdConfig Main { get; set; }

        public bool KeyMenuTopmost { get; set; }

        public bool DisplayOutput { get; set; }

        public int UploadDelay { get; set; }

        private string _CurrentInputMethod;

        public string CurrentInputMethod
        {
            get { return _CurrentInputMethod; }
            set
            {
                _CurrentInputMethod = value;
            }
        }
        
        public static void Init()
        {

            Main = MdCore.Deserialize<MdConfig>(Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
            
            
        }

        public MdConfig()
        {
            CurrentInputMethod = "US-ASCII" + MdConstant.E_INPUT_METHOD;
            KeyMenuTopmost = true;
            DisplayOutput = false;
            UploadDelay = 10;
        }

        public ClDisplayCharacterContainer GetCurrentInputMethod()
        {
            return MdCore.Deserialize<ClDisplayCharacterContainer>(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD, CurrentInputMethod));
        }
    }
}
