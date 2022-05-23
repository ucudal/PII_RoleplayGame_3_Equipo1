namespace RoleplayGame
{
    public class Hero : Character
    {
        protected Hero(string name)
        : base(name)
        {

        }

        public virtual void AbsorbVictoryPoints(Enemy defeatedEnemy)
        {
            this.VictoryPoints += defeatedEnemy.VictoryPoints;
        }

        
    }
}