using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Tor:Figure
    {
        public Tor(float radiusBig, float radiusSmall, Point origin, Graphics context = null)
        {
            RadiusBig = radiusBig;
            RadiusSmall = radiusSmall;
            Origin = origin;
            Context = context;
        }

        public int Dimension => 3;

        public string Type => "tor";

        public double Area => 4*Math.PI*RadiusBig*RadiusSmall;

        public double Volume => 2 * Math.Pow(Math.PI * RadiusSmall, 2) * RadiusBig;

        public double Perimeter => throw new NotSupportedException();

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, volume: {3}, radius_big: {4}, radius_small: {5}",
                                                Type, Dimension, Area, Perimeter, RadiusBig, RadiusSmall);

        public float RadiusBig { get; set; }
        public float RadiusSmall { get; set; }

        public Point Origin { get; set; }
        public Graphics Context { get; set; }

        public event DrawnHandler Drawn;

        public void Draw()
        {
            Point position = Origin;
            for (int i = 8; i > 4;i--)
            {
                float a = 4*RadiusBig/(i);
                float b = 4*RadiusSmall/(i);
                (new Ellips(a, b, position, Context)).Draw();
                    position = new Point(position.X, position.Y - b/8);
            }
            for (int i = 8; i > 4; i--)
            {
                float a = 7 * RadiusBig / (i);
                float b = 7 * RadiusSmall / (i);
                (new Ellips(a, b, position, Context)).Draw();
                position = new Point(position.X, position.Y + b / 6);
            }
            /*for (int i = 8; i > 6; i--)
            {
                float a = 4 * RadiusBig / (i);
                float b = 4 * RadiusSmall / (i);
                (new Ellips(a, b, position, Context)).Draw();
                position = new Point(position.X, position.Y - b / 8);
            }*/

        }

        public void Move(float dX, float dY)
        {
            throw new NotImplementedException();
        }

        public void Scale(float coeficient)
        {
            throw new NotImplementedException();
        }
    }
}
