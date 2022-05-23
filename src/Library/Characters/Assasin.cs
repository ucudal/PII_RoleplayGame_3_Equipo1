using System.Collections.Generic;
using System;
namespace RoleplayGame
{
    /// <summary>
    /// Clase creada aplicando Herencia, "Assasin" tiene todos los argumentos y funcionalidades de sus superclases "Character" y "Enemy".
    /// A su vez se utiliza un override para añadir un comportamiento especial en el método "RecieveAttack" y en la propiedad "AttackValue".
    /// </summary>
    public class Assasin : Enemy
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

        /// <summary>
        /// Método que permite cambiar la probabilidad de asestar un golpe crítico
        /// el "value" ingresado debe ser un número entero entre el 1 y el 10.
        /// </summary>
        /// <param name="value"></param>
        public void ChangeCriticalChance(int value)
        {
            this.criticalStrike = value;
        }

        /// <summary>
        /// Método que permite cambiar la probabilidad de esquivar el daño de un
        /// ataque el "value" ingresado debe ser un número entero entre el 1 y el 10.
        /// </summary>
        /// <param name="value"></param>
        public void ChangeDodgeChance(int value)
        {
            this.Dodge = value;
        }

        /// <summary>
        /// Propiedad modificada para añadir la posibilidad de causar un golpe critico,
        /// lo cual duplica el AttackValue del asesino. Para esto se crea una instancia
        /// de random, la cual devuelve un número al azar del 1 al 10 y si ese número
        /// es menor o igual al contenido en la propiedad "criticalStrike". el cual por 
        /// defecto es "4". Lo cual hace que la probabilidad por defecto de provocar un 
        /// golpe crítico sea del 40%.
        /// </summary>
        /// <value></value>
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
                /// <summary>
                /// Se compara si el número creado al azar es menor o igual al
                /// contenido en la propiedad "criticalStrike"
                /// </summary>
                /// <returns></returns>
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

        /// <summary>
        /// Método extendido mediante el override para agregar la funcionalidad
        /// de tener la posibilidad de esquivar el daño de un ataque. Para esto se crea una instancia
        /// de random, la cual devuelve un número al azar del 1 al 10 y si ese número
        /// es menor o igual al contenido en la propiedad "Dodge". el cual por 
        /// defecto es "2". Lo cual hace que la probabilidad por defecto de provocar un 
        /// golpe crítico sea del 20%.
        /// </summary>
        /// <param name="attacker"></param>
        public override void ReceiveAttack(Character attacker)
        {
            int damage = attacker.AttackValue;
            Random DodgeChance = new Random();
            
            if (this.DefenseValue < damage)
            {
                if (DodgeChance.Next(1,11) <= Dodge)
                {
                    Console.WriteLine($"{this.Name} has dodged an attack of {damage}⚔️ from {attacker.Name} ");
                }
                else
                {                    
                    this.Health -= attacker.AttackValue - this.DefenseValue;
                }
            }
        }
    }
}