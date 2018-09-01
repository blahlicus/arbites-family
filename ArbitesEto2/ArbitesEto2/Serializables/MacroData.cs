using System.Collections.Generic;
using System.Linq;

namespace ArbitesEto2
{
    public class MacroData
    {
        public int Index { get; set; }
        public List<bool> IsKeyDown { get; set; }
        public List<Key> Keys { get; set; }

        public MacroData()
        {
            this.IsKeyDown = new List<bool>();
            this.Keys = new List<Key>();
            this.Index = -1;
        }

        public MacroData(MacroData input) : this()
        {
            this.IsKeyDown = input.IsKeyDown.Select(ele => ele).ToList();
            this.Keys = input.Keys.Select(ele => new Key(ele)).ToList();
            this.Index = input.Index;
        }

        public string GenerateCommand()
        {
            var output = "uniqueksetmacro(" + this.Index + "(" + this.Keys.Count;

            for (var i = 0; i < 8; i++)
            {
                if (this.Keys.Count > i)
                {
                    int keyDVal;
                    if (this.IsKeyDown[i])
                    {
                        keyDVal = 0;
                    }
                    else
                    {
                        keyDVal = 1;
                    }
                    output = output + "(" + this.Keys[i].ValScan + "(" + this.Keys[i].KeyType + "(" + keyDVal;
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
