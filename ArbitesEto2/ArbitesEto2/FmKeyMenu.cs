using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Eto.Drawing;
using Eto.Forms;


namespace ArbitesEto2
{

    public sealed partial class FmKeyMenu
    {

        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")] private List<StackLayout> slMainList = new List<StackLayout>();
        private readonly List<StackLayout> slList = new List<StackLayout>();
        private readonly List<int> slcList = new List<int>();
        private readonly List<Button> buttons = new List<Button>();

        public FmKeyMenu()
        {
            InitializeComponent();
            Init();
            this.Height = 640;
            this.Width = 860;
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
            this.Icon = MdSessionData.WindowIcon;
        }
        
        public void Init()
        {
            foreach (var str in MdSessionData.CurrentInputMethod.Groups)
            {
                var tp = new TabPage();
                tp.Text = str;

                var sc = new Scrollable();
                sc.Border = BorderType.None;
                tp.Content = sc;

                this.slcList.Add(999);
                var msl = new StackLayout();
                msl.Orientation = Orientation.Vertical;
                this.slMainList.Add(msl);
                sc.Content = msl;

                this.slList.Add(null);

                int ind = TCMain.Pages.Count;
                this.TCMain.Pages.Add(tp);
                tp.Click += (sender, e) => PressedTab(sender, ind);
            }

            
            for (var i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                if (MdSessionData.CurrentInputMethod.GroupIndex[i] == 0)
                {

                    var gi = MdSessionData.CurrentInputMethod.GroupIndex[i];
                    var dt = MdSessionData.CurrentInputMethod.Display[i];
                    var di = MdSessionData.CurrentInputMethod.Index[i];
                    var nb = new Button();
                    nb.Tag = di;
                    nb.Text = dt;
                    nb.ToolTip = dt;
                    nb.Size = new Size(72, 72);

                    nb.Click += (sender, e) => SelectKey(sender);

                    AddKey(nb, gi);
                }
            }
        }

        private void PressedTab(object sndr, int index)
        {
            for (var i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                if (MdSessionData.CurrentInputMethod.GroupIndex[i] == index)
                {

                    var gi = MdSessionData.CurrentInputMethod.GroupIndex[i];
                    var dt = MdSessionData.CurrentInputMethod.Display[i];
                    var di = MdSessionData.CurrentInputMethod.Index[i];
                    var nb = new Button();
                    nb.Tag = di;
                    nb.Text = dt;
                    nb.ToolTip = dt;
                    nb.Size = new Size(72, 72);

                    nb.Click += (sender, e) => SelectKey(sender);

                    AddKey(nb, gi);
                }
            }
        }

        private void AddKey(Button btn, int groupIndex)
        {
            if (this.slcList[groupIndex] > 10)
            {
                var nsl = new StackLayout();
                nsl.Orientation = Orientation.Horizontal;
                this.slMainList[groupIndex].Items.Add(nsl);
                this.slList[groupIndex] = nsl;
                this.slcList[groupIndex] = 0;
            }
            this.buttons.Add(btn);
            this.slcList[groupIndex]++;
            this.slList[groupIndex].Items.Add(btn);
        }

        public void ReloadInputMethod()
        {
            foreach (var btn in this.buttons)
            {
                btn.Text = MdSessionData.CurrentInputMethod.GetDisplay(Convert.ToInt32(btn.Tag.ToString()));
                btn.ToolTip = btn.Text;
            }
        }

        private void SelectKey(object sender)
        {
            MdSessionData.SelectedFromKeyMenu = true;
            var button = sender as Button;
            if (button != null) MdSessionData.KeyMenuKey = ClKeyGroup.GetKeyFromDisplayId(Convert.ToInt32(button.Tag.ToString()));
        }

        public void ReloadTopmost()
        {
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
        }

    }

}
