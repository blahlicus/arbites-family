using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbites4
{
    public class MdGlobals
    {
        public static int selectedX { get; set; }
        public static int selectedY { get; set; }
        public static int selectedZ { get; set; }
        public static bool specialS { get; set; }
        public static ClKey selectedS { get; set; }
        public static List<List<List<ClKey>>> keys { get; set; }
    }
}
