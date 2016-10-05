using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmMacroEdit
    {
        public List<UCMacroButton> Buttons { get; set; }
        public ClMacroData Data { get; set; }
        public bool SaveOutput { get; set; }
        public FmMacroEdit()
        {
            InitializeComponent();
            Icon = MdSessionData.WindowIcon;
            Buttons = new List<UCMacroButton>();
            Data = new ClMacroData();
            SaveOutput = false;
            for (int i = 0; i < 8; i++ )
            {
                var btn = new UCMacroButton();
                btn.KeyIndex = i;
                Buttons.Add(btn);
                var tc = new TableCell();
                tc.Control = btn;
                btn.Visible = false;
                TRStack.Cells.Add(tc);

                btn.LeftClick += (sender, e) => KeyLeft(sender, e);
                btn.RightClick += (sender, e) => KeyRight(sender, e);
                btn.DeleteClick += (sender, e) => KeyDelete(sender, e);
                btn.ValueChanged += (sender, e) => KeyUpdate(sender, e);
                btn.IsDownChanged += (sender, e) => KeyIsDownChanged(sender, e);
            }
            TRStack.Cells.Add(null);
            EventHook();
            RefreshStack();
        }


        public FmMacroEdit(ClMacroData Data) : this()
        {
            this.Data = new ClMacroData(Data);
            RefreshStack();
        }


        private void EventHook()
        {
            BtnAddKey.Click += (sender, e) => AddKey();
            BtnOK.Click += (sender, e) => Save();
            BtnCancel.Click += (sender, e) => Cancel();
            this.Closing += (sender, e) => IsClosing();

        }


        private void IsClosing()
        {
            MdSessionData.OpenedMacroEdit = false;
        }

        private void Save()
        {

            SaveOutput = true;


            var lay = MdSessionData.CurrentLayout;
            var dataCont = new ClMacroDataContainer();
            var hasData = false;
            foreach (ClAdditionalData ele in lay.AddonDatas)
            {
                if (ele.GetType() == ClMacroDataContainer.DATA_TYPE)
                {
                    hasData = true;
                    dataCont = ele as ClMacroDataContainer;
                }
            }

            if (!hasData)
            {
                lay.AddonDatas.Add(dataCont);
            }

            var data = this.Data;
            hasData = false;
            var oldDataIndex = 0;
            foreach (ClMacroData ele in dataCont.MacroKeys)
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
            MdSessionData.CurrentKeyboardUI.DisplayUnsavedChangeSignal();
            this.Close();
        }

        private void Cancel()
        {
            this.Close();
        }

        private void KeyLeft(object sender, EventArgs e)
        {
            var btn = (sender as UCMacroButton);
            int index = btn.KeyIndex;
            if (index >0)
            {
                var ele = Data.Keys[index];
                var bele = Data.IsKeyDown[index];

                Data.Keys.RemoveAt(index);
                Data.IsKeyDown.RemoveAt(index);

                Data.Keys.Insert(index - 1, ele);
                Data.IsKeyDown.Insert(index - 1, bele);
                RefreshStack();
            }
            else
            {
                MessageBox.Show("Error: Already leftmost key.");
            }

        }
        private void KeyRight(object sender, EventArgs e)
        {

            var btn = (sender as UCMacroButton);
            int index = btn.KeyIndex;
            if (index < Data.Keys.Count - 1)
            {
                var ele = Data.Keys[index];
                var bele = Data.IsKeyDown[index];

                Data.Keys.RemoveAt(index);
                Data.IsKeyDown.RemoveAt(index);

                Data.Keys.Insert(index+1, ele);
                Data.IsKeyDown.Insert(index+1, bele);
                RefreshStack();
            }
            else
            {
                MessageBox.Show("Error: Already rightmost key.");
            }
        }
        private void KeyDelete(object sender, EventArgs e)
        {
            var btn = (sender as UCMacroButton);
            int index = btn.KeyIndex;
            var ele = Data.Keys[index];
            var bele = Data.IsKeyDown[index];

            Data.Keys.RemoveAt(index);
            Data.IsKeyDown.RemoveAt(index);
            RefreshStack();
        }
        private void KeyUpdate(object sender, EventArgs e)
        {
            var btn = (sender as UCMacroButton);
            int index = btn.KeyIndex;

            Data.Keys[index] = new ClKey(btn.Key);
        }
        private void KeyIsDownChanged(object sender, EventArgs e)
        {

            var btn = (sender as UCMacroButton);
            int index = btn.KeyIndex;
            Data.IsKeyDown[index] = btn.IsDown;
        }





        private void AddKey()
        {
            if (Data.Keys.Count < 8)
            {
                Data.Keys.Add(new ClKey());
                Data.IsKeyDown.Add(true);
                RefreshStack();
            }
            else
            {
                MessageBox.Show("Error: Maximum number of keys reached");
            }
        }

        private void RefreshStack()
        {
            for (int i = 0; i < 8; i++)
            {
                if (i < Data.Keys.Count)
                {
                    Buttons[i].Key = new ClKey(Data.Keys[i]);
                    Buttons[i].IsDown = Data.IsKeyDown[i];
                    Buttons[i].ReloadUI();
                    Buttons[i].Visible = true;
                }
                else
                {
                    Buttons[i].Visible = false;
                }


            }

            LTip.Text = "Currently editing macro key \"macro" + Data.Index.ToString() + "\"";
            LKeyAmount.Text = "Capacity: " + Data.Keys.Count.ToString() + " out of 8 keys.";
            
        }

    }
}
