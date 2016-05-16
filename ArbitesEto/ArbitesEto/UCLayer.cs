using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class UCLayer
    {

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

        public UCLayer(List<ClButton> buttons, int sliceIndex, int index, ClLayoutContainer layout, bool init)
        {
            InitializeComponent();
            this.buttons = new List<Button>();


            this.sliceIndex = sliceIndex;
            this.index = index;
            this.layout = layout;
            this.LName.Text = "Layer " + index.ToString();

            int maxx = 0, maxy = 0;
            foreach (ClButton input in buttons)
            {
                if (input.gw + input.gx > maxx)
                {
                    maxx = input.gw + input.gx + 5;
                }
                if (input.gh + input.gy > maxy)
                {
                    maxy = input.gh + input.gy + 5;
                }
                var btn = new Button();
                btn.Tag = "bt_" + sliceIndex + "_" + input.x + "_" + input.y + "_" + index;
                if (init)
                {
                    layout.keys[index].Add(new ClKeyData(sliceIndex, input.x, input.y));
                }
                btn.Size = new Size(input.gw, input.gh);
                PLMain.Add(btn, input.gx, input.gy);
                btn.Click += (sender, e) => this.KeyBtnClicked(sender, e);
                btn.KeyDown += (sender, e) => this.KeyBtnKeyPressed(sender, e);
                this.buttons.Add(btn);
                LoadLayout(this.layout);
            }
            maxy = maxy + 33;
            ClientSize = new Size(maxx, maxy);
            BtnDeleteLayer.Click += (sender, e) => this.btDelete_Click(sender, e);
        }

        public void LoadLayout(ClLayoutContainer input)
        {
            this.layout = input;
            foreach (Button btn in buttons)
            {
                foreach (ClKeyData kd in layout.keys[index])
                {
                    if (btn.Tag.ToString() == "bt_" + kd.slice + "_" + kd.x + "_" + kd.y + "_" + index)
                    {
                        btn.Text = kd.key.display;
                    }
                }
            }
        }

        private void KeyBtnClicked(object sender, EventArgs e)
        {
            if (MdGlobals.selectedSpecial)
            {
                SetLayoutWithKey(sender as Button, MdGlobals.selectedKey);
                MdGlobals.selectedSpecial = false;
            }
        }

        private void KeyBtnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToShortcutString().Length == 1)
            {
                char input = e.KeyData.ToShortcutString().ToLower()[0];
                SetLayoutFromButton(sender as Button, input);
            }
        }


        private void SetLayoutWithKey(Button sender, ClKey key)
        {
            string btn = sender.Tag.ToString();
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int slice = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int x = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int y = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int z = Convert.ToInt32(btn);


            if (CBAllLayers.Checked.Value || key.allLayers)
            {
                foreach (List<ClKeyData> kl in layout.keys)
                {

                    foreach (ClKeyData k in kl)
                    {
                        if (k.slice == slice && k.x == x && k.y == y)
                        {
                            k.key = key;
                        }
                    }
                }
            }
            else
            {
                layout.keys[index].Find(k => (k.slice == slice && k.x == x && k.y == y)).key = key;
            }
            MdGlobals.board.LoadLayout(layout);
        }

        private void SetLayoutFromButton(Button sender, char input)
        {

            string btn = sender.Tag.ToString();
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int slice = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int x = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int y = Convert.ToInt32(btn.Substring(0, btn.IndexOf("_")));
            btn = btn.Substring(btn.IndexOf("_") + 1);
            int z = Convert.ToInt32(btn);


            if (CBAllLayers.Checked.Value)
            {
                foreach (List<ClKeyData> kl in layout.keys)
                {

                    foreach (ClKeyData k in kl)
                    {
                        if (k.slice == slice && k.x == x && k.y == y)
                        {
                            k.key = ClKey.GetKeyFromChar(input);
                        }
                    }
                }
            }
            else
            {
                layout.keys[index].Find(k => (k.slice == slice && k.x == x && k.y == y)).key = ClKey.GetKeyFromChar(input);
            }
            MdGlobals.board.LoadLayout(layout);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (layout.keys.Count > 1)
            {

                this.layout.keys.RemoveAt(index);
                MdGlobals.board.LoadLayout(layout);
                MdGlobals.board.UpdateScrollable();
            }
            else
            {
                MessageBox.Show("Error: Minimum number of layers reached: 1");
            }
        }

    }
}
