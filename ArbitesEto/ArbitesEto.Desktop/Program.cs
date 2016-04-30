using System;
using Eto;
using Eto.Forms;

namespace ArbitesEto.Desktop
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platform.Detect).Run(new FmMain());
        }
    }
}
