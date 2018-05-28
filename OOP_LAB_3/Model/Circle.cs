using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Circle : Figure
    {
        public Circle(double radius, Point startPoint, Graphics context)
        {
            Radius = radius;
            StartPoint = startPoint;
            _context = context;
        }

        Graphics _context;

        public Point StartPoint { get; private set; }

        public double Radius { get; private set; }

        public int Dimension => 2;

        public string Type => "Circle";

        public double Area => Math.PI * Math.Pow(Radius,2);

        public double Perimeter => 2 * Math.PI * Radius;

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, perimeter: {3}, radius: {4}",
                                                Type, Dimension, Area, Perimeter, Radius);

        public static bool eq(double a, double b, int maxDeltaBits)
        {
            int aInt = BitConverter.ToInt32(BitConverter.GetBytes(a), 0);
            if (aInt < 0)
                aInt = Int32.MinValue - aInt;  // Int32.MinValue = 0x80000000

            int bInt = BitConverter.ToInt32(BitConverter.GetBytes(b), 0);
            if (bInt < 0)
                bInt = Int32.MinValue - bInt;

            int intDiff = Math.Abs(aInt - bInt);
            return intDiff <= (1 << maxDeltaBits);
        }

        public void Draw()
        {
            for (double i = -8*Math.PI; i <= 8 * Math.PI; i+=0.0001)
            {
                _context.DrawRectangle(Pens.Red, StartPoint.X - 240 * Convert.ToSingle(Math.Cos(i)),StartPoint.Y + 200 * Convert.ToSingle(-Math.Sin(i) - Math.Pow(Math.Abs(Math.Cos(i)), 0.5)),  5, 5);
            }
            /*for (double i = -600; i <= 600;i+=0.1)
            {
                for (double j = -400; j <= 601;j+=0.1)
                {
                    if(Math.Pow(j - Math.Pow(Math.Abs(250*i), 0.5), 2.0) - 0.5 * Math.Pow(i, 2.0) - 150000.0 == 0)
                    {
                        _context.DrawRectangle(Pens.Red, StartPoint.X + Convert.ToSingle(i), StartPoint.Y + Convert.ToSingle(j), 1, 1);
                    }
                }
            }*/
        }

        public void Move(float dX, float dY)
        {
            StartPoint.X += dX;
            StartPoint.Y += dY;
            Draw();
        }

        public void Scale(float coeficient)
        {
            Radius *= coeficient;
            Draw();
        }
    }
}
