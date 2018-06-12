using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Cylinder : Figure
    {
        public Cylinder(float radius, float height, Point origin, Graphics context = null)
        {
            Radius = radius;
            Height = height;
            Origin = origin;
            _context = context;
            calculate(_context);
        }

        private void calculate(Graphics context)
        {
            float a = Radius / 2;
            float b = (Radius * Math.Sin(Math.PI / 12)).ToFloat();
            var lowerOrigin = new Point(Origin.X, Origin.Y + Height);
            Higher = new Ellips(a, b, Origin, context);
            Lower = new Ellips(a, b, lowerOrigin, context);
            LeftLine = new Line(new Point(Origin.X - a, Origin.Y), new Point(Origin.X - a, Origin.Y + Height), context);
            RightLine = new Line(new Point(Origin.X + a, Origin.Y), new Point(Origin.X + a, Origin.Y + Height), context);
        }

        public Ellips Higher { get; private set; }
        public Ellips Lower { get; private set; }
        public Line LeftLine { get; private set; }
        public Line RightLine { get; private set; }

        private Graphics _context;

        public int Dimension => 2;

        public string Type => "cylinder";

        public double Area => 2 * Math.PI * Radius * Radius + Height * 2 * Math.PI * Radius;

        public double Volume => Math.PI * Radius* Radius * Height;

        public float Radius { get; set; }

        public float Height { get; set; }

        public double Perimeter => 8*Math.PI*Radius + 2*Height;

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, perimeter: {3}, radius: {4}, height: {5}, volume: {6}",
                                              Type, Dimension, Area, Perimeter, Radius, Height, Volume);

        public Point Origin { get; set; }
        public Graphics Context { get => _context;
            set
            {
                _context = value;
                Higher.Context = value;
                Lower.Context = value;
                LeftLine.Context = value;
                RightLine.Context = value;
            }
        }

        public event DrawnHandler Drawn;

        public void Draw()
        {

            calculate(Context);
            Higher.Draw();
            Lower.Draw();
            LeftLine.Draw();
            RightLine.Draw();
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
            Height *= coeficient;
            Origin.X *= coeficient;
            Origin.Y *= coeficient;
            Draw();
            Drawn(this);
        }

        public bool isInConture(Point p)
        {
            if (Higher.isInConture(p) || Lower.isInConture(p) || LeftLine.isInConture(p) || RightLine.isInConture(p))
                return true;
            return false;
        }
    }
}
