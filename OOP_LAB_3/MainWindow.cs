﻿using System;
using Gtk;
using Gdk;
using System.DrawingCore;
using System.IO;
using OOP_LAB_3.Model;

public partial class MainWindow : Gtk.Window
{
    public Picture p;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        p = new Picture();
        p.Add(new Line(new OOP_LAB_3.Model.Point(0, 0), new OOP_LAB_3.Model.Point(250, 340)));
        p.Add(new Circle(100, new OOP_LAB_3.Model.Point(120, 120)));
        p.Add(new UnFilledRing(100, 150, new OOP_LAB_3.Model.Point(250, 250)));
        p.Add(new Ring(20, 50, new OOP_LAB_3.Model.Point(500, 500)));
        p.Add(new Ellips(100,50,new OOP_LAB_3.Model.Point(200,200)));
        p.Add(new Cylinder(100, 300, new OOP_LAB_3.Model.Point(100, 150)));
        p.Add(new Tor(100,50, new OOP_LAB_3.Model.Point(500,350)));
        p.Add(new Sphere(100, new OOP_LAB_3.Model.Point(600, 200)));
        //p[2].Move(0, 150);
        //p[1].Scale(0.5.ToFloat());
        //p.ScaleAll(1.5.ToFloat());
        /*Picture.Serialize("/home/dimonlu/Projects/", p);*/
        //p = Picture.Deserialize("/home/dimonlu/Projects/");
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

    protected void buttonPressHanlder(object o, ButtonPressEventArgs args)
    {
        //args.Event.Button = 1, args.Event.X, args.Event.Y
        if(args.Event.Button == 1)
        {
            p.ChangeColor(new OOP_LAB_3.Model.Point(args.Event.X.ToFloat(), args.Event.Y.ToFloat()));
        }
    }
}
