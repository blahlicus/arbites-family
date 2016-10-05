using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmPreferences : Dialog
    {
        CheckBox CBKeyMenuTopMost, CBDisplayOutput;
        DropDown DDUploadDelay;
        Button BtnResetDefaults, BtnClose;


        void InitializeComponent()
        {
            
            Title = "Preferences";

            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trMain = new TableRow();
            tlMain.Rows.Add(trMain);

            var tlTop = new TableLayout();
            trMain.Cells.Add(tlTop);


            var trKeyMenuTop = new TableRow();
            tlTop.Rows.Add(trKeyMenuTop);

            var lKeyMenuTop = new Label();
            lKeyMenuTop.Text = "Key menu is top most";
            trKeyMenuTop.Cells.Add(lKeyMenuTop);

            CBKeyMenuTopMost = new CheckBox();
            CBKeyMenuTopMost.Text = "";
            trKeyMenuTop.Cells.Add(CBKeyMenuTopMost);


            var trDisplayOutput = new TableRow();
            tlTop.Rows.Add(trDisplayOutput);

            var lDisplayOutput = new Label();
            lDisplayOutput.Text = "Display command outputs";
            trDisplayOutput.Cells.Add(lDisplayOutput);

            CBDisplayOutput = new CheckBox();
            CBDisplayOutput.Text = "";
            trDisplayOutput.Cells.Add(CBDisplayOutput);


            var trUploadDelay = new TableRow();
            tlTop.Rows.Add(trUploadDelay);

            var lUploadDelay = new Label();
            lUploadDelay.Text = "Serial upload delay: ";
            trUploadDelay.Cells.Add(lUploadDelay);

            DDUploadDelay = new DropDown();
            trUploadDelay.Cells.Add(DDUploadDelay);


            var trBot = new TableRow();
            tlMain.Rows.Add(trBot);


            var tlBot = new TableLayout();
            trBot.Cells.Add(tlBot);


            var trBotBar = new TableRow();
            tlBot.Rows.Add(trBotBar);



            BtnResetDefaults = new Button();
            BtnResetDefaults.Text = "Reset Defaults";
            trBotBar.Cells.Add(BtnResetDefaults);

            
            trBotBar.Cells.Add(new TableCell(null, true));


            BtnClose = new Button();
            BtnClose.Text = "Close";
            trBotBar.Cells.Add(BtnClose);


            Content = tlMain;
        }
    }
}
