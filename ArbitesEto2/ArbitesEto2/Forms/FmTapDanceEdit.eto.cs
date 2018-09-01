using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmTapDanceEdit : Form
    {
        Label LTip, LKeyAmount;

        TableRow TRStack;

        DropDown DDDelay;

        Button BtnAddKey, BtnOK, BtnCancel;
        void InitializeComponent()
        {
            Title = "Editing Tap Dance";


            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trTip = new TableRow();
            tlMain.Rows.Add(trTip);

            LTip = new Label();
            trTip.Cells.Add(LTip);

            var trKeyAmount = new TableRow();
            tlMain.Rows.Add(trKeyAmount);

            LKeyAmount = new Label();
            trKeyAmount.Cells.Add(LKeyAmount);

            var trMain = new TableRow();
            tlMain.Rows.Add(trMain);

            var tlStack = new TableLayout();
            tlStack.Height = 133;
            tlStack.Padding = 5;
            tlStack.Spacing = new Size(5, 5);
            trMain.Cells.Add(tlStack);

            TRStack = new TableRow();
            tlStack.Rows.Add(TRStack);


            var trAddKey = new TableRow();
            tlMain.Rows.Add(trAddKey);

            BtnAddKey = new Button();
            BtnAddKey.Text = "Add Key";
            BtnAddKey.ToolTip = "Add Key";
            trAddKey.Cells.Add(BtnAddKey);

            tlMain.Rows.Add(null);

            var trBot = new TableRow();
            trBot.ScaleHeight = false;
            tlMain.Rows.Add(trBot);

            var tlBot = new TableLayout();
            trBot.Cells.Add(tlBot);




            var trBotBar = new TableRow();
            tlBot.Rows.Add(trBotBar);


            var lDelay = new Label();
            lDelay.Text = "Timeout: ";
            trBotBar.Cells.Add(lDelay);

            DDDelay = new DropDown();
            trBotBar.Cells.Add(DDDelay);

            trBotBar.Cells.Add(new TableCell(null, true));

            BtnOK = new Button();
            BtnOK.Text = "Save";
            BtnOK.ToolTip = "Save";
            trBotBar.Cells.Add(BtnOK);

            BtnCancel = new Button();
            BtnCancel.Text = "Cancel";
            BtnCancel.ToolTip = "Cancel";
            trBotBar.Cells.Add(new TableCell(BtnCancel, false));

            Content = tlMain;
        }
    }
}
