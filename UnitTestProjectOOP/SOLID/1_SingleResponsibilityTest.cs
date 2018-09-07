using System;
using OOP.SOLID._1_SingleResponsibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectOOP.SOLID
{
    [TestClass]
    public class SingleResponsibilityTestTest
    {
        [TestMethod]
        public void TextAsPropertyIsNotModified()
        {
            string text = "Очень большой текст";
            Report report = new Report();

            report.Text = text;

            Assert.AreEqual(text, report.Text);
        }

        [TestMethod]
        public void GotoFirstPageAreEqual()
        {
            string example = "Переход к первой странице";
            string result;
            Report report = new Report();

            result = report.GotoFirstPage();

            Assert.AreEqual(example, result);
        }

        [TestMethod]
        public void GotoLastPageAreEqual()
        {
            string example = "Переход к последней странице";
            string result;
            Report report = new Report();

            result = report.GotoLastPage();

            Assert.AreEqual(example, result);
        }

        [TestMethod]
        public void GotoPageAreEqual()
        {
            string example = "Переход к 5 странице";
            string result;
            int page = 5;
            Report report = new Report();

            result = report.GotoPage(page);

            Assert.AreEqual(example, result);
        }

        [TestMethod]
        public void StringPrinterPrintAreEqual()
        {
            string example = "Печать отчета: очень большой текст";
            string result;
            StringPrinter printer = new StringPrinter();

            result = printer.Print("очень большой текст");

            Assert.AreEqual(example, result);
        }

        [TestMethod]
        public void ReporterPrintAreEqual()
        {
            string example = "Печать отчета: Очень большой текст";
            string result;

            result = Example00.Instance.Main("Очень большой текст");

            Assert.AreEqual(example, result);
        }
    }
}
