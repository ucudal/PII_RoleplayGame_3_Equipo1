using System.Collections.Generic;
using System;

namespace RoleplayGame
{
    public abstract class Character
    {                
        protected int health = 100;
        protected List<IItem> items = new List<IItem>();
        protected int victorypoints = 0;
        public string side{ get; protected set; }

        protected Character(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }


        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public int VictoryPoints
        {
            get
            {
                return this.victorypoints;
            }
            protected set
            {
                this.victorypoints = value < 0 ? 0 : value;
            }
        }

        public virtual int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        public virtual int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        public virtual void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public virtual void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }

        public virtual void Cure()
        {
            this.Health = 100;
        }

        public virtual void ReceiveAttack(Character attacker)
        {
            int damage = attacker.AttackValue;
            if (this.DefenseValue < damage)
            {
                this.Health -= damage - this.DefenseValue;
                //Console.WriteLine($"{attacker.Name} attacks {this.Name} with ⚔️ {damage}");
            }
        }
    }
}