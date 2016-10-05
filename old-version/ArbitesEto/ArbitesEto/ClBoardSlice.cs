using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
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
            this.layers = -1; // deprecated
            this.sliceIndex = sliceIndex;
            this.sliceName = sliceName;
            keys = new List<ClButton>();
        }

        public List<string> GenerateSerialCommands(ClLayoutContainer input)
        {
            List<string> output = new List<string>();
            int _lay = 0;
            foreach (List<ClKeyData> ckdl in input.keys)
            {

                foreach (ClKeyData ckd in ckdl)
                {
                    if (ckd.slice == sliceIndex)
                    {
                        output.Add(command + "(" + ckd.x + "(" + ckd.y + "(" + _lay + "(" + ckd.key.val + "(" + ckd.key.ktype + " ");
                    }
                }
                _lay++;
            }
            return output;
        }

    }
}
