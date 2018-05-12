using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArbitesEto2
{
    [Serializable]
    [XmlInclude(typeof(MacroDataContainer))]
    [XmlInclude(typeof(TapDanceDataContainer))]
    public abstract class AdditionalData
    {
        public new abstract string GetType();

        public abstract List<string> GetCommands();
    }
}
