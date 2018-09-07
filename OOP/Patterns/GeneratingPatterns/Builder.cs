// 1. инкапсулирует создание объекта и позволяет разделить его на различные этапы
// 2.   - когда процесс создания нового объекта не должен зависеть от того 
//          из каких частей этот объект состоит и как эти части связаны между собой
//      - когда необходимо обеспечить получение различных вариаций объекта в процессе создания 
// 3. 

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Patterns.GeneratingPatterns.Builder
{
    #region Template
    // объект, который должен быть создан
    class Product
    {
        private readonly List<string> _parts = new List<string>();
        
        public void AddPart(string part)
        {
            _parts.Add(part);
        }
    }

    // интерфейс для создания различных частей объекта
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();

    }
    class ConcreteBuilder : Builder
    {
        private readonly Product _product = new Product();

        public override void BuildPartA()
        {
            _product.AddPart("Part A");
        }
        public override void BuildPartB()
        {
            _product.AddPart("Part B");
        }
        public override void BuildPartC()
        {
            _product.AddPart("Part C");
        }
        public override Product GetResult()
        {
            return _product;
        }
    }

    // распорядитель, который использует интерфейс для создания объекта
    class Director
    {
        private readonly Builder _buider;
        public Director(Builder builder)
        {
            _buider = builder;
        }
        public void Construct()
        {
            _buider.BuildPartA();
            _buider.BuildPartB();
            _buider.BuildPartC();

        }
    }

    class Client
    {
        public void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();

            Product product = builder.GetResult();
        }
    }
    #endregion

    #region BackerExample
    public class Flour
    {
        public string Sort { get; set; }
    }
    public class Salt
    {
        public string What { get; set; }
    }
    public class Addivitive
    {
        public string Name { get; set; }
    }

    public class Bread
    {
        public string Name { get; set; }
        public Flour Flour { get; set; }
        public Salt Salt { get; set; }
        public Addivitive Addivitive { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Хлеб {0}:{1}", Name, Environment.NewLine);

            if (Flour != null)
                sb.AppendFormat("Мука - {0}{1}", Flour.Sort, Environment.NewLine);
            if (Salt != null)
                sb.AppendFormat("Соль - {0}{1}", Salt.What, Environment.NewLine);
            if (Addivitive != null)
                sb.AppendFormat("Добавки - {0}{1}", Addivitive.Name, Environment.NewLine);

            return sb.ToString();
        }
    }

    public abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }

        public abstract void SetName();
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAddivitive();
    }
    public class RyeBreadBuilder : BreadBuilder
    {
        public override void SetName()
        {
            this.Bread.Name = "Ржаной";
        }
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour() { Sort = "ржаная, 1 сорт" };
        }
        public override void SetSalt()
        {
            this.Bread.Salt = new Salt() { What = "обычная" };
        }
        public override void SetAddivitive()
        {
            
        }
    }
    public class WheatBreadBuilder : BreadBuilder
    {
        public override void SetName()
        {
            this.Bread.Name = "Пшеничный";
        }
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour() { Sort = "пшеничная, 1 сорт" };
        }
        public override void SetSalt()
        {
            this.Bread.Salt = new Salt() { What = "обычная" };
        }
        public override void SetAddivitive()
        {
            this.Bread.Addivitive = new Addivitive() { Name = "улучшитель хлебопекарный" };
        }
    }

    public class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();

            breadBuilder.SetName();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAddivitive();

            return breadBuilder.Bread;
        }
    }

    public class B_Example
    {
        private static B_Example _instance;
        private static readonly object _synchrObj = new object();

        private B_Example()
        {

        }

        public static B_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new B_Example();
                    }
                }
                return _instance;
            }
        } 

        public string Main(BreadBuilder breadBuilder)
        {
            Baker baker = new Baker();
            Bread bread = baker.Bake(breadBuilder);
            return bread.ToString();
        }
    }
    #endregion
}
