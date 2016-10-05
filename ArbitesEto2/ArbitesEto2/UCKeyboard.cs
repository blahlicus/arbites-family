using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto2
{
    public partial class UCKeyboard
    {
        public ClKeyboard Keyboard { get; set; }
        public List<UCLayer> Layers { get; set; }
        public string SavePath { get; set; }
        private bool initalized = false;
        public UCKeyboard()
        {
            InitializeComponent();
        }

        public UCKeyboard(ClKeyboard keyboard, ClLayoutContainer layout)
        {
            InitializeComponent();
            this.Keyboard = keyboard;
            this.Layers = new List<UCLayer>();
            initalized = true;
            this.LoadLayout(layout);
            this.SavePath = "<UNSAVED LAYOUT>";
            this.LLayoutName.Text = "<UNSAVED LAYOUT>";
            InitHandle();
        }

        private void InitHandle()
        {
            BtnAddLayer.Click += (sender, e) => AddLayer();
            BtnSaveAs.Click += (sender, e) => SaveLayoutAs();
            BtnSave.Click += (sender, e) => SaveLayout();
            BtnLoad.Click += (sender, e) => LoadLayoutFile();
        }

        public void LoadLayoutFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter(Keyboard.Name+ " layout", "*." + Keyboard.SaveFileExtension));
            dialog.Title = "Load Layout";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstant.psep+ "layouts");
            dialog.ShowDialog(this);
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                MdSessionData.CurrentLayout = MdCore.Deserialize<ClLayoutContainer>(dialog.FileName);
                LoadLayout(MdSessionData.CurrentLayout);
                SavePath = dialog.FileName;
                this.LLayoutName.Text = System.IO.Path.GetFileNameWithoutExtension(SavePath);
                this.BtnSave.Text = "Save Layout";
            }
        }

        public void SaveLayout()
        {
            if (SavePath == "<UNSAVED LAYOUT>")
            {
                SaveLayoutAs();
            }
            else
            {
                MdCore.Serialize<ClLayoutContainer>(MdSessionData.CurrentLayout, SavePath);
                this.BtnSave.Text = "Save Layout";
            }
        }

        public void SaveLayoutAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter(Keyboard.Name + " layout", "*." + Keyboard.SaveFileExtension));
            dialog.Title = "Save Layout As";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstant.psep + "layouts");
            dialog.ShowDialog(this);
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                SavePath = dialog.FileName;
                MdCore.Serialize<ClLayoutContainer>(MdSessionData.CurrentLayout, SavePath);
                this.BtnSave.Text = "Save Layout";
                this.LLayoutName.Text = System.IO.Path.GetFileNameWithoutExtension(SavePath);
            }
        }

        public void AddLayer()
        {
            if (this.Layers.Count < Keyboard.MaxLayers)
            {

                MdSessionData.CurrentLayout.AddLayer(Layers.Count);
                LoadLayout(MdSessionData.CurrentLayout);
            }
            else
            {
                MessageBox.Show("Error: Maximum number of layers reached.");
            }
        }

        public void LoadLayout(ClLayoutContainer input)
        {
            if (initalized)
            {

                int cLay = 0;
                foreach (ClKeyData kd in input.KeyDatas)
                {
                    if (kd.Z > cLay)
                    {
                        cLay = kd.Z;
                    }
                }
                while (this.Layers.Count < cLay + 1)
                {
                    var lay = new UCLayer(Keyboard, input, this.Layers.Count);
                    this.Layers.Add(lay);
                    this.SLMain.Items.Add(lay);
                }

                while (this.Layers.Count > cLay + 1)
                {
                    this.SLMain.Items.RemoveAt(this.Layers.Count - 1);
                    this.Layers.RemoveAt(this.Layers.Count - 1);

                }

                foreach (UCLayer lay in this.Layers)
                {
                    lay.LoadLayout(input);
                }
                this.BtnSave.Text = "Save Layout*";
            }
        }

        public void DisplayUnsavedChangeSignal()
        {
            this.BtnSave.Text = "Save Layout*";

        }
    }
}
