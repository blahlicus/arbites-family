using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.IO.Ports;
using ArduinoUploader;
using System.Threading;
using System.ComponentModel;

namespace ArbitesEto2
{
    public partial class FmFirmwareUpdater
    {
        string SelectedPort = "none";
        string SelectedFile = "none";
        List<string> Ports;

        BackgroundWorker bw;

        private class SketchUploaderLogReceiver : IArduinoUploaderLogger
        {
            public void Error(string message, Exception exception)
            {
                //Logger.Error(exception, message);
                //Console.WriteLine("e: " + message);

            }

            public void Warn(string message)
            {
                //Console.WriteLine("w: " + message);

                //Logger.Warn(message);
            }

            public void Info(string message)
            {
                //Console.WriteLine("i: " + message);
                //Application.Instance.Invoke(new Action(() => RTA.Append(message)));
                //RTA.Append(message);

            }

            public void Debug(string message)
            {
                //Console.WriteLine("d: " + message);


                //Logger.Debug(message);
            }

            public void Trace(string message)
            {
                //RTA.Append(message);
                //Console.WriteLine(message);

            }
        }


        public FmFirmwareUpdater()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            EventHook();
        }

        private void EventHook()
        {
            BtnPorts.Click += (sender, e) => BtnPortsClicked();
            BtnSelectFile.Click += (sender, e) => BtnSelectFileClicked();
            BtnUpload.Click += (sender, e) => BtnUploadClicked();
            bw.RunWorkerCompleted += (sender, e) => BWCompleted(sender, e);
            bw.DoWork += (sender, e) => BWDoWork(sender, e);
            bw.ProgressChanged += (sender, e) => BWReportProgress(sender, e);
        }
        

        private void BWCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PBMain.Value = 0;
            if (e.Error != null)
            {
                RTAStatus.Append(e.Error.ToString(),true);
            }
            else
            {
                RTAStatus.Append("Successful upload to port " + SelectedPort + " with file " + SelectedFile, true);
            }
        }

        private void BWDoWork(object sender, DoWorkEventArgs e)
        {

            var asuo = new ArduinoSketchUploaderOptions();
            asuo.FileName = SelectedFile;
            asuo.PortName = SelectedPort;
            asuo.ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.Leonardo;
            var logger = new SketchUploaderLogReceiver();

            var progress = new Progress<double>(
                p => logger.Info($"Programming progress: {p * 100:F1}% ..."));
            progress.ProgressChanged += (isender, ie) => UploadProgressChanged(isender, ie);


            var uploader = new ArduinoSketchUploader(asuo, logger, progress);

            uploader.UploadSketch();
        }

        private void BWReportProgress(object sender, ProgressChangedEventArgs e)
        {
            PBMain.Value = e.ProgressPercentage;
        }
        
        
        private void UploadProgressChanged(object sender, double e)
        {
            int prog = Convert.ToInt32(e * 100);
            bw.ReportProgress(prog);
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
                RTAStatus.Append("Upload Started to port " + SelectedFile + " with file " + SelectedFile);
                bw.RunWorkerAsync();
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
