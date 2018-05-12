using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class TapDanceData
    {
        public int Index { get; set; }
        public int Delay { get; set; }
        public List<Key> Keys { get; set; }

        public TapDanceData()
        {
            this.Index = -1;
            this.Keys = new List<Key>();
            this.Delay = 40;
        }

        public TapDanceData(TapDanceData input) : this()
        {
            this.Index = input.Index;
            this.Keys = input.Keys.Select(ele => new Key(ele)).ToList();
            this.Delay = input.Delay;
        }

        public string GenerateCommand()
        {
            var output = "uniqueksettapdance(" + this.Index + "(" + this.Keys.Count + "(" + this.Delay;


            for (var i = 0; i < 3; i++)
            {
                if (this.Keys.Count > i)
                {
                    output = output + "(" + this.Keys[i].ValScan + "(" + this.Keys[i].KeyType;
                }
                else
                {
                    output = output + "(0(0";
                }
            }
            output = output + " ";
            return output;
        }
    }
}
