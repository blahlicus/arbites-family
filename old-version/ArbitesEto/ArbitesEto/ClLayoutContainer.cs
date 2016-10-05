using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    public class ClLayoutContainer
    {
        public string keyboardType { get; set; }
        //public List<ClKeyData> keys { get; set; }
        public List<List<ClKeyData>> keys { get; set; }

        public ClLayoutContainer()
        {
            keys = new List<List<ClKeyData>>();
        }


    }
}
