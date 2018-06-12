using System;
using System.Collections.Generic;
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

        private List<Ellips> _ellipses;

        public void Draw()
        {
            _ellipses = new List<Ellips>();
            Point position = Origin;
            for (int i = 8; i > 4;i--)
            {
                float a = 4*RadiusBig/(i);
                float b = 4*RadiusSmall/(i);
                var tmp = new Ellips(a, b, position, Context);
                tmp.Draw();
                _ellipses.Add(tmp);
                //(new Ellips(a, b, position, Context)).Draw();
                    position = new Point(position.X, position.Y - b/8);
            }
            for (int i = 8; i > 4; i--)
            {
                float a = 7 * RadiusBig / (i);
                float b = 7 * RadiusSmall / (i);
                var tmp = new Ellips(a, b, position, Context);
                tmp.Draw();
                _ellipses.Add(tmp);
                //(new Ellips(a, b, position, Context)).Draw();
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

        public bool isInConture(Point p)
        {
            foreach(var e in _ellipses)
            {
                if (e.isInConture(p))
                    return true;
            }
            return false;
        }

        public void Move(float dX, float dY)
        {
            Context.Clear(new Color());
            Origin.X += dX;
            Origin.Y += dY;
            Draw();
            Drawn(this);
        }

        public void Scale(float coeficient)
        {
            Context.Clear(new Color());
            RadiusBig *= coeficient;
            RadiusSmall *= coeficient;
            Origin.X *= coeficient;
            Origin.Y *= coeficient;
            Draw();
            Drawn(this);
        }
    }
}
