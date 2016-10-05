using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class ClMacroDataContainer : ClAdditionalData
    {
        public List<ClMacroData> MacroKeys { get; set; }
        public const string DATA_TYPE = "macro";
        public ClMacroDataContainer()
        {
            MacroKeys = new List<ClMacroData>();
        }

        override public string GetType()
        {
            var output = DATA_TYPE;
            return output;
        }

        override public List<string> GetCommands()
        {
            var output = new List<string>();
            foreach(var mk in MacroKeys)
            {
                if (mk.Keys.Count > 0)
                {
                    output.Add(mk.GenerateCommand());
                }
            }
            return output;
        }
    }
}
