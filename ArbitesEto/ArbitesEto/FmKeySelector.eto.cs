using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmKeySelector : Form
    {
        void InitializeComponent()
        {
            Title = "My Form";

            Content = new Label { Text = "Some Content" };
        }
    }
}
