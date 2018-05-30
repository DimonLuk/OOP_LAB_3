using System;
using System.Collections;
using System.Collections.Generic;
using System.DrawingCore;

namespace OOP_LAB_3.Model
{
    public class Picture : IEnumerable<Figure>
    {
        List<Figure> _list = new List<Figure>();
        Bitmap image;
        public Graphics Context { get; private set; }
        public Picture()
        {
            image = new Bitmap(1000, 700);
            Context = Graphics.FromImage(image);
        }

        public void Add(Figure f)
        {
            f.Context = Context;
            f.Drawn += Handler;
            f.Draw();
            _list.Add(f);
        }

        public Figure this[int i]
        { 
            get
            {
                return _list[i];
            }
            set
            {
                value.Context = Context;
                value.Drawn += Handler;
                value.Draw();
                _list[i] = value;
            }
        }

        public void Display()
        {
            image.Save("/home/dimonlu/Projects/image.png", System.DrawingCore.Imaging.ImageFormat.Png);
        }

        public IEnumerator<Figure> GetEnumerator()
        {
            foreach (var i in _list)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var i in _list)
                yield return i;
        }
        public void Handler(Figure f)
        {
            foreach(var i in this)
            {
                if (!i.Equals(f))
                    i.Draw();
            }
        }
    }
}
