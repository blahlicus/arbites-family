using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClBoardSlice
    {
        public string command { get; set; }
        public string sliceName { get; set; }
        public int sliceIndex { get; set; }
        public int layers { get; set; }
        public List<ClButton> keys { get; set; }

        public ClBoardSlice()
        {
            command = "uniqueksetkey";
            layers = 0;
            keys = new List<ClButton>();
        }

        public ClBoardSlice(string command, string sliceName, int sliceIndex, int layers)
        {
            this.command = command;
            this.layers = layers;
            this.sliceIndex = sliceIndex;
            this.sliceName = sliceName;
            keys = new List<ClButton>();
        }

        public List<string> GetSerialCommand()
        {
            List<string> output = new List<string>();
            foreach (ClButton btn in keys)
            {
                for (int i = 0; i < btn.keys.Count; i++ )
                {
                    output.Add(command + "(" + btn.x.ToString() + "(" + btn.y.ToString() + "(" + i.ToString() + "(" + btn.keys[i].val.ToString() + "(" + btn.keys[i].ktype.ToString());
                }
            }
            return output;
        }

    }
}
