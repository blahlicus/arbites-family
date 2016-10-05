using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArbitesR
{
    public partial class UCBoard : UserControl
    {

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<UCSlice> slices { get; set; }
        public string saveExtension { get; set; }
        public ClLayoutContainer layout { get; set; }
        public UCBoard()
        {
            InitializeComponent();
            slices = new List<UCSlice>();
            layout = new ClLayoutContainer();
        }


        public UCBoard(ClKeyboard keyboard)
        {
            InitializeComponent();
            slices = new List<UCSlice>();
            layout = new ClLayoutContainer();
            layout.layers = keyboard.layers;
            layout.keyboardType = keyboard.keyboardType;
            saveExtension = keyboard.fileFormat;
            foreach (ClBoardSlice slice in keyboard.slices)
            {
                var ns = new UCSlice(slice, this.layout);
                this.slices.Add(ns);
                ns.Parent = this.flpMain;
            }
            lKeyboardName.Text = keyboard.keyboardName;
        }

        public void LoadLayout(ClLayoutContainer input)
        {

            this.layout = input;
            foreach (UCSlice slice in slices)
            {
                slice.LoadLayout(input);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = layout.keyboardType + " layout | *." + saveExtension;
            dialog.Title = "Save Layout";
            dialog.InitialDirectory = Environment.CurrentDirectory + MdConstants.pseparator + "layouts";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {

                MdCore.Serialize<ClLayoutContainer>(layout, dialog.FileName);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = layout.keyboardType + " layout | *." + saveExtension;
            dialog.Title = "Load Layout";
            dialog.InitialDirectory = Environment.CurrentDirectory + MdConstants.pseparator + "layouts";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {

                LoadLayout(MdCore.Deserialize<ClLayoutContainer>(dialog.FileName));
            }
        }

        private void btAddLayer_Click(object sender, EventArgs e)
        {
            this.layout.layers++;
            LoadLayout(this.layout);
        }

    }
}
