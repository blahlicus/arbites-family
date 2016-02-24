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
    public partial class UCSlice : UserControl
    {
        public int sliceIndex { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<UCLayer> layers { get; set; }
        public ClLayoutContainer layout { get; set; }
        public ClBoardSlice sliceInfo { get; set; }
        public UCSlice()
        {
            InitializeComponent();
            sliceIndex = 0;
            layers = new List<UCLayer>();
        }

        public UCSlice(ClBoardSlice input, ClLayoutContainer layout)
        {
            InitializeComponent();
            this.layout = layout;
            layers = new List<UCLayer>();
            lName.Text = input.sliceName;
            this.sliceInfo = input;
            this.sliceIndex = input.sliceIndex;

            for (int i = 0; i < input.layers; i++)
            {
                AddLayer();
                
            }
        }

        public void AddLayer()
        {
            var nl = new UCLayer(sliceInfo.keys, sliceInfo.sliceIndex, layers.Count, this.layout);
            nl.Parent = this.flpMain;
            layers.Add(nl);
            this.Size = new Size(layers[0].Size.Width + 30, layers[0].Size.Height * layers.Count + 30);
        }
        
        public void LoadLayout(ClLayoutContainer input)
        {
            this.layout = input;
            while(layout.layers < layers.Count)
            {
                this.flpMain.Controls.Remove(layers[layers.Count - 1]);
                layers.RemoveAt(layers.Count - 1);
            }
            while (layout.layers > layers.Count)
            {
                AddLayer();
            }
            foreach (UCLayer layer in layers)
            {
                layer.LoadLayout(input);
            }
        }

    }
}
