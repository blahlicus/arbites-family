using System;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmMain : Form
    {
        Button BtnSelectDevice, BtnOpenKeyMenu, BtnEditMacro, BtnEditDualRoles, BtnEditMouse, BtnSelectPort, BtnApply;

        TableCell TCContent;
        void InitializeComponent()
        {
            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trTop = new TableRow();
            tlMain.Rows.Add(trTop);

            var tcTop = new TableCell();
            trTop.Cells.Add(tcTop);

            var tlTop = new TableLayout();
            tcTop.Control = tlTop;

            var trContext = new TableRow();
            tlTop.Rows.Add(trContext);

            var tcTopLeft = new TableCell();
            tcTopLeft.ScaleWidth = true;
            trContext.Cells.Add(tcTopLeft);

            var scTopLeft = new StackLayout();
            scTopLeft.Orientation = Orientation.Horizontal;
            scTopLeft.HorizontalContentAlignment = HorizontalAlignment.Center;
            scTopLeft.Spacing = 5;
            tcTopLeft.Control = scTopLeft;

            BtnSelectDevice = new Button();
            BtnSelectDevice.Text = "Select Device";
            BtnSelectDevice.ToolTip = "Select Device";
            scTopLeft.Items.Add(BtnSelectDevice);

            BtnOpenKeyMenu = new Button();
            BtnOpenKeyMenu.Text = "Key Menu";
            BtnOpenKeyMenu.ToolTip = "Key Menu";
            scTopLeft.Items.Add(BtnOpenKeyMenu);


            var tcTopMid = new TableCell();
            tcTopMid.ScaleWidth = true;
            trContext.Cells.Add(tcTopMid);


            var scTopMid = new StackLayout();
            scTopMid.Orientation = Orientation.Horizontal;
            scTopMid.HorizontalContentAlignment = HorizontalAlignment.Center;
            scTopMid.Spacing = 5;
            tcTopMid.Control = scTopMid;

            BtnEditMacro = new Button();
            BtnEditMacro.Text = "Edit Macros";
            BtnEditMacro.ToolTip = "Edit Macros";
            scTopMid.Items.Add(BtnEditMacro);

            BtnEditDualRoles = new Button();
            BtnEditDualRoles.Text = "Edit Dual-Roles";
            BtnEditDualRoles.ToolTip = "Edit Dual-Roles";
            scTopMid.Items.Add(BtnEditDualRoles);

            BtnEditMouse = new Button();
            BtnEditMouse.Text = "Edit Mouse Keys";
            BtnEditMouse.ToolTip = "Edit Mouse Keys";
            scTopMid.Items.Add(BtnEditMouse);

            var tcTopRight = new TableCell();
            tcTopRight.ScaleWidth = true;
            trContext.Cells.Add(tcTopRight);

            var tlTopRight = new TableLayout();
            tcTopRight.Control = tlTopRight;

            var trTopRight = new TableRow();
            tlTopRight.Rows.Add(trTopRight);

            var tcTopRightSpacer = new TableCell();
            tcTopRightSpacer.ScaleWidth = true;
            trTopRight.Cells.Add(tcTopRightSpacer);

            var tcTopRightContent = new TableCell();
            tcTopRightContent.ScaleWidth = false;
            trTopRight.Cells.Add(tcTopRightContent);


            var scTopRight = new StackLayout();
            scTopRight.Orientation = Orientation.Horizontal;
            scTopRight.HorizontalContentAlignment = HorizontalAlignment.Center;
            scTopRight.Spacing = 5;
            tcTopRightContent.Control = scTopRight;


            BtnSelectPort = new Button();
            BtnSelectPort.Text = "Select Port";
            BtnSelectPort.ToolTip = "Select Port";
            scTopRight.Items.Add(BtnSelectPort);

            BtnApply = new Button();
            BtnApply.Text = "Apply";
            BtnApply.ToolTip = "Apply";
            scTopRight.Items.Add(BtnApply);

            this.Content = tlMain;
        }
    }
}