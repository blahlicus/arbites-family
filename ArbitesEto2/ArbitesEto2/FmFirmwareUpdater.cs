using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.IO.Ports;

namespace ArbitesEto2
{
    public partial class FmFirmwareUpdater
    {
        Timer Counter;
        string SelectedPort = "none";
        string SelectedFile = "none";
        int timerElapsedCount = 0;
        List<string> Ports;
        bool hasUploaded = false;
        public FmFirmwareUpdater()
        {
            InitializeComponent();
            Counter = new Timer(250);
            Counter.Enabled = false;
            Counter.AutoReset = false;
            EventHook();

        }

        private void EventHook()
        {
            BtnPorts.Click += (sender, e) => BtnPortsClicked();
            BtnSelectFile.Click += (sender, e) => BtnSelectFileClicked();
            BtnUpload.Click += (sender, e) => BtnUploadClicked();
            Counter.Elapsed += (sender, e) => TimerElapsed();
        }

        private void TimerElapsed()
        {
            timerElapsedCount++;
            var tempPorts = GetPorts();
            var ls = tempPorts.Except(Ports).ToList();

            if (timerElapsedCount > 19)
            {
                // timeout after 5 seconds
                if (!hasUploaded)
                {
                    hasUploaded = true;
                    MessageBox.Show("Unable to find device, please make sure the device is plugged in and the correct device is selected");
                }
                Counter.Stop();
            }
            else
            {
                // check again
                if (ls.Count == 1)
                {
                    if (!hasUploaded)
                    {
                        hasUploaded = true;
                        UploadHex(ls[0]);
                        hasUploaded = false;
                    }
                    Counter.Stop();
                }
                else
                {
                    Counter.Enabled = true;
                }
            }

        }

        private void UploadHex(string port) //TODO add platform specific code for linxu and mac
        {


            if ((Environment.OSVersion.Platform == PlatformID.Unix) || (Environment.OSVersion.Platform == PlatformID.MacOSX))
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
                        psi.StartInfo.FileName = @"sh";
                        psi.StartInfo.Arguments = "\"avrdude -v -patmega32u4 -cavr109 -P" + port + " -b57600 -D -Uflash:w:" + SelectedFile + ":i\"";

                        psi.Start();
                    }
                    else
                    {
                        // probably is mac

                        var psi = new Process();
                        psi.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        psi.EnableRaisingEvents = false;
                        psi.StartInfo.UseShellExecute = false;
                        psi.StartInfo.FileName = @"sh";
                        psi.StartInfo.Arguments = "\"avrdude -v -patmega32u4 -cavr109 -P" + port + " -b57600 -D -Uflash:w:" + SelectedFile + ":i\"";

                        psi.Start();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to detect OS version, please retry.");
                }
            }
            else
            {
                // probably is windows
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.FileName = Path.Combine(MdConstant.windowsAvrdudeLocation, "avrdude");
                startInfo.WorkingDirectory = MdConstant.windowsAvrdudeLocation;
                startInfo.Arguments = @"-v -patmega32u4 -cavr109 -P" + port + " -b57600 -D -Uflash:w:" + SelectedFile + ":i";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("\nAVRDUDE started with argument: " + startInfo.Arguments + "\n\nYou may close this window once AVRDUDE completes uploading");

            }

        }


        private void BtnPortsClicked()
        {
            Ports = GetPorts();
            var dialog = new FmSelectTextDialog(Ports, Ports, "Select your port");
            dialog.ShowModal();
            if (dialog.OutputIndex >= 0)
            {
                this.LSelectedPort.Text = "Port: " + dialog.OutputKeys[dialog.OutputIndex];
                SelectedPort = dialog.OutputKeys[dialog.OutputIndex];
            }
        }

        private void BtnSelectFileClicked()
        {

            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter("Hex Binary File", "*.hex"));
            dialog.Title = "Load Layout";
            try
            {
                dialog.ShowDialog(this);
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    this.SelectedFile = dialog.FileName;
                    LSelectedFile.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUploadClicked()
        {
            if (File.Exists(SelectedFile))
            {

                var sp = new SerialPort();
                sp.PortName = SelectedPort;
                sp.BaudRate = 1200;

                try
                {
                    sp.Open();
                }
                catch (Exception)
                {
                    var dr = MessageBox.Show("Arbites failed to detect the selected port\nAre you sure you wish to upload to this port?", "Port Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        //do nothing
                    }
                    else
                    {
                        return;
                    }
                }
                LStatus.Text += "\nPulsing " + SelectedPort + " to enter boot mode";
                sp.Close();
                timerElapsedCount = 0;
                Counter.Enabled = true;
            }
            else
            {
                MessageBox.Show("Arbites cannot find the selected .hex file, please make sure the .hex file exists.");
            }
        }

        private List<string> GetPorts()
        {

            // POSIX specific
            List<string> ports;
            if ((Environment.OSVersion.Platform == PlatformID.Unix) || (Environment.OSVersion.Platform == PlatformID.MacOSX))
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
                catch (Exception)
                {
                    ports = SerialPort.GetPortNames().ToList();
                }
            }
            else
            {
                ports = SerialPort.GetPortNames().ToList();
            }
            return ports;
        }

    }
}
