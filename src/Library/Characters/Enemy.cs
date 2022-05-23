namespace RoleplayGame
{
    public class Enemy : Character
    {

        protected Enemy(string name)
        : base(name)
        {
            this.side = "Enemy";
        }
    
    }
}