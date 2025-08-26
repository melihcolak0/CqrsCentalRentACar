using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _10PC_Cqrs.AIImplementation
{
    public class HelsinkiNPLTranslation
    {
        private readonly string _apiKey = "My_API_Key";
        private readonly string _apiUrl = "https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en";

        public async Task<string> TranslateAsync(string text)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var translateRequestBody = new
                {
                    inputs = text
                };

                var translateJson = JsonSerializer.Serialize(translateRequestBody);
                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_apiUrl, translateContent);
                var responseString = await response.Content.ReadAsStringAsync();

                if (responseString.TrimStart().StartsWith("["))
                {
                    var doc = JsonDocument.Parse(responseString);
                    return doc.RootElement[0].GetProperty("translation_text").GetString();
                }

                return "Çeviri alınamadı.";
            }
        }
    }
}
