using  EspacioPersonaje;
namespace EspacioJuegoDeCaballeros;
 public static class Enfrentamiento
    {
        public static Personaje RealizarEnfrentamiento(Personaje caballero1, Personaje caballero2)
        {
            int carrera = 1;
            do
            {
                Console.WriteLine($"\nEnfrentamiento [{carrera++}]");
                Console.WriteLine($"\n* Turno de {caballero1.NombreCompleto}");
                if (RealizarAtaque(caballero1, caballero2))
                {
                    return caballero1;
                }
                Console.WriteLine($"\n* Turno de {caballero2.NombreCompleto}");
                if (RealizarAtaque(caballero2, caballero1))
                {
                    return caballero2;
                }
            } while (carrera <=3 && caballero1.Salud>0 && caballero2.Salud>0);

            return DeterminarGanador(caballero1, caballero2);
        }

        private static bool RealizarAtaque(Personaje atacante, Personaje defensor)
        {
            int danio = CalcularDanio(atacante, defensor);
            defensor.Salud -= danio;
            if (defensor.Salud < 0)
            {
                defensor.Salud = 0;
            }

            Console.WriteLine($"{atacante.NombreCompleto} ataca a {defensor.NombreCompleto} y provoca {danio} puntos de daño.");
            Console.WriteLine($"{defensor.NombreCompleto} tiene {defensor.Salud} puntos de salud restantes.");

            if (defensor.Salud <= 0)
            {
                Console.WriteLine($"\n{defensor.NombreCompleto} ha sido derrotado. ¡{atacante.NombreCompleto} es el ganador!");
                return true;
            }

            return false;
        }

        private static Personaje DeterminarGanador(Personaje caballero1, Personaje caballero2)
        {
            if (caballero1.Salud > caballero2.Salud)
            {
                Console.WriteLine($"\n¡{caballero1.NombreCompleto} es el ganador con más salud restante!");
                return caballero1;
            }
            else if (caballero2.Salud > caballero1.Salud)
            {
                Console.WriteLine($"\n¡{caballero2.NombreCompleto} es el ganador con más salud restante!");
                return caballero2;
            }

            Console.WriteLine("\n¡El enfrentamiento termina en empate!");
            return null;
        }

  public static int CalcularDanio(Personaje atacante, Personaje defensor)
  {
      
      int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
      int efectividad = Utilidades.ObtenerIntRandom(1, 101);
      int defensa = defensor.Armadura * defensor.Velocidad;
      const int constanteDeAjuste = 50;
      int danioProvocado = ((ataque * efectividad) - defensa) / constanteDeAjuste;

      if (danioProvocado < 0)
      {
          danioProvocado = 0; 
      }
      return danioProvocado;
  }
    }
