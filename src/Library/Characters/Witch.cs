using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    public class Witch : MagicEnemies
    {
        public Witch(string name)
        :base (name)
        {
            this.victorypoints = 20;
            this.AddItem(new Wand());

        }
        
    }
}
