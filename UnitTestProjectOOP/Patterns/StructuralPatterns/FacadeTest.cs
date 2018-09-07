using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.StructuralPatterns.Facade;

namespace UnitTestProjectOOP.Patterns.StructuralPatterns
{
    [TestClass]
    public class FacadeTest
    {
        [TestMethod]
        public void TextEditorCreateCodeAreEqual()
        {
            string constResult = "Написание кода";
            TextEditor component = new TextEditor();
            string result;

            result = component.CreateCode();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void TextEditorSaveCodeAreEqual()
        {
            string constResult = "Сохранение кода";
            TextEditor component = new TextEditor();
            string result;

            result = component.SaveCode();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CompilierCompileAreEqual()
        {
            string constResult = "Компиляция приложения";
            Compilier component = new Compilier();
            string result;

            result = component.Compile();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CLRExecuteAreEqual()
        {
            string constResult = "Выполнение приложения";
            CLR component = new CLR();
            string result;

            result = component.Execute();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CLRFinishAreEqual()
        {
            string constResult = "Завершение работы приложения";
            CLR component = new CLR();
            string result;

            result = component.Finish();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void IDEFacadeStartAreEqual()
        {
            TextEditor textEditor = new TextEditor();
            Compilier compilier = new Compilier();
            CLR clr = new CLR();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(textEditor.CreateCode());
            stringBuilder.Append(textEditor.SaveCode());
            stringBuilder.Append(compilier.Compile());
            stringBuilder.Append(clr.Execute());

            string constResult = stringBuilder.ToString();
            IDEFacade component = new IDEFacade(textEditor, compilier, clr);
            string result;

            result = component.Start();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void IDEFacadeFinishAreEqual()
        {
            TextEditor textEditor = new TextEditor();
            Compilier compilier = new Compilier();
            CLR clr = new CLR();

            string constResult = clr.Finish();
            IDEFacade component = new IDEFacade(textEditor, compilier, clr);
            string result;

            result = component.Finish();

            Assert.AreEqual(constResult, result);
        }

    }
}
