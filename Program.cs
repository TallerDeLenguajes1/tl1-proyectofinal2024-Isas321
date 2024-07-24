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

class Program
{
    static async Task Main(string[] args)
    {
        CasasJuegoDeTronosService apiService = new CasasJuegoDeTronosService();
        var casasNobles = await apiService.GetCasasJuegoDeTronosAsync();

        foreach (var casa in casasNobles)
        {
            Console.WriteLine($"Casa: {casa.nombreDeCasa}, Apellido: {casa.apellido}");
            foreach (var miembro in casa.miembros)
            {
                Console.WriteLine($"  Miembro: {miembro.nombreCompleto}, Primer Nombre: {miembro.primerNombre}");
            }
        }
    }
}
