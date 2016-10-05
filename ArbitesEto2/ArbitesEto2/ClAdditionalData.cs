using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(ClMacroDataContainer))]
    public abstract class ClAdditionalData
    {
        abstract public string GetType();

        abstract public List<string> GetCommands(); 

        public ClAdditionalData()
        {

        }
    }
}
