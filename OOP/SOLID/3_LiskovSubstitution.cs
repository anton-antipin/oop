// 1 liskov substitution principle
// 2 принцип подстановки Лисков
// 3 должна быть возможность вместо базового типа подставить любой его подтип
// 4 производный класс который может делать меньше чем базовый нельзя использовать вместо базового

using System;

namespace OOP.SOLID._3_LiskovSubstitution
{
    public class Example00
    {
        private static Example00 _instance;
        private static readonly object _synchtObj = new object();

        private Example00()
        {

        }

        public static Example00 Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchtObj)
                    {
                        if (_instance == null)
                            _instance = new Example00();
                    }
                }
                return _instance;
            }
        }

        public int Main(IGettingArea gettingArea)
        {
            return gettingArea.GetArea();
        }
    }

    public interface IGettingArea
    {
        int GetArea();
    }

    public class Rectangle : IGettingArea
    {
        public virtual int Width
        { get; set; }

        public virtual int Height
        { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
