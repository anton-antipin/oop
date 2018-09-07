using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.StructuralPatterns.Adapter;

namespace UnitTestProjectOOP.Patterns.StructuralPatterns
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void AutoDriveAreEqual()
        {
            string constResult = "Машина едет по дороге";
            ITransport transport = new Auto();
            string result;

            result = transport.Drive();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void CamelMoveAreEqual()
        {
            string constResult = "Верблюд идёт по пескам пустыни";
            IAnimal animal = new Camel();
            string result;

            result = animal.Move();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void AnimalToTransportAdapterIsNotModified()
        {
            IAnimal animal = new Camel();
            string constResult = animal.Move();
            string result;

            AnimalToTransportAdapter animalToTransportAdapter = new AnimalToTransportAdapter(animal);
            result = animalToTransportAdapter.Drive();

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void DriverTravelAutoIsNotModified()
        {
            ITransport transport = new Auto();
            string constResult = transport.Drive();
            string result;

            result = A_Example.Instance.Main(transport);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void DriverTravelCamelIsNotModified()
        {
            IAnimal animal = new Camel();
            string constResult = animal.Move();
            AnimalToTransportAdapter animalToTransportAdapter = new AnimalToTransportAdapter(animal);
            string result;

            result = A_Example.Instance.Main(animalToTransportAdapter);

            Assert.AreEqual(constResult, result);
        }
    }
}
