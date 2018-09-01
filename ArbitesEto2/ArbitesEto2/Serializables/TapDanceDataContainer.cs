using System.Collections.Generic;
using System.Linq;

namespace ArbitesEto2
{
    public class TapDanceDataContainer : AdditionalData
    {
        public List<TapDanceData> TapDanceKeys { get; set; }
        public const string DATA_TYPE = "tapdance";

        public TapDanceDataContainer()
        {
            this.TapDanceKeys = new List<TapDanceData>();
        }

        public override string GetType()
        {
            var output = DATA_TYPE;
            return output;
        }

        public override List<string> GetCommands()
        {
            return (from mk in this.TapDanceKeys where mk.Keys.Count > 0 select mk.GenerateCommand()).ToList();
        }
    }
}
