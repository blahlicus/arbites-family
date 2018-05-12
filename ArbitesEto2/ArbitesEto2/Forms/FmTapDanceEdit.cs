using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmTapDanceEdit
    {
        public List<UCMacroButton> Buttons { get; set; }
        public TapDanceData Data { get; set; }
        public bool SaveOutput { get; set; }
        public int Delay { get; set; }

        public FmTapDanceEdit()
        {
            InitializeComponent();
            // this.Icon = MdSessionData.WindowIcon;
            this.Buttons = new List<UCMacroButton>();
            this.Data = new TapDanceData();
            this.SaveOutput = false;

            this.DDDelay.Items.AddRange(new List<ListItem> { "5", "10", "20", "25", "30", "40", "50", "60" });
            foreach (var item in this.DDDelay.Items)
            {
                if (Data.Delay == Convert.ToInt32(item.ToString()))
                {
                    this.DDDelay.SelectedValue = item;
                }
            }


            for (var i = 0; i < 8; i++)
            {
                var btn = new UCMacroButton();
                btn.KeyIndex = i;
                btn.ShowIsDown = false;
                this.Buttons.Add(btn);
                var tc = new TableCell();
                tc.Control = btn;
                btn.Visible = false;
                this.TRStack.Cells.Add(tc);

                btn.LeftClick += (sender, e) => KeyLeft(sender);
                btn.RightClick += (sender, e) => KeyRight(sender);
                btn.DeleteClick += (sender, e) => KeyDelete(sender);
                btn.ValueChanged += (sender, e) => KeyUpdate(sender);
            }
            this.TRStack.Cells.Add(null);


            EventHook();
            RefreshStack();
        }

        public FmTapDanceEdit(TapDanceData data) : this()
        {
            this.Data = new TapDanceData(data);
            RefreshStack();
        }


        private void EventHook()
        {
            this.BtnAddKey.Click += (sender, e) => AddKey();
            this.BtnOK.Click += (sender, e) => Save();
            this.BtnCancel.Click += (sender, e) => Cancel();
            Closing += (sender, e) => IsClosing();
            this.DDDelay.SelectedIndexChanged += (sender, e) => UpdateDelay();
        }


        private void UpdateDelay()
        {
            Data.Delay = Convert.ToInt32(this.DDDelay.SelectedValue.ToString());
        }

        private void IsClosing()
        {
            MdSessionData.OpenedTapDanceEdit = false;
        }

        private void Save()
        {
            this.SaveOutput = true;


            var lay = MdSessionData.CurrentLayout;
            var dataCont = new TapDanceDataContainer();
            var hasData = false;
            foreach (var ele in lay.AddonDatas)
            {
                if (ele.GetType() == TapDanceDataContainer.DATA_TYPE)
                {
                    hasData = true;
                    dataCont = ele as TapDanceDataContainer;
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
                foreach (var ele in dataCont.TapDanceKeys)
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
                    dataCont.TapDanceKeys[oldDataIndex] = data;
                }
                else
                {
                    dataCont.TapDanceKeys.Add(data);
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

                    this.Data.Keys.RemoveAt(index);

                    this.Data.Keys.Insert(index - 1, ele);
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

                    this.Data.Keys.RemoveAt(index);

                    this.Data.Keys.Insert(index + 1, ele);
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



        private void AddKey()
        {
            if (this.Data.Keys.Count < 3)
            {
                this.Data.Keys.Add(new Key());
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
                    this.Buttons[i].ReloadUI();
                    this.Buttons[i].Visible = true;
                }
                else
                {
                    this.Buttons[i].Visible = false;
                }
            }

            foreach (var item in this.DDDelay.Items)
            {
                if (Convert.ToInt32(item.ToString()) == Data.Delay)
                {
                    this.DDDelay.SelectedValue = item;
                }
            }

            this.LTip.Text = "Currently editing tap dance key \"tapdance" + this.Data.Index + "\"";
            this.LKeyAmount.Text = "Capacity: " + this.Data.Keys.Count + " out of 3 keys.";
        }

    }
}
