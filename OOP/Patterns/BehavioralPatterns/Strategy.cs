// 1. определяет набор алгоритмов, инкапсулирует каждый из них и обеспечивает их взаимосвязь
// 2.   - когда есть несколько родственных классов, которые отличаются поведением
//      - когда необходимо обеспечить выбор из нескольких вариантов алгоритмов, которые можно менять в зависимости от условия
//      - когда необходимо менять поведение объектов на стадии выполнения программы
//      - когда класс применяющий определенную функциональность ничего не должен знать о ее реализации
// 3. 

namespace OOP.Patterns.BehavioralPatterns.Strategy
{
    #region Template
    // интерфейс и реализация алгоритма
    interface IStrategy
    {
        void Algorithm();
    }
    class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {

        }
    }
    class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {

        }
    }

    class Context
    {
        public IStrategy Strategy { get; set; }

        public Context(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public void ExecuteAlgorithm()
        {
            Strategy.Algorithm();
        }
    }
    #endregion

    #region Car
    public interface IMovable
    {
        string Move();
    }
    public class PetrolMove : IMovable
    {
        public string Move()
        {
            return "Перемещение на бензине";
        }
    }
    public class ElectricMove : IMovable
    {
        public string Move()
        {
            return "Перемещение на электричестве";
        }
    }

    public class Car
    {
        private int _pass;
        private string _model;

        public IMovable Movable { get; set; }
        public Car(string model, int pass, IMovable movable)
        {
            _model = model;
            _pass = pass;
            Movable = movable;
        }

        public string Move()
        {
            return Movable.Move();
        }
    }

    public class S_Example
    {
        private static S_Example _instance;
        private static readonly object _syncObj = new object();

        private S_Example()
        {

        }

        public static S_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new S_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(string model, int pass, IMovable movable)
        {
            Car car = new Car(model, pass, movable);
            return car.Move();
        }
    }
    #endregion
}
