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
            return Directory.GetFiles(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD), "*" + MdConstant.E_INPUT_METHOD).ToList();
        }

        public static void FirstRunCheck()
        {
            bool needsRestore = false;
            try
            {

                var cfg = MdCore.Deserialize<MdConfig>(Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
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
            if (!Directory.Exists(MdPersistentData.ConfigPath))
            {
                Directory.CreateDirectory(MdPersistentData.ConfigPath);
            }
            CreateDefaultConfig();
            CreateDefaultInputMethods();
            CreateDefaultKeyboards();
            CreateDefaultKeygroups();

            MdSessionData.Init();
        }

        public static void CreateDefaultConfig()
        {
            MdCore.Serialize(new MdConfig(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        public static void CreateDefaultKeyboards()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD));
            }

            MdCore.Serialize(ClKeyboard.GenerateDiverge2(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-2-3" + MdConstant.E_KEYBOARD));
            var d2r = ClKeyboard.GenerateDiverge2();
            d2r.Commands[0] = "uniqueksetsubkey";
            d2r.Commands[1] = "uniqueksetkey";
            MdCore.Serialize(d2r, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-2-3-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.Serialize(ClKeyboard.GenerateDivergeTM(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-tm-1-2" + MdConstant.E_KEYBOARD));
            var dtmr = ClKeyboard.GenerateDivergeTM();
            dtmr.Commands[0] = "uniqueksetsubkey";
            dtmr.Commands[1] = "uniqueksetkey";
            MdCore.Serialize(dtmr, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-tm-1-2-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.Serialize(ClKeyboard.GenerateTerminusMini(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "terminus-mini" + MdConstant.E_KEYBOARD));
            MdCore.Serialize(ClKeyboard.GenerateTerminusMini2(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "terminus-mini-2" + MdConstant.E_KEYBOARD));
            MdCore.Serialize(ClKeyboard.GenerateFelix(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "felix" + MdConstant.E_KEYBOARD));
            MdCore.Serialize(ClKeyboard.GenerateTerminus2(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "terminus-2" + MdConstant.E_KEYBOARD));
            var t2mr = ClKeyboard.GenerateTerminus2();
            t2mr.Commands[0] = "uniqueksetsubkey";
            t2mr.Commands[1] = "uniqueksetkey";
            MdCore.Serialize(t2mr, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "terminus-2-rightmaster" + MdConstant.E_KEYBOARD));
        }

        public static void CreateDefaultKeygroups()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP));
            }

            MdCore.Serialize(ClKeyGroup.GenerateDefault(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP));
        }


        public static void CreateDefaultInputMethods()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD));
            }

            MdCore.Serialize(ClDisplayCharacterContainer.GenerateUSASCII()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
                                 , MdConstant.D_INPUT_METHOD,
                                 "US-ANSI" + MdConstant.E_INPUT_METHOD));

            MdCore.Serialize(ClDisplayCharacterContainer.GenerateUKISO()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
                                 , MdConstant.D_INPUT_METHOD,
                                 "UK-QWERTY-BS4822" + MdConstant.E_INPUT_METHOD));


            //Deutsch-QWERTZ-T1
            MdCore.Serialize(ClDisplayCharacterContainer.GenerateDeuQWERTZ()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
                                 , MdConstant.D_INPUT_METHOD,
                                 "Deutsch-QWERTZ-T1" + MdConstant.E_INPUT_METHOD));

            //GenerateSEDKQWERTY
            MdCore.Serialize(ClDisplayCharacterContainer.GenerateSEDKQWERTY()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
                                 , MdConstant.D_INPUT_METHOD,
                                 "Swedish-Danish-QWERTY" + MdConstant.E_INPUT_METHOD));

            //GenerateSwissGerman
            MdCore.Serialize(ClDisplayCharacterContainer.GenerateSwissQWERTZDE()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
                                 , MdConstant.D_INPUT_METHOD,
                                 "Deutsch-QWERTZ-Schweizer" + MdConstant.E_INPUT_METHOD));

            //GenerateSwissFrench
            MdCore.Serialize(ClDisplayCharacterContainer.GenerateSwissQWERTZFR()
                             , Path.Combine(
                                 MdPersistentData.ConfigPath
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
