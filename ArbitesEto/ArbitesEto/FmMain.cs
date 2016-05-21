using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Timers;
using Eto.Forms;
using Eto.Drawing;
using System.Threading;
using System.ComponentModel;

namespace ArbitesEto
{
    public partial class FmMain
    {

        BackgroundWorker BWProgress;

        SerialPort sp;
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

            this.Closing += (sender, e) => FormClosing();
            
        }

        public void FormClosing()
        {
            if (MdGlobals.kselect.Loaded)
            {
                MdGlobals.kselect.Close();
            }
        }

        public void BtnUploadClicked()
        {
            BtnUpload.Enabled = false;
            sp = new SerialPort();
            sp.PortName = LPort.Text;

            try
            {
                sp.Open();
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show("Arbites failed to detect the selected port\nAre you sure you wish to upload to this port?", "Port Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //do nothing
                }
                else
                {
                    BtnUpload.Enabled = true;
                    return;
                }
            }
            if (MdGlobals.board == null)
            {
                MessageBox.Show("You must first select your device type by pressing the \"Select Device\" button.");
                BtnUpload.Enabled = true;
            }
            else
            {
                var output = MdGlobals.boardType.GenerateSerialCommands(MdGlobals.board.layout);

                BWProgress = new BackgroundWorker();
                BWProgress.DoWork += (sender, e) => BWDoWork(sender, e, output, output.Count);
                BWProgress.ProgressChanged += (sender, e) => BWUpdate(sender, e);
                BWProgress.WorkerReportsProgress = true;
                BWProgress.RunWorkerAsync();

            }

            /*
            for (int i = 0; i < output.Count; i++)
            {
                sp.Write(output[i]);
                Thread.Sleep(10);
                int pg = (i * 100) / output.Count;
                if (pg > 0 && pg < 101)
                {
                    PBMain.Value = pg;
                }

            }
            PBMain.Value = 100;
            MessageBox.Show("Upload completed");
            PBMain.Value = 0;
            sp.Close();
            /*
            var dp = new FmRichTextDisplay(MdGlobals.boardType.GenerateSerialCommands(MdGlobals.board.layout));
            dp.Show();
            //*/
        }
        public void BWDoWork(object sender, DoWorkEventArgs e, List<string> input, int max)
        {
            try
            {
                int lastpg = 0;
                while (input.Count > 0)
                {
                    sp.Write(input[0]);
                    input.RemoveAt(0);

                    Thread.Sleep(5);
                    int pg = ((max - input.Count) * 100) / max;
                    if ((pg > 0 && pg < 101) && (pg > lastpg + 8 || pg == 100))
                    {
                        BWProgress.ReportProgress(pg);
                        lastpg = pg;
                    }
                }
            }
            catch (Exception ex)
            {
                BWProgress.ReportProgress(0);

            }
        }

        public void BWUpdate(object sender, ProgressChangedEventArgs e)
        {
            PBMain.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                MessageBox.Show("Upload Completed");
                PBMain.Value = 0;
                BtnUpload.Enabled = true;
                sp.Close();
            }
            else if (e.ProgressPercentage == 0)
            {
                MessageBox.Show("Intermediate Upload Error!");
                PBMain.Value = 0;
                BtnUpload.Enabled = true;
                sp.Close();
            }
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
