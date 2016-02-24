using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArbitesR
{
    public partial class FmSelectPortDialog : Form
    {
        public string output { get; set; }

        public FmSelectPortDialog()
        {
            InitializeComponent();
            output = "error";
            RefreshPorts();

        }

        public void RefreshPorts()
        {
            flpMain.Controls.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                Button btn = new Button();
                btn.Text = port;
                btn.Size = new Size(173, 23);
                btn.Parent = this.flpMain;
                btn.Click += new EventHandler(this.BtnPress);
            }
        }

        public void BtnPress(object sender, EventArgs e)
        {
            tbPort.Text = (sender as Button).Text;
            btOK.PerformClick();
        }

        private void btOK_Click(object sender, EventArgs e)
        {

            try
            {
                SerialPort port = new SerialPort(output);
                port.Open();
                port.Close();
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show("Arbites failed to detect the selected port\nAre you sure you wish to select this port?", "Port Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            output = (sender as TextBox).Text;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }


    }
}
