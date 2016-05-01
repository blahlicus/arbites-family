using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmSelectTextDialog : Dialog
    {
        StackLayout SLMain;

        Label LDesc;

        void InitializeComponent()
        {

            Title = "Default Title";
            Resizable = false;
            ClientSize = new Size(230, 290);

            var spLayout = new TableLayout();

            var topLayout = new StackLayout();
            topLayout.Orientation = Orientation.Vertical;
            topLayout.Padding = 5;
            topLayout.Spacing = 5;
            spLayout.Rows.Add(new TableRow(topLayout));

            SLMain = new StackLayout();
            SLMain.Orientation = Orientation.Vertical;
            SLMain.HorizontalContentAlignment = HorizontalAlignment.Center;
            SLMain.Padding = 5;
            SLMain.Spacing = 5;

            var scrBot = new Scrollable();
            scrBot.Content = SLMain;
            scrBot.Border = BorderType.None;


            spLayout.Rows.Add(new TableRow(scrBot));

            LDesc = new Label();
            LDesc.Text = "Default Description";
            topLayout.Items.Add(LDesc);






            Content = spLayout;
        }
    }
}
