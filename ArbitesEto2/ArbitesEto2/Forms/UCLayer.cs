using System;
using System.Collections.Generic;
using Eto.Drawing;
using Eto.Forms;

namespace ArbitesEto2
{
    public partial class UCLayer
    {
        public List<Button> Buttons { get; set; }
        public int Layer { get; set; }

        public UCLayer()
        {
            InitializeComponent();
        }

        public UCLayer(Keyboard keyboard, LayoutContainer layout, int layer)
        {
            InitializeComponent();
            this.Layer = layer;
            this.LTitle.Text = "Layer " + layer;
            this.Buttons = new List<Button>();
            foreach (var bi in keyboard.Buttons)
            {
                var btn = new Button();
                btn.Text = "Null";
                btn.Tag = bi.X + "_" + bi.Y + "_" + this.Layer + "_" + bi.Command;
                btn.Size = new Size(bi.GW, bi.GH);
                this.Buttons.Add(btn);
                this.PLMain.Add(btn, new Point(bi.GX, bi.GY));
                if (this.PLMain.Size.Width < bi.GX + bi.GW)
                {
                    this.PLMain.Size = new Size(bi.GX + bi.GW, this.PLMain.Size.Height);
                }
                if (this.PLMain.Size.Height < bi.GY + bi.GH)
                {
                    this.PLMain.Size = new Size(this.PLMain.Size.Width, bi.GY + bi.GH);
                }
                btn.Click += (sender, e) => PressedKey(sender, e);
                btn.MouseUp += (sender, e) => PressedKey(sender, e);
                btn.KeyDown += (sender, e) => KeyboardInput(sender, e);
            }
            LoadLayout(layout);
            InitHandle();
        }

        private void InitHandle()
        {
            this.BtnDelete.Click += (sender, e) => DeleteLayer();
        }

        private void KeyboardInput(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToShortcutString().Length == 1)
            {
                var input = e.KeyData.ToShortcutString().ToLower()[0];
                SetLayoutFromButton(sender as Button, input);
            }
        }

        private void SetLayoutFromButton(Button sender, char input)
        {
            var btn = sender;
            btn.Focus();
            var arr = btn.Tag.ToString().Split('_');
            var x = Convert.ToInt32(arr[0]);
            var y = Convert.ToInt32(arr[1]);
            var z = Convert.ToInt32(arr[2]);
            var com = Convert.ToInt32(arr[3]);


            for (var i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                if ((MdSessionData.CurrentInputMethod.Display[i][0] == input) && (MdSessionData.CurrentInputMethod.GroupIndex[i] < 3))
                {
                    EditKey(x, y, z, com, MdSessionData.KeyGroup.Keys.Find(ele => ele.DisplayID == MdSessionData.CurrentInputMethod.Index[i]));
                }
            }
        }

        private void PressedKey(object sender, EventArgs @event)
        {
            var mouseEvent = @event as MouseEventArgs;
            var btn = sender as Button;
            btn.Focus();
            var arr = btn.Tag.ToString().Split('_');
            var x = Convert.ToInt32(arr[0]);
            var y = Convert.ToInt32(arr[1]);
            var z = Convert.ToInt32(arr[2]);
            var com = Convert.ToInt32(arr[3]);

            if (mouseEvent != null && mouseEvent.Buttons == MouseButtons.Alternate)
            {
                var nullKey = new Key();
                EditKey(x, y, z, com, nullKey);
            }
            else if (MdSessionData.SelectedFromKeyMenu)
            {
                EditKey(x, y, z, com, MdSessionData.KeyMenuKey);
            }

            MdSessionData.SelectedFromKeyMenu = false;
        }

        private void EditKey(int x, int y, int z, int com, Key key)
        {
            foreach (var k in MdSessionData.CurrentLayout.KeyDatas)
            {
                if ((k.X == x) && (k.Y == y) && (k.Command == com))
                {
                    if ((k.Z == z) || key.AllLayers || this.CBAllLayers.Checked.Value)
                    {
                        k.Key = key;
                    }
                }
            }
            MdSessionData.CurrentKeyboardUI.LoadLayout(MdSessionData.CurrentLayout);
        }

        private void DeleteLayer()
        {
            if (MdSessionData.CurrentKeyboardUI.Layers.Count > 1)
            {
                MdSessionData.CurrentLayout.DeleteLayer(this.Layer);
                MdSessionData.CurrentKeyboardUI.LoadLayout(MdSessionData.CurrentLayout);
            }
            else
            {
                MessageBox.Show("Error: Must have at least 1 layer.");
            }
        }

        public void LoadLayout(LayoutContainer input)
        {
            foreach (var btn in this.Buttons)
            {
                foreach (var kd in input.KeyDatas)
                {
                    var arr = btn.Tag.ToString().Split('_');
                    var x = Convert.ToInt32(arr[0]);
                    var y = Convert.ToInt32(arr[1]);
                    var z = Convert.ToInt32(arr[2]);
                    var com = Convert.ToInt32(arr[3]);
                    if ((kd.X == x) && (kd.Y == y) && (kd.Z == z) && (kd.Command == com))
                    {
                        btn.Text = MdSessionData.CurrentInputMethod.GetDisplay(kd.Key.DisplayID);
                        btn.ToolTip = btn.Text;
                    }
                }
            }
        }
    }
}
