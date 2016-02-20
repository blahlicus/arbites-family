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
        public UCLayer()
        {
            InitializeComponent();
            buttons = new List<Button>();
            index = 0;
            sliceIndex = 0;
        }


        public UCLayer(List<ClButton> buttons, int sliceIndex, int index)
        {
            InitializeComponent();
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
                btn.Text = "Null";
                btn.Size = new Size(input.gw, input.gh);
                btn.Location = new Point(input.gx, input.gy);
                btn.Parent = this;
                btn.Click += new EventHandler(this.KeyBtnClicked);
                btn.KeyPress += new KeyPressEventHandler(this.KeyBtnKeyPressed);
                this.buttons.Add(btn);
            }
            this.Size = new Size(maxx, maxy);
        }

        private void KeyBtnClicked (object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Name);
        }

        private void KeyBtnKeyPressed(object sender, KeyPressEventArgs e)
        {
        }

    }
}
