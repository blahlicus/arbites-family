using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmKeyMenu
    {
        List<StackLayout> slMainList = new List<StackLayout>();
        List<StackLayout> slList = new List<StackLayout>();
        List<int> slcList = new List<int>();
        List<Button> buttons = new List<Button>();

        public FmKeyMenu()
        {
            InitializeComponent();
            Init();
            this.Height = 640;
            this.Width = 860;
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
            Icon = MdSessionData.WindowIcon;
        }

        public void Init()
        {
            foreach(string str in MdSessionData.CurrentInputMethod.Groups)
            {
                var tp = new TabPage();
                tp.Text = str;

                var sc = new Scrollable();
                sc.Border = BorderType.None;
                tp.Content = sc;

                slcList.Add(999);
                var msl = new StackLayout();
                msl.Orientation = Orientation.Vertical;
                slMainList.Add(msl);
                sc.Content = msl;

                slList.Add(null);

                TCMain.Pages.Add(tp);
            }

            
            for (int i = 0; i < MdSessionData.CurrentInputMethod.Display.Count; i++)
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

                nb.Click += (sender, e) => SelectKey(sender, e);
                nb2.Click += (sender, e) => SelectKey(sender, e);

                AddKey(nb, gi);
                AddKey(nb2, 0);
            }
        }

        private void AddKey(Button btn, int groupIndex)
        {

            if (slcList[groupIndex] > 10)
            {
                var nsl = new StackLayout();
                nsl.Orientation = Orientation.Horizontal;
                slMainList[groupIndex].Items.Add(nsl);
                slList[groupIndex] = nsl;
                slcList[groupIndex] = 0;
            }
            buttons.Add(btn);
            slcList[groupIndex]++;
            slList[groupIndex].Items.Add(btn);
        }

        public void ReloadInputMethod()
        {
            foreach(Button btn in buttons)
            {
                btn.Text = MdSessionData.CurrentInputMethod.GetDisplay(Convert.ToInt32(btn.Tag.ToString()));
                btn.ToolTip = btn.Text;
            }
        }

        private void SelectKey(object sender, EventArgs e)
        {
            MdSessionData.SelectedFromKeyMenu = true;
            MdSessionData.KeyMenuKey = ClKeyGroup.GetKeyFromDisplayId(Convert.ToInt32((sender as Button).Tag.ToString()));
        }

        public void ReloadTopmost()
        {
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
        }

    }
}
