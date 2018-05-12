using System.IO;
using System.IO.Ports;
using Eto.Drawing;

namespace ArbitesEto2
{
    public class MdSessionData
    {
        public static ClLayoutContainer CurrentLayout;
        public static ClKeyboard CurrentKeyboardType;
        public static UCKeyboard CurrentKeyboardUI;
        public static ClDisplayCharacterContainer CurrentInputMethod;
        public static bool SelectedFromKeyMenu = false;
        public static bool OpenedMacroEdit = false;
        public static bool OpenedTapDanceEdit = false;
        public static ClKey KeyMenuKey;
        public static ClKeyGroup KeyGroup;
        public static SerialPort SP;
        public static FmKeyMenu KeyMenu;
        public static Icon WindowIcon;

        public static void Init()
        {
            MdConfig.Init();
            CurrentKeyboardType = new ClKeyboard();
            CurrentLayout = new ClLayoutContainer();
            CurrentKeyboardUI = new UCKeyboard();
            KeyMenuKey = new ClKey();
            CurrentInputMethod = new ClDisplayCharacterContainer();
            KeyGroup = new ClKeyGroup();
            SP = new SerialPort();

            if (File.Exists("favicon.ico"))
            {
                WindowIcon = new Icon(Path.Combine(MdConstant.root, MdConstant.N_ICON));
            }

            CurrentInputMethod = MdConfig.Main.GetCurrentInputMethod();
            KeyGroup = MdCore.Deserialize<ClKeyGroup>(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP));
        }
    }
}
