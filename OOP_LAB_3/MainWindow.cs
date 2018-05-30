using System;
using Gtk;
using Gdk;
using System.DrawingCore;
using System.IO;
using OOP_LAB_3.Model;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        var p = new Picture();
        p.Add(new Ring(200,250, new OOP_LAB_3.Model.Point(350,350)));
        p.Display();
        var buffer = System.IO.File.ReadAllBytes ("/home/dimonlu/Projects/image.png");
        var pixbuf = new Gdk.Pixbuf (buffer);
        image2.Pixbuf = pixbuf; 
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
    protected static void Handler(Figure f)
    {
        
    }
}
