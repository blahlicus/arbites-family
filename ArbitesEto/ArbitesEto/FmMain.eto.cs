using System;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmMain : Form
    {
        MenuBar MBMain;
        ButtonMenuItem BMIDevice, BMIKeyMenu, BMIUpload, BMIHardware, BMIPort;


        void InitializeComponent()
        {
            Title = "Arbites Innova - 1.2.0 0000";
            ClientSize = new Size(1000, 600);

            var layout = new PixelLayout();



            BMIHardware = new ButtonMenuItem();
            BMIHardware.Text = "Keyboard";

            BMIPort = new ButtonMenuItem();
            BMIPort.Text = "Port";



            Button cmb = new Button();

            BMIDevice = new ButtonMenuItem();
            BMIDevice.Text = "Select Device";
            BMIDevice.Items.Add(cmb);
            //BMIDevice.Items.Add(BMIHardware);
            //BMIDevice.Items.Add(BMIPort);

            BMIKeyMenu = new ButtonMenuItem();
            BMIKeyMenu.Text = "Open Key Menu";


            BMIUpload = new ButtonMenuItem();
            BMIUpload.Text = "Upload";



            MBMain = new MenuBar();


            MBMain.Items.Add(BMIDevice);
            MBMain.Items.Add(BMIKeyMenu);
            MBMain.Items.Add(BMIUpload);

            Menu = MBMain;

            var BtnSelectDevice = new Button();
            BtnSelectDevice.Text = "Select Device";
            layout.Add(BtnSelectDevice, 5, 5);

            var BtnKeyMenu = new Button();
            BtnKeyMenu.Text = "Open Key Menu";

            layout.Add(BtnKeyMenu, 90, 5);



            Content = layout;

        }

    }
}