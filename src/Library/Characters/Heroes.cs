namespace RoleplayGame
{
    public class Hero : Character
    {
        protected Hero(string name)
        : base(name)
        {

        }

        /// <summary>
        /// Método creado para otorgarle a las subclases de "Hero" la capacidad de
        /// absorber los puntos de victoria de los enemigos que derrotan.
        /// </summary>
        /// <param name="defeatedEnemy"></param>
        public virtual void AbsorbVictoryPoints(Enemy defeatedEnemy)
        {
            this.VictoryPoints += defeatedEnemy.VictoryPoints;
        }

        /// <summary>
        /// Método sobreeescrito para causar que cuando un héroe quiera curarse se le resten 
        /// los 5 victory points que se requieren para activar el método cure.
        /// </summary>
        public override void Cure()
        {
            this.Health = 100;
            this.VictoryPoints -= 5;
        }
    }
}
