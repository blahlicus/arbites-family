using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class FmMain
    {
        public FmMain()
        {
            InitializeComponent();

            MdPersistentData.Init();
            MdMetaUtil.FirstRunCheck();

            MdSessionData.Init();
            EventHook();
            PostInitGUI();
        }

        private void PostInitGUI()
        {
            DDInputMethod.Items.Clear();
            var inputMethods = MdMetaUtil.GetListOfInputMethods();
            Icon = MdSessionData.WindowIcon;

            for (int i = 0; i < inputMethods.Count; i++)
            {
                var item = Path.GetFileNameWithoutExtension(inputMethods[i]);
                DDInputMethod.Items.Add(item);

                if (item + MdConstant.E_INPUT_METHOD == MdConfig.Main.CurrentInputMethod)
                {
                    DDInputMethod.SelectedIndex = i;
                }
            }
            MdSessionData.KeyMenu = new FmKeyMenu();


        }

        private void EventHook()
        {
            DDInputMethod.SelectedIndexChanged += (sender, e) => ChangeInputMethod();
            BtnOpenKeyMenu.Click += (sender, e) => OpenKeyMenu();
            BtnSelectDevice.Click += (sender, e) => SelectDevice();
            BtnSelectPort.Click += (sender, e) => LoadPortList();
            BtnApply.Click += (sender, e) => Upload();
            BtnSettings.Click += (sender, e) => OpenSettings();
            BtnEditMacro.Click += (sender, e) => OpenMacroMenu();

        }


        private void OpenMacroMenu()
        {
            var lst = new List<string>{ "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"};
            var fm = new FmSelectTextDialog(lst, lst.Select(ele => ele = "macro" + ele).ToList(), "Select a macro key to edit");
            fm.ShowModal();
            var outputInd = fm.OutputIndex;

            if (outputInd >= 0)
            {
                if (!MdSessionData.OpenedMacroEdit)
                {
                    if (MdSessionData.CurrentLayout.KeyDatas.Count == 0)
                    {
                        MessageBox.Show("Error: You must first select a device");
                    }
                    else
                    {
                        MdSessionData.OpenedMacroEdit = true;
                        var lay = MdSessionData.CurrentLayout;
                        var dataCont = new ClMacroDataContainer();
                        var hasData = false;
                        foreach(ClAdditionalData ele in lay.AddonDatas)
                        {
                            if (ele.GetType() == ClMacroDataContainer.DATA_TYPE)
                            {
                                hasData = true;
                                dataCont = ele as ClMacroDataContainer;
                            }
                        }

                        if (!hasData)
                        {
                            lay.AddonDatas.Add(dataCont); 
                        }

                        var data = new ClMacroData();
                        data.Index = outputInd;
                        hasData = false;
                        foreach(ClMacroData ele in dataCont.MacroKeys)
                        {
                            if (ele.Index == outputInd)
                            {
                                hasData = true;
                                data = ele;
                            }
                        }

                        if (!hasData)
                        {
                            dataCont.MacroKeys.Add(data);
                        }


                        var mdialog = new FmMacroEdit(new ClMacroData(data));
                        mdialog.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Macro editor already opened");
                }
            }
        }

        private void OpenSettings()
        {
            var dg = new FmPreferences();
            dg.ShowModal();
        }

        private void Upload()
        {
            MdSessionData.SP = new SerialPort();
            MdSessionData.SP.PortName = BtnSelectPort.Text.Substring(6);

            try
            {
                MdSessionData.SP.Open();
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
            if (MdSessionData.CurrentLayout.KeyDatas.Count == 0)
            {
                MessageBox.Show("You must first select your device type by pressing the \"Select Device\" button.");
            }
            else
            {
                var upl = new FmLayoutUploader(MdSessionData.CurrentLayout.GenerateCommand(MdSessionData.CurrentKeyboardType));
                upl.ShowModal();

            }
        }

        private void SelectDevice()
        {
            var lst = Directory.GetFiles(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD), "*" + MdConstant.E_KEYBOARD).ToList();
            var fm = new FmSelectTextDialog(lst, lst.Select(ele => ele = Path.GetFileNameWithoutExtension(ele)).ToList(), "Select a device");
            fm.ShowModal();
            var outputInd = fm.OutputIndex;

            if (outputInd >= 0)
            {
                var kb = MdCore.Deserialize<ClKeyboard>(fm.OutputValues[outputInd]);
                MdSessionData.CurrentKeyboardType = kb;
                MdSessionData.CurrentLayout = kb.GenerateLayout();
                var ucl = new UCKeyboard(MdSessionData.CurrentKeyboardType, MdSessionData.CurrentLayout);
                MdSessionData.CurrentKeyboardUI = ucl;
                PnMain.Content = ucl;
                BtnSelectDevice.Text = "Device: " + kb.Name;
            }
        }

        private void OpenKeyMenu()
        {
            if (MdSessionData.KeyMenu.Loaded)
            {
                MdSessionData.KeyMenu.Focus();
                MdSessionData.KeyMenu.ReloadInputMethod();
            }
            else
            {
                MdSessionData.KeyMenu = new FmKeyMenu();
                MdSessionData.KeyMenu.Show();
            }
        }

        private void ChangeInputMethod()
        {
            MdConfig.Main.CurrentInputMethod = DDInputMethod.SelectedKey + MdConstant.E_INPUT_METHOD;
            MdSessionData.CurrentInputMethod = MdConfig.Main.GetCurrentInputMethod();
            MdMetaUtil.ReloadInputMethodUI();

            MdCore.Serialize<MdConfig>(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        public void LoadPortList()
        {


            // POSIX specific
            List<string> ports = new List<string>();
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                try
                {

                    if (Directory.Exists(@"/dev/serial/by-id"))
                    {
                        // probably is unix
                        var psi = new Process();
                        psi.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        psi.EnableRaisingEvents = false;
                        psi.StartInfo.UseShellExecute = false;
                        psi.StartInfo.RedirectStandardOutput = true;
                        psi.StartInfo.FileName = @"sh";
                        psi.StartInfo.Arguments = @"-c 'for s in /dev/serial/by-path/*; do readlink -f $s; done'";

                        psi.Start();
                        psi.WaitForExit();
                        ports = psi.StandardOutput.ReadToEnd().Split('\n').ToList();
                        ports.RemoveAt(ports.Count - 1);


                    }
                    else
                    {
                        // probably is mac

                        var psi = new Process();
                        psi.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        psi.EnableRaisingEvents = false;
                        psi.StartInfo.UseShellExecute = false;
                        psi.StartInfo.RedirectStandardOutput = true;
                        psi.StartInfo.FileName = @"sh";
                        psi.StartInfo.Arguments = @"-c 'ls /dev/tty.*'";

                        psi.Start();
                        psi.WaitForExit();
                        ports = psi.StandardOutput.ReadToEnd().Split('\n').ToList();
                        ports.RemoveAt(ports.Count - 1);


                    }
                }
                catch (Exception e)
                {
                    ports = SerialPort.GetPortNames().ToList();
                }
            }
            else
            {

                ports = SerialPort.GetPortNames().ToList();
            }
            FmSelectTextDialog dialog = new FmSelectTextDialog(ports, ports, "Select your port");
            dialog.ShowModal();
            if (dialog.OutputIndex >= 0)
            {
                BtnSelectPort.Text = "Port: " + dialog.OutputKeys[dialog.OutputIndex];
            }


        }


        public void test()
        {


            MdCore.Serialize<MdPersistentData>(new MdPersistentData(), MdConstant.N_PERSISTENT_DATA);



            MdMetaUtil.ResetDefaults();



        }
    }
}