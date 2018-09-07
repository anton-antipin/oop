// 1. предоставляет объект-заместитель который управляет доступом к другому объекту
//      т.е. создается объект-суррогат который может выступать в роли другого объекта и замещать его
// 2.   - когда надо осуществлять взаимодействие по сети а объект-прокси должен имитировать поведение объекта
//      в другом адресном пространстве 
//      - когда нужно управлять доступом к ресурсу создание которого требует больших затрат
//      - когда необходимо разграничить доступ к вызываемому объекту в зависимости от прав вызывающего объекта
//      - когда нужно вести подсчет ссылок на объект и обеспечить потокобезопасную работу с реальным объектом
// 3. поскольку иногда будет выполняться сначала функциональность прокси, а потом функциональность реального объекта,
//      то это может привести к замедлению выполнения программы

namespace OOP.Patterns.StructuralPatterns.Proxy
{
    #region Template
    // определяет общий интерфейс 
    abstract class Subject
    {
        public abstract void Request();
    }
    // реальный объект
    class RealSubject : Subject
    {
        public override void Request()
        {
            
        }
    }
    // заместитель реального объекта
    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            if (_realSubject == null)
                _realSubject = new RealSubject();

            _realSubject.Request();
        }
    }

    class Client
    {
        public void Main()
        {
            Subject subject = new Proxy();
            subject.Request();
        }
    }
    #endregion
}
