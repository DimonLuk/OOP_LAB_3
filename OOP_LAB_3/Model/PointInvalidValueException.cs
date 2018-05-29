using System;
namespace OOP_LAB_3.Model
{
    public class PointInvalidValueException : Exception
    {
        public PointInvalidValueException()
            :base("Value must be positive or 0")
        {
        }
    }
}
