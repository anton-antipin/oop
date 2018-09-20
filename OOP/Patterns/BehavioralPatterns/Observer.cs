// 1. представляет поведенческий шаблон проектирования который использует отношение один ко многим
//      при изменении наблюдаемого объекта автоматически происходит оповещение всех наблюдателей
//      publisher - subscriber (издатель-подписчик)
// 2.   - когда система состоит из множества классов объекты которых должны находится в согласованном состоянии
//      - когда общая схема взаимодействия объектов предполагает две стороны (одна рассылает сообщения и является главным 
//      другая получает сообщения и реагирует на них)
//      - когда существует один объект рассылающий сообщения и множество подписчиков, которые получают сообщения
// 3.

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Patterns.BehavioralPatterns.Observer
{
    #region Template
    // интерфейс наблюдаемого объекта
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    // интерфейс наблюдателя
    interface IObserver
    {
        void Update();
    }

    class ConcreteObservable : IObservable
    {
        private List<IObserver> _observers;
        public ConcreteObservable()
        {
            _observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
                o.Update();
        }
    }
    class ConcreteObserver : IObserver
    {
        public void Update()
        {

        }
    }
    #endregion

    #region StockExchange
    public interface IObserverSE
    {
        string Update(object o);
    }
    public interface IObservableSE
    {
        void RegisterObserver(IObserverSE o);
        void RemoveObserver(IObserverSE o);
        string NotifyObservers();
    }

    public class StockInfo
    {
        public int USD { get; set; }
        public int EU { get; set; }
    }
    public class Stock : IObservableSE
    {
        private StockInfo _stockInfo;
        private List<IObserverSE> _observers;

        public Stock()
        {
            _stockInfo = new StockInfo();
            _observers = new List<IObserverSE>();
        }

        public void RegisterObserver(IObserverSE o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserverSE o)
        {
            _observers.Remove(o);
        }

        public string NotifyObservers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (IObserverSE o in _observers)
                stringBuilder.AppendLine(o.Update(_stockInfo));

            return stringBuilder.ToString();
        }

        public string Market(int eu, int usd)
        {
            //Random rnd = new Random();
            //_stockInfo.USD = rnd.Next(50, 100);
            //_stockInfo.EU = rnd.Next(50, 100);
            _stockInfo.USD = usd;
            _stockInfo.EU = eu;

            string result;
            result = NotifyObservers();
            return result;
        }
    }
    public class Broker : IObserverSE
    {
        private IObservableSE _stock;
        public string Name { get; set; }
        
        public Broker(string name, IObservableSE observable)
        {
            Name = name;
            _stock = observable;
            _stock.RegisterObserver(this);
        }

        public string Update(object o)
        {
            StockInfo stockInfo = (StockInfo)o;

            string result;
            if (stockInfo.USD > 70)
                result = string.Format("Брокер {0} продает доллары", Name);
            else
                result = string.Format("Брокер {0} покупает доллары", Name);

            return result;
        }

        public void StopTrade()
        {
            _stock.RemoveObserver(this);
            _stock = null;
        }
    }
    public class Bank : IObserverSE
    {
        private IObservableSE _stock;
        public string Name { get; set; }

        public Bank(string name, IObservableSE observable)
        {
            Name = name;
            _stock = observable;
            _stock.RegisterObserver(this);
        }

        public string Update(object o)
        {
            StockInfo stockInfo = (StockInfo)o;

            string result;
            if (stockInfo.EU > 70)
                result = string.Format("Банк {0} продает евро", Name);
            else
                result = string.Format("Банк {0} покупает евро", Name);

            return result;
        }
    }

    public class O_Example
    {
        private static O_Example _instance;
        private static readonly object _syncObj = new object();

        private O_Example()
        {

        }

        public static O_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new O_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(Stock stock, int usd, int eu)
        {
            Bank bank = new Bank("ЮС", stock);
            Broker broker = new Broker("Б", stock);

            string result;
            result = stock.Market(eu, usd);
            return result;
        }
    }
    #endregion
}
