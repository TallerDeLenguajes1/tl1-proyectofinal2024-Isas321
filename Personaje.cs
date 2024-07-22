using System;

namespace EspacioPersonaje;

// Diferencia entre campos y propiedades saber bien
// Clases: personajes, caracteristicas, datos persJson, historial,
//  fabrica de personajes, estadisticas, combate Daño provocado con if no puede ser negativo
// motor grafico godot

public class Personaje{
  //Datos
  private int id;
  private string? tipo; 
  private string? nombre;
  private DateTime fechaNacimiento;
  private int edad;  
  //Caracteristicas
  private int velocidad;
  private int destreza;
  private int fuerza;
  private int nivel;
  private int armadura;
  private int salud;


    public Personaje(int id, string? tipo, string? nombre, DateTime fechaNacimiento, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
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

    public int ID { get => id; set => id = value; }
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    //public mostrarPersonaje
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

public static class FabricaDePersonajes
    {
        private static string[] tipos = { "Caballeria", "Infanteria", "Arquero"};
        private static string[] nombresInfanteria = { "Rey Arturo", " William Wallace", "Carlos Martel"};
        private static string[] nombresArquero = { "Robin Hood", "Lord de Graville", "Arquero de los Ojos"};
        private static string[] nombresCaballero = { "Juana de Arco", "Lancelot", "Alexander Nevski" };



        public static Personaje CrearPersonaje()
        {
            int id = Utilidades.ObtenerIntRandom(1, 1000);
            string tipo = tipos[Utilidades.ObtenerIntRandom(0, tipos.Length)];
            string nombre = nombresInfanteria[Utilidades.ObtenerIntRandom(0, nombresInfanteria.Length)];
            DateTime fechaNacimiento = Utilidades.FechaAleatoria();
            int edad = Utilidades.ObtenerEdad(fechaNacimiento);
            int velocidad = Utilidades.ObtenerIntRandom(1, 101);
            int destreza = Utilidades.ObtenerIntRandom(1, 101);
            int fuerza = Utilidades.ObtenerIntRandom(1, 101);
            int nivel = Utilidades.ObtenerIntRandom(1, 101);
            int armadura = Utilidades.ObtenerIntRandom(1, 101);
            int salud = Utilidades.ObtenerIntRandom(1, 101);

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
                dia = ObtenerIntRandom(1, DateTime.IsLeapYear(anio) ? 30 : 29);
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
//Solo civilizaciones: 
//https://aoe2-data-api.herokuapp.com/civs?includeUnits=false&includeTechs=false&includeBuildings=false
