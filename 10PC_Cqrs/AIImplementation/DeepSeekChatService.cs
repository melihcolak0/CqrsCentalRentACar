using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _10PC_Cqrs.AIImplementation
{
    public class DeepSeekChatService
    {
        private readonly string _apiKey = "My_API_Key";
        private readonly string _apiUrl = "https://api-inference.huggingface.co/models/deepseek-ai/DeepSeek-V3.1";
        private readonly HttpClient _client;

        public DeepSeekChatService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {

            // Authorization header
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            // Gönderilecek JSON
            var requestBody = new
            {
                inputs = prompt
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Hugging Face API error: {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            // JSON'dan yanıtı almak
            using var doc = JsonDocument.Parse(responseString);
            if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                var text = doc.RootElement[0].GetProperty("generated_text").GetString();
                return text;
            }

            return "Yanıt alınamadı.";
        }

        //public async Task<string> GetResponseAsync(string prompt)
        //{
        //    // JSON payload
        //    var payload = new
        //    {
        //        inputs = prompt
        //    };

        //    var jsonPayload = JsonSerializer.Serialize(payload);
        //    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //    // Authorization header
        //    _httpClient.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", _apiKey);

        //    // POST request
        //    var response = await _httpClient.PostAsync(_apiUrl, content);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var error = await response.Content.ReadAsStringAsync();
        //        throw new HttpRequestException($"Hugging Face API error: {error}");
        //    }

        //    var responseString = await response.Content.ReadAsStringAsync();

        //    // API cevabı genellikle JSON array içinde dönüyor, basitleştirilmiş parsing
        //    using var doc = JsonDocument.Parse(responseString);
        //    var answer = doc.RootElement[0].GetProperty("generated_text").GetString();

        //    return answer;
        //}
    }
}
