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
            BtnDevice.Click += (sender, e) => LoadHardwareList();

            // load devices event
            BtnPort.Click += (sender, e) => LoadPortList();
            
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

            FmSelectTextDialog dialog = new FmSelectTextDialog("Select Device", "Select Your Keyboard:", fileDisplayName, files);
            dialog.ShowModal();
            if (dialog.hasResult)
            {
                LDevice.Text = dialog.outputDisplay;
            }
            
        }

        public void LoadPortList()
        {

            //CMBPort.Items.Clear();
            List<string> ports = SerialPort.GetPortNames().ToList();
            FmSelectTextDialog dialog = new FmSelectTextDialog("Select Port", "Select Your Port:", ports, ports);
            dialog.ShowModal();
            if (dialog.hasResult)
            {
                LPort.Text = dialog.outputDisplay;
            }


        }

        public void SelectDeviceClicked(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Command).MenuText);
        }

    }
}
