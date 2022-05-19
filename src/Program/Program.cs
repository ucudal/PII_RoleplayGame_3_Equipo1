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

            Assasin talion = new Assasin("Talion");

            talion.ReceiveAttack(gimli);
            Console.WriteLine($"Gimli attacks Talion with ⚔️ {gimli.AttackValue}");
            Console.WriteLine($"Talion has ❤️ {talion.Health}");

            gimli.ReceiveAttack(talion);
            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        }
    }
}
