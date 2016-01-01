using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace Arbites4
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
            serialPort1.BaudRate = 19200;
            serialPort1.Open();
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            var output = new List<string>();
            output.Add("uniqueksetlay(3 ");
            serialPort1.Write("uniqueksetlay(3 ");
            Thread.Sleep(50);
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (MdGlobals.keys[i][j][k].ktype !=255)
                        {
                            Thread.Sleep(50);
                            output.Add(textBox1.Text + "(" + i.ToString() + "(" + j.ToString() + "(" + k.ToString() + "(" + MdGlobals.keys[i][j][k].val.ToString() + "(" + MdGlobals.keys[i][j][k].ktype.ToString());
                            serialPort1.Write(textBox1.Text + "(" + i.ToString() + "(" + j.ToString() + "(" + k.ToString() + "(" + MdGlobals.keys[i][j][k].val.ToString() + "(" + MdGlobals.keys[i][j][k].ktype.ToString() + " ");
                        }
                    }
                }
            }

            var dout = new FmOutput(output);
            dout.Show();
        }


        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.Open();
        }
    }
}
