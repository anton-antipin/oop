// 1. позволяет инкапсулировать запрос на выполнение определенного действия в виде определенного объекта
// 2.   - когда надо передавать в качестве параметров определенные действия вызываемые в ответ на другие действия 
//      - когда надо обеспечить выполнение очереди запросов, а также их возможную отмену
//      - когда надо поддерживать логирование изменений в результате запросов
// 3. 

namespace OOP.Patterns.BehavioralPatterns.Command
{
    #region Template
    // получатель команды
    class Receiver
    {
        public void Operation()
        {

        }
    }

    // интерфейс и конкретная реализация комманды
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
    class ConcreteCommand : Command
    {
        Receiver _receiver;
        public ConcreteCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public override void Execute()
        {
            _receiver.Operation();
        }

        public override void Undo()
        {
            
        }
    }

    // инициатор команды
    class Invoker
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void Run()
        {
            _command.Execute();
        }

        public void Cancel()
        {
            _command.Undo();
        }
    }

    class Client
    {
        void Main()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand concreteCommand = new ConcreteCommand(receiver);
            invoker.SetCommand(concreteCommand);
            invoker.Run();
        }
    }
    #endregion

    #region PultTV
    public interface ICommand
    {
        string Execute();
        string Undo();
        void SetObject(object obj);
    }

    public class TV 
    {
        public string On()
        {
            return "Телевизор включен";
        }

        public string Off()
        {
            return "Телевизор выключен";
        }
    }

    public class TVOnCommand : ICommand
    {
        private TV _tv;
        public TVOnCommand(TV tv)
        {
            _tv = tv;
        }

        public string Execute()
        {
            return _tv.On();
        }

        public string Undo()
        {
            return _tv.Off();
        }

        public void SetObject(object obj)
        {
            _tv = (TV)obj;
        }
    }

    public class Pult
    {
        private ICommand _command;
        public Pult(ICommand command)
        {
            _command = command;
        }

        public string PressButton()
        {
            return _command.Execute();
        }

        public string PressUndo()
        {
            return _command.Undo();
        }
    }

    public class C_Example
    {
        private static C_Example _instance;
        private static readonly object _syncObj = new object();

        private C_Example()
        {

        }

        public static C_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new C_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(ICommand command, bool on)
        {
            TV tv = new TV();
            command.SetObject(tv);

            Pult pult = new Pult(command);

            string result = "";
            if (on)
                result = pult.PressButton();
            else
                result = pult.PressUndo();

            return result;
        }
    }
    #endregion
}
