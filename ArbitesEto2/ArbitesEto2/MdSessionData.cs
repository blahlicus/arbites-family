using System.IO;
using System.IO.Ports;
using Eto.Drawing;

namespace ArbitesEto2
{
    public class MdSessionData
    {
        public static LayoutContainer CurrentLayout;
        public static Keyboard CurrentKeyboardType;
        public static UCKeyboard CurrentKeyboardUI;
        public static DisplayCharacterContainer CurrentInputMethod;
        public static bool SelectedFromKeyMenu = false;
        public static bool OpenedMacroEdit = false;
        public static bool OpenedTapDanceEdit = false;
        public static Key KeyMenuKey;
        public static KeyGroup KeyGroup;
        public static SerialPort SP;
        public static FmKeyMenu KeyMenu;
        public static Icon WindowIcon;

        public static void Init()
        {
            MdConfig.Init();
            CurrentKeyboardType = new Keyboard();
            CurrentLayout = new LayoutContainer();
            CurrentKeyboardUI = new UCKeyboard();
            KeyMenuKey = new Key();
            CurrentInputMethod = new DisplayCharacterContainer();
            KeyGroup = new KeyGroup();
            SP = new SerialPort();

            if (File.Exists("favicon.ico"))
            {
                WindowIcon = new Icon(Path.Combine(MdConstant.Root, MdConstant.N_ICON));
            }

            CurrentInputMethod = MdConfig.Main.GetCurrentInputMethod();
            KeyGroup = MdCore.Deserialize<KeyGroup>(Path.Combine(MdConstant.Root, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP));
        }
    }
}
