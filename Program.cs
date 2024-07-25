
using System;
using System.Threading.Tasks;
using consumoApiService;
using EspacioImagenes;
using EspacioPersonaje;
//Task es una tarea, una operacion asincronicas
class Program
{
    static async Task Main(string[] args)
    {
        List<Personaje> personajes = new List<Personaje>();
        Imagenes.caballero();
        Console.WriteLine("\n\t\t\t\t\t\t\tPRESIONE UNA TECLA PARA JUGAR");
        await EsperarPorTeclaOPorTiempoAgotado(TimeSpan.FromSeconds(3));
        Console.Clear();
        Presentacion();
            
        int menu;
        do
        {   
            Console.Clear();
            menu = Menu(); //Mostrar Menu principal
            // Console.WriteLine("Presione enter para continuar.");
            // Console.ReadKey();
            Console.Clear();
            switch (menu)
            {
                case 1:
                    personajes = await PersonajesJson.LeerPersonajesAsync("personajes.json");
                    Console.WriteLine("\n\nLista de Caballeros que pueden participar en la Justa: ");
                    foreach (var personaje in personajes)
                    {
                      Console.WriteLine("");
                      personaje.MostraPersonaje();
                    }
                    Console.WriteLine("\nPresione una tecla para volver al menu");
                    Console.ReadKey();

                    break;
                case 2:
                    Console.WriteLine("\nOpcion 2");
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

        
        personajes  = await PersonajesJson.LeerPersonajesAsync("personajes.json");
    }

    static async Task EsperarPorTeclaOPorTiempoAgotado(TimeSpan tiempoDeEspera)
    {
        Task tareaDePresiónDeTecla = Task.Run(() => Console.ReadKey(true));
        Task tareaDeEspera = Task.Delay(tiempoDeEspera);
        Task tareaCompletada = await Task.WhenAny(tareaDePresiónDeTecla, tareaDeEspera);
        //  await se usa para esperar de manera asíncrona a que se complete la tarea devuelta por Task.WhenAny. 
        //  La ejecución del método se suspende aquí y se reanuda cuando una de las tareas 
        //  (tareaPresionDeTecla o tareaDeEspera) se haya completado.
    }

    static void Presentacion(){
      Console.WriteLine("\n\n");
        Console.WriteLine("¡Bienvenido a 'Apuestas de Juego de Tronos'!");
        Console.WriteLine("Un emocionante juego de apuestas.");
        Console.WriteLine("Elige a uno de los personajes de Juego de Tronos.");
        Console.WriteLine("Apuesta por su victoria en Justas de caballeros.");
        Console.WriteLine("Analiza bien sus fortalezas y ten en cuenta que cualquiera puede tener un mal dia.");
        Console.WriteLine("¡Que comience la diversión y la intriga!");
        Console.WriteLine("\n\n");
        Console.WriteLine("Presione una tecla para comenzar");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\n");
    }

    static int Menu(){
    int op;
    do{
      Console.WriteLine("\t\t\t\t\t========    MENU    ========\n");
      Console.WriteLine("\t\t\t\t\t 1- Lista de caballeros");
      Console.WriteLine("\t\t\t\t\t 2- Apostar en una Justa de caballeros");
      Console.WriteLine("\t\t\t\t\t 3- Historial de ganadores");
      Console.WriteLine("\t\t\t\t\t 4- Salir\n");
      Console.Write("Ingresar opcion: ");
      op = IngresarEntero();
      if(op < 1 || op > 4){
          Console.WriteLine("\nOpcion incorrecta");
          Console.WriteLine("Presione enter para continuar");
          Console.ReadKey();
          Console.Clear();
      }
    }while(op < 1 || op > 4);
    return op;
}

    static int IngresarEntero(){
      int num;
      if(int.TryParse(Console.ReadLine(), out num)){
        return num;
      } else{
        return -999;
      }
    }

}



