// 1. объединяет группы объектов в древовидную структуру по принципу "часть-целое" и 
//      позволяет клиенту одинаково работать как с отдельными объектами так и с группой объектов
// 2.   - когда объекты должны быть реализованы в виде иерархической древовидной структуры
//      - когда клиенты единообразно должны управлять как целыми объектами так и составными частями 
// 3.

using System.Collections.Generic;

namespace OOP.Patterns.StructuralPatterns.Composite
{
    #region Template
    // определяет интерфейс для все компонентов в древовидной структуре
    abstract class Component
    {
        private string _name;

        public Component(string name)
        {
            _name = name;
        }

        public abstract void Display();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
    }
    class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        public Composite(string name) : base(name)
        {

        }

        public override void Display()
        {
            foreach (Component component in _children)
                component.Display();
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }
    }
    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {

        }

        public override void Display()
        {
            
        }

        public override void Add(Component component)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new System.NotImplementedException();
        }
    }

    class Client
    {
        public void Main()
        {
            Component root = new Composite("root");
            Component leaf = new Leaf("leaf");
            Component subtree = new Composite("subtree");

            root.Add(leaf);
            root.Add(subtree);

            root.Display();
        }
    }
    #endregion

    #region FileSystem

    #endregion
}
