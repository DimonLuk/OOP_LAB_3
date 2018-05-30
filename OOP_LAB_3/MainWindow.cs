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
        /*p.Add(new Ellips(100,50,new OOP_LAB_3.Model.Point(200,200)));
        p.Add(new Ring(20, 50, new OOP_LAB_3.Model.Point(500, 500)));
        p.Add(new Line(new OOP_LAB_3.Model.Point(0, 0), new OOP_LAB_3.Model.Point(250, 340)));
        p.Add(new Cylinder(100, 300, new OOP_LAB_3.Model.Point(100, 150)));
        p[3].Scale(0.5.ToFloat());
        p[3].Move(500, 0);*/
        p.Add(new Sphere(100, new OOP_LAB_3.Model.Point(400, 150)));
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
