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

        public UCSlice()
        {
            InitializeComponent();
            sliceIndex = 0;
            layers = new List<UCLayer>();
        }

        public UCSlice(ClBoardSlice input)
        {
            InitializeComponent();
            layers = new List<UCLayer>();
            lName.Text = input.sliceName;
            this.sliceIndex = input.sliceIndex;

            for (int i = 0; i < input.layers; i++)
            {
                var nl = new UCLayer(input.keys, input.sliceIndex, i);
                layers.Add(nl);
                nl.Parent = this;
                nl.Location = new Point(3, 20 + i * nl.Size.Height);
                
            }
            this.Size = new Size(layers[0].Size.Width + 30, layers[0].Size.Height * layers.Count + 30);
        }

    }
}
