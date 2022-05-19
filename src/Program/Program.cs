using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");

            Assasin Talion = new Assasin("Talion");

            gimli.ReceiveAttack(Talion);
            Console.WriteLine($"Talion attacks Gimli with ⚔️ {Talion.AttackValue}");
            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            Talion.ReceiveAttack(gimli);
            Console.WriteLine($"gimli attacks Talion with ⚔️ {gimli.AttackValue}");
            Console.WriteLine($"Talion has ❤️ {Talion.Health}");

        }
    }
}
