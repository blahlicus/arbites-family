using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Timers;
namespace ArbitesEto2
{
    public partial class FmFirmwareUpdater
    {
        Timer Counter;
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
        }

        private void BtnPortsClicked()
        {
            //TODO
        }

        private void BtnSelectFileClicked()
        {
            //TODO
        }

        private void BtnUploadClicked()
        {
            //TODO
        }
    }
}
