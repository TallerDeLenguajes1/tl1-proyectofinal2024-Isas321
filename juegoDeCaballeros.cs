using  EspacioPersonaje;
namespace EspacioJuegoDeCaballeros;

public class Enfrentamiento{
  public static Personaje RealizarEnfrentamiento(Personaje caballero1, Personaje caballero2)
  {
      int carrera = 0;
      do
      {
        carrera++;
        Console.WriteLine($"\nCarrera numero [{carrera}]");
        int danioCaballero1 = CalcularDanio(caballero1, caballero2);
        caballero2.Salud -= danioCaballero1;
        if(caballero2.Salud<0){
          caballero2.Salud=0;
        }
        Console.WriteLine($"{caballero1.NombreCompleto} ataca a {caballero2.NombreCompleto} y provoca {danioCaballero1} puntos de daño.");
        Console.WriteLine($"{caballero2.NombreCompleto} tiene {caballero2.Salud} puntos de salud restantes.");

        if (caballero2.Salud <= 0)
        {
            Console.WriteLine($"\n{caballero2.NombreCompleto} ha sido derrotado. ¡{caballero1.NombreCompleto} es el ganador!");
            return caballero1;
        }

        int danioCaballero2 = CalcularDanio(caballero2, caballero1);
        caballero1.Salud -= danioCaballero2;
        if(caballero1.Salud<0){
          caballero1.Salud=0;
        }
        Console.WriteLine($"\n{caballero2.NombreCompleto} ataca a {caballero1.NombreCompleto} y provoca {danioCaballero2} puntos de daño.");
        Console.WriteLine($"{caballero1.NombreCompleto} tiene {caballero1.Salud} puntos de salud restantes.");

        if (caballero1.Salud <= 0)
        {
            Console.WriteLine($"\n{caballero1.NombreCompleto} ha sido derrotado. ¡{caballero2.NombreCompleto} es el ganador!");
            return caballero2;
        }

      } while (carrera<5);

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
      const int constanteDeAjuste = 85;
      int danioProvocado = ((ataque * efectividad) - defensa) / constanteDeAjuste;

      if (danioProvocado < 0)
      {
          danioProvocado = 0; // Asegurar que el daño no sea negativo
      }
      return danioProvocado;
  }





}