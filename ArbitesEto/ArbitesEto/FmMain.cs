using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
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

            // POSIX specific
            List<string> ports = new List<string>();
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                if (Directory.Exists(@"/dev/serial/by-id"))
                {
                    // probably is unix

                }
                else
                {
                    // probably is mac

                    var psi = new Process();
                    psi.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    psi.EnableRaisingEvents = false;
                    psi.StartInfo.UseShellExecute = false;
                    psi.StartInfo.RedirectStandardOutput = true;
                    psi.StartInfo.FileName = @"sh";
                    psi.StartInfo.Arguments = @"-c 'ls /dev/tty.*'";

                    psi.Start();
                    psi.WaitForExit();
                    ports = psi.StandardOutput.ReadToEnd().Split('\n').ToList();

                    //ports = psi.StandardOutput.

                }
            }
            else
            {

                ports = SerialPort.GetPortNames().ToList();
            }
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
