using System;
using System.Collections.Generic;

namespace ArbitesEto2
{
    [Serializable]
    public abstract class AdditionalData
    {
        public new abstract string GetType();

        public abstract List<string> GetCommands();
    }
}
