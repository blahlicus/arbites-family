using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class ClKeyboard
    {
        public string Name { get; set; }
        public int MaxLayers { get; set; }
        public List<ClButtonInfo> Buttons { get; set; }
        public List<string> Commands { get; set; }
        public string SaveFileExtension { get; set; }

        public ClKeyboard()
        {
            this.Name = "Unnamed Keyboard";
            this.Buttons = new List<ClButtonInfo>();
            this.Commands = new List<string>();
            this.SaveFileExtension = "uk2kl";
            this.MaxLayers = 3;

        }

        public ClKeyboard(ClKeyboard input)
        {
            this.Name = input.Name;
            this.Buttons = new List<ClButtonInfo>();
            foreach(ClButtonInfo btn in input.Buttons)
            {
                this.Buttons.Add(new ClButtonInfo(btn));
            }
            this.Commands = new List<string>();
            foreach(string str in input.Commands)
            {
                this.Commands.Add(str);
            }
            this.MaxLayers = input.MaxLayers;
            this.SaveFileExtension = input.SaveFileExtension;
        }

        public ClLayoutContainer GenerateLayout()
        {
            var newLay = new ClLayoutContainer();
            foreach(ClButtonInfo bi in this.Buttons)
            {
                var kd = new ClKeyData();
                kd.X = bi.X;
                kd.Y = bi.Y;
                kd.Z = 0;
                kd.Command = bi.Command;
                kd.Key = new ClKey();
                newLay.KeyDatas.Add(kd);
            }

            return newLay;
        }


        public static ClKeyboard GenerateDiverge2()
        {
            var kb = new ClKeyboard();
            kb.MaxLayers = 8;
            kb.Name = "Diverge 2 and 3";
            kb.SaveFileExtension = "arb2d2";
            kb.Commands.Add("uniqueksetkey");
            kb.Commands.Add("uniqueksetsubkey");

            // buttons
            for (int i = 0; i < 8; i++ )
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int s = 0; s < 2; s++)
                    {
                        if (i != 7 || j == 4)
                        {

                            var bi = new ClButtonInfo();
                            bi.X = i;
                            bi.Y = j;
                            bi.Command = s;
                            bi.GW = 72;
                            bi.GH = 72;
                            if (s == 0)
                            {
                                bi.GX = 5 + i * 77;
                            }
                            else
                            {

                                bi.GX = (s * 1242) - (5 + i * 77);
                            }
                            bi.GY = 5 + j * 77;
                            kb.Buttons.Add(bi);
                        }
                    }
                }
            }
            return kb;
        }

        public static ClKeyboard GenerateDivergeTM()
        {
            var kb = new ClKeyboard();
            kb.MaxLayers = 13;
            kb.Name = "Diverge TM 1 and 2";
            kb.SaveFileExtension = "arb2dtm";
            kb.Commands.Add("uniqueksetkey");
            kb.Commands.Add("uniqueksetsubkey");

            // buttons
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int s = 0; s < 2; s++)
                    {
                        if (i == 5 && j == 3)
                        {
                            //do nothing
                        }
                        else
                        {

                            var bi = new ClButtonInfo();
                            bi.X = i;
                            bi.Y = j;
                            bi.Command = s;
                            bi.GW = 72;
                            bi.GH = 72;


                            if (s == 0)
                            {
                                bi.GX = 5 + i * 77;
                            }
                            else
                            {

                                bi.GX = (s * 935) - (5 + i * 77);
                            }
                            if (i == 4 && j == 3)
                            {
                                bi.GW = 149;
                                if (s == 1)
                                {
                                    bi.GX = bi.GX - 77;
                                }
                            }
                            bi.GY = 5 + j * 77;
                            kb.Buttons.Add(bi);
                        }
                    }
                }
            }
            return kb;
        }


        public static ClKeyboard GenerateTerminusMini()
        {
            var kb = new ClKeyboard();
            kb.MaxLayers = 6;
            kb.Name = "Terminus Mini";
            kb.SaveFileExtension = "arb2tm";
            kb.Commands.Add("uniqueksetkey");

            // buttons
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((i == 5 && j == 3) || (i == 7 && j == 3))
                    {
                        //do nothing
                    }
                    else
                    {

                        var bi = new ClButtonInfo();
                        bi.X = i;
                        bi.Y = j;
                        bi.Command = 0;
                        bi.GW = 72;
                        bi.GH = 72;


                            bi.GX = 5 + i * 77;
                        if ((i == 4 && j == 3) || (i == 6 && j == 3))
                        {
                            bi.GW = 149;
                        }
                        bi.GY = 5 + j * 77;
                        kb.Buttons.Add(bi);
                    }
                }
            }
            return kb;
        }




        public static ClKeyboard GenerateFelix()
        {
            var kb = new ClKeyboard();
            kb.MaxLayers = 15;
            kb.Name = "Felix";
            kb.SaveFileExtension = "arb2f";
            kb.Commands.Add("uniqueksetkey");

            // buttons
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {


                    var bi = new ClButtonInfo();
                    bi.X = i;
                    bi.Y = j;
                    bi.Command = 0;
                    bi.GW = 72;
                    bi.GH = 72;


                    bi.GX = 5 + i * 77;
                    bi.GY = 5 + j * 77;
                    kb.Buttons.Add(bi);
                    
                }
            }
            return kb;
        }
    }
}
