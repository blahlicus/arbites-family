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
            Icon = new Icon(MdConstants.icon);
            //Icon = ArbitesEto.Properties.Resources.favicon as Eto.Drawing.Icon;
            //Icon = Icon.FromResource("favicon.ico", typeof(System.Drawing.Icon));
            ClKey.iniList();
            MdGlobals.Initiate();

            // load ports event
            BtnDevice.Click += (sender, e) => LoadHardwareList();

            // load devices event
            BtnPort.Click += (sender, e) => LoadPortList();

            // launch key selector
            BtnKeyMenu.Click += (sender, e) => LaunchKeyMenu();

            BtnUpload.Click += (sender, e) => BtnUploadClicked();
            
        }

        public void BtnUploadClicked()
        {
            MdGlobals.board.slices[0].ClientSize = new Size(200, 400);
        }

        public void LaunchKeyMenu()
        {
            if (MdGlobals.kselect.Loaded)
            {
                MdGlobals.kselect.Focus();
            }
            else
            {
                MdGlobals.kselect = new FmKeySelector();
                MdGlobals.kselect.Show();
            }
            
        }


        public void LoadHardwareList()
        {
            List<string> files = System.IO.Directory.GetFiles(MdConstants.keyboards, MdConstants.eKeyboards).ToList<string>();
            var fileDisplayName = files.Select(str => str.Substring(str.LastIndexOf(MdConstants.pseparator) + 1)).ToList();

            FmSelectTextDialog dialog = new FmSelectTextDialog("Select Device", "Select Your Keyboard:", fileDisplayName, files);
            dialog.ShowModal();
            if (dialog.hasResult)
            {
                ClKeyboard output = MdCore.Deserialize<ClKeyboard>(dialog.output);

                DisplayKeyboard(output);
            }
            
        }

        private void DisplayKeyboard(ClKeyboard input)
        {
            MdGlobals.boardType = input;
            MdGlobals.board = new UCBoard(input);
            PMain.Content = MdGlobals.board;
        }

        public void LoadPortList()
        {

            //CMBPort.Items.Clear();

            // POSIX specific
            List<string> ports = new List<string>();
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                try
                {

                    if (Directory.Exists(@"/dev/serial/by-id"))
                    {
                        // probably is unix
                        var psi = new Process();
                        psi.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        psi.EnableRaisingEvents = false;
                        psi.StartInfo.UseShellExecute = false;
                        psi.StartInfo.RedirectStandardOutput = true;
                        psi.StartInfo.FileName = @"sh";
                        psi.StartInfo.Arguments = @"-c 'for s in /dev/serial/by-path/*; do readlink -f $s; done'";

                        psi.Start();
                        psi.WaitForExit();
                        ports = psi.StandardOutput.ReadToEnd().Split('\n').ToList();
                        ports.RemoveAt(ports.Count - 1);


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
                        ports.RemoveAt(ports.Count - 1);


                    }
                }
                catch (Exception e)
                {
                    ports = SerialPort.GetPortNames().ToList();
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


    }
}
