using System;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmMain : Form
    {
        Button BtnSelectDevice, BtnOpenKeyMenu, BtnSettings, BtnEditMacro, BtnEditTapDance, BtnEditMouse, BtnEditLED, BtnSelectPort, BtnApply;
        DropDown DDInputMethod;
        Panel PnMain;
        void InitializeComponent()
        {

            Title = "Arbites Innova - 2.3 5000";
            ClientSize = new Size(1000, 600);

            
            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trTop = new TableRow();
            tlMain.Rows.Add(trTop);

            var tcTop = new TableCell();
            trTop.Cells.Add(tcTop);

            var tlTop = new TableLayout();
            tcTop.Control = tlTop;
            tlTop.Padding = 5;

            var trContext = new TableRow();
            
            tlTop.Rows.Add(trContext);

            var tcTopLeft = new TableCell();
            tcTopLeft.ScaleWidth = true;
            trContext.Cells.Add(tcTopLeft);

            var slTopLeft = new StackLayout();
            slTopLeft.Orientation = Orientation.Horizontal;
            slTopLeft.VerticalContentAlignment = VerticalAlignment.Center;
            slTopLeft.Spacing = 5;
            tcTopLeft.Control = slTopLeft;

            BtnSelectDevice = new Button();
            BtnSelectDevice.Text = "Select Device";
            BtnSelectDevice.ToolTip = "Select Device";
            slTopLeft.Items.Add(BtnSelectDevice);

            BtnOpenKeyMenu = new Button();
            BtnOpenKeyMenu.Text = "Key Menu";
            BtnOpenKeyMenu.ToolTip = "Key Menu";
            slTopLeft.Items.Add(BtnOpenKeyMenu);

            BtnSettings = new Button();
            BtnSettings.Text = "Preferences";
            BtnSettings.ToolTip = "Preferences";
            slTopLeft.Items.Add(BtnSettings);

            var tcTopMid = new TableCell();
            tcTopMid.ScaleWidth = true;
            trContext.Cells.Add(tcTopMid);


            var slTopMid = new StackLayout();
            slTopMid.Orientation = Orientation.Horizontal;
            slTopMid.VerticalContentAlignment = VerticalAlignment.Center;
            slTopMid.Spacing = 5;
            tcTopMid.Control = slTopMid;

            BtnEditMacro = new Button();
            BtnEditMacro.Text = "Edit Macros";
            BtnEditMacro.ToolTip = "Edit Macros";
            slTopMid.Items.Add(BtnEditMacro);

            BtnEditTapDance = new Button();
            BtnEditTapDance.Text = "Edit Tap-Dance";
            BtnEditTapDance.ToolTip = "Edit Tap-Dance";
            slTopMid.Items.Add(BtnEditTapDance);

            BtnEditMouse = new Button();
            BtnEditMouse.Text = "Edit Mouse Keys";
            BtnEditMouse.ToolTip = "Edit Mouse Keys";
            //slTopMid.Items.Add(BtnEditMouse);

            BtnEditLED = new Button();
            BtnEditLED.Text = "Edit LEDs";
            BtnEditLED.ToolTip = "Edit LEDs";
            //slTopMid.Items.Add(BtnEditLED);

            var tcTopRight = new TableCell();
            tcTopRight.ScaleWidth = true;
            trContext.Cells.Add(tcTopRight);

            var tlTopRight = new TableLayout();
            tcTopRight.Control = tlTopRight;

            var trTopRight = new TableRow();
            tlTopRight.Rows.Add(trTopRight);

            var tcTopInputMethod = new TableCell();
            tcTopInputMethod.ScaleWidth = true;
            trTopRight.Cells.Add(tcTopInputMethod);

            var tlInputMethod = new TableLayout();
            tcTopInputMethod.Control = tlInputMethod;

            var trInputMethod = new TableRow();
            tlInputMethod.Rows.Add(trInputMethod);

            var lInputmethod = new Label();
            lInputmethod.Text = "Input Method:";
            lInputmethod.VerticalAlignment = VerticalAlignment.Center;
            trInputMethod.Cells.Add(lInputmethod);

            DDInputMethod = new DropDown();
            trInputMethod.Cells.Add(DDInputMethod);


            var tcTopRightContent = new TableCell();
            tcTopRightContent.ScaleWidth = false;
            trTopRight.Cells.Add(tcTopRightContent);


            var slTopRight = new StackLayout();
            slTopRight.Orientation = Orientation.Horizontal;
            slTopRight.VerticalContentAlignment = VerticalAlignment.Center;
            slTopRight.Spacing = 5;
            tcTopRightContent.Control = slTopRight;


            BtnSelectPort = new Button();
            BtnSelectPort.Text = "Select Port";
            BtnSelectPort.ToolTip = "Select Port";
            slTopRight.Items.Add(BtnSelectPort);

            BtnApply = new Button();
            BtnApply.Text = "Apply";
            BtnApply.ToolTip = "Apply";
            slTopRight.Items.Add(BtnApply);

            var trMain = new TableRow();
            tlMain.Rows.Add(trMain);

            var tcContent = new TableCell();
            trMain.Cells.Add(tcContent);

            PnMain = new Panel();
            tcContent.Control = PnMain;

            this.Size = new Size(1200, 480);

            this.Content = tlMain;
        }
    }
}