
using System;
using System.Threading.Tasks;
using consumoApiService;
using EspacioImagenes;
using EspacioPersonaje;
using EspacioInterfaz;
using EspacioJuegoDeCaballeros;
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

                    List<Personaje> participantes;

                    participantes = ObtenerPersonajesAleatorios(personajes, 8);
                    Console.WriteLine("Los caballeros que participaran en el torneo seran:");
                    foreach (Personaje caballero in participantes)
                    {
                      caballero.MostraPersonaje();
                    }

                    TablaDePosiciones.CuartosDefinal(participantes);
                    // int participante;
                    // char confirmacion;



                    // Personaje caballero1, caballero2;
                    // caballero1=personajes[Utilidades.ObtenerIntRandom(0,personajes.Count)];
                    // do
                    // {
                    //   caballero2=personajes[Utilidades.ObtenerIntRandom(0,personajes.Count)];
                    // } while (caballero1==caballero2);

                    // Console.WriteLine("Los caballeros que participaran en la justa son: ");
                    // Console.WriteLine("");
                    // caballero1.MostraPersonaje();
                    // Console.WriteLine("");
                    // caballero2.MostraPersonaje();

                    // Console.WriteLine("\nDesea apostar por un participante?");
                    // Console.Write("Si (s) / No (cualquier tecla): ");
                    // confirmacion = Console.ReadKey().KeyChar; 
                    // Console.WriteLine();

                    // if(confirmacion=='s' || confirmacion=='S')
                    // {
                    //   Console.WriteLine("\nPor cual apostara?\n");
                    //   Console.WriteLine("\t"+caballero1.NombreCompleto+" con numero: "+caballero1.ID);
                    //   Console.WriteLine("\tó");
                    //   Console.WriteLine("\t"+caballero2.NombreCompleto+" con numero: "+caballero2.ID);
                    //   do{
                    //     Console.Write("\nIngrese numero del participante: ");
                    //     participante=Interfaz.IngresarEntero();
                    //   } while (participante == -999 || (participante != caballero1.ID && participante != caballero2.ID)); 
                      // do
                      // {
                      //   do{
                      //     Console.Write("\nIngrese monto entero que desea apostar: ");
                      //     monto=Interfaz.IngresarEntero();
                      //   } while (monto==-999);  
                      //   Console.WriteLine("El monto que desea apostar es: "+monto);
                      //   Console.Write("Es correcto? Si (s) / No (cualquier tecla): ");
                      //   confirmacion = Console.ReadKey().KeyChar; 
                      //   Console.WriteLine();
                      // } while (confirmacion != 'S' && confirmacion != 's');
                      // Console.WriteLine("\nApuesta: " + monto + " a " + (participante == caballero1.ID ? caballero1.NombreCompleto : caballero2.NombreCompleto));
                    //   Console.Write("\nCOMIENZA LA JUSTA!\n");
                    //   Enfrentamiento.RealizarEnfrentamiento(caballero1, caballero2);
                    // } else{
                    //   Console.WriteLine("\nNo se realizaron apuestas...");
                    // }

                    Console.Write("\nPresione una tecla para volver al menu... ");
                    Console.ReadKey();                    
                    break;
                case 3:
                    Console.WriteLine("\nOpcion 3");
                    break;
                case 4:
                    //Funcion que elimina archivo JSON y crea uno nuevo

                    Console.WriteLine("Nuevos Personajes creados.");
                    Console.WriteLine("Presione enter para continuar");
                    TablaDePosiciones.Semifinal(personajes);
                    Console.WriteLine("*************************");
                    TablaDePosiciones.Final(personajes);
                    Console.WriteLine("*************************");
                    TablaDePosiciones.TablaCompleta(personajes);

                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Muchas gracias por elegirnos.");
                    break;
            }

        } while (menu != 5);
    }

    public static List<Personaje> ObtenerPersonajesAleatorios(List<Personaje> listaPersonajes, int cantidad)
    {
        List<Personaje> participantes = new List<Personaje>();

        while (participantes.Count < cantidad)
        {
            Personaje personaje;
            do
            {
                personaje = listaPersonajes[Utilidades.ObtenerIntRandom(0, listaPersonajes.Count)];
            } while (participantes.Contains(personaje));
            
            participantes.Add(personaje);
        }

        return participantes;
    }
}