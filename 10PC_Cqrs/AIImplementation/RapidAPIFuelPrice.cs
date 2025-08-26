using _10PC_Cqrs.Models;
using System.Globalization;
using System.Text.Json;

namespace _10PC_Cqrs.AIImplementation
{
    public class RapidAPIFuelPrice
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RapidAPIFuelPrice(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RapidAPIFuelPriceViewModel> GetFuelPricesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
                {
                    { "x-rapidapi-key", "My_API_Key" },
                    { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(body);

            var root = jsonDoc.RootElement;

            if (!root.GetProperty("success").GetBoolean())
                return null;

            var resultArray = root.GetProperty("result");
            if (resultArray.GetArrayLength() == 0)
                return null;

            // Türkiye entry'sini bul
            JsonElement? turkeyEntry = null;
            foreach (var item in resultArray.EnumerateArray())
            {
                if (item.GetProperty("country").GetString() == "Turkey")
                {
                    turkeyEntry = item;
                    break;
                }
            }

            if (turkeyEntry == null)
                return null;

            // Modeli oluştur
            var model = new RapidAPIFuelPriceViewModel
            {
                country = turkeyEntry.Value.GetProperty("country").GetString(),
                currency = turkeyEntry.Value.GetProperty("currency").GetString(),
                gasoline = turkeyEntry.Value.GetProperty("gasoline").GetString(),
                diesel = turkeyEntry.Value.GetProperty("diesel").GetString(),
                lpg = turkeyEntry.Value.GetProperty("lpg").GetString()
            };

            // TL dönüşümü
            double euroToTL = 47.56;

            model.gasolineTL = ConvertEuroToTL(model.gasoline, euroToTL);
            model.dieselTL = ConvertEuroToTL(model.diesel, euroToTL);
            model.lpgTL = ConvertEuroToTL(model.lpg, euroToTL);

            return model;
        }

        private string ConvertEuroToTL(string euroString, double euroToTL)
        {
            if (string.IsNullOrWhiteSpace(euroString) || euroString == "-")
                return "-";

            if (double.TryParse(euroString.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double euroValue))
            {
                double tl = euroValue * euroToTL;
                return tl.ToString("0.00") + " ₺";
            }

            return "-";
        }
    }
}
