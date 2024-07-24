using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EspacioCasasJuegoDeTronos;

namespace consumoApiService
{
    public class CasasJuegoDeTronosService
    {
        private readonly string url = "https://api.gameofthronesquotes.xyz/v1/houses"; 
        public async Task<List<Casas>> GetCasasJuegoDeTronosAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Casas>  casasJuegoDeTronos = JsonSerializer.Deserialize<List<Casas>>(responseBody);
                return casasJuegoDeTronos;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"No se pudieron obtener las casas. Error: {e.Message}");
                return new List<Casas>();
            }
        }
    }
}
