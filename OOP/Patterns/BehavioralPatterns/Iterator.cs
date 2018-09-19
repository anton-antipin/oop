// 1. предоставляет абстрактный интерфейс для последовательного доступа ко всем элементам составного объекта
//      без раскрытия его внутренней структуры
// 2.   - когда необходимо осуществить обход объекта без раскрытия его внутренней структуры
//      - когда имеется набор составных объектов и надо обеспечить единый интерфейс для их перебора
//      - когда необходимо предоставить несколько альтернативных вариантов перебора одного и того же объекта
// 3.

using System;
using System.Collections;

namespace OOP.Patterns.BehavioralPatterns.Iterator
{
    #region Template
    // определение интерфейса и реализации для обхода составных объектов
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object Current();
    }
    class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object returnValue = null;
            _current++;

            if (_current < _aggregate.Count)
                returnValue = _aggregate[_current];

            return returnValue;
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override object Current()
        {
            return _aggregate[_current];
        }
    }

    // интерфейс и реализация объекта итератора
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; }
        public abstract object this[int index] { get; set; }

    }
    class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _arrayList = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this); 
        }

        public override int Count
        {
            get
            {
                return _arrayList.Count;
            }            
        }

        public override object this[int index]
        {
            get
            {
                return _arrayList[index];
            }
            set
            {
                _arrayList.Insert(index, value);
            }
        }
    }

    class Client
    {
        void Main()
        {
            Aggregate aggregate = new ConcreteAggregate();

            Iterator iterator = aggregate.CreateIterator();

            object currentItem = iterator.First();
            while(!iterator.IsDone())
            {
                currentItem = iterator.Next();
            }
        }
    }
    #endregion

    #region I_Example
    public interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    public interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }

    public class Book
    {
        public string Name { get; set; }
    }
    public class Library : IBookNumerable
    {
        private Book[] _books;
        public Library()
        {
            _books = new[]
            {
                new Book() {Name = "Война и мир"},
                new Book() {Name = "Отцы и дети"},
                new Book() {Name = "Вишневый сад"}
            };
        }

        public int Count
        {
            get { return _books.Length; }
        }

        public Book this[int index]
        {
            get { return _books[index]; }
        }

        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }

    public class LibraryNumerator : IBookIterator
    {
        private IBookNumerable _bookNumerable;
        private int _index;

        public LibraryNumerator(IBookNumerable bookNumerable)
        {
            _bookNumerable = bookNumerable;
            _index = 0;
        }

        public bool HasNext()
        {
            return _index < _bookNumerable.Count;
        }

        public Book Next()
        {
            return _bookNumerable[_index++];
        }
    }
    
    public class Reader
    {
        public string SeeBook(Library library)
        {
            string result = "";
            IBookIterator bookIterator = library.CreateNumerator();
            while(bookIterator.HasNext())
            {
                Book book = bookIterator.Next();

                result = string.Format("{0}{1}{2}", result, Environment.NewLine, book.Name);
            }
            return result;
        }
    }

    public class I_Example
    {
        private static I_Example _instance;
        private static readonly object _syncObj = new object();

        private I_Example()
        {

        }

        public static I_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new I_Example();
                    }
                }
                return _instance;
            }
        }

        public string Main()
        {
            Library library = new Library();
            Reader reader = new Reader();

            return reader.SeeBook(library);
        }
    }
    #endregion
}
