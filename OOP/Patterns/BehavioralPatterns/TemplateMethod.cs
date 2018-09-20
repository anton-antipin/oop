// 1. оперделяет общий алгоритм поведения подклассов, позволяя им переопределять отдельные шаги этого алгоритма 
//      без изменения структуры
// 2.   - когда планируется что в будущем подклассы должны будут переопределять различные этапы алгоритма 
//      без изменения его структуры
//      - когда в классах реализующих схожий алгоритм происходит дублирование кода
// 3.

using System.Text;

namespace OOP.Patterns.BehavioralPatterns.TemplateMethod
{
    #region Template
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }

        public abstract void Operation1();
        public abstract void Operation2();
    }

    class ConcreteClass : AbstractClass
    {
        public override void Operation1()
        {
            
        }

        public override void Operation2()
        {
            
        }
    }
    #endregion

    #region Education
    public abstract class Education
    {
        public string Learn()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Enter());
            sb.AppendLine(Study());
            sb.AppendLine(PassExams());
            sb.AppendLine(GetDocument());

            return sb.ToString();
        }

        public abstract string Enter();
        public abstract string Study();
        public virtual string PassExams()
        {
            return "Сдаем выпускные экзамены";
        }
        public abstract string GetDocument();
    }
    public class School : Education
    {
        public override string Enter()
        {
            return "Идем в первый класс";
        }
        public override string Study()
        {
            return "Посещаем уроки";
        }
        public override string GetDocument()
        {
            return "Получаем аттестат";
        }
    }
    public class University : Education
    {
        public override string Enter()
        {
            return "Сдаем вступительные экзамены";
        }
        public override string Study()
        {
            return "Посещаем пары";
        }
        public override string PassExams()
        {
            return "Сдаем экзамен по специальности";
        }
        public override string GetDocument()
        {
            return "Получаем диплом";
        }
    }

    public class TM_Example
    {
        private static TM_Example _instance;
        private static readonly object _syncObj = new object();

        private TM_Example()
        {

        }

        public TM_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new TM_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(Education education)
        {
            return education.Learn();
        }
    }
    #endregion
}
