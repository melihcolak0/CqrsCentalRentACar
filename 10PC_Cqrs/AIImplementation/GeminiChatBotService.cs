using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace _10PC_Cqrs.AIImplementation
{
    public class GeminiChatBotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "My_API_Key"; // RapidAPI Key
        private readonly string _apiUrl = "https://gemini-pro-ai-new.p.rapidapi.com/chat";

        public GeminiChatBotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "gemini-pro-ai-new.p.rapidapi.com");
        }

        public async Task<string> GetAnswerAsync(string prompt)
        {
            var requestBody = new
            {
                contents = new object[]
                {
                    new {
                        role = "user",
                        parts = new object[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _httpClient.PostAsync(_apiUrl, content);
            var responseText = await response.Content.ReadAsStringAsync();

            try
            {
                var doc = JsonDocument.Parse(responseText);

                string answer = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                return answer ?? "Yanıt alınamadı.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}\nResponse: {responseText}";
            }
        }
    }
}
