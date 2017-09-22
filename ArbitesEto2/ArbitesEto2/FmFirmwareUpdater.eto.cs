using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmFirmwareUpdater : Form
    {
        Button BtnSelectFile, BtnUpload, BtnPorts;
        Label LSelectedFile, LSelectedPort;
        ProgressBar PBMain;
        RichTextArea RTAStatus;

        void InitializeComponent()
        {
            Title = "Firmware Uploader";
            ClientSize = new Size(400, 300);

            var tlMain = new TableLayout();
            tlMain.Spacing = new Size(5,5);
            Content = tlMain;

            var l1 = new Label();
            l1.Wrap = WrapMode.Word;
            l1.Text = "This is the firmware uploader, it is used to upload firmware to your hardware device, allowing you to update the firmware in your device, follow the steps below to upload your firmware:\n\n1. Download the compiled *.hex firmware file for your device\n2. Press browse and select your *.hex file\n3. Press select port to select the port of your device\n4. Press upload, then wait around 30 seconds for the firmware to be uploaded to your hardware, a command line window will pop up during the upload\n";
            tlMain.Rows.Add(l1);

            var slFile = new StackLayout();
            slFile.Spacing = 5;
            slFile.Orientation = Orientation.Horizontal;
            slFile.VerticalContentAlignment = VerticalAlignment.Center;
            tlMain.Rows.Add(slFile);

            LSelectedFile = new Label();
            LSelectedFile.Text = "No file seelcted";
            slFile.Items.Add(LSelectedFile);

            BtnSelectFile = new Button();
            BtnSelectFile.Text = "Browse";
            BtnSelectFile.ToolTip = "Browse";
            slFile.Items.Add(BtnSelectFile);

            var slPort = new StackLayout();
            slPort.Spacing = 5;
            slPort.Orientation = Orientation.Horizontal;
            slPort.VerticalContentAlignment = VerticalAlignment.Center;
            tlMain.Rows.Add(slPort);

            LSelectedPort = new Label();
            LSelectedPort.Text = "No Ports Selected";
            slPort.Items.Add(LSelectedPort);

            BtnPorts = new Button();
            BtnPorts.Text = "Select Port";
            BtnPorts.ToolTip = "Select Port";
            slPort.Items.Add(BtnPorts);

            BtnUpload = new Button();
            BtnUpload.Text = "Upload";
            BtnUpload.ToolTip = "Upload";
            slPort.Items.Add(BtnUpload);

            PBMain = new ProgressBar();
            tlMain.Rows.Add(PBMain);

            RTAStatus = new RichTextArea();
            RTAStatus.ReadOnly = true;
            tlMain.Rows.Add(RTAStatus);
            
        }
    }
}
