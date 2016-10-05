using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
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


        public List<string> GenerateSerialCommands(ClLayoutContainer input)
        {
            List<string> output = new List<string>();
            output.Add(MdGlobals.SERIAL_SET_LAYER_COMMAND + "(" + layers + " ");
            foreach (ClBoardSlice slice in slices)
            {
                output.AddRange(slice.GenerateSerialCommands(input));
            }
            return output;
        }

    }
}
