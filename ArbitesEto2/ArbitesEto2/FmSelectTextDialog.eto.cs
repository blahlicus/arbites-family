using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{

    sealed partial class FmSelectTextDialog : Dialog
    {
        TableLayout TLMain;
        void InitializeComponent()
        {
            this.Maximizable = false;


            var scMain = new Scrollable();
            scMain.Border = BorderType.None;

            TLMain = new TableLayout();
            scMain.Content = TLMain;
            TLMain.Padding = 5;
            Content = scMain;
        }

    }
}
