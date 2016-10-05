using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class UCBoard : Panel
    {
        Label LName;
        Button BtnSave, BtnLoad, BtnAddLayer;
        StackLayout SLMain;
        Scrollable SCMain;
        void InitializeComponent()
        {
            

            var TLMain = new TableLayout();
            var SLTop = new StackLayout();
            SLTop.Orientation = Orientation.Horizontal;
            SLTop.VerticalContentAlignment = VerticalAlignment.Center;
            SLTop.Padding = 5;
            SLTop.Spacing = 5;
            TLMain.Rows.Add(SLTop);

            LName = new Label();
            LName.Text = "Keyboard Type: NA";
            SLTop.Items.Add(LName);

            BtnAddLayer = new Button();
            BtnAddLayer.Text = "Add New Layer";
            SLTop.Items.Add(BtnAddLayer);

            BtnSave = new Button();
            BtnSave.Text = "Save Layout";
            SLTop.Items.Add(BtnSave);

            BtnLoad = new Button();
            BtnLoad.Text = "Load Layout";
            SLTop.Items.Add(BtnLoad);
            Content = new Label { Text = "Some Content" };

            SCMain = new Scrollable();
            SCMain.Border = BorderType.None;
            TLMain.Rows.Add(SCMain);

            SLMain = new StackLayout();
            SLMain.Orientation = Orientation.Horizontal;
            SCMain.Content = SLMain;

            Content = TLMain;
        }
    }
}
