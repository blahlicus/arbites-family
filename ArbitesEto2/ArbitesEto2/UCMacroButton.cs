using System;
using Eto.Drawing;
using Eto.Forms;


namespace ArbitesEto2
{

    public sealed partial class UCMacroButton
    {

        public ClKey Key { get; set; }
        public int KeyIndex { get; set; }
        public bool IsDown { get; set; }
        public bool ShowIsDown { get; set; }

        public event EventHandler LeftClick;
        public event EventHandler RightClick;
        public event EventHandler DeleteClick;
        public event EventHandler ValueChanged;
        public event EventHandler IsDownChanged;

        public UCMacroButton()
        {
            InitializeComponent();
            this.Size = new Size(128, 128);
            this.Key = new ClKey();
            this.KeyIndex = -1;
            this.ShowIsDown = true;
            this.IsDown = true;
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
            if (LeftClick != null)
            {
                LeftClick(this, e);
            }
        }

        private void ClickedRight(object sender, EventArgs e)
        {
            if (RightClick != null)
            {
                RightClick(this, e);
            }
        }


        private void ClickedDelete(object sender, EventArgs e)
        {
            if (DeleteClick != null)
            {
                DeleteClick(this, e);
            }
        }


        private void ToggleIsDown()
        {
            this.IsDown = !this.IsDown;

            ReloadUI();
            IsDownChanged(this, EventArgs.Empty);
        }

        public void ReloadUI()
        {
            this.BtnMain.Text = MdSessionData.CurrentInputMethod.GetDisplay(this.Key.DisplayID);

            if (ShowIsDown)
            {

                if (this.IsDown)
                {
                    this.BtnKeyMode.Text = "Press";
                }
                else
                {
                    this.BtnKeyMode.Text = "Release";
                }
            }
            else
            {
                {
                    this.BtnKeyMode.Text = "";
                }
            }
        }

        private void KeyboardInput(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToShortcutString().Length == 1)
            {
                var input = e.KeyData.ToShortcutString().ToLower()[0];
                SetKeyFromButton(sender as Button, input);
            }
        }

        private void SetKeyFromButton(Button sender, char input)
        {
            var btn = sender;
            btn.Focus();
            for (var i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                if ((MdSessionData.CurrentInputMethod.Display[i][0] == input) && (MdSessionData.CurrentInputMethod.GroupIndex[i] < 3))
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
            this.BtnMain.Text = MdSessionData.CurrentInputMethod.GetDisplay(key.DisplayID);
            this.Key = key;

            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

    }

}
