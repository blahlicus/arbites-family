using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmLayoutUploader : Dialog
    {
        Label LStatus;
        ProgressBar PBMain;
        void InitializeComponent()
        {
            Title = "Uploading Layout";


            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trStatus = new TableRow();
            tlMain.Rows.Add(trStatus);

            LStatus = new Label();
            LStatus.Text = "Status: Starting Upload";
            trStatus.Cells.Add(LStatus);

            var trPB = new TableRow();
            tlMain.Rows.Add(trPB);
            
            PBMain = new ProgressBar();
            PBMain.Width = 400;
            trPB.Cells.Add(PBMain);

            

            Content = tlMain;

            this.Resizable = false;
            this.Topmost = true;
        }
    }
}
