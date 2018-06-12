using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Line : Figure
    {
        public Line(Point p1, Point p2, Graphics context=null)
        {
            P1 = p1;
            P2 = p2;
            Context = context;
        }

        public Point P1 { get; set; }

        public Point P2 { get; set; }

        public int Dimension => 1;

        public string Type => "line";

        public double Area => throw new NotSupportedException();

        public double Perimeter => Math.Pow(Math.Pow(P1.X - P2.X,2)+Math.Pow(P1.Y-P2.Y, 2), 0.5);

        public string Params => String.Format("Type: {0}, dimension: {1}, perimeter: {3}",
                                                Type, Dimension, Perimeter);

        public Point Origin { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        public Graphics Context { get; set; }

        public event DrawnHandler Drawn;

        public void Draw()
        {
            Context.DrawLine(Pens.Black, P1.X, P1.Y, P2.X, P2.Y);
        }

        public bool isInConture(Point p)
        {
            float dx1 = P2.X - P1.X;
            float dy1 = P2.Y - P1.Y;

            float dx = p.X - P1.X;
            float dy = p.Y - P1.Y;

            float s = dx1 * dy - dy1 * dx;
            if(s == 0)
            {
                return true;
            }
            return false;
        }

        public void Move(float dX, float dY)
        {
            Context.Clear(new Color());
            P1.X += dX;
            P2.X += dX;
            P1.Y += dY;
            P2.Y += dY;
            Draw();
            Drawn(this);
        }

        public void Scale(float coeficient)
        {
            Context.Clear(new Color());
            P1.X *= coeficient;
            P2.X *= coeficient;
            P2.X *= coeficient;
            P2.Y *= coeficient;
            Draw();
            Drawn(this);
        }
    }
}
