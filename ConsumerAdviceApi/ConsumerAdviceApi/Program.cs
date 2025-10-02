using System.Text.Json;
using ConsumerAdviceApi.Models;

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
                Console.WriteLine(adviceObject?.slip?.advice ?? "Nenhum conselho encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
            }
