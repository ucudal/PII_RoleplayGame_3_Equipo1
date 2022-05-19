using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    public class Viking : Enemies
    {
        public Viking(string name)
        : base(name)
        {            
            this.victorypoints = 9;
            this.AddItem(new Axe());
            this.AddItem(new Helmet());
        }

        public override int AttackValue
        {
            get
            {
                Random CriticalChance = new Random();
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;                    
                    }
                }
                if (CriticalChance.Next(1,11) <= 4)
                {
                    value = value * 2;
                    return value;
                    
                }
                else
                {
                    return value;
                }
            }
        }

        public override void ReceiveAttack(Character attacker)
        {
            Random DodgeChance = new Random();
            if (this.DefenseValue < attacker.AttackValue)
            {
                if (DodgeChance.Next(1,11) <= 2)
                {
                    Console.WriteLine($"{this.Name} ha esquivado un golpe de {attacker.AttackValue}⚔️");
                }
                else
                {                    
                    this.Health -= attacker.AttackValue - this.DefenseValue;
                }
            }
        }
    }
}