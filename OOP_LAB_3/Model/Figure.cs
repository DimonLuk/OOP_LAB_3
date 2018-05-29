using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public delegate void MovedHandler(Figure movedFigure);

    public static class Extensions
    {
        public static float ToFloat(this double d)
        {
            return Convert.ToSingle(d);
        }
    }

    public interface Figure
    {
        void Draw();
        int Dimension { get; }
        string Type { get; }
        void Move(float dX, float dYs);
        void Scale(float coeficient);
        double Area { get; }
        double Perimeter { get; }
        string Params { get; }
        Point StartPoint { get; set; }
        Graphics Context { get; set; }
        event MovedHandler Moved;
    }
}
