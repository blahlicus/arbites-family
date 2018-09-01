using System.Collections.Generic;
using Eto.Forms;


namespace ArbitesEto2
{

    public partial class FmMacroEdit
    {

        public List<UCMacroButton> Buttons { get; set; }
        public MacroData Data { get; set; }
        public bool SaveOutput { get; set; }

        public FmMacroEdit()
        {
            InitializeComponent();
            this.Icon = MdSessionData.WindowIcon;
            this.Buttons = new List<UCMacroButton>();
            this.Data = new MacroData();
            this.SaveOutput = false;
            for (var i = 0; i < 8; i++)
            {
                var btn = new UCMacroButton();
                btn.KeyIndex = i;
                this.Buttons.Add(btn);
                var tc = new TableCell();
                tc.Control = btn;
                btn.Visible = false;
                this.TRStack.Cells.Add(tc);

                btn.LeftClick += (sender, e) => KeyLeft(sender);
                btn.RightClick += (sender, e) => KeyRight(sender);
                btn.DeleteClick += (sender, e) => KeyDelete(sender);
                btn.ValueChanged += (sender, e) => KeyUpdate(sender);
                btn.IsDownChanged += (sender, e) => KeyIsDownChanged(sender);
            }
            this.TRStack.Cells.Add(null);
            EventHook();
            RefreshStack();
        }


        public FmMacroEdit(MacroData data) : this()
        {
            this.Data = new MacroData(data);
            RefreshStack();
        }


        private void EventHook()
        {
            this.BtnAddKey.Click += (sender, e) => AddKey();
            this.BtnOK.Click += (sender, e) => Save();
            this.BtnCancel.Click += (sender, e) => Cancel();
            Closing += (sender, e) => IsClosing();
        }


        private void IsClosing()
        {
            MdSessionData.OpenedMacroEdit = false;
        }

        private void Save()
        {
            this.SaveOutput = true;


            var lay = MdSessionData.CurrentLayout;
            var dataCont = new MacroDataContainer();
            var hasData = false;
            foreach (var ele in lay.AddonDatas)
            {
                if (ele.GetType() == MacroDataContainer.DATA_TYPE)
                {
                    hasData = true;
                    dataCont = ele as MacroDataContainer;
                }
            }

            if (!hasData)
            {
                lay.AddonDatas.Add(dataCont);
            }

            var data = this.Data;
            hasData = false;
            var oldDataIndex = 0;
            if (dataCont != null)
            {
                foreach (var ele in dataCont.MacroKeys)
                {
                    if (ele.Index == this.Data.Index)
                    {
                        hasData = true;
                        break;
                    }
                    oldDataIndex++;
                }

                if (hasData)
                {
                    dataCont.MacroKeys[oldDataIndex] = data;
                }
                else
                {
                    dataCont.MacroKeys.Add(data);
                }
            }
            MdSessionData.CurrentKeyboardUI.DisplayUnsavedChangeSignal();
            Close();
        }

        private void Cancel()
        {
            Close();
        }

        private void KeyLeft(object sender)
        {
            var btn = sender as UCMacroButton;
            if (btn != null)
            {
                var index = btn.KeyIndex;
                if (index > 0)
                {
                    var ele = this.Data.Keys[index];
                    var bele = this.Data.IsKeyDown[index];

                    this.Data.Keys.RemoveAt(index);
                    this.Data.IsKeyDown.RemoveAt(index);

                    this.Data.Keys.Insert(index - 1, ele);
                    this.Data.IsKeyDown.Insert(index - 1, bele);
                    RefreshStack();
                }
                else
                {
                    MessageBox.Show("Error: Already leftmost key.");
                }
            }
        }

        private void KeyRight(object sender)
        {
            var btn = sender as UCMacroButton;
            if (btn != null)
            {
                var index = btn.KeyIndex;
                if (index < this.Data.Keys.Count - 1)
                {
                    var ele = this.Data.Keys[index];
                    var bele = this.Data.IsKeyDown[index];

                    this.Data.Keys.RemoveAt(index);
                    this.Data.IsKeyDown.RemoveAt(index);

                    this.Data.Keys.Insert(index + 1, ele);
                    this.Data.IsKeyDown.Insert(index + 1, bele);
                    RefreshStack();
                }
                else
                {
                    MessageBox.Show("Error: Already rightmost key.");
                }
            }
        }

        private void KeyDelete(object sender)
        {
            var btn = sender as UCMacroButton;
            if (btn != null)
            {
                var index = btn.KeyIndex;

                this.Data.Keys.RemoveAt(index);
                this.Data.IsKeyDown.RemoveAt(index);
            }
            RefreshStack();
        }

        private void KeyUpdate(object sender)
        {
            var btn = sender as UCMacroButton;
            if (btn != null)
            {
                var index = btn.KeyIndex;

                this.Data.Keys[index] = new Key(btn.Key);
            }
        }

        private void KeyIsDownChanged(object sender)
        {
            var btn = sender as UCMacroButton;
            if (btn != null)
            {
                var index = btn.KeyIndex;
                this.Data.IsKeyDown[index] = btn.IsDown;
            }
        }


        private void AddKey()
        {
            if (this.Data.Keys.Count < 8)
            {
                this.Data.Keys.Add(new Key());
                this.Data.IsKeyDown.Add(true);
                RefreshStack();
            }
            else
            {
                MessageBox.Show("Error: Maximum number of keys reached");
            }
        }

        private void RefreshStack()
        {
            for (var i = 0; i < 8; i++)
            {
                if (i < this.Data.Keys.Count)
                {
                    this.Buttons[i].Key = new Key(this.Data.Keys[i]);
                    this.Buttons[i].IsDown = this.Data.IsKeyDown[i];
                    this.Buttons[i].ReloadUI();
                    this.Buttons[i].Visible = true;
                }
                else
                {
                    this.Buttons[i].Visible = false;
                }
            }

            this.LTip.Text = "Currently editing macro key \"macro" + this.Data.Index + "\"";
            this.LKeyAmount.Text = "Capacity: " + this.Data.Keys.Count + " out of 8 keys.";
        }

    }

}
