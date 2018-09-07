// 1 dependency inversion principle
// 2 принцип инверсии зависимостей
// 3 модули верхнего уровня не должны зависеть от модулей нижнего уровня - и те и другие должны зависеть об абстракций;
// абстракции не должны зависеть от деталей - детали должны зависеть от абстракций
// 4 служит для создания слабосвязанных сущностей, которые легко тестировать, модифицировать и обновлять

using System;

namespace OOP.SOLID._5_DependencyInversion
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
                if (_instance == null)
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

        public string Main(Book book)
        {
            return book.Print();
        }
    }

    public interface IPrinter
    {
        string Print(string text);
    }

    public class Book
    {
        public Book(IPrinter printer)
        {
            Printer = printer;
        }

        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        public string Print()
        {
            return Printer.Print(Text);
        }
    }

    public class ConsolePrinter : IPrinter
    {
        public string Print(string text)
        {
            return string.Format("Print console:{0}", text);
        }
    }

    public class HtmlPrinter : IPrinter
    {
        public string Print(string text)
        {
            return string.Format("Print html:{0}", text);
        }
    }
}
