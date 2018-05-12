using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Eto.Drawing;
using Eto.Forms;
using System.Linq;

namespace ArbitesEto2
{
    public sealed partial class FmKeyMenu
    {
        public FmKeyMenu()
        {
            InitializeComponent();
            Init();
            this.Height = 640;
            this.Width = 860;
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
            // this.Icon = MdSessionData.WindowIcon;
        }

        public void Init()
        {
            int groupIndex = 0;
            foreach (var groupName in MdSessionData.CurrentInputMethod.Groups)
            {
                var tabPage = new TabPage
                {
                    Text = groupName,
                    Tag = groupIndex,
                    Content = CreateList(groupIndex++)
                };

                this.TCMain.Pages.Add(tabPage);
            }
        }

        private ListControl CreateList(int groupIndex)
        {
            var layout = new ListBox();
            var keys = MdSessionData
                .CurrentInputMethod
                .Keys
                .Where((key) => key.GroupIndex == groupIndex);

            foreach (var key in keys)
            {
                layout.Items.Add(key.DisplayText, key.Index.ToString());
            }

            layout.SelectedKeyChanged += (sender, args) => SelectKey(sender, args);

            return layout;
        }

        public void ReloadInputMethod()
        {
            this.Close();
        }

        private void SelectKey(object sender, EventArgs args)
        {
            MdSessionData.SelectedFromKeyMenu = true;
            var layout = sender as ListBox;
            if (layout != null)
            {
                var keyId = Convert.ToInt32(layout.SelectedKey);
                MdSessionData.KeyMenuKey = KeyGroup.GetKeyFromDisplayId(keyId);
            }
        }

        public void ReloadTopmost()
        {
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
        }
    }
}
