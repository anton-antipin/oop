// 1. позволяет выносить внутреннее состояние объекта за его пределы для последующего возможного восстановления объекта
//      без нарушения принципа инкапсуляции 
// 2.   - когда нужно сохранить состояние объекта для возможного последующего восстановления
//      - когда сохранение состояния должно проходить без нарушений принципа инкапсуляции
// 3. если требуется сохранение большого объема информации то возрастут и издержки на хранение всего объема состояния

using System.Collections.Generic;

namespace OOP.Patterns.BehavioralPatterns.Memento
{
    #region Template
    // хранитель который сохраняет состояние Originator 
    class Memento
    {
        public string State { get; private set; }
        public Memento(string state)
        {
            State = state;
        }
    }

    // выполняет только функцию хранения
    class CareTaker
    {
        public Memento Memento { get; set; }
    }

    // создает объект хранитель для сохранения своего состояния
    class Originator
    {
        public string State { get; set; }
        public void SetMememnto(Memento memento)
        {
            State = memento.State;
        }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
    #endregion

    #region Game
    public class HeroMomento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMomento(int patrons, int lives)
        {
            Patrons = patrons;
            Lives = lives;
        }
    }

    public class Hero
    {
        private int _patrons;
        private int _lives;

        public Hero()
        {
            _patrons = 10;
            _lives = 5;
        }

        public string Shoot()
        {
            string result;
            if (_patrons > 0)
            {
                _patrons--;
                result = string.Format("Производим выстрел, осталось {0} патронов", _patrons);
            }
            else
                result = "Патронов больше нет";

            return result;
        }

        public HeroMomento SaveState()
        {
            return new HeroMomento(_patrons, _lives);
        }

        public void RestoreState(HeroMomento momento)
        {
            _patrons = momento.Patrons;
            _lives = momento.Lives;
        }
    }

    public class GameHistory
    {
        public Stack<HeroMomento> History { get; private set; }
        
        public GameHistory()
        {
            History = new Stack<HeroMomento>();
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

        public string Main(int countShoots, int countRestore)
        {
            Hero hero = new Hero();
            GameHistory gameHistory = new GameHistory();

            for (int i = 0; i < countShoots; ++i)
            {
                hero.Shoot();
                gameHistory.History.Push(hero.SaveState());
            }

            for(int i = 0; i < countRestore; ++i)
                hero.RestoreState(gameHistory.History.Pop());

            string result;
            result = hero.Shoot();

            return result;
        }
    }
    #endregion
}
