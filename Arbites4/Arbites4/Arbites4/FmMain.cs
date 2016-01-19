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
using System.IO;
using System.Xml.Serialization;

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
            MdGlobals.keys = new ClLayoutContainer((int)nudx.Value, (int)nudy.Value, (int)nudz.Value);
            UCBoard newb = new UCBoard((int)nudx.Value, (int)nudy.Value, (int)nudz.Value);

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

            serialPort1.Open();
            var output = new List<string>();
            output.Add("uniqueksetlay(" + nudz.Value.ToString() + " ");
            serialPort1.Write("uniqueksetlay(" + nudz.Value.ToString() + " ");
            Thread.Sleep(50);
            for (int k = 0; k < (int)nudz.Value; k++)
            {
                for (int j = 0; j < (int)nudy.Value; j++)
                {
                    for (int i = 0; i < (int)nudx.Value; i++)
                    {
                        if (MdGlobals.keys.keys[i][j][k].ktype != 255)
                        {
                            Thread.Sleep(50);
                            output.Add(textBox1.Text + "(" + i.ToString() + "(" + j.ToString() + "(" + k.ToString() + "(" + MdGlobals.keys.keys[i][j][k].val.ToString() + "(" + MdGlobals.keys.keys[i][j][k].ktype.ToString());
                            serialPort1.Write(textBox1.Text + "(" + i.ToString() + "(" + j.ToString() + "(" + k.ToString() + "(" + MdGlobals.keys.keys[i][j][k].val.ToString() + "(" + MdGlobals.keys.keys[i][j][k].ktype.ToString() + " ");
                        }
                    }
                }
            }

            serialPort1.Close();
            var dout = new FmOutput(output);
            dout.Show();
        }


        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && serialPort1 != null)
            {
                
                serialPort1.Close();
            }
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Terminus Mini Layout | *.arb4l";
            dialog.Title = "Save Layout";
            dialog.InitialDirectory = Environment.CurrentDirectory + "/data";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                StreamWriter sw = new StreamWriter(dialog.FileName, false);
                XmlSerializer ser = new XmlSerializer(typeof(ClLayoutContainer));
                ser.Serialize(sw, MdGlobals.keys);
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Terminus Mini Layout | *.arb4l";
            dialog.Title = "Load Layout";
            dialog.InitialDirectory = Environment.CurrentDirectory + "/data";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                StreamReader sr = new StreamReader(dialog.FileName);
                XmlSerializer ser = new XmlSerializer(typeof(ClLayoutContainer));
                MdGlobals.keys = (ClLayoutContainer)ser.Deserialize(sr);
                sr.Close();
            }
        }
    }
}
