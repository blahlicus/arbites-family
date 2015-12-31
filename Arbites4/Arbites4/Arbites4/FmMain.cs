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
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            test.Text = e.KeyChar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UCBoard newb = new UCBoard(2, 3, 4);
            newb.Parent = this;
            newb.Location = new Point(32, 32);
        }
    }
}
