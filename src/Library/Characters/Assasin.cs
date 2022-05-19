using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    public class Assasin : Enemies
    {
        private int criticalstrike =4;
        private int dodge = 2;
        public Assasin(string name)
        : base(name)
        {
            this.victorypoints = 12;
            this.AddItem(new Dagger());
            this.AddItem(new LeatherArmor());
        }

        public int criticalStrike
        {
            get
            {
                return this.criticalstrike;
            }
            private set
            {
                this.criticalstrike = value;
            }
        }
        public int Dodge
        {
            get
            {
                return this.dodge;
            }
            private set
            {
                this.dodge = value;
            }
        }
        public void ChangeCriticalChance(int value)
        {
            this.criticalStrike = value;
        }

        public void ChangeDodgeChance(int value)
        {
            this.Dodge = value;
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
                if (CriticalChance.Next(1,11) <= criticalStrike)
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
                if (DodgeChance.Next(1,11) <= Dodge)
                {
                    Console.WriteLine($"{this.Name} has dodged an attack from {attacker.AttackValue}⚔️");
                }
                else
                {                    
                    this.Health -= attacker.AttackValue - this.DefenseValue;
                }
            }
        }
    }
}