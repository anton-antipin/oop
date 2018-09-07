// 1. позволяет создать объекты на основе уже ранее созданных объектов-прототипов
//      (т.е. по сути данный паттерн предлагает технику клонирования объектов)
// 2.   - когда конкретный тип создаваемого объекта должен определяться динамически во время выполнения
//      - когда нежелательно создание отдельной иерархии классов
//      - когда клонирование объекта является более предпочтительным вариантом нежели его создание и инициализация
// 3.


namespace OOP.Patterns.GeneratingPatterns.Prototype
{
    #region Template
    // определяет интерфейс для клонирования самого себя и конкретные реализации
    abstract class Prototype
    {
        public int Id { get; private set; }

        public Prototype(int id)
        {
            Id = id;
        }

        public abstract Prototype Clone();
    }
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }
    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {

        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }
    
    // создает объекты прототипов с помощью методов Clone 
    class Client
    {
        public void Operation()
        {
            Prototype prototype1 = new ConcretePrototype1(1);
            Prototype clone1 = prototype1.Clone();

            Prototype prototype2 = new ConcretePrototype2(2);
            Prototype clone2 = prototype2.Clone();
        }
    }
    #endregion

    #region FigureExample
    public interface IFigure
    {
        IFigure Clone();
        string GetInfo();
    }
    public class Rectangle : IFigure
    {
        private int _width;
        private int _height;
        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public IFigure Clone()
        {
            return new Rectangle(_width, _height);
        }
        public string GetInfo()
        {
            return string.Format("Прямоугольник длиной {0} и шириной {0}.", _height, _width);

        }
    }
    public class Circle : IFigure
    {
        private int _radius;

        public Circle(int radius)
        {
            _radius = radius;
        }

        public IFigure Clone()
        {
            return new Circle(_radius);
        }

        public string GetInfo()
        {
            return string.Format("Круг радиусом {0}", _radius);
        }
    }
    
    public class P_Example
    {
        private static P_Example _instance;
        private static object _synchrObj = new object();

        private P_Example()
        {

        }

        public static P_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                         
   _instance = new P_Example();
                    }
                }

                return _instance;
            }
        }

        public string Main(IFigure figure)
        {
            IFigure cloneObject = figure.Clone();
            return cloneObject.GetInfo();
        }
    }
    #endregion
}
