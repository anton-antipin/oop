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

    #endregion
}
