using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitesR
{
    public partial class FmSelectTextDialog : Form
    {
        public string output { get; set; }
        public int index { get; set; }
        public FmSelectTextDialog()
        {
            InitializeComponent();
            output = "error";
        }

        public FmSelectTextDialog(string title, string tip, List<string> options)
        {
            InitializeComponent();
            output = "error";
            lTip.Text = tip;
            this.Text = title;
            AddOptions(options);
        }

        public void AddOption(string input, int index)
        {

            Button btn = new Button();
            btn.Text = input;
            btn.Name = "b" + index;
            btn.Size = new Size(173, 23);
            btn.Parent = this.flpMain;
            btn.Click += new EventHandler(this.BtnPress);
        }

        public void AddOptions(List<string> options)
        {
            int i = 0;
            foreach(string str in options)
            {
                AddOption(str, i);
                i++;
            }
        }

        public void BtnPress(object sender, EventArgs e)
        {
            output = (sender as Button).Text;
            index = Convert.ToInt32((sender as Button).Name.Substring(1));
            this.DialogResult = DialogResult.OK;
            Close();

        }
    }
}
