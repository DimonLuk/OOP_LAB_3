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
        var b = new Bitmap(1000, 700);
        var scene = Graphics.FromImage(b);
        //var circle = new Circle(100, new OOP_LAB_3.Model.Point(200,200), scene);
        //circle.Draw();
        var unfilledRing = new Ring(100, 120, new OOP_LAB_3.Model.Point(200, 200), scene);
        unfilledRing.Moved += Handler;
        unfilledRing.Draw();
        //unfilledRing.Move(250, 255);
        b.Save("/home/dimonlu/Projects/image.png", System.DrawingCore.Imaging.ImageFormat.Png);
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
