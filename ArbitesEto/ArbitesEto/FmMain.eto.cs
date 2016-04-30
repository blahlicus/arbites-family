using System;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmMain : Form
    {
        StackLayout SLTopBar;
        PixelLayout PLMain;

        Label LDevice, LPort;

        Button BtnDevice, BtnPort, BtnKeyMenu, BtnSave, BtnLoad, BtnUpload;

        ProgressBar PBMain;


        void InitializeComponent()
        {
            Title = "Arbites Innova - 1.2.0 0000";
            ClientSize = new Size(1000, 600);

            var layout = new TableLayout();

            var topSplitter = new TableLayout();
            layout.Rows.Add(new TableRow(topSplitter));

            SLTopBar = new StackLayout();
            SLTopBar.Padding = 5;
            SLTopBar.Spacing = 5;
            SLTopBar.Orientation = Orientation.Horizontal;
            SLTopBar.VerticalContentAlignment = VerticalAlignment.Center;
            topSplitter.Rows.Add(new TableRow(SLTopBar));


            var l1 = new Label();
            l1.Text = "Current Device:";
            SLTopBar.Items.Add(l1);

            LDevice = new Label();
            LDevice.Text = "None Selected";
            SLTopBar.Items.Add(LDevice);

            BtnDevice = new Button();
            BtnDevice.Text = "Select Device";
            SLTopBar.Items.Add(BtnDevice);
                
            var l2 = new Label();
            l2.Text = "Current Port:";
            SLTopBar.Items.Add(l2);

            LPort = new Label();
            LPort.Text = "None Selected";
            SLTopBar.Items.Add(LPort);

            BtnPort = new Button();
            BtnPort.Text = "Select Port";
            SLTopBar.Items.Add(BtnPort);

            BtnKeyMenu = new Button();
            BtnKeyMenu.Text = "Open Key Menu";
            SLTopBar.Items.Add(BtnPort);


            BtnSave = new Button();
            BtnSave.Text = "Save";
            SLTopBar.Items.Add(BtnSave);

            BtnLoad = new Button();
            BtnLoad.Text = "Load";
            SLTopBar.Items.Add(BtnLoad);

            BtnUpload = new Button();
            BtnUpload.Text = "Apply";
            SLTopBar.Items.Add(BtnUpload);

            PBMain = new ProgressBar();
            PBMain.Value = 50;
            PBMain.Size = new Size(100, 23);
            topSplitter.Rows.Add(new TableRow(PBMain));




            PLMain = new PixelLayout();
            layout.Rows.Add(new TableRow(PLMain));

            Button lala = new Button();
            lala.Text = "stuff";
            PLMain.Add(lala, 20, 20);






            Content = layout;

        }

    }
}