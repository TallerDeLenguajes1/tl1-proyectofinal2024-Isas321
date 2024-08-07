using System.Text.Json;
using EspacioCasasJuegoDeTronos;
using EspacioPersonaje;
namespace EspacioManejoJson;


public class HistorialJson
{
    public static List<Ganador> LeerGanadores(string nombreArchivo)
    {
        if (ExistenGanadores(nombreArchivo))
        {
            using (var archivoAbierto = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoAbierto))
                {
                    string jsonContenido = strReader.ReadToEnd();
                    List<Ganador> ganadores = JsonSerializer.Deserialize<List<Ganador>>(jsonContenido);
                    archivoAbierto.Close();
                    return ganadores;
                }
            }
        }
        else
        {
            Console.WriteLine("No hay ganadores registrados");
            return new List<Ganador>();
        }
    }


    public static void GuardarGanador(string nombreArchivo, List<Ganador> ganadores)
{
    string jsonGanadores = JsonSerializer.Serialize(ganadores);
    using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
    {
        using (var strWriter = new StreamWriter(archivo))
        {
            strWriter.Write(jsonGanadores);
        }
    }
}

    public static  bool ExistenGanadores(string nombreArchivo)
    {
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
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
     public static void EliminarPersonajes(string nombreArchivo)
    {
        if (File.Exists(nombreArchivo))
        {
            File.Delete(nombreArchivo);
            Console.WriteLine("\n\nEl archivo de personajes ha sido eliminado.");
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }
}

public class Ganador
{
    private string nombre;
    private string casa;
    private float salud;

    public Ganador(string nombre, string casa, float salud)
    {
        this.Nombre = nombre;
        this.Casa = casa;
        this.Salud = salud;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Casa { get => casa; set => casa = value; }
    public float Salud { get => salud; set => salud = value; }

    public void MostrarGanador()
    {
        if (this == null) 
        {
            Console.WriteLine("No hay información del ganador.");
            return;
        }

        Console.WriteLine("\t\tGanador");
        Console.WriteLine("\t\tNombre: " + Nombre);
        Console.WriteLine("\t\tCasa: " + Casa);
        Console.WriteLine($"\t\tSalud: {Salud:F2}");
    }
}