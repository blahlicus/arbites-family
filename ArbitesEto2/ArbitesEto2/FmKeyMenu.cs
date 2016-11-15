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

                this.TCMain.Pages.Add(tp);
            }


            for (var i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
            {
                var gi = MdSessionData.CurrentInputMethod.GroupIndex[i];
                var dt = MdSessionData.CurrentInputMethod.Display[i];
                var di = MdSessionData.CurrentInputMethod.Index[i];
                var nb = new Button();
                nb.Tag = di;
                nb.Text = dt;
                nb.ToolTip = dt;
                nb.Size = new Size(72, 72);

                var nb2 = new Button();
                nb2.Tag = di;
                nb2.Text = dt;
                nb2.ToolTip = dt;
                nb2.Size = new Size(72, 72);

                nb.Click += (sender, e) => SelectKey(sender);
                nb2.Click += (sender, e) => SelectKey(sender);

                AddKey(nb, gi);
                AddKey(nb2, 0);
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
