using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsumerAdviceApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Conectando à API de conselhos...\n");

            try
            {
                using HttpClient client = new HttpClient();
                string url = "https://api.adviceslip.com/advice";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 

                string responseBody = await response.Content.ReadAsStringAsync();

                var adviceObject = JsonSerializer.Deserialize<AdviceResponse>(responseBody);

                Console.WriteLine("Conselho de Hoje:");
                Console.WriteLine(adviceObject.slip.advice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
            }
        }
    }

    public class AdviceResponse
    {
        public Slip slip { get; set; }
    }

    public class Slip
    {
        public int id { get; set; }
        public string advice { get; set; }
    }
}
