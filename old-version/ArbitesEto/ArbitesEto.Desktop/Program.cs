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

            if (Platform.Detect.IsMac)
            {
                new Application(Eto.Platforms.Gtk2).Run(new FmMain());
            }
            else
            {
                //new Application(Eto.Platforms.WinForms).Run(new FmMain());
                new Application(Platform.Detect).Run(new FmMain());

            }
        }
    }
}
