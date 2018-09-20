using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.TemplateMethod;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class TemplateMethodTest
    {
        [TestMethod]
        public void SchoolEnterAreEqual()
        {
            string constResult = "Идем в первый класс";
            Education education = new School();
            string result;

            result = education.Enter();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void SchoolStudyAreEqual()
        {
            string constResult = "Посещаем уроки";
            Education education = new School();
            string result;

            result = education.Study();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void SchoolPassExamsAreEqual()
        {
            string constResult = "Сдаем выпускные экзамены";
            Education education = new School();
            string result;

            result = education.PassExams();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void SchoolGetDocumentAreEqual()
        {
            string constResult = "Получаем аттестат";
            Education education = new School();
            string result;

            result = education.GetDocument();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void UniversityEnterAreEqual()
        {
            string constResult = "Сдаем вступительные экзамены";
            Education education = new University();
            string result;

            result = education.Enter();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void UniversityStudyAreEqual()
        {
            string constResult = "Посещаем пары";
            Education education = new University();
            string result;

            result = education.Study();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void UniversityPassExamsAreEqual()
        {
            string constResult = "Сдаем экзамен по специальности";
            Education education = new University();
            string result;

            result = education.PassExams();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void UniversityGetDocumentAreEqual()
        {
            string constResult = "Получаем диплом";
            Education education = new University();
            string result;

            result = education.GetDocument();

            Assert.AreEqual(constResult, result);
        }
    }
}
