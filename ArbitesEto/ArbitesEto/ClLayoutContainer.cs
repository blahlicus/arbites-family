using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
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

        public void DeleteLayer(int index)
        {
            if (layers > 1)
            {
                layers--;
                keys = keys.Where(k => k.z != index).ToList();
                var tlist = keys.Where(k => k.z > index).ToList();
                foreach (ClKeyData kd in tlist)
                {
                    kd.z--;
                }
            }
        }


    }
}
