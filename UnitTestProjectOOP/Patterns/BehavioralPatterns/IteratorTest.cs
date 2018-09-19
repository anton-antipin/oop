using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Iterator;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void BookNameIsNotModified()
        {
            string constName = "Тест";
            Book book = new Book() { Name = constName };
            string result;

            result = book.Name;

            Assert.AreEqual(constName, result);
        }

        [TestMethod]
        public void LibraryIsNotModified()
        {
            Library library = new Library();
            int contCount = 3;
            int resultCount = 0;
            IBookIterator iterator;
            string bookName1 = "Война и мир";
            string resultName1;
            string bookName2 = "Отцы и дети";
            string resultName2;
            string bookName3 = "Вишневый сад";
            string resultName3;

            resultCount = library.Count;
            iterator = library.CreateNumerator();
            resultName1 = library[0].Name;
            resultName2 = library[1].Name;
            resultName3 = library[2].Name;

            Assert.AreEqual(contCount, resultCount);
            Assert.IsTrue(iterator is LibraryNumerator);
            Assert.AreEqual(bookName1, resultName1);
            Assert.AreEqual(bookName2, resultName2);
            Assert.AreEqual(bookName3, resultName3);
        }

        [TestMethod]
        public void ReaderAreEqual()
        {
            string constResult = Environment.NewLine + "Война и мир" + Environment.NewLine + "Отцы и дети" + Environment.NewLine + "Вишневый сад";
            string result;

            result = I_Example.Instance.Main();

            Assert.AreEqual(constResult, result);
        }
    }
}
