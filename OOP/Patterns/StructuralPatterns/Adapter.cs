// 1. для преобразования интерфейса одного класса в интерфейс другого 
// 2.   - когда необходимо использовать имеющийся класс, но его интерфейс не соответствует потребностям
//      - когда надо использовать уже существующий класс совместно с другими классами, интерфейсы которых не совместимы
// 3. 

namespace OOP.Patterns.StructuralPatterns.Adapter
{
    #region Template
    // объекты используются клиентом
    class Target
    {
        public virtual void Request()
        {

        }
    }
    // адаптируемый класс
    class Adaptee
    {
        public void SpecificRequest()
        {

        }
    }
    // адаптер для адаптируемого класса
    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }
    #endregion

    #region TransportExample
    public interface ITransport
    {
        string Drive();
    }
    public class Auto : ITransport
    {
        public string Drive()
        {
            return "Машина едет по дороге";
        }
    }

    public interface IAnimal
    {
        string Move();
    }
    public class Camel : IAnimal
    {
        public string Move()
        {
            return "Верблюд идёт по пескам пустыни";
        }
    }

    public class AnimalToTransportAdapter : ITransport
    {
        private IAnimal _animal;
        public AnimalToTransportAdapter(IAnimal animal)
        {
            _animal = animal;
        }

        public string Drive()
        {
            return _animal.Move();

        }
    }

    public class Driver
    {
        public string Travel(ITransport transport)
        {
            return transport.Drive();
        }
    }

    public class A_Example
    {
        private static A_Example _instance;
        private static object _synchrObj = new object();

        private A_Example()
        {

        }

        public static A_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new A_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(ITransport transport)
        {
            Driver driver = new Driver();
            return driver.Travel(transport);
        }
    }
    #endregion
}
