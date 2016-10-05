
using System;
using Gtk;

namespace ArbitesGTK
{
    class MainProgram
    {
        static void Main()
        {
            
            Application.Init();

            Button btn = new Button("lalala");
            btn.Clicked += new EventHandler(BtnClickedEvent);
            Window window = new Window("helloworld");
            window.SetDefaultSize(640, 480);
            window.Add(btn);
            window.ShowAll();
            Application.Run();
            //*/
        }

        static void BtnClickedEvent(object obj, EventArgs args)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "blah");
            md.Run();
            md.Destroy();
        }
    }
}
