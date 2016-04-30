using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    public class ClButton
    {
        public int x { get; set; }
        public int y { get; set; }
        public int gw { get; set; }
        public int gh { get; set; }
        public int gx { get; set; }
        public int gy { get; set; }
        //public List<ClKey> keys { get; set; }

        public ClButton()
        {
            x = 0;
            y = 0;
            gw = 0;
            gh = 0;
            gx = 0;
            gy = 0;
            //keys = new List<ClKey>();
        }

        public ClButton(int x, int y, int gw, int gh, int gx, int gy)
        {
            this.x = x;
            this.y = y;
            this.gw = gw;
            this.gh = gh;
            this.gx = gx;
            this.gy = gy;
            //keys = new List<ClKey>();
        }
    }
}
