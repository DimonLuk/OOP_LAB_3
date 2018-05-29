using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Ring : UnFilledRing
    {
        public Ring(float radiusSmall, float radiusBig, Point startPoint, Graphics context) : base(radiusSmall, radiusBig, startPoint, context)
        {
        }
        public override string Type => "filled ring";
        public override void Draw()
        {
            base.Draw();
            for (double i = 0; i < 1000;i+=1)
            {
                for (double j = 0; j < 700;j+=1)
                {
                    if (Math.Pow(i-StartPoint.X,2) + Math.Pow(j-StartPoint.Y,2) > Math.Pow(CircleSmall.Radius,2) && Math.Pow(i-StartPoint.X, 2) + Math.Pow(j-StartPoint.Y, 2) < Math.Pow(CircleBig.Radius, 2))
                        Context.DrawRectangle(Pens.Black, i.ToFloat(), j.ToFloat(), 1, 1);
                }
            }
        }
	}
}
