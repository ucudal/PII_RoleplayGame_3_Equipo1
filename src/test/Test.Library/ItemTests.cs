using NUnit.Framework;
using RoleplayGame;
using System;


namespace Test.Library
{
    public class WandTest 
    {
         [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AttackValueTest() //Verifico el ataque de un item.
        {
            IAttackItem item = new Wand();
            Assert.AreEqual(55,item.AttackValue);
             
        }
        [Test]
        public void DefenseValueTest() //Verifico la defensa de un item.
        {
            IDefenseItem item = new Wand();
            Assert.AreEqual(80, item.DefenseValue);
        }
    }
}