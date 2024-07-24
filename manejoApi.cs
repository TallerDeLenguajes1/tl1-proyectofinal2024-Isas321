// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

using System.Text.Json.Serialization;

namespace EspacioJuegoDeTronos{
  public class Miembros
  {
      [JsonPropertyName("name")]
      public string  nombreCompleto { get; set; }

      [JsonPropertyName("slug")]
      public string  primerNombre { get; set; }
  }

  public class Casas
  {
      [JsonPropertyName("slug")]
      public string  apellido { get; set; }

      [JsonPropertyName("name")]
      public string  nombreDeCasa { get; set; }

      [JsonPropertyName("members")]
      public List<Miembros>  miembros { get; set; }
  }
}