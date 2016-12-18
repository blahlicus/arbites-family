using System.Collections.Generic;
using System.Linq;


namespace ArbitesEto2
{

    public class ClTapDanceDataContainer : ClAdditionalData
    {

        public List<ClTapDanceData> TapDanceKeys { get; set; }
        public const string DATA_TYPE = "tapdance";

        public ClTapDanceDataContainer()
        {
            this.TapDanceKeys = new List<ClTapDanceData>();
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
