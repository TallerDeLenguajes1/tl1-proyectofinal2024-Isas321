
using System;
using System.Threading.Tasks;
using consumoApiService;
using EspacioImagenes;
using EspacioPersonaje;
using EspacioInterfaz;
//Task es una tarea, una operacion asincronicas
class Program
{
    static async Task Main(string[] args)
    {
        List<Personaje> personajes = new List<Personaje>();
        Imagenes.caballero();
        Console.WriteLine("\n\t\t\t\t\t\t\tPRESIONE UNA TECLA PARA JUGAR");
        await Interfaz.EsperarPorTeclaOPorTiempoAgotado(TimeSpan.FromSeconds(3));
        Console.Clear();
        Interfaz.Presentacion();
        personajes = await PersonajesJson.LeerPersonajesAsync("personajes.json");
        int menu;
        do
        {   
            Console.Clear();
            menu = Interfaz.Menu();
            Console.Clear();
            switch (menu)
            {
                case 1:
                    Console.WriteLine("\n\nLista de Caballeros que pueden participar en la Justa: ");
                    foreach (var personaje in personajes)
                    {
                      Console.WriteLine("");
                      personaje.MostraPersonaje();
                    }
                    Console.Write("\nPresione una tecla para volver al menu...");
                    Console.ReadKey();
                    break;
                case 2:
                    int monto, participante;
                    char confirmacion;

                    Personaje caballero1, caballero2;
                    caballero1=personajes[Utilidades.ObtenerIntRandom(0,personajes.Count)];
                    do
                    {
                      caballero2=personajes[Utilidades.ObtenerIntRandom(0,personajes.Count)];
                    } while (caballero1==caballero2);

                    Console.WriteLine("Los caballeros que participaran en la justa son: ");
                    Console.WriteLine("");
                    caballero1.MostraPersonaje();
                    Console.WriteLine("");
                    caballero2.MostraPersonaje();

                    Console.WriteLine("\nDesea apostar por un participante?");
                    Console.Write("Si (s) / No (cualquier tecla): ");
                    confirmacion = Console.ReadKey().KeyChar; 
                    Console.WriteLine();

                    if(confirmacion=='s' || confirmacion=='S')
                    {
                      Console.WriteLine("\nPor cual apostara?\n");
                      Console.WriteLine("\t"+caballero1.NombreCompleto+" con numero: "+caballero1.ID);
                      Console.WriteLine("\tó");
                      Console.WriteLine("\t"+caballero2.NombreCompleto+" con numero: "+caballero2.ID);
                      do{
                        Console.Write("\nIngrese numero del participante: ");
                        participante=Interfaz.IngresarEntero();
                      } while (participante == -999 || (participante != caballero1.ID && participante != caballero2.ID)); 
                      do
                      {
                        do{
                          Console.Write("\nIngrese monto entero que desea apostar: ");
                          monto=Interfaz.IngresarEntero();
                        } while (monto==-999);  
                        Console.WriteLine("El monto que desea apostar es: "+monto);
                        Console.Write("Es correcto? Si (s) / No (cualquier tecla): ");
                        confirmacion = Console.ReadKey().KeyChar; 
                        Console.WriteLine();
                      } while (confirmacion != 'S' && confirmacion != 's');
                      Console.WriteLine("\nApuesta: " + monto + " a " + (participante == caballero1.ID ? caballero1.NombreCompleto : caballero2.NombreCompleto));
                      Console.Write("\nCOMIENZA LA JUSTA!");
                      RealizarEnfrentamiento(caballero1, caballero2);
                    } else{
                      Console.WriteLine("\nNo se realizaron apuestas...");
                    }

                    Console.Write("\nPresione una tecla para volver al menu... ");
                    Console.ReadKey();                    
                    break;
                case 3:
                    Console.WriteLine("\nOpcion 3");
                    break;
//                 case 4:
//                     //Funcion que elimina archivo JSON y crea uno nuevo

//                     Console.WriteLine("Nuevos Personajes creados.");
//                     Console.WriteLine("Presione enter para continuar");
//                     Console.ReadKey();
//                     Console.Clear();
//                     break;
//                 default:
//                     Console.Clear();
//                     Console.WriteLine("Muchas gracias por elegirnos.");

//                     break;
            }

        } while (menu != 4);

        
        
    }




  static Personaje RealizarEnfrentamiento(Personaje caballero1, Personaje caballero2)
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

  static int CalcularDanio(Personaje atacante, Personaje defensor)
  {
      
      int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
      int efectividad = Utilidades.ObtenerIntRandom(1, 101);
      int defensa = defensor.Armadura * defensor.Velocidad;
      const int constanteDeAjuste = 400;
      int danioProvocado = ((ataque * efectividad) - defensa) / constanteDeAjuste;

      if (danioProvocado < 0)
      {
          danioProvocado = 0; // Asegurar que el daño no sea negativo
      }
      return danioProvocado;
  }

}

