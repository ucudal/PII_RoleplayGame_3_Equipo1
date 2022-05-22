namespace RoleplayGame
{
    public class Wand: IAttackItem, IDefenseItem
    {
        public int AttackValue 
        {
            get
            {
                return 55;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 80;
            }
        }
    }
}