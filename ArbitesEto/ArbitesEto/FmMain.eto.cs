using System;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmMain : Form
    {
        StackLayout SLTopBar;
        PixelLayout PLMain;

        DropDown DDDevice, DDPort;

        Button BtnSave, BtnLoad, BtnUpload, BtnKeyMenu;

        ProgressBar PBMain;


        void InitializeComponent()
        {
            Title = "Arbites Innova - 1.2.0 0000";
            ClientSize = new Size(1000, 600);

            var layout = new Splitter();
            layout.Orientation = Orientation.Vertical;
            layout.SplitterWidth = 0;

            var topSplitter = new Splitter();
            
            topSplitter.Orientation = Orientation.Vertical;
            topSplitter.SplitterWidth = 0;

            var l1 = new Label();
            l1.Text = "Select Device: ";

            DDDevice = new DropDown();
            DDDevice.Size = new Size(120, 22);

            var l2 = new Label();
            l2.Text = "Select Port: ";

            DDPort = new DropDown();
            DDPort.Size = new Size(120, 22);

            BtnKeyMenu = new Button();
            BtnKeyMenu.Text = "Open Key Menu";


            BtnSave = new Button();
            BtnSave.Text = "Save";

            BtnLoad = new Button();
            BtnLoad.Text = "Load";

            BtnUpload = new Button();
            BtnUpload.Text = "Apply";

            PBMain = new ProgressBar();
            PBMain.Value = 50;

            SLTopBar = new StackLayout();
            SLTopBar.Padding = 5;
            SLTopBar.Spacing = 5;
            SLTopBar.Orientation = Orientation.Horizontal;
            SLTopBar.Items.Add(l1);
            SLTopBar.Items.Add(DDDevice);
            SLTopBar.Items.Add(l2);
            SLTopBar.Items.Add(DDPort);
            SLTopBar.Items.Add(BtnKeyMenu);
            SLTopBar.Items.Add(BtnSave);
            SLTopBar.Items.Add(BtnLoad);
            SLTopBar.Items.Add(BtnUpload);

            topSplitter.Panel1 = SLTopBar;
            topSplitter.Panel2 = PBMain;

            PLMain = new PixelLayout();

            Button lala = new Button();
            lala.Text = "stuff";
            PLMain.Add(lala, 20, 20);

            layout.Panel1 = topSplitter;
            layout.Panel2 = PLMain;

            //var layout = new PixelLayout();






            Content = layout;

        }

    }
}