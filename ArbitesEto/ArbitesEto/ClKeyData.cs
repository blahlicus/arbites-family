using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    public class ClKeyData
    {
        public ClKey key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int slice { get; set; }
        public ClKeyData()
        {
            key = new ClKey();
            x = 0;
            y = 0;
            slice = 0;
        }
        public ClKeyData(int slice, int x, int y)
        {
            key = new ClKey();
            this.x = x;
            this.y = y;
            this.slice = slice;
        }
    }
}
