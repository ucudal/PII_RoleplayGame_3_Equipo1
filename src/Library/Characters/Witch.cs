using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    public class Witch : MagicEnemy
    {
        public Witch(string name)
        :base (name)
        {
            this.victorypoints = 20;
            this.AddItem(new Wand());

        }
        
    }
}
