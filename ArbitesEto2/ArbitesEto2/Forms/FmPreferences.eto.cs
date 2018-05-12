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
        Button BtnResetDefaults, BtnClose, BtnAddKeyboard, BtnAddLanguage, BtnAddKeyGroup;


        void InitializeComponent()
        {
            
            Title = "Preferences";
            this.Size = new Size(330, 240);
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
            trKeyMenuTop.Cells.Add(new TableCell(lKeyMenuTop, true));

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

            var trAddKeyboard = new TableRow();
            tlTop.Rows.Add(trAddKeyboard);

            var lAddKeyboard = new Label();
            lAddKeyboard.Text = "Add Keyboard Type";
            trAddKeyboard.Cells.Add(lAddKeyboard);

            BtnAddKeyboard = new Button();
            BtnAddKeyboard.Text = "Browse";
            BtnAddKeyboard.ToolTip = "Browse an Arbites keyboard file to add a keyboard type.";
            trAddKeyboard.Cells.Add(BtnAddKeyboard);


            var trAddLanguage = new TableRow();
            tlTop.Rows.Add(trAddLanguage);

            var lAddLanguage = new Label();
            lAddLanguage.Text = "Add Input Method";
            trAddLanguage.Cells.Add(lAddLanguage);

            BtnAddLanguage = new Button();
            BtnAddLanguage.Text = "Browse";
            BtnAddLanguage.ToolTip = "Browse an Arbites input method file to add an input method.";
            trAddLanguage.Cells.Add(BtnAddLanguage);


            var trAddKeyGroup = new TableRow();
            tlTop.Rows.Add(trAddKeyGroup);

            var lAddKeyGroup = new Label();
            lAddKeyGroup.Text = "Update Keygroup Definition";
            trAddKeyGroup.Cells.Add(lAddKeyGroup);

            BtnAddKeyGroup = new Button();
            BtnAddKeyGroup.Text = "Browse";
            BtnAddKeyGroup.ToolTip = "Browse an Arbites keygroup file to update your key definitions.";
            trAddKeyGroup.Cells.Add(BtnAddKeyGroup);

            var trTopBotSpacer = new TableRow();
            trTopBotSpacer.ScaleHeight = true;
            tlMain.Rows.Add(trTopBotSpacer);

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
