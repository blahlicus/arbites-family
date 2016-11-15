using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Eto.Forms;


namespace ArbitesEto2
{

    public partial class FmLayoutUploader
    {

        private readonly BackgroundWorker bw;
        private readonly List<string> commands;
        private bool inProgress = true;

        public FmLayoutUploader()
        {
            this.ShowInTaskbar = true;
            InitializeComponent();
            this.commands = new List<string>();
            this.bw = new BackgroundWorker();
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = false;
            this.bw.DoWork += (sender, e) => UploadCommand(sender, e);
            this.bw.ProgressChanged += (sender, e) => ProgressUpdate(sender, e);
            this.bw.RunWorkerCompleted += (sender, e) => UploadCompleted(sender, e);
            Closing += (sender, e) => FmClosing(sender, e);
            Closed += (sender, e) => FmClosed();
            this.Icon = MdSessionData.WindowIcon;
        }


        public FmLayoutUploader(List<string> input) : this()
        {
            this.commands = input;
            this.bw.RunWorkerAsync();
        }

        public void FmClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = this.inProgress;
        }

        public void UploadCommand(object sender, DoWorkEventArgs e)
        {
            //try
            {
                for (var i = 0; i < this.commands.Count; i++)
                {
                    MdSessionData.SP.Write(this.commands[i]);
                    Thread.Sleep(MdConfig.Main.UploadDelay);
                    var pg = i * 100 / this.commands.Count;
                    if (pg > 100)
                    {
                        pg = 100;
                    }
                    this.bw.ReportProgress(pg);
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
            this.inProgress = false;
            MdSessionData.SP.Close();
            if (this.PBMain.Value == 0)
            {
                MessageBox.Show("Error: Failed to upload");
            }
            else
            {
                MessageBox.Show("Upload Completed", "Upload Completed", MessageBoxType.Information);
            }
            Close();
        }

        private void FmClosed()
        {
            if (MdConfig.Main.DisplayOutput)
            {
                var fm = new FmRichTextDisplay(this.commands);
                fm.Show();
            }
        }

    }

}
