using System;
using System.Collections;
using System.Collections.Generic;
using System.DrawingCore;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_LAB_3.Model
{
    [Serializable]
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
        public void ScaleAll(float c)
        {
            foreach (var i in this)
                i.Scale(c);
        }
        public void MoveAll(float dX, float dY)
        {
            foreach (var i in this)
                i.Move(dX, dY);
        }
        public static void Serialize(string path, Picture p)
        {
            BinaryFormatter f = new BinaryFormatter();
            using(var fs = new FileStream(path+"/figure.data", FileMode.OpenOrCreate))
            {
                try
                {
                    f.Serialize(fs, p);
                } catch(SerializationException)
                {}
            }
        }
        public static Picture Deserialize(string path)
        {
            var f = new BinaryFormatter();
            Picture p = new Picture();
            using(var fs = new FileStream(path+"/figure.data", FileMode.Open))
            {
                try
                {
                    p = (Picture)f.Deserialize(fs);
                } catch(SerializationException)
                {}
            }
            return p;
        }
        public void ChangeColor(Point p)
        {
            foreach(var v in _list)
            {
                if (v.isInConture(p))
                    Console.WriteLine(v.Params);
            }
        }
    }
}
