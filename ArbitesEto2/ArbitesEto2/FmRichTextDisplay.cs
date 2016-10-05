using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmRichTextDisplay
    {
        public FmRichTextDisplay()
        {
            InitializeComponent();
        }

        public FmRichTextDisplay(List<string> input)
        {
            InitializeComponent();
            foreach(string str in input)
            {
                RTAMain.Text += str + "\n";
            }
            Icon = MdSessionData.WindowIcon;
        }
    }
}
