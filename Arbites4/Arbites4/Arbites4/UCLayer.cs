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
        public List<Button> buttons { get; set; }
        public int layCount { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public UCLayer()
        {
            InitializeComponent();
        }

        public UCLayer(int cx, int cy, int z)
        {
            this.x = cx;
            this.y = cy;
            buttons = new List<Button>();
            layCount = z;
            InitializeComponent();
            lLayer.Text = "Layer " + z;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button newb = new Button();
                    newb.Name = "bt_" + i + "_" + j;
                    newb.Text = "Null";
                    newb.Size = new Size(72, 72);
                    newb.Location = new Point(8 + (72*i), 16 + (72*j));
                    newb.Parent = this;
                    newb.Click += new EventHandler(this.KeyBtnClicked);
                    newb.KeyPress += new KeyPressEventHandler(this.KeyBtnKeyPressed);
                    buttons.Add(newb);
                    
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
                MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][MdGlobals.selectedZ] = MdGlobals.selectedS;
                if (checkBox1.Checked)
                {
                    MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][0] = MdGlobals.selectedS;
                    MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][1] = MdGlobals.selectedS;
                    MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][2] = MdGlobals.selectedS;

                }
                lLayer.Focus();
                MdGlobals.specialS = false;
                MdGlobals.board.updateLayers();
            }
        }

        private void KeyBtnKeyPressed (object sender, KeyPressEventArgs e)
        {
            var btn = sender as Button;
            MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][MdGlobals.selectedZ] = ClKey.GetKeyFromChar(e.KeyChar);
            if (checkBox1.Checked)
            {
                MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][0] = ClKey.GetKeyFromChar(e.KeyChar);
                MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][1] = ClKey.GetKeyFromChar(e.KeyChar);
                MdGlobals.keys.keys[MdGlobals.selectedX][MdGlobals.selectedY][2] = ClKey.GetKeyFromChar(e.KeyChar);

            }
            btn.Text = ClKey.GetDisplayFromChar(e.KeyChar);
            lLayer.Focus();
            MdGlobals.board.updateLayers();
        }

        public void updateLayer()
        {
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button btn = buttons.Find(b => b.Name == "bt_" + i + "_" + j);
                    btn.Text = MdGlobals.keys.keys[i][j][layCount].display;
                }
            }
        }


    }
}
