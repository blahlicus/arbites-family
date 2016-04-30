using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto
{
    class MdEto
    {
        public static int ToRight(Eto.Forms.Control ctrl)
        {
            return ctrl.Location.X + ctrl.Size.Width + 5;
        }

        public static int ToBotton(Eto.Forms.Control ctrl)
        {
            return ctrl.Location.Y + ctrl.Size.Height + 5;
        }

    }
}
