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

        public List<string> GenerateSerialCommands(ClLayoutContainer input)
        {
            List<string> output = new List<string>();
            foreach (ClKeyData ckd in input.keys)
            {
                if (ckd.slice == sliceIndex)
                {
                    output.Add(command + "(" + ckd.x + "(" + ckd.y + "(" + ckd.z + "(" + ckd.key.val + "(" + ckd.key.ktype + " ");
                }
            }
            return output;
        }

    }
}
