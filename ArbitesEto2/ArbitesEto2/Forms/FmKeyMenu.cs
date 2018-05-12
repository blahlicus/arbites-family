using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Eto.Drawing;
using Eto.Forms;
using System.Linq;

namespace ArbitesEto2
{
    public sealed class FmKeyMenu : Form
    {
        private DropDown DropDown;
        private SearchBox SearchBox;
        private ListBox ListBox;
        private int GroupIndex = 0;

        public FmKeyMenu()
        {
            Title = "Key Menu - Select a key from the menu below";
            Height = 640;
            Width = 860;
            Topmost = MdConfig.Main.KeyMenuTopmost;
            // Icon = MdSessionData.WindowIcon;

            Init();
        }

        public void Init()
        {
            DropDown = CreateDropDown();
            SearchBox = CreateSearch();
            ListBox = CreateList();

            UpdateListBox(GetKeys());

            var layout = new StackLayout
            {
                Orientation = Orientation.Vertical
            };

            layout.Items.Add(new StackLayoutItem(DropDown)
            {
                Expand = false,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });

            layout.Items.Add(new StackLayoutItem(SearchBox)
            {
                Expand = false,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });

            layout.Items.Add(new StackLayoutItem(ListBox)
            {
                Expand = true,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });

            Content = layout;
        }

        private IEnumerable<DisplayCharacterContainer.Key> GetKeys()
        {
            return MdSessionData
                .CurrentInputMethod
                .Keys
                .Where((key) => key.GroupIndex == GroupIndex);
        }

        private DropDown CreateDropDown()
        {
            var groups = new DropDown();

            foreach (var groupName in MdSessionData.CurrentInputMethod.Groups)
            {
                groups.Items.Add(groupName);
            }

            groups.SelectedIndex = GroupIndex;
            groups.SelectedIndexChanged += OnSelectGroup;

            return groups;
        }

        private SearchBox CreateSearch()
        {
            var search = new SearchBox();
            search.Load += (sender, args) => search.Focus();
            search.TextChanged += OnSearch;

            return search;
        }

        private ListBox CreateList()
        {
            var layout = new ListBox();
            layout.SelectedKeyChanged += OnSelectKey;

            return layout;
        }

        private void OnSelectKey(object sender, EventArgs args)
        {
            MdSessionData.SelectedFromKeyMenu = true;
            var layout = sender as ListBox;
            if (layout != null)
            {
                var keyId = Convert.ToInt32(layout.SelectedKey);
                MdSessionData.KeyMenuKey = KeyGroup.GetKeyFromDisplayId(keyId);
            }
        }

        private void OnSearch(object sender, EventArgs args)
        {
            var search = sender as SearchBox;
            if (search != null)
            {
                var query = search.Text.ToLower();
                var keys = GetKeys()
                    .Where((key) => key.DisplayText.ToLower().Contains(query));
                UpdateListBox(keys);
            }
        }

        private void OnSelectGroup(object sender, EventArgs args)
        {
            SearchBox.Text = "";
            GroupIndex = (sender as DropDown).SelectedIndex;
            UpdateListBox(GetKeys());
        }

        private void UpdateListBox(IEnumerable<DisplayCharacterContainer.Key> keys)
        {
            ListBox.DataStore = null;
            foreach (var key in keys)
            {
                ListBox.Items.Add(key.DisplayText, key.Index.ToString());
            }
        }

        public void ReloadInputMethod()
        {
            this.Close();
        }

        public void ReloadTopmost()
        {
            this.Topmost = MdConfig.Main.KeyMenuTopmost;
        }
    }
}
