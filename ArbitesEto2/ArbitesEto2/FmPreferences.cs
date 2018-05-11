using System;
using System.IO;
using Eto.Forms;


namespace ArbitesEto2
{

    public partial class FmPreferences
    {

        public FmPreferences()
        {
            this.ShowInTaskbar = true;
            InitializeComponent();
            this.CBKeyMenuTopMost.Checked = MdConfig.Main.KeyMenuTopmost;
            this.CBDisplayOutput.Checked = MdConfig.Main.DisplayOutput;
            this.DDUploadDelay.Items.Add("5");
            this.DDUploadDelay.Items.Add("6");
            this.DDUploadDelay.Items.Add("7");
            this.DDUploadDelay.Items.Add("8");
            this.DDUploadDelay.Items.Add("9");
            this.DDUploadDelay.Items.Add("10");
            this.DDUploadDelay.Items.Add("15");
            this.DDUploadDelay.Items.Add("20");


            foreach (var itm in this.DDUploadDelay.Items)
            {
                if (MdConfig.Main.UploadDelay == Convert.ToInt32(itm.Text))
                {
                    this.DDUploadDelay.SelectedValue = itm;
                }
            }
            EventHook();

            this.Icon = MdSessionData.WindowIcon;
        }

        public void EventHook()
        {
            this.BtnResetDefaults.Click += (sender, e) => ResetDefaults();
            this.BtnAddKeyboard.Click += (sender, e) => AddKeyboard();
            this.BtnAddLanguage.Click += (sender, e) => AddLanguage();
            this.BtnAddKeyGroup.Click += (sender, e) => AddKeyGroup();
            this.CBKeyMenuTopMost.CheckedChanged += (sender, e) => CheckedKeyMenuTopMost();
            this.CBDisplayOutput.CheckedChanged += (sender, e) => CheckedDisplayOutput();
            this.BtnClose.Click += (sender, e) => CloseForm();
            this.DDUploadDelay.SelectedIndexChanged += (sender, e) => UploadDelayChanged();
            Closing += (sender, e) => FmClosing();
        }

        private void CloseForm()
        {
            Close();
        }

        private void FmClosing()
        {
            MdCore.Serialize(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }


        private void AddKeyGroup()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileFilter("Arbites Keygroup File", MdConstant.E_KEYGROUP));
            dialog.Title = "Load Keygroup";
            try
            {
                dialog.ShowDialog(this);
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    // this line is needed because gtk savefiledialog doesnt work properly with extensions
                    var savePath = Path.ChangeExtension(dialog.FileName, MdConstant.E_KEYGROUP.Substring(1));

                    if (File.Exists(savePath))
                    {
                        File.Copy(savePath, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP), true);
                        MessageBox.Show("Key definitions successfully updated.", MessageBoxType.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cannot access file: " + savePath, MessageBoxType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddKeyboard()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileFilter("Arbites Keyboard File", MdConstant.E_KEYBOARD));
            dialog.Title = "Load Keyboard Type";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstant.psep + "keyboards");
            try
            {
                dialog.ShowDialog(this);
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    // this line is needed because gtk savefiledialog doesnt work properly with extensions
                    var savePath = Path.ChangeExtension(dialog.FileName, MdConstant.E_KEYBOARD.Substring(1));

                    if (File.Exists(savePath))
                    {
                        File.Copy(savePath, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, Path.GetFileName(savePath)), true);
                        MessageBox.Show("Keyboard type successfully added", MessageBoxType.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cannot access file: " + savePath, MessageBoxType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void AddLanguage()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileFilter("Arbites Input Method File", MdConstant.E_INPUT_METHOD));
            dialog.Title = "Load Input Method";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstant.psep + "input-method");
            try
            {
                dialog.ShowDialog(this);
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    // this line is needed because gtk savefiledialog doesnt work properly with extensions
                    var savePath = Path.ChangeExtension(dialog.FileName, MdConstant.E_INPUT_METHOD.Substring(1));

                    if (File.Exists(savePath))
                    {
                        File.Copy(savePath, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD, Path.GetFileName(savePath)), true);
                        MessageBox.Show("Input method successfully added", MessageBoxType.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cannot access file: " + savePath, MessageBoxType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CheckedKeyMenuTopMost()
        {
            MdConfig.Main.KeyMenuTopmost = this.CBKeyMenuTopMost.Checked.Value;
            MdSessionData.KeyMenu.ReloadTopmost();
            MdCore.Serialize(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void CheckedDisplayOutput()
        {
            MdConfig.Main.DisplayOutput = this.CBDisplayOutput.Checked.Value;
            MdCore.Serialize(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void UploadDelayChanged()
        {
            MdConfig.Main.UploadDelay = Convert.ToInt32(this.DDUploadDelay.SelectedKey);
            MdCore.Serialize(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void ResetDefaults()
        {
            // TODO
            if (MessageBox.Show("Are you sure you wish to proceed?\nArbites will restart itself after this operation.", "This will reset your defaults.", MessageBoxButtons.YesNo, MessageBoxType.Question, MessageBoxDefaultButton.No) == DialogResult.Yes)
            {
                MdMetaUtil.ResetDefaults();
                Application.Instance.Restart();
            }
        }

    }

}
