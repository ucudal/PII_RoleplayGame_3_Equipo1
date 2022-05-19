using System.Collections.Generic;
namespace RoleplayGame
{
    public class Archer : Heroes
    {
        public Archer(string name)
        : base(name)
        { 
            this.AddItem(new Bow());
            this.AddItem(new Helmet());
        }
    }
}