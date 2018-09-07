using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.GeneratingPatterns.AbstractFatory;

namespace UnitTestProjectOOP.Patterns.GeneratingPatterns
{
    [TestClass]
    public class AbstractFatoryTest
    {
        [TestMethod]
        public void ElfNameIsNotModified()
        {
            string constName = "Эльф";
            Name name = new Elf();
            string result;

            result = name.HeroName();

            Assert.AreEqual(constName, result);
        }

        [TestMethod]
        public void VoinNameIsNotModified()
        {
            string constName = "Воин";
            Name name = new Voin();
            string result;

            result = name.HeroName();

            Assert.AreEqual(constName, result);
        }

        [TestMethod]
        public void ArbaletHitIsNotModified()
        {
            string constWeaponHit = "Стреляем из арбалета";
            Weapon weapon = new Arbalet();
            string result;

            result = weapon.Hit();

            Assert.AreEqual(constWeaponHit, result);
        }

        [TestMethod]
        public void SwordHitIsNotModified()
        {
            string constWeaponHit = "Бьем мечом";
            Weapon weapon = new Sword();
            string result;

            result = weapon.Hit();

            Assert.AreEqual(constWeaponHit, result);
        }

        [TestMethod]
        public void FlyMoveIsNotModified()
        {
            string constMovementMove = "Летим";
            Movement movement = new Fly();
            string result;

            result = movement.Move();

            Assert.AreEqual(constMovementMove, result);
        }

        [TestMethod]
        public void RunMoveIsNotModified()
        {
            string constMovementMove = "Бежим";
            Movement movement = new Run();
            string result;

            result = movement.Move();

            Assert.AreEqual(constMovementMove, result);
        }

        [TestMethod]
        public void ElfCompositeIsTrue()
        {
            HeroFactory heroFactory = new ElfFactory();
            Name nameResult;
            Weapon weaponResult;
            Movement movementResult;

            nameResult = heroFactory.CreateName();
            weaponResult = heroFactory.CreateWeapon();
            movementResult = heroFactory.CreateMovement();
            
            Assert.IsTrue(nameResult is Elf);
            Assert.IsTrue(weaponResult is Arbalet);
            Assert.IsTrue(movementResult is Fly);
        }

        [TestMethod]
        public void VoinCompositeIsTrue()
        {
            HeroFactory heroFactory = new VoinFactory();
            Name nameResult;
            Weapon weaponResult;
            Movement movementResult;

            nameResult = heroFactory.CreateName();
            weaponResult = heroFactory.CreateWeapon();
            movementResult = heroFactory.CreateMovement();

            Assert.IsTrue(nameResult is Voin);
            Assert.IsTrue(weaponResult is Sword);
            Assert.IsTrue(movementResult is Run);
        }

        [TestMethod]
        public void ElfHeroCompositeAreEqual()
        {
            string constResult = string.Format("Герой - {0}; Оружие - {1}; Движение - {2}.", new Elf().HeroName(), 
                                                                                                new Arbalet().Hit(), 
                                                                                                new Fly().Move());
            HeroFactory heroFactory = new ElfFactory();
            string result;

            result = AF_Example.Instance.Main(heroFactory);

            Assert.AreEqual(constResult, result);
        }

        [TestMethod]
        public void VoinHeroCompositeAreEqual()
        {
            string constResult = string.Format("Герой - {0}; Оружие - {1}; Движение - {2}.", new Voin().HeroName(),
                                                                                                new Sword().Hit(),
                                                                                                new Run().Move());
            HeroFactory heroFactory = new VoinFactory();
            string result;

            result = AF_Example.Instance.Main(heroFactory);

            Assert.AreEqual(constResult, result);
        }
    }
}
