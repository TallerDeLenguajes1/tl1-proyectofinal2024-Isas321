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
  private string? apodo;
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
        this.tipo = tipo;
        this.nombre = nombre;
        this.apodo = apodo;
        this.fechaNacimiento = fechaNacimiento;
        this.edad = edad;
        this.velocidad = velocidad;
        this.destreza = destreza;
        this.fuerza = fuerza;
        this.nivel = nivel;
        this.armadura = armadura;
        this.salud = salud;
    }
}

