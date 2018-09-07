// 1 open/closed principle
// 2 принцип открытости закрытости
// 3 сущности программы должны быть открыты для расширения но закрыты для изменения
// 4 система должна быть построена таким образом что все последующие изменения 
// должны быть реализованы с помощью добавления нового кода, а не изменения уже существующего

using System;

namespace OOP.SOLID._2_OpenClosed
{
    public class Example00
    {
        private static Example00 _instance;
        private static readonly object _synchrObj = new object();

        private Example00()
        {

        }

        public static Example00 Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new Example00();
                    }
                }
                return _instance;
            }
        }

        public string Main()
        {
            string result = "";
            Cook cook = new Cook("Dave");
            result = cook.MakeDinner(new PotatoMeal());
            return result;
        }
    }

    public class Cook
    {
        public Cook(string name)
        {
            Name = name;
        }

        public string Name
        { get; set; }

        public string MakeDinner(IMeal meal)
        {
            return meal.Make();
        }
    }

    public interface IMeal
    {
        string Make();
    }

    public class PotatoMeal : IMeal
    {
        public string Make()
        {
            string result = "";
            result = String.Format("{0} Чистим картошку {1}", result, Environment.NewLine);
            result = String.Format("{0} Ставим почищенную картошку на огонь {1}", result, Environment.NewLine);
            result = String.Format("{0} Сливаем остатки воды, разминаем варенный картофель в пюре {1}", result, Environment.NewLine);
            result = String.Format("{0} Посыпаем пюре специями и зеленью {1}", result, Environment.NewLine);
            result = String.Format("{0} Картофельное пюре готово {1}", result, Environment.NewLine);
            return result;
        }
    }
}
