using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Circle : Figure
    {
        public Circle(double radius, Point startPoint, Graphics context = null)
        {
            Radius = radius;
            Context = context;
            _startPoint = startPoint;
        }

        public Graphics Context { get; set; }

        public Point StartPoint { get => _startPoint; 
            set
            {
                _startPoint = value;
                //Draw();
            }
        }

        private Point _startPoint;

        public event DrawnHandler Drawn;

        public double Radius { get; private set; }

        public int Dimension => 2;

        public string Type => "Circle";

        public double Area => Math.PI * Math.Pow(Radius,2);

        public double Perimeter => 2 * Math.PI * Radius;

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, perimeter: {3}, radius: {4}",
                                                Type, Dimension, Area, Perimeter, Radius);

        public void Draw()
        {
            for (double i = 0; i <= 2 * Math.PI; i+=0.0001)
            {
                Context.DrawRectangle(Pens.Black, Convert.ToSingle(StartPoint.X + Radius*Math.Cos(i)), Convert.ToSingle(StartPoint.Y + Radius*Math.Sin(i)), 1, 1);
            }
            Drawn(this);
        }

        public void Move(float dX, float dY)
        {
            Context.Clear(new Color());
            StartPoint.X += dX;
            StartPoint.Y += dY;
            Draw();
            Drawn(this);
        }

        public void Scale(float coeficient)
        {
            Radius *= coeficient;
            Draw();
        }
    }
}
