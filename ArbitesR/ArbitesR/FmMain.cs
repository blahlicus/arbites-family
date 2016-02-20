using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitesR
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();

            var nkb = new ClKeyboard();
            nkb.keyboardName = "test board name";
            nkb.layers = 3;

            var nbs1 = new ClBoardSlice("testcommand", "testname1", 0, nkb.layers);
            nbs1.keys.Add(new ClButton(0, 0, 72, 72, 3, 22));
            nbs1.keys.Add(new ClButton(0, 0, 72, 72, 3, 22 + 76));
            nbs1.keys.Add(new ClButton(0, 0, 72, 72, 3, 22 + 76 + 76));
            var nbs2 = new ClBoardSlice("testcommand", "testname2", 1, nkb.layers);
            nbs2.keys.Add(new ClButton(0, 0, 72, 72, 3, 22));
            nbs2.keys.Add(new ClButton(0, 0, 72, 72, 3 + 76, 22 + 76));
            nbs2.keys.Add(new ClButton(0, 0, 72, 72, 3 + 76 + 76, 22 + 76 + 76));
            nkb.slices.Add(nbs1);
            nkb.slices.Add(nbs2);
            var board = new UCBoard(nkb);
            board.Dock = DockStyle.Fill;
            board.Location = new Point(30, 30);
            board.Parent = tabPage1;

        }

    }
}
