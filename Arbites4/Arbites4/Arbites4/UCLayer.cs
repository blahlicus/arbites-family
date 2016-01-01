using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbites4
{
    public partial class UCLayer : UserControl
    {
        public event EventHandler deleteSent;

        public int layCount { get; set; }
        public UCLayer()
        {
            InitializeComponent();
        }

        public UCLayer(int x, int y, int z)
        {
            InitializeComponent();
            lLayer.Text = "Layer " + z;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button newb = new Button();
                    newb.Name = "bt_" + i + "_" + j;
                    newb.Text = "";
                    newb.Size = new Size(72, 72);
                    newb.Location = new Point(8 + (72*i), 16 + (72*j));
                    newb.Parent = this;
                    newb.Click += new EventHandler(this.KeyBtnClicked);
                    newb.KeyPress += new KeyPressEventHandler(this.KeyBtnKeyPressed);
                    
                }
            }

            this.Size = new Size(64 + (72) * x, 64 + (72) * y);
        }

        private void KeyBtnClicked (object sender, EventArgs e)
        {

            var btn = sender as Button;
            string input = btn.Name;
            input = input.Substring(input.IndexOf("_")+1);
            int x = Convert.ToInt32(input.Substring(0, input.IndexOf("_")));
            input = input.Substring(input.IndexOf("_")+1);
            int y = Convert.ToInt32(input);
            int z = layCount;

            MdGlobals.selectedX = x;
            MdGlobals.selectedY = y;
            MdGlobals.selectedZ = z;
            if (MdGlobals.specialS)
            {

                btn.Text = MdGlobals.selectedS.display;
                MdGlobals.keys[MdGlobals.selectedX][MdGlobals.selectedY][MdGlobals.selectedZ] = MdGlobals.selectedS;
                lLayer.Focus();
                MdGlobals.specialS = false;
            }
        }

        private void KeyBtnKeyPressed (object sender, KeyPressEventArgs e)
        {
            var btn = sender as Button;
            btn.Text = ClKey.GetDisplayFromChar(e.KeyChar);
            MdGlobals.keys[MdGlobals.selectedX][MdGlobals.selectedY][MdGlobals.selectedZ] = ClKey.GetKeyFromChar(e.KeyChar);
            lLayer.Focus();
        }


    }
}
