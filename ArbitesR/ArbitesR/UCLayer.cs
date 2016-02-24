using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitesR
{
    public partial class UCLayer : UserControl
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Button> buttons { get; set; }
        public int index { get; set; }
        public int sliceIndex { get; set; }
        public ClLayoutContainer layout { get; set; }
        public UCLayer()
        {
            InitializeComponent();
            buttons = new List<Button>();
            index = 0;
            sliceIndex = 0;
        }


        public UCLayer(List<ClButton> buttons, int sliceIndex, int index, ClLayoutContainer layout)
        {
            InitializeComponent();
            this.layout = layout;
            this.buttons = new List<Button>();
            this.index = index;
            this.sliceIndex = sliceIndex;
            this.lLayerCount.Text = "Layer " + index;
            int maxx = 0, maxy = 0;
            foreach (ClButton input in buttons)
            {
                if (input.gw + input.gx > maxx)
                {
                    maxx = input.gw + input.gx +5;
                }
                if (input.gh + input.gy > maxy)
                {
                    maxy = input.gh + input.gy +5;
                }
                var btn = new Button();
                btn.Name = "bt_" + sliceIndex + "_" + input.x + "_" + input.y + "_" + index;
                layout.keys.Add(new ClKeyData(sliceIndex, input.x, input.y, index));
                btn.Text = "Null";
                btn.Size = new Size(input.gw, input.gh);
                btn.Location = new Point(input.gx, input.gy);
                btn.Parent = this;
                btn.Click += new EventHandler(this.KeyBtnClicked);
                //btn.KeyDown += new KeyEventHandler(this.KeyBtnKeyDown);
                //btn.KeyUp += new KeyEventHandler(this.KeyBtnKeyUp);
                btn.KeyPress += new KeyPressEventHandler(this.KeyBtnKeyPressed);
                this.buttons.Add(btn);
            }
            this.Size = new Size(maxx, maxy);
        }


        public void LoadLayout(ClLayoutContainer input)
        {
            this.layout = input;
            foreach (Button btn in buttons )
            {
                foreach (ClKeyData kd in input.keys)
                {
                    if (btn.Name == "bt_" + kd.slice + "_" + kd.x + "_" + kd.y + "_" + kd.z)
                    {
                        btn.Text = kd.key.display;
                    }
                }
            }
        }

        private void KeyBtnClicked (object sender, EventArgs e)
        {
        }
        /*
        private void KeyBtnKeyDown(object sender, KeyEventArgs e)
        {
            //(sender as Button).Enabled = false;
        }
        private void KeyBtnKeyUp(object sender, KeyEventArgs e)
        {
            //(sender as Button).Enabled = true;
        }
        //*/

        private void KeyBtnKeyPressed(object sender, KeyPressEventArgs e)
        {
            SetLayoutFromButton(sender as Button, e.KeyChar);
        }

        private void SetLayoutFromButton(Button sender, char input)
        {

            string btn = sender.Name;
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int slice = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int x = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int y = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int z = Convert.ToInt32(btn);


            if (cbAllLayers.Checked)
            {
                foreach (ClKeyData k in layout.keys)
                {
                    if (k.slice == slice && k.x == x && k.y == y)
                    {
                        k.key = ClKey.GetKeyFromChar(input);
                    }
                }
            }
            else
            {
                layout.keys.Find(k => (k.slice == slice && k.x == x && k.y == y && k.z == z)).key = ClKey.GetKeyFromChar(input);
            }
            MdGlobals.board.LoadLayout(layout);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            layout.DeleteLayer(this.index);
            MdGlobals.board.LoadLayout(layout);
        }

    }
}
