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
            Context = context;
        }

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
        public Graphics Context { get; set; }

        public event DrawnHandler Drawn;

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move(float dX, float dYs)
        {
            throw new NotImplementedException();
        }

        public void Scale(float coeficient)
        {
            throw new NotImplementedException();
        }
    }
}
