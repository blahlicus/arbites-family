using System.Collections.Generic;
using Eto.Forms;


namespace ArbitesEto2
{

    public sealed partial class FmSelectTextDialog
    {

        public List<string> OutputValues { get; set; }
        public List<string> OutputKeys { get; set; }
        public int OutputIndex { get; set; }

        public FmSelectTextDialog()
        {
            this.ShowInTaskbar = true;
            InitializeComponent();

            this.OutputIndex = -1;
            this.OutputKeys = new List<string>();
            this.OutputValues = new List<string>();

            this.Title = "Select an item below";
            this.Icon = MdSessionData.WindowIcon;
        }


        public FmSelectTextDialog(List<string> values, List<string> keys, string title) : this()
        {
            this.OutputKeys = keys;
            this.OutputValues = values;
            var i = 0;
            foreach (var str in this.OutputKeys)
            {
                AddButton(str, i);
                i++;
            }
            this.TLMain.Rows.Add(null);
            this.Title = title;
            this.Width = 300;
            this.Height = 400;
        }

        private void AddButton(string input, int index)
        {
            var btn = new Button();
            btn.Text = input;

            var tr = new TableRow();
            tr.Cells.Add(btn);

            this.TLMain.Rows.Add(tr);
            btn.Click += (sender, e) => PressButton(index);
        }

        private void PressButton(int input)
        {
            this.OutputIndex = input;
            Close();
        }

    }

}
