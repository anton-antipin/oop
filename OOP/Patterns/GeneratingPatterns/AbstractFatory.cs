// 1. предоставляет интерфейс для создания семейств взаимосвязанных объектов с определенным интерфейсом
//      без указания конкретных типов данных объектов
// 2.   - когда система не должна зависеть от способа создания и компоновки новых объектов
//      - когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными 
// 3. возможности по расширению в данном паттерне имеют некоторые ограничения

namespace OOP.Patterns.GeneratingPatterns.AbstractFatory
{
    #region Template
    // определяют интерфейсы для классов объекты которых будут создаваться в программе
    abstract class AbstractProductA { }
    abstract class AbstractProductB { }

    // конкретные классы
    class ProductA1 : AbstractProductA { }
    class ProductA2 : AbstractProductA { }
    class ProductB1 : AbstractProductB { }
    class ProductB2 : AbstractProductB { }

    // определяет интерфейс создания абстрактных объектов
    abstract class AbstractFatory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    // конкретные классы фабрик
    class ConcreteFactory1 : AbstractFatory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    class ConcreteFactory2 : AbstractFatory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    // клиент который использует абстрактную фабрику и создает реальные объекты в абстрактные прототипы
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFatory abstractFatory)
        {
            _abstractProductA = abstractFatory.CreateProductA();
            _abstractProductB = abstractFatory.CreateProductB();
        }

        public void Run()
        {

        }
    }
    #endregion

    #region HeroExample
    public abstract class Name
    {
        public abstract string HeroName();
    }
    public class Elf : Name
    {
        public override string HeroName()
        {
            return "Эльф";
        }
    }
    public class Voin : Name
    {
        public override string HeroName()
        {
            return "Воин";
        }
    }

    public abstract class Weapon
    {
        public abstract string Hit();
    }
    public class Arbalet : Weapon
    {
        public override string Hit()
        {
            return "Стреляем из арбалета";
        }
    }
    public class Sword : Weapon
    {
        public override string Hit()
        {
            return "Бьем мечом";
        }
    }

    public abstract class Movement
    {
        public abstract string Move();
    }
    public class Fly : Movement
    {
        public override string Move()
        {
            return "Летим";
        }
    }
    public class Run : Movement
    {
        public override string Move()
        {
            return "Бежим";
        }
    }

    public abstract class HeroFactory
    {
        public abstract Name CreateName();
        public abstract Weapon CreateWeapon();
        public abstract Movement CreateMovement();
    }
    public class ElfFactory : HeroFactory
    {
        public override Name CreateName()
        {
            return new Elf();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }

        public override Movement CreateMovement()
        {
            return new Fly();

        }
    }
    public class VoinFactory : HeroFactory
    {
        public override Name CreateName()
        {
            return new Voin();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
        public override Movement CreateMovement()
        {
            return new Run();
        }
    }

    public class Hero
    {
        private Name _name;
        private Weapon _weapon;
        private Movement _movement;
        
        public Hero(HeroFactory heroFactory)
        {
            _name = heroFactory.CreateName();
            _weapon = heroFactory.CreateWeapon();
            _movement = heroFactory.CreateMovement();
        }
        public string Name()
        {
            return _name.HeroName();
        }
        public string Hit()
        {
            return _weapon.Hit();
        }
        public string Move()
        {
            return _movement.Move();
        }
    }
    
    public class AF_Example
    {
        private static AF_Example _instance;
        private static readonly object _synchrObj = new object();

        private AF_Example()
        {

        }

        public static AF_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new AF_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main(HeroFactory heroFactory)
        {
            Hero hero = new Hero(heroFactory);

            return string.Format("Герой - {0}; Оружие - {1}; Движение - {2}.", hero.Name(), hero.Hit(), hero.Move());
        }
    }
    #endregion
}
