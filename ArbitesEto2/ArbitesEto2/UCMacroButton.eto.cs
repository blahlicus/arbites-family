using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class UCMacroButton : Panel
    {
        Button BtnMain, BtnLeft, BtnRight, BtnDelete, BtnKeyMode;
        void InitializeComponent()
        {
            this.Padding = 5;
            var tlMain = new TableLayout();

            var trMain = new TableRow();
            trMain.ScaleHeight = true;
            tlMain.Rows.Add(trMain);


            BtnMain = new Button();
            BtnMain.Text = "Select a Key";
            trMain.Cells.Add(BtnMain);

            var trBot = new TableRow();
            trBot.ScaleHeight = false;
            tlMain.Rows.Add(trBot);


            var tlBot = new TableLayout();
            trBot.Cells.Add(tlBot);

            var trBotUpper = new TableRow();
            tlBot.Rows.Add(trBotUpper);

            BtnLeft = new Button();
            BtnLeft.Text = "Left";
            BtnLeft.ToolTip = "Move this key forwards";
            BtnLeft.Width = 20;
            trBotUpper.Cells.Add(new TableCell(BtnLeft, true));

            BtnRight = new Button();
            BtnRight.Text = "Right";
            BtnRight.ToolTip = "Move this key backwards";
            BtnRight.Width = 20;
            trBotUpper.Cells.Add(new TableCell(BtnRight, true));

            var trBotLower = new TableRow();
            tlBot.Rows.Add(trBotLower);

            BtnKeyMode = new Button();
            BtnKeyMode.Text = "Press";
            BtnKeyMode.ToolTip = "Toggle between pressing or releasing the key";
            BtnKeyMode.Width = 20;
            trBotLower.Cells.Add(new TableCell(BtnKeyMode, true));

            BtnDelete = new Button();
            BtnDelete.Text = "Delete";
            BtnDelete.ToolTip = "Delete this key";
            BtnDelete.Width = 20;
            trBotLower.Cells.Add(new TableCell(BtnDelete, true));



            Content = tlMain;
        }
    }
}
