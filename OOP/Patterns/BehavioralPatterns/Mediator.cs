// 1. обеспечивает взаимодействие множества объектов без необходимости ссылаться друг на друга
// 2.   - когда имеется множество взаимосвязанных объектов и связи между которыми сложны и запутаны
//      - когда необходимо повторно использовать объект, однако повторное использование затруднено 
//      в силу сильных связей с другими объектами
// 3. 

namespace OOP.Patterns.BehavioralPatterns.Mediator
{
    #region Template
    // интерфейс и реализация для взаимодействия с Colleague
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            if (Colleague1 == colleague)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }

    // интерфейс и реализация для взаимодействия с Mediator
    abstract class Colleague
    {
        protected Mediator _mediator;
        public Colleague(Mediator mediator)
        {
            _mediator = mediator;
        }
    }
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {

        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {

        }
    }
    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {

        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {

        }
    }
    #endregion

    #region Development
    public abstract class MediatorDev
    {
        public abstract string Send(string message, ColleagueDev colleagueDev);
    }
    public abstract class ColleagueDev
    {
        protected MediatorDev _mediatorDev;
        public ColleagueDev(MediatorDev mediatorDev)
        {
            _mediatorDev = mediatorDev;
        }

        public virtual string Send(string message)
        {
            return _mediatorDev.Send(message, this);
        }

        public abstract string Notify(string message);
    }

    public class CustomerCollegue : ColleagueDev
    {
        public CustomerCollegue(MediatorDev mediatorDev) : base(mediatorDev)
        {

        }

        public override string Notify(string message)
        {
            return string.Format("Сообщение заказчику - {0}", message);
        }
    }
    public class ProgrammerCollegue : ColleagueDev
    {
        public ProgrammerCollegue(MediatorDev mediatorDev) : base(mediatorDev)
        {

        }

        public override string Notify(string message)
        {
            return string.Format("Сообщение программисту - {0}", message);
        }
    }
    public class TesterCollegue : ColleagueDev
    {
        public TesterCollegue(MediatorDev mediatorDev) : base(mediatorDev)
        {

        }

        public override string Notify(string message)
        {
            return string.Format("Сообщение тестеру - {0}", message);
        }
    }

    public class ManagerMediator : MediatorDev
    {
        public ColleagueDev Customer { get; set; }
        public ColleagueDev Programmer { get; set; }
        public ColleagueDev Tester { get; set; }

        public override string Send(string message, ColleagueDev colleagueDev)
        {
            string result = "";
            if (Customer == colleagueDev)
                result = Programmer.Notify(message);
            else if (Programmer == colleagueDev)
                result = Tester.Notify(message);
            else if (Tester == colleagueDev)
                result = Customer.Notify(message);
            return result;
        }
    }

    public class M_Example
    {
        private static M_Example _instance;
        private static readonly object _syncObj = new object();

        private M_Example()
        {

        }

        public static M_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new M_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(ColleagueDev colleagueDev, string message)
        {
            //ManagerMediator mediator = new ManagerMediator();
            //ColleagueDev customer = new CustomerCollegue(mediator);
            //ColleagueDev programmer = new ProgrammerCollegue(mediator);
            //ColleagueDev tester = new TesterCollegue(mediator);

            //mediator.Customer = customer;
            //mediator.Programmer = programmer;
            //mediator.Tester = tester;

            //customer.Send("Есть заказ, надо сделать программу");
            //programmer.Send("Программа готова, надо протестировать");
            //tester.Send("Программа протестирована, готова к продаже");
            return colleagueDev.Send(message);
        }
    }
    #endregion
}
