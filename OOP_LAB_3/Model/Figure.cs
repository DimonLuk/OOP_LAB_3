using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public delegate void DrawnHandler(Figure movedFigure);

    public static class Extensions
    {
        public static float ToFloat(this double d)
        {
            return Convert.ToSingle(d);
        }
        public static double ToDouble(this float f)
        {
            return Convert.ToDouble(f);
        }
    }

    public interface Figure
    {
        void Draw();
        int Dimension { get; }
        string Type { get; }
        void Move(float dX, float dY);
        void Scale(float coeficient);
        double Area { get; }
        double Perimeter { get; }
        string Params { get; }
        Point Origin { get; set; }
        Graphics Context { get; set; }
        bool isInConture(Point p);
        event DrawnHandler Drawn;
    }
}
