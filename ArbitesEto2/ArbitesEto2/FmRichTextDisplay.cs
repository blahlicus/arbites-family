using System.Collections.Generic;


namespace ArbitesEto2
{

    public partial class FmRichTextDisplay
    {

        public FmRichTextDisplay()
        {
            InitializeComponent();
        }

        public FmRichTextDisplay(List<string> input)
        {
            InitializeComponent();
            foreach (var str in input)
            {
                this.RTAMain.Text += str + "\n";
            }
            this.Icon = MdSessionData.WindowIcon;
        }

    }

}
