using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using Eto.Forms;

namespace ArbitesEto2
{
    public partial class FmMain
    {
        public FmMain()
        {
            InitializeComponent();

            MdMetaUtil.FirstRunCheck();

            MdSessionData.Init();
            EventHook();
            PostInitGUI();
        }

        private void PostInitGUI()
        {
            this.DDInputMethod.Items.Clear();
            var inputMethods = MdMetaUtil.GetListOfInputMethods();
            // this.Icon = MdSessionData.WindowIcon;

            for (var i = 0; i < inputMethods.Count; i++)
            {
                var item = Path.GetFileNameWithoutExtension(inputMethods[i]);
                this.DDInputMethod.Items.Add(item);

                if (item + MdConstant.E_INPUT_METHOD == MdConfig.Main.CurrentInputMethod)
                {
                    this.DDInputMethod.SelectedIndex = i;
                }
            }
            MdSessionData.KeyMenu = new FmKeyMenu();
        }

        private void EventHook()
        {
            this.DDInputMethod.SelectedIndexChanged += (sender, e) => ChangeInputMethod();
            this.BtnOpenKeyMenu.Click += (sender, e) => OpenKeyMenu();
            this.BtnSelectDevice.Click += (sender, e) => SelectDevice();
            this.BtnSelectPort.Click += (sender, e) => LoadPortList();
            this.BtnApply.Click += (sender, e) => Upload();
            this.BtnSettings.Click += (sender, e) => OpenSettings();
            this.BtnEditMacro.Click += (sender, e) => OpenMacroMenu();
            this.BtnEditTapDance.Click += (sender, e) => OpenTapDanceMenu();
            this.BtnFirmwareUpdate.Click += (sender, e) => OpenFirmwareUploader();
            this.Closing += ConfirmClose;
        }

        private void OpenFirmwareUploader()
        {
            var fm = new FmFirmwareUpdater();
            fm.Show();
        }
        private void OpenMacroMenu()
        {
            var lst = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var fm = new FmSelectTextDialog(lst, lst.Select(ele => "macro" + ele).ToList(), "Select a macro key to edit");
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
                        var dataCont = new MacroDataContainer();
                        var hasData = false;
                        foreach (var ele in lay.AddonDatas)
                        {
                            if (ele.GetType() == MacroDataContainer.DATA_TYPE)
                            {
                                hasData = true;
                                dataCont = ele as MacroDataContainer;
                            }
                        }

                        if (!hasData)
                        {
                            lay.AddonDatas.Add(dataCont);
                        }

                        var data = new MacroData();
                        data.Index = outputInd;
                        hasData = false;
                        if (dataCont != null)
                        {
                            foreach (var ele in dataCont.MacroKeys)
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
                        }

                        var mdialog = new FmMacroEdit(new MacroData(data));
                        mdialog.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Macro editor already opened");
                }
            }
        }

        private void OpenTapDanceMenu()
        {
            var lst = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };
            var fm = new FmSelectTextDialog(lst, lst.Select(ele => "TapDance" + ele).ToList(), "Select a tap dance key to edit");
            fm.ShowModal();
            var outputInd = fm.OutputIndex;

            if (outputInd >= 0)
            {
                if (!MdSessionData.OpenedTapDanceEdit)
                {
                    if (MdSessionData.CurrentLayout.KeyDatas.Count == 0)
                    {
                        MessageBox.Show("Error: You must first select a device");
                    }
                    else
                    {
                        MdSessionData.OpenedTapDanceEdit = true;
                        var lay = MdSessionData.CurrentLayout;
                        var dataCont = new TapDanceDataContainer();
                        var hasData = false;
                        foreach (var ele in lay.AddonDatas)
                        {
                            if (ele.GetType() == TapDanceDataContainer.DATA_TYPE)
                            {
                                hasData = true;
                                dataCont = ele as TapDanceDataContainer;
                            }
                        }

                        if (!hasData)
                        {
                            lay.AddonDatas.Add(dataCont);
                        }

                        var data = new TapDanceData();
                        data.Index = outputInd;
                        hasData = false;
                        if (dataCont != null)
                        {
                            foreach (var ele in dataCont.TapDanceKeys)
                            {
                                if (ele.Index == outputInd)
                                {
                                    hasData = true;
                                    data = ele;
                                }
                            }

                            if (!hasData)
                            {
                                dataCont.TapDanceKeys.Add(data);
                            }
                        }

                        var mdialog = new FmTapDanceEdit(new TapDanceData(data));
                        mdialog.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Tap dance editor already opened");
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
            MdSessionData.SP.PortName = this.BtnSelectPort.Text.Substring(6);

            try
            {
                MdSessionData.SP.Open();
            }
            catch (Exception)
            {
                var dr = MessageBox.Show("Arbites failed to detect the selected port\nAre you sure you wish to upload to this port?", "Port Confirmation", MessageBoxButtons.YesNo);
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
            var lst = Directory.GetFiles(Path.Combine(MdConstant.Root, MdConstant.D_KEYBOARD), "*" + MdConstant.E_KEYBOARD).ToList();
            var fm = new FmSelectTextDialog(lst, lst.Select(ele => Path.GetFileNameWithoutExtension(ele)).ToList(), "Select a device");
            fm.ShowModal();
            var outputInd = fm.OutputIndex;

            if (outputInd >= 0)
            {
                var kb = MdCore.DeserializeFromPath<Keyboard>(fm.OutputValues[outputInd]);
                MdSessionData.CurrentKeyboardType = kb;
                MdSessionData.CurrentLayout = kb.GenerateLayout();
                var ucl = new UCKeyboard(MdSessionData.CurrentKeyboardType, MdSessionData.CurrentLayout);
                MdSessionData.CurrentKeyboardUI = ucl;
                this.PnMain.Content = ucl;
                this.BtnSelectDevice.Text = "Device: " + kb.Name;
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
            MdConfig.Main.CurrentInputMethod = this.DDInputMethod.SelectedKey + MdConstant.E_INPUT_METHOD;
            MdSessionData.CurrentInputMethod = MdConfig.Main.GetCurrentInputMethod();
            MdMetaUtil.ReloadInputMethodUI();

            MdCore.SerializeToPath(MdConfig.Main, Path.Combine(MdConstant.Root, MdConstant.N_CONFIG));
        }

        public void LoadPortList()
        {
            // POSIX specific
            List<string> ports;
            if ((Environment.OSVersion.Platform == PlatformID.Unix) || (Environment.OSVersion.Platform == PlatformID.MacOSX))
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
                catch (Exception)
                {
                    ports = SerialPort.GetPortNames().ToList();
                }
            }
            else
            {
                ports = SerialPort.GetPortNames().ToList();
            }
            var dialog = new FmSelectTextDialog(ports, ports, "Select your port");
            dialog.ShowModal();
            if (dialog.OutputIndex >= 0)
            {
                this.BtnSelectPort.Text = "Port: " + dialog.OutputKeys[dialog.OutputIndex];
            }
        }
    }
}
