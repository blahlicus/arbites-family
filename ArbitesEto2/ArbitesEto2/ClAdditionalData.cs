using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace ArbitesEto2
{

    [Serializable]
    [XmlInclude(typeof(ClMacroDataContainer))]
    [XmlInclude(typeof(ClTapDanceDataContainer))]
    public abstract class ClAdditionalData
    {

        public new abstract string GetType();

        public abstract List<string> GetCommands();

    }

}
