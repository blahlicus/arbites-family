using System.Collections.Generic;
using System.Linq;


namespace ArbitesEto2
{

    public class ClLayoutContainer
    {

        public List<ClKeyData> KeyDatas { get; set; }
        public List<ClAdditionalData> AddonDatas { get; set; }

        public ClLayoutContainer()
        {
            this.KeyDatas = new List<ClKeyData>();
            this.AddonDatas = new List<ClAdditionalData>();
        }

        public ClLayoutContainer(ClLayoutContainer input)
        {
            this.KeyDatas = new List<ClKeyData>();
            foreach (var kd in input.KeyDatas)
            {
                this.KeyDatas.Add(new ClKeyData(kd));
            }

            this.AddonDatas = new List<ClAdditionalData>();
            foreach (var ad in input.AddonDatas)
            {
                this.AddonDatas.Add(ad);
            }
        }

        public void DeleteLayer(int input)
        {
            this.KeyDatas.RemoveAll(kd => kd.Z == input);
            foreach (var kd in this.KeyDatas)
            {
                if (kd.Z > input)
                {
                    kd.Z--;
                }
            }
        }

        public void AddLayer(int input)
        {
            var alist = new List<ClKeyData>();
            foreach (var kd in this.KeyDatas)
            {
                if (kd.Z == 0)
                {
                    var tkd = new ClKeyData(kd);
                    tkd.Z = input;
                    alist.Add(tkd);
                }
            }
            this.KeyDatas.AddRange(alist);
        }

        public List<string> GenerateCommand(ClKeyboard board, bool isScancode = true)
        {
            var lt = new List<string>();
            var layCount = 0;
            if (this.KeyDatas.Count > 0)
            {
                layCount = this.KeyDatas.Max(ele => ele.Z) + 1;
            }
            lt.Add("uniqueksetlay(" + layCount + " ");
            foreach (var kd in this.KeyDatas)
            {
                string keyVal;
                if (isScancode)
                {
                    keyVal = kd.Key.ValScan.ToString();
                }
                else
                {
                    keyVal = kd.Key.ValASCII.ToString();
                }
                lt.Add(board.Commands[kd.Command] + "(" + kd.X + "(" + kd.Y + "(" + kd.Z + "(" + keyVal + "(" + kd.Key.KeyType + " ");
            }

            foreach (var ad in this.AddonDatas)
            {
                lt.AddRange(ad.GetCommands());
            }

            return lt;
        }

    }

}
