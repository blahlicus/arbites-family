using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesR
{
    public class ClKeyboard
    {
        public string keyboardName { get; set; }
        public string keyboardType { get; set; }
        public string fileFormat { get; set; }
        public int layers { get; set; }
        public List<ClBoardSlice> slices { get; set; }

        public ClKeyboard()
        {
            keyboardName = "Unknown Keyboard Type";
            keyboardType = "Unknown Keyboard Type";
            fileFormat = ".arbru";
            slices = new List<ClBoardSlice>();
        }

        public bool LoadLayout(ClLayoutContainer input)
        {
            bool output = false;
            if (input.keyboardType == this.keyboardType)
            {
                this.layers = input.layers;
                foreach(ClKeyData key in input.keys)
                {
                    slices[key.slice].keys.Where(o => (o.x == key.x && o.y == key.y)).FirstOrDefault().keys.Add(key.key);
                }
            }

            return output;
        }

        public List<string> GetSerialCommand()
        {
            List<string> output = new List<string>();
            output.Add(MdGlobals.SERIAL_SET_LAYER_COMMAND + "(" + layers.ToString());
            foreach (ClBoardSlice slice in slices)
            {
                output.AddRange(slice.GetSerialCommand());
            }
            return output;
        }

    }
}
