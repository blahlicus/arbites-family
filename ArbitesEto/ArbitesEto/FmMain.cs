using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class FmMain
    {

        public FmMain()
        {
            InitializeComponent();

            // load ports event
            DDPort.MouseEnter += (sender, e) => LoadPortList();

            // load devices event
            DDDevice.MouseEnter += (sender, e) => LoadHardwareList();
        }


        public void LoadDevices()
        {
            LoadHardwareList();
            LoadPortList();

        }

        public void LoadHardwareList()
        {
            List<string> files = System.IO.Directory.GetFiles(MdConstants.keyboards, MdConstants.eKeyboards).ToList<string>();
            var fileDisplayName = files.Select(str => str.Substring(str.LastIndexOf(MdConstants.pseparator) + 1)).ToList();

            DDDevice.Items.Clear();
            foreach(string str in fileDisplayName)
            {
                DDDevice.Items.Add(str);
            }
        }

        public void LoadPortList()
        {

            DDPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string str in ports)
            {
                DDPort.Items.Add(str);
            }


        }

        public void SelectDeviceClicked(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Command).MenuText);
        }

    }
}
