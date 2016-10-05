using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class UCLayer : Panel
    {
        PixelLayout PLMain;
        Label LTitle;
        Button BtnDelete;
        CheckBox CBAllLayers;
        void InitializeComponent()
        {
            
            var tlMain = new TableLayout();
            Padding = 5;

            var trTop = new TableRow();
            tlMain.Rows.Add(trTop);

            var tcTop = new TableCell();
            trTop.Cells.Add(tcTop);

            var tlTop = new TableLayout();
            tcTop.Control = tlTop;

            var trTopBar = new TableRow();
            tlTop.Rows.Add(trTopBar);

            LTitle = new Label();
            LTitle.VerticalAlignment = VerticalAlignment.Center;
            LTitle.Text = "Layer X";
            trTopBar.Cells.Add(LTitle);

            BtnDelete = new Button();
            BtnDelete.Text = "Delete Layer";
            BtnDelete.ToolTip = "Delete Layer";
            trTopBar.Cells.Add(BtnDelete);

            var tcSpacer = new TableCell();
            tcSpacer.ScaleWidth = true;
            trTopBar.Cells.Add(tcSpacer);

            CBAllLayers = new CheckBox();
            CBAllLayers.Text = "Apply to all layers";
            trTopBar.Cells.Add(new TableCell(CBAllLayers, false));

            var trMain = new TableRow();
            tlMain.Rows.Add(trMain);

            PLMain = new PixelLayout();
            trMain.Cells.Add(PLMain);

            Content = tlMain;
        }
    }
}
