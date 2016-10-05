using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmRichTextDisplay : Form
    {
        RichTextArea RTAMain;
        void InitializeComponent()
        {
            var scMain = new Scrollable();
            scMain.Border = BorderType.None;

            RTAMain = new RichTextArea();
            scMain.Content = RTAMain;

            this.Size = new Size(400, 400);

            Content = scMain;
        }
    }
}
