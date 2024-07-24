// using System;
// using EspacioPersonaje;


// class Program
// {
//     static void Main()
//     {
//         List<Personaje>? personajes = new List<Personaje>();
        
//         personajes  = PersonajesJson.LeerPersonajes("personajes.json");

//         foreach (var personaje in personajes)
//         {
//           Console.WriteLine("");
//           personaje.MostraPersonaje();
//         }

//     }
// }
using System;
using System.Threading.Tasks;
using consumoApiService;
using EspacioPersonaje;

class Program
{
    static async Task Main(string[] args)
    {

        List<Personaje> personajes = new List<Personaje>();
        
        personajes  = await PersonajesJson.LeerPersonajesAsync("personajes.json");

        foreach (var personaje in personajes)
        {
          Console.WriteLine("");
          personaje.MostraPersonaje();
        }
    }
}
