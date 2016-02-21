using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClLayoutContainer
    {
        public string keyboardType { get; set; }
        public int layers { get; set; }
        public List<ClKeyData> keys { get; set; }

        public ClLayoutContainer()
        {
            keys = new List<ClKeyData>();
        }


    }
}
