using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClKeyGroup
    {
        public List<ClKey> key { get; set; }
        public string name { get; set; }
        public int priority { get; set; }

        public ClKeyGroup(string name, int priority, List<ClKey> key)
        {
            this.name = name;
            this.priority = priority;
            this.key = key;
        }

        public ClKeyGroup()
        {
            this.name = "";
            this.priority = -1;
            this.key = new List<ClKey>();
        }
    }
}
