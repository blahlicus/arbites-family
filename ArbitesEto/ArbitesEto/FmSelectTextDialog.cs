using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class FmSelectTextDialog
    {
        public List<string> outputList { get; set; }
        public List<string> outputDisplayList { get; set; }
        public string output { get; set; }
        public string outputDisplay { get; set; }
        public bool hasResult { get; set; }

        public FmSelectTextDialog()
        {
            InitializeComponent();
            Icon = new Icon(MdConstants.icon);
            outputList = new List<string>();
            outputDisplayList = new List<string>();
            hasResult = false;
        }

        public FmSelectTextDialog(string title, string desc, List<string> displayList, List<string> outputList)
        {

            InitializeComponent();
            Icon = new Icon(MdConstants.icon);
            hasResult = false;

            Title = title;
            LDesc.Text = desc;

            this.outputList = new List<string>(outputList);
            this.outputDisplayList = new List<string>(displayList);

            int i = 0;
            foreach (string str in displayList)
            {
                var btn = new Button();
                btn.Text = str;
                btn.Tag = i.ToString();
                btn.Size = new Size(200, 22);
                btn.Click += (sender, e) => ButtonClicked(sender, e);
                SLMain.Items.Add(btn);
                i++;
            }
        }

        public void ButtonClicked(object sender, EventArgs e)
        {
            int i = Convert.ToInt32((sender as Button).Tag);
            output = outputList[i];
            outputDisplay = outputDisplayList[i];
            hasResult = true;
            
            Close();
        }
    }
}
