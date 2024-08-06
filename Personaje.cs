
using System.Text.Json;
using EspacioCasasJuegoDeTronos;
using consumoApiService;
namespace EspacioPersonaje;

//  fabrica de personajes, estadisticas, combate Daño provocado con if no puede ser negativo

public class Personaje{
    //Datos
    private int id;
    private string  casa; 
    private string   nombreCompleto;
    private int edad;  
    //Caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;


    public Personaje(int id, string  casa, string   nombreCompleto, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.ID = id;
        this.Casa = casa;
        this.NombreCompleto =  nombreCompleto;
        this.Edad = edad;
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
    }

    //Cuidar los set y get porque lo publico pueden acceder de cualquier parte
    public int ID { get => id; set => id = value; }
    public string  Casa { get => casa; set => casa = value; }
    public string   NombreCompleto { get =>  nombreCompleto; set =>  nombreCompleto = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    public void MostraPersonaje(){
        if (this == null) {
            Console.WriteLine("No hay caballero");
        return;
    }
        Console.WriteLine("\t\tCaballero numero["+ID+"]");
        Console.WriteLine("\t\tNombre: "+ NombreCompleto);
        Console.WriteLine("\t\tCasa: "+ Casa);
        Console.WriteLine("\t\tEdad: "+Edad);
        Console.WriteLine("\t\tVelocidad: "+Velocidad);
        Console.WriteLine("\t\tDestreza: "+Destreza);
        Console.WriteLine("\t\tFuerza: "+Fuerza);
        Console.WriteLine("\t\tNivel: "+Nivel);
        Console.WriteLine("\t\tArmadura: "+Armadura);
        Console.WriteLine("\t\tSalud: "+Salud);
    }
}

public static class FabricaDePersonajes{
    public static Personaje CrearPersonaje(int identificador, string nombreDeCasa, string nombrePersonaje)
    {
        int id = identificador;
        string casa = nombreDeCasa;
        string nombreCompleto = nombrePersonaje;
        int edad = Utilidades.ObtenerIntRandom(18, 45);
        int velocidad = Utilidades.ObtenerIntRandom(1, 11);
        int destreza = Utilidades.ObtenerIntRandom(1, 6);
        int fuerza = Utilidades.ObtenerIntRandom(1, 11);
        int nivel = 1;
        int armadura = Utilidades.ObtenerIntRandom(1, 11);
        int salud = 100;

        return new Personaje(id, casa, nombreCompleto, edad, velocidad, destreza, fuerza, nivel, armadura, salud);
    }
}

public static class Utilidades{
    private static readonly Random random = new Random();
 
    public static int ObtenerIntRandom(int ini, int fin)
    {
        return random.Next(ini, fin);
    }
}


public static class CasasNobles{    
    public static async Task <List<Casas>> ObtenerCasasNobles(){
        CasasJuegoDeTronosService apiService = new CasasJuegoDeTronosService();
        var casasNobles = await apiService.GetCasasJuegoDeTronosAsync();
        return casasNobles;
    }
}


public static class PersonajesJson{
    public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo){
        string jsonPersonajes = JsonSerializer.Serialize(personajes);
        File.WriteAllText(nombreArchivo, jsonPersonajes);
        // Console.WriteLine("Exito al guardar en: " + nombreArchivo);
    }

    public static async Task<List<Personaje>> LeerPersonajesAsync(string nombreArchivo){
        if (ExistenPersonajes(nombreArchivo)){
            string jsonContenido = File.ReadAllText(nombreArchivo);
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonContenido);
            return personajes;
        }
        else{
            List<Personaje> personajes = new List<Personaje>();
            List<Casas> casas = await CasasNobles.ObtenerCasasNobles();
   
            for (int i = 0; i < casas.Count; i++){
                personajes.Add(FabricaDePersonajes.CrearPersonaje(i+1, casas[i].nombreDeCasa, casas[i].miembros[0].nombreCompleto));
            }
            // Console.WriteLine("\nFalta de datos...");
            // Console.WriteLine("Se crearon: "+casas.Count+" casas nobles");
            GuardarPersonajes(personajes, nombreArchivo);
            return personajes;
        }
    }

    public static bool ExistenPersonajes(string nombreArchivo){
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
    }
}

//Solo civilizaciones: 
//https://aoe2-data-api.herokuapp.com/civs includeUnits=false&includeTechs=false&includeBuildings=false