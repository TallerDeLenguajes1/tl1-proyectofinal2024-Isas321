using System;
using EspacioPersonaje;


class Program
{
    static void Main()
    {

        // Crear un personaje para probar
        Personaje personaje = FabricaDePersonajes.CrearPersonaje();
        personaje.MostraPersonaje();
    }
}