using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbites4
{
    public class ClLayoutContainer
    {
        public List<List<List<ClKey>>> keys { get; set; }

        public ClLayoutContainer()
        {

        }

        public ClLayoutContainer(int x, int y, int z)
        {
            keys = new List<List<List<ClKey>>>();
            for (int i = 0; i < x; i++)
            {
                var il = new List<List<ClKey>>();
                keys.Add(il);
                for (int j = 0; j < y; j++)
                {
                    var jl = new List<ClKey>();
                    il.Add(jl);
                    for (int k = 0; k < z; k++)
                    {
                        var kl = new ClKey();
                        jl.Add(kl);
                    }
                }
            }
        }
    }
}
