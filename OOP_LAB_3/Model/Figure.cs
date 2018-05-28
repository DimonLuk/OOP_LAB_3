using System;
namespace OOP_LAB_3.Model
{
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
    }
}
