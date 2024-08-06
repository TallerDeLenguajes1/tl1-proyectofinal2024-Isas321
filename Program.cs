
using System;
using System.Threading.Tasks;
using consumoApiService;
using EspacioImagenes;
using EspacioPersonaje;
using EspacioInterfaz;
using EspacioJuegoDeCaballeros;
using System.Text.RegularExpressions;
//Task es una tarea, una operacion asincronicas
class Program
{
    static async Task Main(string[] args)
    {
        char confirmacion='n';
        int menu;
        List<Personaje> personajes = new List<Personaje>();
        Imagenes.caballero();
        Console.WriteLine("\n\t\t\t\t\t\t\tPRESIONE UNA TECLA PARA JUGAR");
        await Interfaz.EsperarPorTeclaOPorTiempoAgotado(TimeSpan.FromSeconds(3));
        Console.Clear();
        Interfaz.Presentacion();
        personajes = await PersonajesJson.LeerPersonajesAsync("personajes.json");


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

                    List<Personaje> semifinalistas, finalistas;
                    Personaje semifinalista1, semifinalista2, semifinalista3, semifinalista4;
                    Personaje finalista1, finalista2, ganador, jugador=null;
                    int seEncuentra=0;

                    
                    List<Personaje> participantes = new List<Personaje>();
                    participantes=null;
                    
                    participantes = ObtenerPersonajesAleatorios(personajes, 7);

                    Console.WriteLine("Los caballeros que participan en este torneo son:");
                    foreach (Personaje caballero in participantes)
                    {   
                        Console.WriteLine();
                        caballero.MostraPersonaje();
                    }

                    string nombreJugador = "", nombreDeCasa="";
                    do
                    {
                        Console.Write("\nIngrese su nombre: ");
                        nombreJugador = Console.ReadLine();

                        if (!EsNombreValido(nombreJugador))
                        {
                            Console.WriteLine("Nombre inválido. Por favor, ingrese solo letras.");
                            nombreJugador = "";
                        }

                        if (nombreJugador.Length>19)
                        {
                            Console.WriteLine("Nombre demasiado largo.");
                            nombreJugador = "";
                        }
                        
                        seEncuentra = 0;

                        foreach (var caballero in personajes)
                        {
                            if(caballero.NombreCompleto==nombreJugador){
                                Console.WriteLine("El Nombre que deseas ya lo tiene otro caballero");
                                seEncuentra=1;
                                break;
                            } 
                        }

                    } while (string.IsNullOrEmpty(nombreJugador) || seEncuentra==1);

                    do
                    {
                        Console.Write("\nIngrese el nombre de su casa: ");
                        nombreDeCasa = Console.ReadLine();

                        if (!EsNombreValido(nombreJugador))
                        {
                            Console.WriteLine("Nombre inválido. Por favor, ingrese solo letras.");
                            nombreDeCasa = "";
                        }
                        if (nombreJugador.Length>19)
                        {
                            Console.WriteLine("Nombre demasiado largo.");
                            nombreJugador = "";
                        }
                    } while (string.IsNullOrEmpty(nombreDeCasa));

                    jugador = FabricaDePersonajes.CrearPersonaje(13, nombreDeCasa, nombreJugador);

                    Console.WriteLine($"\n\nTus datos y caracteristicas: \n");
                    jugador.MostraPersonaje();
                    Console.Write("\nPresione una tecla para ver la tabla de enfrentamientos");
                    await Interfaz.EsperarPorTecla();

                    Console.WriteLine("\n\n\n**** TABLA DE ENFRENTAMIENTOS CUARTOS DE FINAL ***\n");
                    TablaDePosiciones.CuartosDefinal(jugador, participantes);

                    Console.Write("\nPresione una tecla para comenzar el torneo...");
                    await Interfaz.EsperarPorTecla();

                    Console.Write("\n\n\n\n\t\tQUE COMIENCE El TORNEO!");

                    Console.WriteLine("\n\n\n\n**** Compiten por el lugar para el primer semifinalista ***\n");
                    semifinalista1 = Enfrentamiento.RealizarEnfrentamiento(participantes[0], participantes[1]);
                    await Interfaz.EsperarPorTecla();
                    Console.WriteLine("\n\n\n\n**** Compiten por el lugar para el segundo semifinalista ***\n");
                    semifinalista2 = Enfrentamiento.RealizarEnfrentamiento(participantes[2], participantes[3]);
                    await Interfaz.EsperarPorTecla();
                    Console.WriteLine("\n\n\n\n**** Compiten por el lugar para el tercer semifinalista ***\n");
                    semifinalista3 = Enfrentamiento.RealizarEnfrentamiento(participantes[4], participantes[5]);
                    await Interfaz.EsperarPorTecla();
                    Console.WriteLine("\n\n\n\n**** Compiten por el lugar para el cuarto semifinalista ***\n");
                    semifinalista4 = Enfrentamiento.RealizarEnfrentamiento(participantes[6], jugador);
                    await Interfaz.EsperarPorTecla();

                    if(semifinalista4!=jugador){
                        Console.WriteLine("\n\nPerdiste, pero puede que en la proxima vez tengas mas suerte!\n");
                        Console.WriteLine("El torneo continua");
                         
                        do{
                            Console.Write("Presione (s) para ver el resultado final del torneo: ");
                            confirmacion = Console.ReadKey().KeyChar; 
                            Console.WriteLine();
                        } while (confirmacion != 'S' && confirmacion != 's');
                    }
                    
                    semifinalistas = new List<Personaje>();

                    semifinalistas.Add(semifinalista1);
                    semifinalistas.Add(semifinalista2);
                    semifinalistas.Add(semifinalista3);
                    semifinalistas.Add(semifinalista4);

                    if(confirmacion != 'S' && confirmacion != 's'){
                        Console.Write("\n\nPresione una tecla para seguir a la semifinal\n");
                        await Interfaz.EsperarPorTecla();
                    }

                    Console.WriteLine("\n\n\n**** TABLA DE ENFRENTAMIENTOS SEMIFINAL ***\n");
                    TablaDePosiciones.SemiFinal1(jugador, participantes, semifinalistas);

                    Console.WriteLine("\n\n\n**** Compiten por el lugar para el primer finalista ***\n");
                    finalista1 = Enfrentamiento.RealizarEnfrentamiento(semifinalista1, semifinalista2);
                    if(confirmacion != 'S' && confirmacion != 's'){
                        await Interfaz.EsperarPorTecla();
                    }

                    Console.WriteLine("\n\n\n**** Compiten por el lugar para el segundo finalista ***\n");
                    finalista2 = Enfrentamiento.RealizarEnfrentamiento(semifinalista3, semifinalista4);

                    if(confirmacion != 'S' && confirmacion != 's'){
                        if(finalista2!=jugador){
                            Console.WriteLine("\n\nPerdiste, pero puede que en la proxima vez tengas mas suerte\n");
                            Console.WriteLine("Pero el torneo continua");
                            
                            do{
                                Console.Write("Presione (s) para ver el resultado final del torneo: ");
                                confirmacion = Console.ReadKey().KeyChar; 
                                Console.WriteLine();
                            } while (confirmacion != 'S' && confirmacion != 's');
                        }
                    }

                    if(confirmacion != 'S' && confirmacion != 's'){
                        await Interfaz.EsperarPorTecla();
                    }

                    finalistas = new List<Personaje>();

                    finalistas.Add(finalista1);
                    finalistas.Add(finalista2);

                    if(confirmacion != 'S' && confirmacion != 's'){
                        Console.Write("\n\nPresione una tecla para seguir a lafinal\n");
                        await Interfaz.EsperarPorTecla();
                    }

                    Console.WriteLine("\n\n\n**** TABLA DE ENFRENTAMIENTOS FINAL ***\n");
                    TablaDePosiciones.Final1(jugador, participantes, semifinalistas, finalistas);

                    Console.WriteLine("\n\n\n**** Enfrentamiento Final ***");
                    ganador = Enfrentamiento.RealizarEnfrentamiento(finalista1, finalista2);
                    if(confirmacion != 'S' && confirmacion != 's'){
                        if(ganador!=jugador){
                        Console.WriteLine("\n\nPerdiste, pero puede que en la proxima vez tengas mas suerte!\n");                         
                        do{
                            Console.Write("Presione (s) para ver el resultado final del torneo: ");
                            confirmacion = Console.ReadKey().KeyChar; 
                            Console.WriteLine();
                        } while (confirmacion != 'S' && confirmacion != 's');
                        
                        }
                    }
                    // if(confirmacion != 'S' && confirmacion != 's'){
                    //     await Interfaz.EsperarPorTeclaOPorTiempoAgotado(TimeSpan.FromSeconds(8));
                    // }

                    Console.WriteLine("\n\n\n**** TABLA COMPLETA DEL TORNEO ***\n");
                    TablaDePosiciones.TablaCompleta1(jugador, participantes, semifinalistas, finalistas, ganador);

                    Console.Write("\nPresione una tecla para volver al menu... ");
                    Console.ReadKey();
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

    static bool EsNombreValido(string nombre)
    {
        return Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");
    }


}