using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard : MagicHero
    {
        public Wizard(string name)
        : base(name)
        {
            this.AddItem(new Staff());
        }
    }
}