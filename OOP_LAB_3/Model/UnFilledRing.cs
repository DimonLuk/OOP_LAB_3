using System;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class UnFilledRing : Figure
    {
        public UnFilledRing(float radiusSmall, float radiusBig, Point startPoint, Graphics context = null)
        {
            RadiusBig = radiusBig;
            RadiusSmall = radiusSmall;
            _startPoint = startPoint;
            _context = context;
            CircleBig = new Circle(RadiusBig, startPoint, Context);
            CircleSmall = new Circle(RadiusSmall, startPoint, context);
        }

        private Graphics _context;

        protected Point _startPoint;

        protected Circle CircleBig;

        protected Circle CircleSmall;

        virtual public event DrawnHandler Drawn;

        public float RadiusBig { get; private set; }

        public float RadiusSmall { get; private set; }

        public int Dimension => 2;

        virtual public string Type => "unfilled ring";

        public double Area => Math.PI*RadiusBig*RadiusBig - Math.PI*RadiusSmall*RadiusSmall;

        public double Perimeter => 2*Math.PI*RadiusBig + 2*Math.PI*RadiusSmall;

        public string Params => String.Format("Type: {0}, dimension: {1}, area: {2}, perimeter: {3}, radiusSmall: {4}, radisuBig: {5}",
                                              Type, Dimension, Area, Perimeter, RadiusSmall, RadiusBig);

        public Point StartPoint { get => _startPoint; 
            set
            {
                _startPoint = value;
                CircleBig.StartPoint = value;
                CircleSmall.StartPoint = value;
                //Draw();
            }
        }
        public Graphics Context { get => _context; 
            set
            {
                _context = value;
                CircleBig.Context = value;
                CircleSmall.Context = value;
            }
        }

        virtual public void Draw()
        {
            CircleSmall.Drawn += Drawn;
            CircleBig.Drawn += Drawn;
            CircleBig.Draw();
            CircleSmall.Draw();
            Drawn(this);
        }

        virtual public void Move(float dX, float dY)
        {
            Context.Clear(new Color());
            StartPoint.X += dX;
            StartPoint.Y += dY;
            Draw();
            Drawn(this);
        }

        public void Scale(float coeficient)
        {
            throw new NotImplementedException();
        }
    }
}
