using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class UCMacroButton
    {
        public ClKey Key { get; set; }
        public int KeyIndex { get; set; }
        public bool IsDown { get; set; }

        public event EventHandler LeftClick, RightClick, DeleteClick, ValueChanged, IsDownChanged;

        public UCMacroButton()
        {
            InitializeComponent();
            this.Size = new Size(128, 128);
            this.Key = new ClKey();
            this.KeyIndex = -1;

            IsDown = true;
            ReloadUI();

            EventHook();
        }

        private void EventHook()
        {
            this.BtnMain.Click += (sender, e) => PressedKey(sender, e);
            this.BtnMain.KeyDown += (sender, e) => KeyboardInput(sender, e);
            this.BtnKeyMode.Click += (sender, e) => ToggleIsDown();


            this.BtnLeft.Click += (sender, e) => ClickedLeft(sender, e);
            this.BtnRight.Click += (sender, e) => ClickedRight(sender, e);
            this.BtnDelete.Click += (sender, e) => ClickedDelete(sender, e);
        }

        private void ClickedLeft(object sender, EventArgs e)
        {
            if (this.LeftClick != null)
            {
                this.LeftClick(this, e);
            }
        }

        private void ClickedRight(object sender, EventArgs e)
        {
            if (this.RightClick != null)
            {
                this.RightClick(this, e);
            }
        }


        private void ClickedDelete(object sender, EventArgs e)
        {
            if (this.DeleteClick != null)
            {
                this.DeleteClick(this, e);
            }
        }


        private void ToggleIsDown()
        {
            this.IsDown = !IsDown;

            if (this.IsDown)
            {
                BtnKeyMode.Text = "Press";
            }
            else
            {
                BtnKeyMode.Text = "Release";
            }
            IsDownChanged(this, EventArgs.Empty);
        }

        public void ReloadUI()
        {
            this.BtnMain.Text = MdSessionData.CurrentInputMethod.GetDisplay(Key.DisplayID);

            if (this.IsDown)
            {
                BtnKeyMode.Text = "Press";
            }
            else
            {
                BtnKeyMode.Text = "Release";
            }
        }

        private void KeyboardInput(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToShortcutString().Length == 1)
            {
                char input = e.KeyData.ToShortcutString().ToLower()[0];
                SetKeyFromButton(sender as Button, input);
            }
        }

        private void SetKeyFromButton(Button sender, char input)
        {


            for (int i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                if (MdSessionData.CurrentInputMethod.Display[i][0] == input && MdSessionData.CurrentInputMethod.GroupIndex[i] <3)
                {

                    EditKey(MdSessionData.KeyGroup.Keys.Find(ele => ele.DisplayID == MdSessionData.CurrentInputMethod.Index[i]));
                }
            }

        }

        private void PressedKey(object sender, EventArgs e)
        {
            (sender as Button).Focus();
            if (MdSessionData.SelectedFromKeyMenu)
            {
                EditKey(MdSessionData.KeyMenuKey);
                MdSessionData.SelectedFromKeyMenu = false;
            }


        }

        private void EditKey(ClKey key)
        {
            BtnMain.Text = MdSessionData.CurrentInputMethod.GetDisplay(key.DisplayID);
            this.Key = key;

            if (this.ValueChanged != null)
            {

                ValueChanged(this, EventArgs.Empty);
            }
        }
    }
}
