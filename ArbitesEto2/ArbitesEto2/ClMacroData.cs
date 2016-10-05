using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class ClMacroData
    {
        public int Index { get; set; }
        public List<bool> IsKeyDown { get; set; }
        public List<ClKey> Keys { get; set; }
        public ClMacroData()
        {
            IsKeyDown = new List<bool>();
            Keys = new List<ClKey>();
            Index = -1;
            
        }

        public ClMacroData(ClMacroData input) : this()
        {
            IsKeyDown = input.IsKeyDown.Select(ele => ele).ToList();
            Keys = input.Keys.Select(ele => new ClKey(ele)).ToList();
            Index = input.Index;
        }

        public string GenerateCommand()
        {
            string output = "uniqueksetmacro(" + Index.ToString() + "(" + Keys.Count.ToString();

            for (int i = 0; i < 8; i++ )
            {
                if (Keys.Count > i)
                {

                    var keyDVal = 0;
                    if (IsKeyDown[i])
                    {
                        keyDVal = 0;
                    }
                    else
                    {
                        keyDVal = 1;
                    }
                    output = output + "(" + Keys[i].ValScan.ToString() + "(" + Keys[i].KeyType.ToString() + "(" + keyDVal.ToString();
                }
                else
                {
                    output = output + "(0(0(0";
                }
            }
            output = output + " ";

            return output;
        }

    }
}
