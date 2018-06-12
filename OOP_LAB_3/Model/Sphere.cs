using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Sphere : Figure
    {
        public Sphere(float radius, Point origin, Graphics context = null)
        {
            Radius = radius;
            Origin = origin;
            _context = context;
            calculate(_context);
        }

        private void calculate(Graphics context)
        {
            circle = new Circle(Radius, Origin, context);
            float a = Radius;
            float b = (Radius * Math.Sin(Math.PI / 12)).ToFloat();
            ellips = new Ellips(a, b, Origin, context);
        }

        private Circle circle;

        private Ellips ellips;

        public int Dimension => 3;

        public string Type => "sphere";

        public double Area => 4*Math.PI*Radius*Radius;

        public double Perimeter => throw new NotSupportedException();

        public double Volume => 4 / 3 * Math.PI*Radius * Radius * Radius;

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, volume: {3}, radius: {4}",
                                                Type, Dimension, Area, Volume, Radius);

        public float Radius { get; set; }

        public Point Origin { get; set; }
        public Graphics Context { get => _context;
            set
            {
                _context = value;
                circle.Context = value;
                ellips.Context = value;
            }
        }
        private Graphics _context;
        public event DrawnHandler Drawn;

        public void Draw()
        {
            calculate(Context);
            circle.Draw();
            ellips.Draw();
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
            Radius *= coeficient;
            Origin.X *= coeficient;
            Origin.Y *= coeficient;
            Draw();
            Drawn(this);
        }

        public bool isInConture(Point p)
        {
            if (circle.isInConture(p) || ellips.isInConture(p))
                return true;
            return false;
        }
    }
}
