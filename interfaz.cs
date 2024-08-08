namespace EspacioInterfaz;

public class Interfaz{
  public static int Menu(){
    int op;
    do{
      Console.WriteLine("\n\t\t\t\t\t=========    MENU    =========\n");
      Console.WriteLine("\t\t\t\t\t 1- Lista de caballeros");
      Console.WriteLine("\t\t\t\t\t 2- Participar en el torneo");
      Console.WriteLine("\t\t\t\t\t 3- Eliminar y cargar personajes");
      Console.WriteLine("\t\t\t\t\t 4- Historial de ganadores");
      Console.WriteLine("\t\t\t\t\t 5- Salir\n");
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
    }

        public static async Task EsperarPorTecla()
    {
        Task tareaDePresiónDeTecla = Task.Run(() => Console.ReadKey(true));
        Task tareaCompletada = await Task.WhenAny(tareaDePresiónDeTecla);
    }

    public static void Presentacion(){
      Console.WriteLine("\n");
      Console.WriteLine($@"
  ¡Bienvenido al torneo de justas de caballeros de Juego de Tronos!
  Enfréntate a los más valientes guerreros, demuestra tu destreza y avanza en el torneo.
  Solo los mejores prevalecerán. ¡Prepárate para la gloria y que el mejor caballero triunfe!
  El honor y la valentía serán puestos a prueba. ¿Estás listo para hacer historia?
  ");
      Console.Write("\n  Presione una tecla para comenzar... ");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("\n\n");
    }
}