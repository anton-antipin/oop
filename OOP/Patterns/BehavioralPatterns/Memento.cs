// 1. позволяет выносить внутреннее состояние объекта за его пределы для последующего возможного восстановления объекта
//      без нарушения принципа инкапсуляции 
// 2.   - когда нужно сохранить состояние объекта для возможного последующего восстановления
//      - когда сохранение состояния должно проходить без нарушений принципа инкапсуляции
// 3. если требуется сохранение большого объема информации то возрастут и издержки на хранение всего объема состояния

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

    #endregion
}
