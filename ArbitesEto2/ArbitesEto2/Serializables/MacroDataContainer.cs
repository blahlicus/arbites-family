using System.Collections.Generic;
using System.Linq;

namespace ArbitesEto2
{
    public class MacroDataContainer : AdditionalData
    {
        public List<MacroData> MacroKeys { get; set; }
        public const string DATA_TYPE = "macro";

        public MacroDataContainer()
        {
            this.MacroKeys = new List<MacroData>();
        }

        public override string GetType()
        {
            var output = DATA_TYPE;
            return output;
        }

        public override List<string> GetCommands()
        {
            return (from mk in this.MacroKeys where mk.Keys.Count > 0 select mk.GenerateCommand()).ToList();
        }
    }
}
