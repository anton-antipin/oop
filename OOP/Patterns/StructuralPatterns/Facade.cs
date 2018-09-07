// 1. позволяет скрыть сложность системы с помощью представления упращенного интерфеса для взаимодествия с ней
// 2.   - когда имеется сложная система и необходимо упростить с ней работу
//      (фасад позволяет определить одну точку взаимодействия между клиентом и системой)
//      - когда надо уменьшить количество зависимостей между клиентом и сложной системой
//      (фасадные объекты позволяют отделить изолировать компоненты системы от клиента и развивать и работать с ними независимо)
//      - когда нужно определить подсистемы компонентов в сложной системе
//      (создание фасадов для компонентов каждой отдельной подсистемы позволит упростить взаимодействие между ними и повысить их независимость друг от друга)
// 3.

using System.Text;

namespace OOP.Patterns.StructuralPatterns.Facade
{
    #region Template
    // компоненты сложной подсистемы
    class SubsystemA
    {
        public void A1() { }
    }
    class SubsystemB
    {
        public void B1() { }
    }
    class SubsystemC
    {
        public void C1() { }
    }
    // фасад, предоставляющий интерфейс клиенту для работы с компонентами
    class Facade
    {
        private SubsystemA _subsystemA;
        private SubsystemB _subsystemB;
        private SubsystemC _subsystemC;

        public Facade(SubsystemA subsystemA, SubsystemB subsystemB, SubsystemC subsystemC)
        {
            _subsystemA = subsystemA;
            _subsystemB = subsystemB;
            _subsystemC = subsystemC;
        }

        public void Operation1()
        {
            _subsystemA.A1();
            _subsystemB.B1();
            _subsystemC.C1();
        }

        public void Operation2()
        {
            _subsystemB.B1();
            _subsystemC.C1();
        }
    }

    class Client
    {
        public void Main()
        {
            Facade facade = new Facade(new SubsystemA(), new SubsystemB(), new SubsystemC());
            facade.Operation1();
            facade.Operation2();
        }
    }
    #endregion

    #region IDE
    public class TextEditor
    {
        public string CreateCode()
        {
            return "Написание кода";
        }

        public string SaveCode()
        {
            return "Сохранение кода";
        }
    }
    public class Compilier
    {
        public string Compile()
        {
            return "Компиляция приложения";
        }
    }
    public class CLR
    {
        public string Execute()
        {
            return "Выполнение приложения";
        }

        public string Finish()
        {
            return "Завершение работы приложения";
        }
    }

    public class IDEFacade
    {
        private TextEditor _textEditor;
        private Compilier _compilier;
        private CLR _clr;

        public IDEFacade(TextEditor textEditor, Compilier compilier, CLR clr)
        {
            _textEditor = textEditor;
            _compilier = compilier;
            _clr = clr;
        }

        public string Start()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(_textEditor.CreateCode());
            stringBuilder.Append(_textEditor.SaveCode());
            stringBuilder.Append(_compilier.Compile());
            stringBuilder.Append(_clr.Execute());
            return stringBuilder.ToString();
        }

        public string Finish()
        {
            return _clr.Finish();
        }
    }

    public class F_Example
    {
        private static F_Example _instance;
        private static readonly object _syncObj = new object();

        private F_Example()
        {

        }

        public static F_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null) 
                            _instance = new F_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(IDEFacade facade)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(facade.Start());
            stringBuilder.Append(facade.Finish());
            return stringBuilder.ToString();
        }
    }
    #endregion
}
