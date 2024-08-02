namespace EspacioInterfaz;

public class Interfaz{
  public static int Menu(){
    int op;
    do{
      Console.WriteLine("\t\t\t\t\t========    MENU    ========\n");
      Console.WriteLine("\t\t\t\t\t 1- Lista de caballeros");
      Console.WriteLine("\t\t\t\t\t 2- Participar en el torneo");
      Console.WriteLine("\t\t\t\t\t 3- Historial de ganadores");
      Console.WriteLine("\t\t\t\t\t 4- Salir\n");
      Console.Write("Ingresar opcion: ");
      op = IngresarEntero();
      if(op < 1 || op > 5){
          Console.WriteLine("\nOpcion incorrecta");
          Console.Write("Presione enter para continuar...");
          Console.ReadKey();
          Console.Clear();
      }
    }while(op < 1 || op > 5);
    return op;
  }
  public static int IngresarEntero(){
    int num;
    if(int.TryParse(Console.ReadLine(), out num)){
      return num;
    } else{
      return -999;
    }
  }

    public static async Task EsperarPorTeclaOPorTiempoAgotado(TimeSpan tiempoDeEspera)
    {
        Task tareaDePresiónDeTecla = Task.Run(() => Console.ReadKey(true));
        Task tareaDeEspera = Task.Delay(tiempoDeEspera);
        Task tareaCompletada = await Task.WhenAny(tareaDePresiónDeTecla, tareaDeEspera);
        //  await se usa para esperar de manera asíncrona a que se complete la tarea devuelta por Task.WhenAny. 
        //  La ejecución del método se suspende aquí y se reanuda cuando una de las tareas 
        //  (tareaPresionDeTecla o tareaDeEspera) se haya completado.
    }

    public static void Presentacion(){
      Console.WriteLine("\n\n");
        Console.WriteLine("¡Bienvenido a 'Apuestas de Juego de Tronos'!");
        Console.WriteLine("Un emocionante juego de apuestas.");
        Console.WriteLine("Elige a uno de los personajes de Juego de Tronos.");
        Console.WriteLine("Apuesta por su victoria en Justas de caballeros.");
        Console.WriteLine("Analiza bien sus fortalezas y ten en cuenta que cualquiera puede tener un mal dia.");
        Console.WriteLine("¡Que comience la diversión y la intriga!");
        Console.WriteLine("\n\n");
        Console.Write("Presione una tecla para comenzar... ");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\n");
    }
}