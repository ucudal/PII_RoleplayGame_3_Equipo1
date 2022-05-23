using System.Collections.Generic;
namespace RoleplayGame
{
    public abstract class MagicEnemy : Enemy
    {
        protected List<IMagicalItem> magicalItems = new List<IMagicalItem>();

        protected MagicEnemy(string name)
        : base(name)
        {

        }

        public virtual void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

         public virtual void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }
    }
}
