namespace ArbitesEto2
{

    public class ClKeyData
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Command { get; set; }
        public ClKey Key { get; set; }

        public ClKeyData()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.Command = 0;
            this.Key = new ClKey();
        }

        public ClKeyData(ClKeyData input)
        {
            this.X = input.X;
            this.Y = input.Y;
            this.Z = input.Z;
            this.Command = input.Command;
            this.Key = new ClKey(input.Key);
        }

    }

}
