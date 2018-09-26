using System.Collections.Generic;
using System.Linq;

namespace ArbitesEto2
{
    public class LayoutContainer
    {
        public List<KeyData> KeyDatas { get; set; }
        public List<AdditionalData> AddonDatas { get; set; }

        public LayoutContainer()
        {
            this.KeyDatas = new List<KeyData>();
            this.AddonDatas = new List<AdditionalData>();
        }

        public LayoutContainer(LayoutContainer input)
        {
            this.KeyDatas = new List<KeyData>();
            foreach (var kd in input.KeyDatas)
            {
                this.KeyDatas.Add(new KeyData(kd));
            }

            this.AddonDatas = new List<AdditionalData>();
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
            var alist = new List<KeyData>();
            foreach (var kd in this.KeyDatas)
            {
                if (kd.Z == 0)
                {
                    var tkd = new KeyData(kd);
                    tkd.Z = input;
                    alist.Add(tkd);
                }
            }
            this.KeyDatas.AddRange(alist);
        }

        public List<byte> GenerateBinaryCommand(Keyboard board)
        {
            var preArr = new List<byte>();
            preArr.Add(0); //message key
            preArr.Add(1); //message key
            preArr.Add(2); //message key
            preArr.Add(3); //message key
            preArr.Add(4); //message type (load layout and mod data)


            // generate main key layout

            int commandType = 0;
            if (board.Commands[0] == "uniqueksetsubkey")
            {
                commandType = 1;
            }
            var arr = new List<byte>();
            for (int k = 0; k < KeyDatas.Select(ele => ele.Z).Max() + 1; k++)
            {
                for (int i = 0; i < board.YCount; i++)
                {
                    for (int j = 0; j < board.XCount; j++)
                    {
                        var result = KeyDatas.Where(ele => ele.X == j && ele.Y == i && ele.Z == k && ele.Command == commandType).ToList();
                        if (result.Count > 0)
                        {
                            arr.Add(result[0].Key.ValScan);
                            arr.Add(result[0].Key.KeyType);
                        }
                        else
                        {
                            arr.Add(0);
                            arr.Add(0);
                        }
                    }
                }
            }

            //TODO: add mod handling here

            while (arr.Count < board.MaxEEPROM)
            {
                arr.Add(0);
            }
            // end of main layout

            //TODO: generate sub layout

            var output = new List<byte>();
            output.AddRange(preArr);
            output.AddRange(arr);
            return output;
        }

        // Deprecated
        public List<string> GenerateCommand(Keyboard board, bool isScancode = true)
        {
            var lt = new List<string>();
            var layCount = 0;
            if (this.KeyDatas.Count > 0)
            {
                layCount = this.KeyDatas.Max(ele => ele.Z) + 1;
            }
            lt.Add("uniqueksetlay(" + layCount + " ");
            lt.Add("uniqueksetsublay(" + layCount + " ");
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
