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
              Enemies enemy =  enemies[i];
              enemy.ReceiveAttack(hero);

              if (enemy.health <= 0)
                {
                  hero.AbsorbVictoryPoints(enemy);

                  if (hero.VictoryPoints >= 5)
                  {
                    hero.Cure();
                    hero.VictoryPoints -= 5;
                  }
                }

              i++;
            }
          }
          
          if (enemies.Length > heroes.Length && heroes.Length > 1)
          {
            // En este bloque de codigo, cada enemigo le pega al siguiente heroe de su posicion.
            // Por ejemplo: El primer enemigo le pega al segundo heroe, y asi sucesivamente por cada enemigo
            // Decidimos hacerlo asi debido a que en la letra no queda claro. Al hablar con los profesores decidimos esto

            int i = 1;

            foreach (Enemies enemy in enemies)
            {
              if (i == heroes.Length)
              {
                i = 0;
              } else {
                heroes[i].ReceiveAttack(enemy);
              }
            }

            //  Luego cada heroe le pega a cada enemigo de manera normal
            int i = 0;

            foreach (Heroes hero in heroes)
            {
              Enemies enemy =  enemies[i];
              enemy.ReceiveAttack(hero);

              if (enemy.health <= 0)
                {
                  hero.AbsorbVictoryPoints(enemy);

                  if (hero.VictoryPoints >= 5)
                  {
                    hero.Cure();
                    hero.VictoryPoints -= 5;
                  }
                }

              i++;
            }
          }

          if (enemies.Length < heroes.Length && enemies.Length > 1)
          {
            // Este bloque hace lo mismo que el anterior, pero para los heroes
            // Esto decidimos hacerlo nosotros debido a que la letra no lo dejaba claro
            // No se sabia que pasaba cuando habian mas heroes que enemigos

            int i = 0;

            // Los enemigos atacan primero de manera normal
            foreach (Enemies enemy in enemies)
            {
              Heroes[i].ReceiveAttack(enemy);

              i++;
            }

            int i = 1;

            // Se repite lo mismo que el if anterior
            foreach (Heroes hero in heroes)
            {
              if (i == enemies.Length)
              {
                i = 0;
              } else {
                Enemies enemy = enemies[i];
                enemy.ReceiveAttack(hero);

                if (enemy.health <= 0)
                {
                  hero.AbsorbVictoryPoints(enemy);

                  if (hero.VictoryPoints >= 5)
                  {
                    hero.Cure();
                    hero.VictoryPoints -= 5;
                  }
                }
              }
            }
          }
  
          if (heroes.Length == 1 && enemies.Length >= 1)
          {
            // Todos los enemigos le pegan al primer heroe
            foreach (Enemies enemy in enemies)
            {
              heroes[0].ReceiveAttack(enemy);
            }

            //El primer heroe le pega al primer enemigo
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
