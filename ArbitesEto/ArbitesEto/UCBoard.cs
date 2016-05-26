using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class UCBoard
    {
        public List<UCSlice> slices { get; set; }
        public string saveExtension { get; set; }
        public ClLayoutContainer layout { get; set; }
        public int maxLayer { get; set; }
        public UCBoard()
        {
            //teste dit
            InitializeComponent();
            slices = new List<UCSlice>();
            layout = new ClLayoutContainer();
            BtnSave.Click += (sender, e) => btSave_Click(sender, e);
            BtnLoad.Click += (sender, e) => btLoad_Click(sender, e);
            BtnAddLayer.Click += (sender, e) => btAddLayer_Click(sender, e);
        }


        public UCBoard(ClKeyboard keyboard)
        {
            InitializeComponent();
            slices = new List<UCSlice>();
            layout = new ClLayoutContainer();

            for (int i = 0; i < 3; i++ )
            {
                layout.keys.Add(new List<ClKeyData>());
            }
            layout.keyboardType = keyboard.keyboardType;
            saveExtension = "." + keyboard.fileFormat;
            foreach (ClBoardSlice slice in keyboard.slices)
            {
                var ns = new UCSlice(slice, this.layout);
                this.slices.Add(ns);
                SLMain.Items.Add(ns);
            }
            maxLayer = keyboard.layers;
            LName.Text = "Keyboard Type: " + keyboard.keyboardName;
            BtnSave.Click += (sender, e) => btSave_Click(sender, e);
            BtnLoad.Click += (sender, e) => btLoad_Click(sender, e);
            BtnAddLayer.Click += (sender, e) => btAddLayer_Click(sender, e);
        }

        public void LoadLayout(ClLayoutContainer input)
        {

            this.layout = input;
            foreach (UCSlice slice in slices)
            {
                slice.LoadLayout(layout);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter(layout.keyboardType + " layout",  saveExtension));
            dialog.Title = "Save Layout";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstants.pseparator + "layouts");
            dialog.ShowDialog(this);
            if (dialog.FileName != "")
            {
                var tempPath = System.IO.Path.GetDirectoryName(dialog.FileName);
                tempPath = System.IO.Path.ChangeExtension(dialog.FileName, saveExtension);
                MdCore.Serialize<ClLayoutContainer>(layout, tempPath);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter(layout.keyboardType + " layout", saveExtension));
            dialog.Title = "Load Layout";
            dialog.Directory = new Uri(Environment.CurrentDirectory + MdConstants.pseparator + "layouts");
            dialog.ShowDialog(this);
            if (dialog.FileName != "" && System.IO.File.Exists(dialog.FileName))
            {

                LoadLayout(MdCore.Deserialize<ClLayoutContainer>(dialog.FileName));
            }
        }

        private void btAddLayer_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        private void AddLayer()
        {
            if (layout.keys.Count < maxLayer)
            {

                this.layout.keys.Add(new List<ClKeyData>());
                LoadLayout(this.layout);
            }
            else
            {
                MessageBox.Show("Error: Maximum number of layers reached: " + maxLayer.ToString());
            }
        }

        public void UpdateScrollable()
        {
            SCMain.UpdateScrollSizes();
        }
    }
}
