using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class EnemyWithCriticalDamageTests //Testeo de enemigo con daño crítico (Critical Damage).
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AttackValueTestHighCriticalChanceTest() //Verifico el ataque total del Assasin si la probabilidad de daño crítico es alta.
        {
            Assasin talion = new Assasin("Talion");
            talion.ChangeCriticalChance(10);
            int attackvalue = talion.AttackValue;
            int expected = 30*2;

            Assert.AreEqual(expected,attackvalue);
        }

        [Test]
        public void AttackValueLowCriticalChanceTest() //Verifico el ataque total del Assasin si la probabilidad de daño crítico es baja.
        {
            Assasin talion = new Assasin("Talion");
            talion.ChangeCriticalChance(0);
            int attackvalue = talion.AttackValue;
            int expected = 30;

            Assert.AreEqual(expected,attackvalue);
        }
         [Test]
        public void ReceiveAttackTest() //Verifico el ataque que recibe Assasin.
        {
            Assasin talion = new Assasin("Talion");
            talion.ChangeCriticalChance(1);
            Dwarf steven = new Dwarf("Steven");
            IAttackItem axe = new Axe();
            steven.AddItem(axe);
            talion.ReceiveAttack(steven);
            Assert.AreEqual(65,talion.Health);
        }

    }
}