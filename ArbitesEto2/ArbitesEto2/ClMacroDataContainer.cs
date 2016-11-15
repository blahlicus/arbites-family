using System.Collections.Generic;
using System.Linq;


namespace ArbitesEto2
{

    public class ClMacroDataContainer : ClAdditionalData
    {

        public List<ClMacroData> MacroKeys { get; set; }
        public const string DATA_TYPE = "macro";

        public ClMacroDataContainer()
        {
            this.MacroKeys = new List<ClMacroData>();
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
