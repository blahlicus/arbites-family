namespace ArbitesEto2
{
    public class Key
    {
        public int DisplayID { get; set; }
        public byte ValASCII { get; set; }
        public byte ValScan { get; set; }
        public byte KeyType { get; set; }
        public bool AllLayers { get; set; }
        public bool HasASCII { get; set; }

        public Key()
        {
            this.DisplayID = 300;
            this.ValASCII = 0;
            this.ValScan = 0;
            this.KeyType = 255;
            this.AllLayers = false;
            this.HasASCII = true;
        }

        public Key(int displayID, byte valASCII, byte valScan, byte keyType, bool allLayers, bool hasASCII)
        {
            this.DisplayID = displayID;
            this.ValASCII = valASCII;
            this.ValScan = valScan;
            this.KeyType = keyType;
            this.AllLayers = allLayers;
            this.HasASCII = hasASCII;
        }

        public Key(int displayID, byte valASCII, byte valScan, byte keyType) : this(displayID, valASCII, valScan, keyType, false, true)
        {
        }

        public Key(int displayID, byte valScan, byte keyType) : this(displayID, 0, valScan, keyType, false, false)
        {
        }

        public Key(Key input)
        {
            this.DisplayID = input.DisplayID;
            this.ValASCII = input.ValASCII;
            this.ValScan = input.ValScan;
            this.KeyType = input.KeyType;
            this.AllLayers = input.AllLayers;
            this.HasASCII = input.HasASCII;
        }
    }
}
