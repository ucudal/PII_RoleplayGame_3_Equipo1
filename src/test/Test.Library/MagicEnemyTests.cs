using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class MagicEnemyTests //Testeo de enemigo mágico.
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void AttackValueTest() //Verifico el ataque total de Witch con su respectivo item mágico.
        {
            Witch triss = new Witch("Triss");
            int attackvalue = triss.AttackValue;
            int expected = 55;

            Assert.AreEqual(expected,attackvalue);
        }
        
        [Test]
        public void AttackingTest() //Verifico el ataque de Witch a un Hero.
        {
            Witch triss = new Witch("Triss");
            Dwarf gimli = new Dwarf("Gimli");
            gimli.ReceiveAttack(triss);
            Assert.AreEqual(63,gimli.Health); // 100 - (55 (Wand de Witch) - 18 (Helmet de Dwarf))= 45
        }
         [Test]
        public void ReceiveAttackTest() //Verifico el ataque que recibe Witch con su respectivo item mágico.
        {
            Witch triss = new Witch("Triss");
            Dwarf steven = new Dwarf("Steven");
            IAttackItem axe = new Axe();
            steven.AddItem(axe);
            triss.ReceiveAttack(steven);
            Assert.AreEqual(100,triss.Health); // El item Wand brinda mayor defensa anulando el ataque de Steven.
        }
    }
}