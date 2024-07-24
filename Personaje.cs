using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace EspacioPersonaje;

// Diferencia entre campos y propiedades saber bien
// Clases: personajes, caracteristicas, datos persJson, historial,
//  fabrica de personajes, estadisticas, combate Daño provocado con if no puede ser negativo
// motor grafico godot

public class Personaje{
    //Datos
    private int id;
    private string  tipo; 
    private string  nombre;
    private DateTime fechaNacimiento;
    private int edad;  
    //Caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;


    public Personaje(int id, string  tipo, string  nombre, DateTime fechaNacimiento, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.ID = id;
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.FechaNacimiento = fechaNacimiento;
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
    public string  Tipo { get => tipo; set => tipo = value; }
    public string  Nombre { get => nombre; set => nombre = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    public void MostraPersonaje(){
        Console.WriteLine("\t\tID: "+ ID);
        Console.WriteLine("\t\tTipo: "+ Tipo);
        Console.WriteLine("\t\tNombre: "+ Nombre);
        Console.WriteLine("\t\tFecha de nacimiento: "+FechaNacimiento.ToString("d")); //Expresado en formato corto
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
    private static string[] tipos = { "Caballeria", "Infanteria"};
    public static Personaje CrearPersonaje(int identificador)
    {
        int id = identificador;
        string tipo = tipos[Utilidades.ObtenerIntRandom(0, tipos.Length)];
        string  nombre = NombresJson.ObtenerNombreAleatorio();
        DateTime fechaNacimiento = Utilidades.FechaAleatoria();
        int edad = Utilidades.ObtenerEdad(fechaNacimiento);
        int velocidad = Utilidades.ObtenerIntRandom(1, 101);
        int destreza = Utilidades.ObtenerIntRandom(1, 101);
        int fuerza = Utilidades.ObtenerIntRandom(1, 101);
        int nivel = Utilidades.ObtenerIntRandom(1, 101);
        int armadura = Utilidades.ObtenerIntRandom(1, 101);
        int salud = 100;

        return new Personaje(id, tipo, nombre, fechaNacimiento, edad, velocidad, destreza, fuerza, nivel, armadura, salud);
    }
}

public static class Utilidades{

    private static readonly Random random = new Random();
 
    public static int ObtenerIntRandom(int ini, int fin)
    {
        return random.Next(ini, fin);
    }

    public static DateTime FechaAleatoria()
    {
        int anio = ObtenerIntRandom(1724, 2025);
        int mes = ObtenerIntRandom(1, 13);
        int dia;
        if(mes == 2){
            dia = ObtenerIntRandom(1, DateTime.IsLeapYear(anio) ?  30 : 29);
        } else{
            dia = ObtenerIntRandom(1, DateTime.DaysInMonth(anio, mes));
        }

        DateTime fecha = new DateTime(anio, mes, dia);
        return fecha;
    }

    public static int ObtenerEdad(DateTime fecha)
    {
        if (fecha > DateTime.Today) return -1;

        int edad = DateTime.Today.Year - fecha.Year;
        if (fecha.Date > DateTime.Today.AddYears(-edad)) edad--;
        return edad;
    }
}


public static class NombresJson{
    private static List<string>  nombresMedievales;
    public static void CargarNombres()
    {
        string filePath = "nombresMedievales.json";
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            Nombres  nombresObject = JsonSerializer.Deserialize<Nombres>(jsonContent);
            nombresMedievales = nombresObject .NombresList;
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }


    private class Nombres
    {
        [JsonPropertyName("nombresMedievales")]
        public List<string>  NombresList { get; set; }
    }

    public static List<string>  ObtenerNombresMedievales()
    {
        if (nombresMedievales == null || nombresMedievales.Count == 0)
        {
            throw new Exception("No se pudieron cargar los nombres medievales.");
        }
        return nombresMedievales;
    }

    public static string  ObtenerNombreAleatorio(){
        CargarNombres();
        List<string>  nombresMedievales = ObtenerNombresMedievales();
        string  nombre = nombresMedievales  [Utilidades.ObtenerIntRandom(0, nombresMedievales.Count)];
        
        return nombre;
    }
}


public static class PersonajesJson{
    public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo){
        string jsonPersonajes = JsonSerializer.Serialize(personajes);
        File.WriteAllText(nombreArchivo, jsonPersonajes);
        Console.WriteLine("Exito al guardar en: " + nombreArchivo);
    }

    public static List<Personaje>  LeerPersonajes(string nombreArchivo){
        if (ExistenPersonajes(nombreArchivo)){
            string jsonContenido = File.ReadAllText(nombreArchivo);
            List<Personaje>  personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonContenido);
            return personajes;
        }
        else{
            Console.WriteLine("\nSe crearon 10 personajes");
            List <Personaje> personajes = new List<Personaje>();
            for (int i = 0; i < 10; i++)
            {
               personajes.Add(FabricaDePersonajes.CrearPersonaje(i+1));
            }
            GuardarPersonajes(personajes, nombreArchivo);
            return personajes;
        }
    }

    public static bool ExistenPersonajes (string nombreArchivo){
        if(File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0){
            return true;
        } else{
            return false;
        }
    }
}

//Solo civilizaciones: 
//https://aoe2-data-api.herokuapp.com/civs includeUnits=false&includeTechs=false&includeBuildings=false