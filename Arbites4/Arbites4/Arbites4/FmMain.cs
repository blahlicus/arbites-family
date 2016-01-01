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
            MdGlobals.keys = new List<List<List<ClKey>>>();
            UCBoard newb = new UCBoard(8, 5, 3);
            for (int i = 0; i<8; i++)
            {
                var il = new List<List<ClKey>>();
                MdGlobals.keys.Add(il);
                for (int j = 0; j<5; j++)
                {
                    var jl = new List<ClKey>();
                    il.Add(jl);
                    for (int k = 0; k<3; k++)
                    {
                        var kl = new ClKey();
                        jl.Add(kl);
                    }
                }
            }

            newb.Parent = pMain;
            newb.Dock = DockStyle.Fill;
        }

        private void KeyBtnClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            int str = Convert.ToInt32(btn.Name.Substring(btn.Name.IndexOf("_")+1));
            MdGlobals.specialS = true;
            MdGlobals.selectedS = ClKey.dKeys[str];
            MessageBox.Show(ClKey.dKeys[str].display);
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            ClKey.iniList();
            ClKey.dKeys = ClKey.dKeys.OrderBy(o => o.val).ToList();
            ClKey.dKeys = ClKey.dKeys.OrderBy(o => o.ktype).ToList();
            for (int i = 0; i < ClKey.dKeys.Count; i++)
            {
                var newb = new Button();
                newb.Name = "bt_" + i;
                newb.Text = ClKey.dKeys[i].display;
                newb.Size = new Size(72, 72);
                newb.Parent = flpOSwitches;
                newb.Click += new EventHandler(this.KeyBtnClicked);
            }
            MdGlobals.specialS = false;
        }
    }
}
