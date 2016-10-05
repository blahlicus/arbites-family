using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    
    public partial class FmLayoutUploader
    {
        BackgroundWorker bw;
        List<string> commands;
        bool inProgress = true;
        public FmLayoutUploader()
        {
            this.ShowInTaskbar = true;
            InitializeComponent();
            commands = new List<string>();
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += (sender, e) => UploadCommand(sender, e);
            bw.ProgressChanged += (sender, e) => ProgressUpdate(sender, e);
            bw.RunWorkerCompleted += (sender, e) => UploadCompleted(sender, e);
            this.Closing += (sender, e) => FmClosing(sender, e);
            this.Closed += (sender, e) => FmClosed(sender, e);
            Icon = MdSessionData.WindowIcon;
        }


        public FmLayoutUploader(List<string> input) : this()
        {
            foreach(string str in input)
            {
                //MessageBox.Show(str);
            }
            this.commands = input;
            bw.RunWorkerAsync();
        }

        public void FmClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = inProgress;
        }

        public void UploadCommand(object sender, DoWorkEventArgs e)
        {
            int pg = 0;
            //try
            {
                for (int i = 0; i < commands.Count; i++ )
                {

                    MdSessionData.SP.Write(commands[i]);
                    Thread.Sleep(MdConfig.Main.UploadDelay);
                    pg = (i * 100) / (commands.Count);
                    if (pg > 100)
                    {
                        pg = 100;
                    }
                    bw.ReportProgress(pg);
                }
            }
            //catch (Exception ex)
            {
                //bw.ReportProgress(pg);
                

            }
        }

        public void ProgressUpdate(object sender, ProgressChangedEventArgs e)
        {
            this.PBMain.Value = e.ProgressPercentage;
        }

        public void UploadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            inProgress = false;
            MdSessionData.SP.Close();
            if (PBMain.Value == 0)
            {
                MessageBox.Show("Error: Failed to upload");
            }
            else
            {
                MessageBox.Show("Upload Completed", "Upload Completed", MessageBoxType.Information);
            } 
            this.Close();

        }

        private void FmClosed(object sender, EventArgs e)
        {
            if (MdConfig.Main.DisplayOutput)
            {
                var fm = new FmRichTextDisplay(commands);
                fm.Show();
            }
        }

    }
}
