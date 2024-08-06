using EspacioCasasJuegoDeTronos;
using consumoApiService;
namespace EspacioPersonaje;

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
    private float salud;


    public Personaje(int id, string  casa, string   nombreCompleto, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, float salud)
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
    public float Salud { get => salud; set => salud = value; }

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
        Console.WriteLine($"\t\tSalud: {Salud:F2}");
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
        float salud = 100.00f;

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

