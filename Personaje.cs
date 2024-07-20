using System;

namespace EspacioPersonaje;
// Juego RPG es por turnos
// Diferencia entre campos y propiedades saber bien
// Clases: personajes, caracteristicas, datos persJson, historial,
//  fabrica de personajes, estadisticas, combate Daño provocado con if no puede ser negativo
// Usar apis Fabrica de personajes consumiria una api
// motor grafico godot

public class Personaje{
  //Datos
  private string? tipo; 
  private string? nombre;
  // private string? apodo;
  private DateTime fechaNacimiento;
  private int edad;  
  //Caracteristicas
  private int velocidad;
  private int destreza;
  private int fuerza;
  private int nivel;
  private int armadura;
  private int salud;


    public Personaje(string? tipo, string? nombre, string? apodo, DateTime fechaNacimiento, int edad, int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        // this.Apodo = apodo;
        this.FechaNacimiento = fechaNacimiento;
        this.Edad = edad;
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
        this.Armadura = armadura;
        this.Salud = salud;
    }

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    // public string? Apodo { get => apodo; set => apodo = value; }
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
        Console.WriteLine("\t\tTipo: "+ Tipo);
        Console.WriteLine("\t\tNombre: "+ Nombre);
        // Console.WriteLine("\t\tID: "+ ID);
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

// public static class FabricaDePersonajes{

// }

//Solo civilizaciones: 
//https://aoe2-data-api.herokuapp.com/civs?includeUnits=false&includeTechs=false&includeBuildings=false

