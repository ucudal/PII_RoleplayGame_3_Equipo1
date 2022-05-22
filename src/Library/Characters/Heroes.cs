namespace RoleplayGame
{
    public class Heroes : Character
    {
        protected Heroes(string name)
        : base(name)
        {

        }

        public virtual void AbsorbVictoryPoints(Enemies defeatedEnemy)
        {
            this.VictoryPoints += defeatedEnemy.VictoryPoints;
        }
    }
}
