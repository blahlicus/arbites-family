using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmSelectTextDialog
    {
        
        public List<string> OutputValues { get; set; }
        public List<string> OutputKeys { get; set; }
        public int OutputIndex { get; set; }

        public FmSelectTextDialog()
        {
            this.ShowInTaskbar = true;
            InitializeComponent();

            OutputIndex = -1;
            OutputKeys = new List<string>();
            OutputValues = new List<string>();

            Title = "Select an item below";
            Icon = MdSessionData.WindowIcon;
        }


        public FmSelectTextDialog(List<string> values, List<string> keys, string Title) : this()
        {
            OutputKeys = keys;
            OutputValues = values;
            int i = 0;
            foreach(string str in OutputKeys)
            {
                addButton(str, i);
                i++;
            }
            TLMain.Rows.Add(null);
            this.Title = Title;
            this.Width = 300;
            this.Height = 400;

        }

        private void addButton(string input, int index)
        {
            var btn = new Button();
            btn.Text = input;

            var tr = new TableRow();
            tr.Cells.Add(btn);

            TLMain.Rows.Add(tr);
            btn.Click += (sender, e) => pressButton(index);
        }

        private void pressButton(int input)
        {
            OutputIndex = input;
            this.Close();
        }
    }
}
