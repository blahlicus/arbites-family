using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class UCSlice : Panel
    {

        Label LName;
        StackLayout SLMain;
        void InitializeComponent()
        {
            var tb = new TableLayout();

            LName = new Label();
            LName.Text = "Slice N";
            tb.Rows.Add(LName);


            SLMain = new StackLayout();
            SLMain.Orientation = Orientation.Vertical;
            SLMain.Spacing = 15;
            tb.Rows.Add(SLMain);
            

            Content = tb;
        }
    }
}
