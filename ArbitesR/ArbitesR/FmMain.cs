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

            ClKey.iniList();
            MdGlobals.Initiate();

            //*
            var nkb = new ClKeyboard();
            nkb.keyboardName = "Diverge II";
            nkb.keyboardType = "Diverge II";
            nkb.fileFormat = "ukd2";
            nkb.layers = 3;

            var nbs1 = new ClBoardSlice("uniqueksetkey", "Left Side", 0, nkb.layers);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 7 && j != 4)
                    {
                        // do nothing
                    }
                    else
                    {
                        var clb = new ClButton(i, j, 72, 72, 5 + (72 * i), 30 + (72 * j));
                        nbs1.keys.Add(clb);
                        
                    }

                }
            }
            nkb.slices.Add(nbs1);


            var nbs2 = new ClBoardSlice("uniqueksetsubkey", "Right Side", 1, nkb.layers);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 7 && j != 4)
                    {
                        // do nothing
                    }
                    else
                    {

                        var clb = new ClButton(i, j, 72, 72, 509 - (72 * i), 30 + (72 * j));
                        nbs2.keys.Add(clb);
                    }

                }
            }
            nkb.slices.Add(nbs2);

            MdCore.Serialize<ClKeyboard>(nkb, @"C:\Users\blahlicus\Documents\ArbitesR\Keyboards\diverge-ii.uktb");
            //*/




            /*
            var nkb = new ClKeyboard();
            nkb.keyboardName = "Diverge TM";
            nkb.keyboardType = "Diverge TM";
            nkb.fileFormat = "ukdtm";
            nkb.layers = 3;

            var nbs1 = new ClBoardSlice("uniqueksetkey", "Left Side", 0, nkb.layers);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 5 && j == 3)
                    {
                        // do nothing
                    }
                    else
                    {
                        var clb = new ClButton(i, j, 72, 72, 5 + (72 * i), 30 + (72 * j));
                        for (int k = 0; k < nkb.layers; k++)
                        {
                            var cky = new ClKey();
                            clb.keys.Add(cky);
                        }
                        if (i == 4 && j == 3)
                        {
                            clb.gw = clb.gw * 2;
                        }
                        nbs1.keys.Add(clb);

                    }

                }
            }
            nkb.slices.Add(nbs1);


            var nbs2 = new ClBoardSlice("uniqueksetsubkey", "Right Side", 1, nkb.layers);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 5 && j == 3)
                    {
                        // do nothing
                    }
                    else
                    {

                        var clb = new ClButton(i, j, 72, 72, 365 - (72 * i), 30 + (72 * j));
                        for (int k = 0; k < nkb.layers; k++)
                        {
                            var cky = new ClKey();
                            clb.keys.Add(cky);
                        }
                        if (i == 4 && j == 3)
                        {
                            clb.gx = clb.gx - 72;
                            clb.gw = clb.gw * 2;
                        }
                        nbs2.keys.Add(clb);
                    }

                }
            }
            nkb.slices.Add(nbs2);

            MdCore.Serialize<ClKeyboard>(nkb, @"C:\Users\blahlicus\Documents\ArbitesR\Keyboards\diverge-tm.uktb");
            //*/







            /*
            var nkb = new ClKeyboard();
            nkb.keyboardName = "Terminus Mini";
            nkb.keyboardType = "Terminus Mini";
            nkb.fileFormat = "uktm";
            nkb.layers = 3;

            var nbs1 = new ClBoardSlice("uniqueksetkey", "", 0, nkb.layers);
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((i == 5 || i == 7) && j == 3)
                    {
                        // do nothing
                    }
                    else
                    {
                        var clb = new ClButton(i, j, 72, 72, 5 + (72 * i), 30 + (72 * j));
                        for (int k = 0; k < nkb.layers; k++)
                        {
                            var cky = new ClKey();
                            clb.keys.Add(cky);
                        }

                        if ((i == 4 || i == 6) && j == 3)
                        {
                            clb.gw = clb.gw * 2;
                            
                        }
                        nbs1.keys.Add(clb);

                    }

                }
            }
            nkb.slices.Add(nbs1);


           MdCore.Serialize<ClKeyboard>(nkb, @"C:\Users\blahlicus\Documents\ArbitesR\Keyboards\terminus-mini.uktb");
           //*/





            MdGlobals.board = new UCBoard(nkb);
            MdGlobals.board.Dock = DockStyle.Fill;
            MdGlobals.board.Location = new Point(30, 30);
            MdGlobals.board.Parent = tabPage1;
            var dp = new FmRichTextDisplay(nkb.GenerateSerialCommands(MdGlobals.board.layout));
            dp.Show();

        }


    }
}
