using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    partial class FmKeyMenu : Form
    {
        
        TabControl TCMain;
        void InitializeComponent()
        {
            TCMain = new TabControl();
            Title = "Key Menu - Select a key from the menu below";

            Content = TCMain;
        }
    }
}
