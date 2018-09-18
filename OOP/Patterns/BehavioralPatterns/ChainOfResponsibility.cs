// 1. позволяет избежать жесткой привязки отправителя запроса к получателю, позволяя нескольким объектам обработать запрос
//      каждый объект при получении запроса выбирает либо обработать запрос, либо передать выполнение запроса следующему по цепочке
// 2.   - когда имеется более одного объекта, который может обработать определенный запрос
//      - когда надо передать запрос на выполнение одному из нескольких объектов, точно не определяя какому именно объекту
//      - когда набор объектов задается динамически
// 3. никто не гарантирует, что запрос в конечном итоге будет обработан

namespace OOP.Patterns.BehavioralPatterns.ChainOfResponsibility
{
    #region Template
    // интерфейс для обработки запроса
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(int condition);
    }
    // конкретные обработчики
    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int condition)
        {
            if(condition == 1)
            {

            }
            else if(Successor != null)
            {
                Successor.HandleRequest(condition);
            }
        }
    }
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int condition)
        {
            if(condition == 2)
            {

            }
            else if(Successor != null)
            {
                Successor.HandleRequest(condition);
            }
        }
    }

    class Client
    {
        public void Main()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();

            h1.Successor = h2;

            h1.HandleRequest(2);
        }
    }
    #endregion

    #region PayTransfer
    public class Receiver
    {
        public bool BankTransfer { get; set; }
        public bool MoneyTransfer { get; set; }
        public bool PayPalTransfer { get; set; }

        public Receiver(bool bankTransfer, bool moneyTransfer, bool payPalTransfer)
        {
            BankTransfer = bankTransfer;
            MoneyTransfer = moneyTransfer;
            PayPalTransfer = payPalTransfer;
        }
    }

    public abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract string Handle(Receiver receiver);
    }
    public class BankPaymentHandler : PaymentHandler
    {
        public override string Handle(Receiver receiver)
        {
            string result = "";
            if (receiver.BankTransfer)
                result = "Выполняем банковский перевод";
            else if (Successor != null)
                result = Successor.Handle(receiver);

            return result;
        }
    }
    public class MoneyPaymentHandler : PaymentHandler
    {
        public override string Handle(Receiver receiver)
        {
            string result = "";

            if (receiver.MoneyTransfer)
                result = "Выполняем перевод через системы денежных переводов";
            else if (Successor != null)
                result = Successor.Handle(receiver);

            return result;
        }
    }
    public class PayPalPaymentHandler : PaymentHandler
    {
        public override string Handle(Receiver receiver)
        {
            string result = "";
            if (receiver.PayPalTransfer)
                result = "Выполняем перевод через PayPal";
            else if (Successor != null)
                result = Successor.Handle(receiver);

            return result;
        }
    }
    
    public class COF_Example
    {
        private static COF_Example _instance;
        private static readonly object _syncObj = new object();

        private COF_Example()
        {

        }

        public static COF_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new COF_Example();
                    }
                }

                return _instance;
            }
        }

        public string Main(Receiver receiver)
        {
            PaymentHandler generalHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
            PaymentHandler payPalPaymentHandler = new PayPalPaymentHandler();

            generalHandler.Successor = moneyPaymentHandler;
            moneyPaymentHandler.Successor = payPalPaymentHandler;

            return generalHandler.Handle(receiver);
        }
    }
    #endregion
}
