using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Eto.Forms;

namespace ArbitesEto2
{
    public class MdMetaUtil
    {
        public static List<string> GetListOfInputMethods()
        {
            return Directory.GetFiles(Path.Combine(MdConstant.Root, MdConstant.D_INPUT_METHOD), "*" + MdConstant.E_INPUT_METHOD).ToList();
        }

        public static void FirstRunCheck()
        {
            bool needsRestore = false;
            try
            {
                var cfg = MdCore.DeserializeFromPath<MdConfig>(Path.Combine(MdConstant.Root, MdConstant.N_CONFIG));
                if (cfg.ConfigVersion != MdConfig.SoftwareVersion)
                {
                    needsRestore = true;
                }
            }
            catch
            {
                needsRestore = true;
            }

            if (needsRestore)
            {
                ResetDefaults();
            }
        }

        public static void ResetDefaults()
        {
            if (!Directory.Exists(MdConstant.Root))
            {
                Directory.CreateDirectory(MdConstant.Root);
            }
            CreateDefaultConfig();
            CreateDefaultInputMethods();
            CreateDefaultKeyboards();
            CreateDefaultKeygroups();

            MdSessionData.Init();
        }

        public static void CreateDefaultConfig()
        {
            MdCore.SerializeToPath(new MdConfig(), Path.Combine(MdConstant.Root, MdConstant.N_CONFIG));
        }

        public static void CreateDefaultKeyboards()
        {
            if (!Directory.Exists(Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD)))
            {
                Directory.CreateDirectory(Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD));
            }

            MdCore.SerializeToPath(Keyboard.GenerateDiverge1(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "diverge-1" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateDiverge2(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "diverge-2-3" + MdConstant.E_KEYBOARD));
            var d2r = Keyboard.GenerateDiverge2();
            d2r.Name = "Diverge 2 3 Right Master";
            d2r.Commands[0] = "uniqueksetsubkey";
            d2r.Commands[1] = "uniqueksetkey";
            MdCore.SerializeToPath(d2r, Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "diverge-2-3-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateDivergeTM(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "diverge-tm-1-2" + MdConstant.E_KEYBOARD));
            var dtmr = Keyboard.GenerateDivergeTM();
            dtmr.Name = "Diverge TM 1 2 Right Master";
            dtmr.Commands[0] = "uniqueksetsubkey";
            dtmr.Commands[1] = "uniqueksetkey";
            MdCore.SerializeToPath(dtmr, Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "diverge-tm-1-2-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateTerminusMini(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "terminus-mini" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateTerminusMini2(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "terminus-mini-2" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateFelix(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "felix" + MdConstant.E_KEYBOARD));
            MdCore.SerializeToPath(Keyboard.GenerateTerminus2(), Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "terminus-2" + MdConstant.E_KEYBOARD));
            var t2mr = Keyboard.GenerateTerminus2();
            t2mr.Name = "Terminus 2 Right Master";
            t2mr.Commands[0] = "uniqueksetsubkey"; 
            t2mr.Commands[1] = "uniqueksetkey";
            MdCore.SerializeToPath(t2mr, Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD, "terminus-2-rightmaster" + MdConstant.E_KEYBOARD));
        }

        public static void CreateDefaultKeygroups()
        {
            if (!Directory.Exists(Path.Combine(MdConstant.Root, MdConstant.D_KEYGROUP)))
            {
                Directory.CreateDirectory(Path.Combine(MdConstant.Root, MdConstant.D_KEYGROUP));
            }

            MdCore.SerializeToPath(KeyGroup.GenerateDefault(), Path.Combine(MdConstant.Root, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP));
        }

        public static void CreateDefaultInputMethods()
        {
            if (!Directory.Exists(Path.Combine(MdConstant.Root, MdConstant.D_INPUT_METHOD)))
            {
                Directory.CreateDirectory(Path.Combine(MdConstant.Root, MdConstant.D_INPUT_METHOD));
            }

            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateUSASCII()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "US-ANSI" + MdConstant.E_INPUT_METHOD));

            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateUKISO()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "UK-QWERTY-BS4822" + MdConstant.E_INPUT_METHOD));

            //Deutsch-QWERTZ-T1
            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateDeuQWERTZ()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "Deutsch-QWERTZ-T1" + MdConstant.E_INPUT_METHOD));

            //GenerateSEDKQWERTY
            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateSEDKQWERTY()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "Swedish-Danish-QWERTY" + MdConstant.E_INPUT_METHOD));

            //GenerateSwissGerman
            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateSwissQWERTZDE()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "Deutsch-QWERTZ-Schweizer" + MdConstant.E_INPUT_METHOD));

            //GenerateSwissFrench
            MdCore.SerializeToPath(DisplayCharacterContainer.GenerateSwissQWERTZFR()
                             , Path.Combine(
                                 MdConstant.Root
                                 , MdConstant.D_INPUT_METHOD,
                                 "Français-QWERTZ-Suisse" + MdConstant.E_INPUT_METHOD));
        }

        public static void ReloadInputMethodUI()
        {
            if (MdSessionData.CurrentKeyboardUI != null)
            {
                if (MdSessionData.CurrentKeyboardUI.Layers != null)
                {
                    MdSessionData.CurrentKeyboardUI.LoadLayout(MdSessionData.CurrentLayout);
                }
            }
            if (MdSessionData.KeyMenu != null)
            {
                if (MdSessionData.KeyMenu.Loaded)
                {
                    MdSessionData.KeyMenu.ReloadInputMethod();
                }
            }
        }
    }
}
