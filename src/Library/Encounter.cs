namespace RoleplayGame
{
  public class Encounter
  {
    public List<Enemies> ListOfEnemies;
    public List<Heroes> ListOfHeroes;

    public Encounter(List<IEnemies> enemies, List<Heroes> heroes)
    {
      this.ListOfEnemies = enemies;
      this.ListOfHeroes = heroes;
    }

    void DoEncounter()
    {
      List<Enemies> enemies = this.ListOfEnemies;
      List<Heroes> heroes = this.ListOfHeroes;

      if (enemies.Length >= 1 && heroes.Length >= 1)
      {
        while ( enemies.Length != 0 || heroes.Length != 0 )
        {
          if (enemies.Length == heroes.Length)
          {
            int i = 0;

            foreach (Enemies enemy in enemies)
            {
              Heroes[i].ReceiveAttack(enemy);

              i++;
            }

            int i = 0;

            foreach (Heroes hero in heroes)
            {
              Enemies enemy =  Enemies[i];
              enemy.ReceiveAttack(hero);

              if (enemy.health <= 0) { hero.AbsorbVictoryPoints(enemy); }

              i++;
            }
          }
          
          if (enemies.Length > heroes.Length && heroes.Length > 1)
          {

          }

          if (enemies.Length < heroes.Length)
          {

          }
  
          if (heroes.Length == 1 && enemies.Length >= 1)
          {
            foreach (Enemies enemy in enemies)
            {
              heroes[0].ReceiveAttack(enemy);
            }

            enemies[0].ReceiveAttack(heroes[0]);
          }
          
          removeDeadCharacters();
        }
      }
    }
    
    private void removeDeadCharacters()
    {
      foreach (Enemies enemy in this.ListOfEnemies)
      {
        if (enemy.health <= 0) { this.ListOfEnemies.Remove(enemy); }
      }

      foreach (Heroes hero in this.ListOfHeroes)
      {
        if (hero.health <= 0) { this.ListOfHeroes.Remove(hero); }
      }
    }
  }
}
