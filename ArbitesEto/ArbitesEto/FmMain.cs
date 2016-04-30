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

            // click port button event
            BMIDevice.Click += (sender, e) => LoadDevices();
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

            foreach(string str in fileDisplayName)
            {
                var nc = new Command();
                nc.MenuText = str;
                nc.ToolBarText = str;
                nc.Executed += (sender, e) => SelectDeviceClicked(sender, e);
                BMIHardware.Items.Add(nc);
            }
            BMIDevice.Items.Add(BMIHardware);
        }

        public void LoadPortList()
        {

            BMIPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string str in ports)
            {
                var nc = new Command();
                nc.MenuText = str;
                nc.ToolBarText = str;
                nc.Executed += (sender, e) => SelectDeviceClicked(sender, e);
                BMIPort.Items.Add(nc);
            }

            BMIDevice.Items.Add(BMIPort);

        }

        public void SelectDeviceClicked(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Command).MenuText);
        }

    }
}
