using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace ArbitesEto
{
    public partial class UCSlice
    {
        public List<UCLayer> layers { get; set; }
        public ClLayoutContainer layout { get; set; }
        public ClBoardSlice sliceInfo { get; set; }
        public int sliceIndex { get; set; }
        public UCSlice()
        {
            InitializeComponent();
            layers = new List<UCLayer>();
            sliceIndex = 0;
        }

        public UCSlice(ClBoardSlice input, ClLayoutContainer layout)
        {
            InitializeComponent();
            this.layout = layout;
            layers = new List<UCLayer>();
            LName.Text = input.sliceName;
            this.sliceInfo = input;
            this.sliceIndex = input.sliceIndex;

            for (int i = 0; i < layout.keys.Count; i++)
            {
                AddLayer(i, true);

            }
        }


        public void AddLayer(int layer, bool init)
        {
            var nl = new UCLayer(sliceInfo.keys, sliceInfo.sliceIndex, layer, this.layout, init);
            SLMain.Items.Add(nl);
            layers.Add(nl);
            
            //MessageBox.Show("Added to client");
            //ClientSize = new Size(layers[0].ClientSize.Width + 30, layers[0].ClientSize.Height * layers.Count + 30);
            //ClientSize = new Size(472, 1023);
            //MessageBox.Show(layers[0].ClientSize.Width.ToString());
        }

        public void LoadLayout(ClLayoutContainer input)
        {
            this.layout = input;

            while (layout.keys.Count < layers.Count)
            {
                this.SLMain.Items.RemoveAt(layers.Count - 1);
                layers.RemoveAt(layers.Count - 1);
            }
            while (layers.Count < layout.keys.Count)
            {
                AddLayer(layers.Count, true);
            }
            //*/
            /*
            if (layout.keys.Count < layers.Count)
            {
                this.SLMain.Items.Clear();
                this.layers.Clear();
                for (int i = 0; i < layout.keys.Count; i++)
                {
                    AddLayer(i, false);
                }
            }
            else if (layout.keys.Count > layers.Count)
            {
                while (layers.Count < layout.keys.Count)
                {
                    AddLayer(layers.Count, true);
                }
                /*
                this.SLMain.Items.Clear();
                this.layers.Clear();
                for (int i = 0; i < layers.Count; i++)
                {
                    var init = false;
                    if (layout.keys[i].Count == 0)
                    {
                        init = true;
                    }
                    AddLayer(i, init);
                }
            }
                //*/





            foreach (UCLayer layer in layers)
            {
                layer.LoadLayout(input);
            }
        }
    }
}
