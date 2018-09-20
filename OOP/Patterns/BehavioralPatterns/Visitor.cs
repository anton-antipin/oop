// 1. позволяет определить операцию для объектов других классов без изменения этих классов
// 2.   - когда имеется много объектов разнородных классов с разными интерфейсами и требуется выполнить ряд операций
//      над каждым из этих объектов
//      - когда классам необходимо добавить одинаковый набор операций без изменения этих классов
//      - когда часто добавляются новые операции к классам при этом общая структура классов стабильна
//      и практически не изменяется
// 3.

using System.Collections.Generic;
using System.Text;

namespace OOP.Patterns.BehavioralPatterns.Visitor
{
    #region Template
    // интерфейс и его реализация для посещения
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
        public string SomeState { get; set; }
    }
    class ElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementA(this);
        }

        public void OperationA()
        {

        }
    }
    class ElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementB(this);
        }

        public void OperationB()
        {

        }
    }

    // интерфейс посетителя и конкретные реализации 
    abstract class Visitor
    {
        public abstract void VisitElementA(ElementA element);
        public abstract void VisitElementB(ElementB element);
    }
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitElementA(ElementA element)
        {
            element.OperationA();
        }

        public override void VisitElementB(ElementB element)
        {
            element.OperationB();
        }
    }
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitElementA(ElementA element)
        {
            element.OperationA();
        }

        public override void VisitElementB(ElementB element)
        {
            element.OperationB();
        }
    }

    class ObjectStructure
    {
        private List<Element> _elements = new List<Element>();
        public void Add(Element e)
        {
            _elements.Add(e);
        }

        public void Remove(Element e)
        {
            _elements.Remove(e);
        }

        public void Accept(Visitor visitor)
        {
            foreach (Element e in _elements)
                e.Accept(visitor);
        }
    }

    class Client
    {
        void Main()
        {
            ObjectStructure obj = new ObjectStructure();
            obj.Add(new ElementA());
            obj.Add(new ElementB());

            obj.Accept(new ConcreteVisitor1());
            obj.Accept(new ConcreteVisitor2());
        }
    }
    #endregion

    #region Serialization
    public interface IAccount
    {
        string Accept(IVisitor visitor);
    }
    public class Person : IAccount
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string Accept(IVisitor visitor)
        {
            return visitor.VisitPersonAcc(this);
        }
    }
    public class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public string Accept(IVisitor visitor)
        {
            return visitor.VisitCompanyAcc(this);
        }
    }

    public interface IVisitor
    {
        string VisitPersonAcc(Person acc);
        string VisitCompanyAcc(Company acc);
    }
    public class XMLVisitor : IVisitor
    {
        public string VisitPersonAcc(Person acc)
        {
            string result;
            result = "<xml><Person><Name>" + acc.Name + "</Name>";
            result += "<Number>" + acc.Number + "</Number></Person></xml>";
            return result;
        }

        public string VisitCompanyAcc(Company acc)
        {
            string result;
            result = "<xml><Company><Name>" + acc.Name + "</Name>";
            result += "<RegNumber>" + acc.Number + "</RegNumber>";
            result += "<Number>" + acc.Number + "</Number></Company></xml>";
            return result;
        }
    }
    public class CSVVisitor : IVisitor
    {
        public string VisitPersonAcc(Person acc)
        {
            string result;
            result = "Name-" + acc.Name + ";";
            result += "Number-" + acc.Number + ";";
            return result;
        }

        public string VisitCompanyAcc(Company acc)
        {
            string result;
            result = "Name-" + acc.Name + ";";
            result += "RegNumber-" + acc.Number + ";";
            result += "Number-" + acc.Number + ";";
            return result;
        }
    }

    public class Bank
    {
        private List<IAccount> _accounts = new List<IAccount>();

        public void Add(IAccount account)
        {
            _accounts.Add(account);
        }

        public void Remove(IAccount account)
        {
            _accounts.Remove(account);
        }

        public string Accept(IVisitor visitor)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAccount account in _accounts)
                sb.AppendLine(account.Accept(visitor));
            return sb.ToString();
        }
    }

    public class V_Example
    {
        private static V_Example _instance;
        private static readonly object _syncObj = new object();

        private V_Example()
        {

        }

        public static V_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new V_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(IVisitor visitor)
        {
            Bank bank = new Bank();
            bank.Add(new Company() { Name = "1", RegNumber = "2", Number = "3" });
            bank.Add(new Person() { Name = "1", Number = "2" });

            return bank.Accept(visitor);
        }
    }
    #endregion
}
