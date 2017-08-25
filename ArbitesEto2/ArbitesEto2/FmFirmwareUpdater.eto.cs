using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmFirmwareUpdater : Dialog
    {
        Button BtnSelectFile, BtnUpload, BtnPorts;
        void InitializeComponent()
        {
            Title = "Firmware Uploader";
            ClientSize = new Size(300, 300);

            var slMain = new StackLayout();
            slMain.Spacing = 5;
            Content = slMain;

            var l1 = new Label();
            l1.Wrap = WrapMode.Word;
            l1.Text = "This is the firmware uploader, it is used to upload firmware to your hardware device, allowing you to update the firmware in your device, follow the steps below to upload your firmware:\n\n1. Download the compiled *.hex firmware file for your device\n2. Press browse and select your *.hex file\n3. Press select port to select the port of your device\n4. Press upload, then wait around 30 seconds for the firmware to be uploaded to your hardware, a command line window will pop up during the upload\n";
            slMain.Items.Add(l1);

            var slTop = new StackLayout();
            slTop.Spacing = 5;
            slTop.Orientation = Orientation.Horizontal;
            slTop.VerticalContentAlignment = VerticalAlignment.Center;
            slMain.Items.Add(slTop);

            var l2 = new Label();
            l2.Text = "No Ports Selected";
            slTop.Items.Add(l2);

            BtnPorts = new Button();
            BtnPorts.Text = "Select Port";
            BtnPorts.ToolTip = "Select Port";
            slTop.Items.Add(BtnPorts);

            BtnUpload = new Button();
            BtnUpload.Text = "Upload";
            BtnUpload.ToolTip = "Upload";
            slTop.Items.Add(BtnUpload);
        }
    }
}
