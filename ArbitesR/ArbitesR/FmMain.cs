using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace ArbitesR
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();

            ClKey.iniList();
            MdGlobals.Initiate();

            /*
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
                        nbs1.keys.Add(clb);

                    }

                }
            }
            nkb.slices.Add(nbs1);


           MdCore.Serialize<ClKeyboard>(nkb, @"C:\Users\blahlicus\Documents\ArbitesR\Keyboards\terminus-mini.uktb");
           //*/




            /*
            MdGlobals.board = new UCBoard(nkb);
            MdGlobals.board.Dock = DockStyle.Fill;
            MdGlobals.board.Location = new Point(30, 30);
            MdGlobals.board.Parent = spcEditLayout.Panel2;
            var dp = new FmRichTextDisplay(nkb.GenerateSerialCommands(MdGlobals.board.layout));
            dp.Show();
            */

        }

        private void DisplayKeyboard(ClKeyboard input)
        {
            spcEditLayout.Panel2.Controls.Clear();
            MdGlobals.boardType = input;
            MdGlobals.board = new UCBoard(input);
            MdGlobals.board.Dock = DockStyle.Fill;
            MdGlobals.board.Location = new Point(30, 30);
            MdGlobals.board.Parent = spcEditLayout.Panel2;
        }
        private void btSelectCom_Click(object sender, EventArgs e)
        {
            var dia =  new FmSelectPortDialog();
            DialogResult dr = dia.ShowDialog();
            if (dr == DialogResult.OK)
            {
                lPort.Text = dia.output;
            }
        }

        private void btSelectDevice_Click(object sender, EventArgs e)
        {
            List<string> files = System.IO.Directory.GetFiles(MdConstants.keyboards, MdConstants.eKeyboards).ToList<string>();
            var dia = new FmSelectTextDialog("Select a Keyboard", "Select your keyboard", files.Select(str => str.Substring(str.LastIndexOf(MdConstants.pseparator)+1)).ToList());
            DialogResult dr = dia.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ClKeyboard output = MdCore.Deserialize<ClKeyboard>(files[dia.index]);
                DisplayKeyboard(output);
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            var sp = new SerialPort();
            sp.PortName = lPort.Text;

            try
            {
                sp.Open();
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show("Arbites failed to detect the selected port\nAre you sure you wish to upload to this port?", "Port Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //do nothing
                }
                else
                {
                    return;
                }
            }
            var output = MdGlobals.boardType.GenerateSerialCommands(MdGlobals.board.layout);
            
            for (int i = 0; i < output.Count; i++ )
            {
                sp.Write(output[i]);
                Thread.Sleep(10);
                int pg = (i * 100)/output.Count;
                if (pg >0 && pg < 101)
                {
                    pbUpload.Value = pg;
                }

            }
            pbUpload.Value = 100;
            MessageBox.Show("Upload completed");
            pbUpload.Value = 0;
            sp.Close();
            /*
            var dp = new FmRichTextDisplay(MdGlobals.boardType.GenerateSerialCommands(MdGlobals.board.layout));
            dp.Show();
            //*/
        }

        private void btKeyMenu_Click(object sender, EventArgs e)
        {
            MdGlobals.kselect.Show();
        }


    }
}
