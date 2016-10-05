using System;
using System.IO;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

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


            foreach(var itm in DDUploadDelay.Items)
            {
                if (MdConfig.Main.UploadDelay == Convert.ToInt32(itm.Text))
                {
                    DDUploadDelay.SelectedValue = itm;
                }
            }
            EventHook();

            Icon = MdSessionData.WindowIcon;
        }

        public void EventHook()
        {
            this.BtnResetDefaults.Click += (sender, e) => ResetDefaults();
            this.CBKeyMenuTopMost.CheckedChanged += (sender, e) => CheckedKeyMenuTopMost();
            this.CBDisplayOutput.CheckedChanged += (sender, e) => CheckedDisplayOutput();
            this.BtnClose.Click += (sender, e) => CloseForm();
            this.DDUploadDelay.SelectedIndexChanged += (sender, e) => UploadDelayChanged();
            this.Closing += (sender, e) => FmClosing();
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void FmClosing()
        {
            MdCore.Serialize<MdConfig>(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void CheckedKeyMenuTopMost()
        {
            MdConfig.Main.KeyMenuTopmost = CBKeyMenuTopMost.Checked.Value;
            MdSessionData.KeyMenu.ReloadTopmost();
            MdCore.Serialize<MdConfig>(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void CheckedDisplayOutput()
        {

            MdConfig.Main.DisplayOutput = CBDisplayOutput.Checked.Value;
            MdCore.Serialize<MdConfig>(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        private void UploadDelayChanged()
        {
            MdConfig.Main.UploadDelay = Convert.ToInt32(DDUploadDelay.SelectedKey);
            MdCore.Serialize<MdConfig>(MdConfig.Main, Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
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
