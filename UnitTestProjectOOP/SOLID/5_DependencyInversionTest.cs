using System;
using OOP.SOLID._5_DependencyInversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectOOP.SOLID
{
    [TestClass]
    public class DependencyInversionTest
    {
        [TestMethod]
        public void BookTextIsNotModified()
        {
            string result = "text";
            Book book = new Book(null);

            book.Text = result;

            Assert.AreEqual(result, book.Text);
        }

        [TestMethod]
        public void BookPrinterIsNotModified()
        {
            IPrinter result = new ConsolePrinter();

            Book book = new Book(result);

            Assert.AreEqual(result, book.Printer);
        }

        [TestMethod]
        public void BookConsoleAreEqual()
        {
            IPrinter consolePrinter = new ConsolePrinter();
            string text = "long long text";
            string consoleResult = string.Format("Print console:{0}", text);
            string result;

            Book book = new Book(consolePrinter);
            book.Text = text;

            result = Example00.Instance.Main(book);

            Assert.AreEqual(consoleResult, result);
        }

        [TestMethod]
        public void BookHtmlAreEqual()
        {
            IPrinter htmlPrinter = new HtmlPrinter();
            string text = "long long text";
            string htmlResult = string.Format("Print html:{0}", text);
            string result;

            Book book = new Book(htmlPrinter);
            book.Text = text;

            result = Example00.Instance.Main(book);

            Assert.AreEqual(htmlResult, result);
        }
    }
}
