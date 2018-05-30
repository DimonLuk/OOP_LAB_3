using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Ellips : Figure
    {
        public Ellips(float a, float b, Point origin, Graphics context = null)
        {
            A = a;
            B = b;
            Origin = origin;
            Context = context;
        }

        public int Dimension => 2;

        public string Type => "ellips";

        public double Area => Math.PI * A * B;

        public double Perimeter => 2*Math.PI*Math.Pow((A*A+B*B)/2, 0.5);

        public float A { get; set; }

        public float B { get; set; }

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, perimeter: {3}, a: {4}, b: {5}",
                                                Type, Dimension, Area, Perimeter, A, B);

        public Point Origin { get; set; }
        public Graphics Context { get; set; }

        public event DrawnHandler Drawn;

        public void Draw()
        {
            for (double i = 0; i <= 2 * Math.PI;i+=0.001)
            {
                Context.DrawRectangle(Pens.Black, Origin.X + (A*Math.Cos(i)).ToFloat(), Origin.Y + (B*Math.Sin(i)).ToFloat(), 1,1);
            }
        }

        public void Move(float dX, float dYs)
        {
            Context.Clear(new Color());
            Origin.X += dX;
            Origin.Y += dYs;
            Draw();
            Drawn(this);

        }

        public void Scale(float coeficient)
        {
            Context.Clear(new Color());

            A *= coeficient;
            B *= coeficient;

            Draw();
            Drawn(this);
        }
    }
}
