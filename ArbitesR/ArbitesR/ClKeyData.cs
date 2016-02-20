using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClKeyData
    {
        public ClKey key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int slice { get; set; }
        public ClKeyData()
        {
            key = new ClKey();
            x = 0;
            y = 0;
            z = 0;
            slice = 0;
        }
    }
}
