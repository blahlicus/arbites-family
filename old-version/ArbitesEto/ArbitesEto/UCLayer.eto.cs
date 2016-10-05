using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class UCLayer : Panel
    {
        StackLayout SLTop;
        TableLayout TLMain;
        PixelLayout PLMain;
        Label LName;
        CheckBox CBAllLayers;
        Button BtnDeleteLayer;
        void InitializeComponent()
        {
            TLMain = new TableLayout();

            SLTop = new StackLayout();
            SLTop.Orientation = Orientation.Horizontal;
            SLTop.VerticalContentAlignment = VerticalAlignment.Center;
            SLTop.Padding = 5;
            SLTop.Spacing = 5;
            TLMain.Rows.Add(SLTop);


            LName = new Label();
            LName.Text = "Layer N";
            SLTop.Items.Add(LName);

            CBAllLayers = new CheckBox();
            CBAllLayers.Text = "Apply to all layers";
            SLTop.Items.Add(CBAllLayers);


            BtnDeleteLayer = new Button();
            BtnDeleteLayer.Text = "Delete Layer";
            SLTop.Items.Add(BtnDeleteLayer);


            PLMain = new PixelLayout();
            TLMain.Rows.Add(PLMain);


            Content = TLMain;
        }
    }
}
