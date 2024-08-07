using System.Text.Json;
using EspacioCasasJuegoDeTronos;
using EspacioPersonaje;
namespace EspacioManejoJson;


public class ManejoDeGanadores
{
    public string AbrirArchivoGanadores(string nombreArchivo)
    {
        string documento;
        using (var archivoAbierto = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoAbierto))
            {
                documento = strReader.ReadToEnd();
                archivoAbierto.Close();
            }
        }
        return documento;
    }

    public void GuardarGanadoresEnJson(string nombreArchivo, string datos)
    {
        using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
        {
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", datos);
                strWriter.Close();
            }
        }
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