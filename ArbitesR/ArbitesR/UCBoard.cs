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
        public UCBoard()
        {
            InitializeComponent();
            slices = new List<UCSlice>();
        }


        public UCBoard(ClKeyboard keyboard)
        {
            InitializeComponent();
            slices = new List<UCSlice>();
            foreach (ClBoardSlice slice in keyboard.slices)
            {
                var ns = new UCSlice(slice);
                this.slices.Add(ns);
                ns.Parent = this.flpMain;
            }
        }
    }
}
