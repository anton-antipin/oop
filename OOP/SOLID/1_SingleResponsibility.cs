// 1 single responsibility principle
// 2 принцип единственной обязанности
// 3 у класса должна быть одна причина для изменения
// 4 класс должен выполнять одну единственную задачу, должен быть целостным, обладать высокой связностью

using System;

namespace OOP.SOLID._1_SingleResponsibility
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

        public string Main(string text)
        {
            IPrinter printer = new StringPrinter();
            Report report = new Report();

            if (String.IsNullOrEmpty(text))
                report.Text = "Очень большой текст";
            else
                report.Text = text;

            return report.Print(printer);
        }
    }

    public class Report
    {
        public string Text
        {
            get;set;
        }

        public string GotoFirstPage()
        {
            return "Переход к первой странице";
        }

        public string GotoLastPage()
        {
            return "Переход к последней странице";
        }

        public string GotoPage(int pageNumber)
        {
            return String.Format("Переход к {0} странице", pageNumber);
        }

        //public string Print()
        //{
        //    return String.Format("Печать отчета: {0}", Text);
        //}

        public string Print(IPrinter printer)
        {
            return printer.Print(Text);
        }
    }

    public interface IPrinter
    {
        string Print(string text);
    }

    public class StringPrinter : IPrinter
    {
        public string Print(string text)
        {
            return String.Format("Печать отчета: {0}", text);
        }
    }
}
