using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using espacioFrase;
using System.IO;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.breakingbadquotes.xyz/v1/quotes/5";

        HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            List<Frase> fraseDelDia = JsonSerializer.Deserialize<List<Frase>>(responseBody);

            Console.WriteLine("FRASES DE BREAKING BAD");
            foreach (var frase in fraseDelDia)
            {
                Console.WriteLine($"\"{frase.quote}\"");
                Console.WriteLine($"— {frase.author}\n");
            }

            string json = JsonSerializer.Serialize(fraseDelDia);
            File.WriteAllText("frases.json", json);

            Console.WriteLine("\nArchivo 'frase.json' guardado correctamente.");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error en la petición HTTP: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error inesperado: {e.Message}");
        }
    }
}
