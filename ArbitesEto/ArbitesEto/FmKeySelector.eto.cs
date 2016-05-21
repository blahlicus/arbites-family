using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    partial class FmKeySelector : Form
    {
        TabControl TCMain;

        void InitializeComponent()
        {
            Title = "Key Selector";
            ClientSize = new Size(610, 515);
            Resizable = false;
            TCMain = new TabControl();
            this.Topmost = true;


            Content = TCMain;
        }
    }
}
