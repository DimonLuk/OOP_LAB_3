using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Point
    {
        public float X 
        {
            get => _x;
            set { if (_x >= _minValue) _x = value; else throw new PointInvalidValueException(); }
        }
        public float Y
        {
            get => _y;
            set { if (_y >= _minValue) _y = value; else throw new PointInvalidValueException(); }
        }
        float _minValue;
        float _x;
        float _y;
        public Point(float x, float y, float minValue)
        {
            _minValue = minValue>=0?minValue:throw new PointInvalidValueException();
            _x = x>=minValue?x:throw new PointInvalidValueException();
            _y = y>=minValue?y:throw new PointInvalidValueException();
        }
        public Point(float x, float y)
            :this(x,y,0)
        {}
    }
}
