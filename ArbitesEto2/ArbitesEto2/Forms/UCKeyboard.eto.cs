using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class UCKeyboard : Panel
    {
        Button BtnSave, BtnSaveAs, BtnLoad, BtnAddLayer;
        Label LLayoutName;
        StackLayout SLMain;
        void InitializeComponent()
        {

            var tlMain = new TableLayout();
            tlMain.Padding = 5;

            var trTop = new TableRow();
            tlMain.Rows.Add(trTop);

            var slTop = new StackLayout();
            slTop.Spacing = 5;
            slTop.Orientation = Orientation.Horizontal;
            slTop.VerticalContentAlignment = VerticalAlignment.Center;
            trTop.Cells.Add(slTop);


            BtnLoad = new Button();
            BtnLoad.Text = "Load Layout";
            BtnLoad.ToolTip = "Load Layout";
            slTop.Items.Add(BtnLoad);

            BtnSave = new Button();
            BtnSave.Text = "Save Layout*";
            BtnSave.ToolTip = "Save Layout";
            slTop.Items.Add(BtnSave);

            BtnSaveAs = new Button();
            BtnSaveAs.Text = "Save Layout As";
            BtnSaveAs.ToolTip = "Save Layout As";
            slTop.Items.Add(BtnSaveAs);

            BtnAddLayer = new Button();
            BtnAddLayer.Text = "Add Layer";
            BtnAddLayer.ToolTip = "Add Layer";
            slTop.Items.Add(BtnAddLayer);

            LLayoutName = new Label();
            slTop.Items.Add(LLayoutName);

            var trMain = new TableRow();
            tlMain.Rows.Add(trMain);

            var scMain = new Scrollable();
            scMain.Border = BorderType.None;
            trMain.Cells.Add(scMain);

            SLMain = new StackLayout();
            SLMain.Spacing = 5;
            SLMain.Orientation = Orientation.Vertical;
            scMain.Content = SLMain;



            Content = tlMain;
        }
    }
}
