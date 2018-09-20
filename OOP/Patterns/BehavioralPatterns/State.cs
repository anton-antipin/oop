// 1. позволяет объекту изменять свое поведение в зависимости от внутреннего состояния 
// 2.   - когда поведение объекта должно зависеть от его состояния и может изменяться динамически во время выполнения
//      - когда в коде методов объекта используются многочисленные уловия конструкции выбор которых зависит от текущего состояния
// 3. 

namespace OOP.Patterns.BehavioralPatterns.State
{
    #region Template
    // объект поведение которого должно динамически меняться
    class Context
    {
        public State State { get; set; }
        public Context(State state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }
    // интерфейс и реализация состояний
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }
    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    class Client
    {
        void Main()
        {
            Context context = new Context(new StateA());
            context.Request();
            context.Request();
        }
    }
    #endregion

    #region Water
    public interface IWaterState
    {
        string Heat(Water water);
        string Frost(Water water);
    }
    public class Water
    {
        public IWaterState WaterState { get; set; }
        public Water(IWaterState waterState)
        {
            WaterState = waterState;
        }

        public string Heat()
        {
            return WaterState.Heat(this);
        }

        public string Frost()
        {
            return WaterState.Frost(this);
        }
    }
    public class SolidWS : IWaterState
    {
        public string Heat(Water water)
        {
            string result;

            result = "Превращаем лёд в жидкость";
            water.WaterState = new LiquidWS();

            return result;
        }

        public string Frost(Water water)
        {
            string result;

            result = "Продолжаем заморозку льда";

            return result;
        }
    }
    public class LiquidWS : IWaterState
    {
        public string Heat(Water water)
        {
            string result;

            result = "Превращаем жидкость в пар";
            water.WaterState = new GassWS();

            return result;
        }

        public string Frost(Water water)
        {
            string result;

            result = "Превращаем жидкость в лёд";
            water.WaterState = new SolidWS();

            return result;
        }
    }
    public class GassWS : IWaterState
    {
        public string Heat(Water water)
        {
            string result;

            result = "Повышаем температуру водяного пара";

            return result;
        }

        public string Frost(Water water)
        {
            string result;

            result = "Превращаем водяной пар в жидкость";
            water.WaterState = new LiquidWS();

            return result;
        }
    }

    public class S_Example
    {
        private static S_Example _instance;
        private static readonly object _syncObj = new object();

        private S_Example()
        {

        }

        public S_Example Instance
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

        public string Main(Water water, bool heat)
        {
            string result;
            if (heat)
                result = water.Heat();
            else
                result = water.Frost();

            return result;
        }
    }
    #endregion
}
