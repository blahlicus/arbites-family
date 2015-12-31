using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbites4
{
    public class ClKey
    {
        public char val { get; set; }
        public Byte ktype { get; set; }
        public string display { get; set; }

        public ClKey()
        {
            val = (char)0;
            display = "Null";
            ktype = 255;
        }

        public ClKey(char val, Byte ktype, string display)
        {
            this.val = val;
            this.ktype = ktype;
            this.display = display;
        }
    }
}
