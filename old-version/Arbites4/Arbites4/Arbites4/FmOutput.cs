using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbites4
{
    public partial class FmOutput : Form
    {
        public FmOutput()
        {
            InitializeComponent();
        }

        public FmOutput(List<string> input)
        {
            InitializeComponent();
            richTextBox1.Lines = input.ToArray();
        }
    }
}
