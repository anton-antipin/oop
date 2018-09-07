// 1. позволяет отделить абстракцию от реализации таким образом, чтобы и абстракцию и реализацию можно было изменять 
//      независимо друг от друга
// 2.   - когда надо избежать постоянной привязки абстракции к реализации
//      - когда наряду с реализацией надо изменять и абстракцию независимо друг от друга
// 3.

using System;

namespace OOP.Patterns.StructuralPatterns.Bridge
{
    #region Template
    // определяет базовый интерфейс для конкретных реализаций
    // как правило определяет только примитивные операции
    abstract class Implementor
    {
        public abstract void OperationImp();
    }
    // конкретные реализации
    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp()
        {
            
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
            
        }
    }

    // определяет базовый интерфейс и хранит ссылку на Implementor
    // как правило определяет более сложные операции, базирующиеся на Implementor 
    abstract class Abstraction
    {
        protected Implementor _implementor;

        public Abstraction(Implementor implementor)
        {
            _implementor = implementor;
        }

        public virtual void Operation()
        {
            _implementor.OperationImp();
        }
    }
    // уточненная абстракция
    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : base(implementor)
        {

        }

        public override void Operation()
        {
            
        }
    }

    class Client
    {
        public void Main()
        {
            Abstraction abstraction;
            abstraction = new RefinedAbstraction(new ConcreteImplementorA());
        }
    }
    #endregion

    #region Programmers
    public interface ILanguage
    {
        string Build();
        string Execute();
    }
    public class CPPLanguage : ILanguage
    {
        public string Build()
        {
            return "С помощью компилятора C++ компилируем программу в бинарный код";
        }

        public string Execute()
        {
            return "Запускаем исполняемый файл программы";
        }
    }
    public class CSharpLanguage : ILanguage
    {
        public string Build()
        {
            return "С помощью компилятора Roslyn компилируем исходный код в файл exe";
        }

        public string Execute()
        {
            string action1 = "JIT компилирует программу бинарный код";
            string action2 = "CLR выполняет скомпилированный бинарный код";
            return string.Format("{0}{1}{2}", action1, Environment.NewLine, action2);
        }
    }

    public abstract class Programmer
    {
        protected ILanguage _language;

        public Programmer(ILanguage language)
        {
            _language = language;
        }

        public virtual string DoWork()
        {
            string build = _language.Build();
            string execute = _language.Execute();
            return string.Format("{0}{1}{2}", build, Environment.NewLine, execute);
        }

        public abstract string EarnMoney();
    }
    public class Freelancer : Programmer
    {
        public Freelancer(ILanguage language) : base(language)
        {

        }

        public override string EarnMoney()
        {
            return "Получаем оплату за выполненный заказ";
        }
    }
    public class Corporater : Programmer
    {
        public Corporater(ILanguage language) : base(language)
        {

        }

        public override string EarnMoney()
        {
            return "Получаем в конце месяца зарплату";
        }
    }

    public class B_Example
    {
        private static B_Example _instance;
        private static readonly object _syncObj = new object();

        private B_Example()
        {

        }

        public static B_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new B_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(bool needFreelancer, ILanguage language)
        {
            Programmer programmer;
            if (needFreelancer)
                programmer = new Freelancer(language);
            else
                programmer = new Corporater(language);

            string doWork = programmer.DoWork();
            string earnMoney = programmer.EarnMoney();

            return string.Format("Работа:{0}{1}Оплата{2}{1}", doWork, Environment.NewLine, earnMoney);
        }
    }
    #endregion
}
