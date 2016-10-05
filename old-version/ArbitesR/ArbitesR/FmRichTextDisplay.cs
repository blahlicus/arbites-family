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
    public partial class FmRichTextDisplay : Form
    {
        public FmRichTextDisplay()
        {
            InitializeComponent();
        }
        public FmRichTextDisplay(List<string> input)
        {
            InitializeComponent();
            rtbMain.Lines = input.ToArray();
        }
    }
}
