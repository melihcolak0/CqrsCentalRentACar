using _10PC_Cqrs.Models;
using Newtonsoft.Json;

namespace _10PC_Cqrs.AIImplementation
{
    public class RapidAPIDistanceAirportsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "My_API_Key";

        public RapidAPIDistanceAirportsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RapidAPIDistanceAirportsViewModel?> GetDistanceAsync(string iata1, string iata2)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://airport-distance-api-apiverve.p.rapidapi.com/v1/iata?iata1={iata1}&iata2={iata2}"),
            };

            request.Headers.Add("x-rapidapi-key", _apiKey);
            request.Headers.Add("x-rapidapi-host", "airport-distance-api-apiverve.p.rapidapi.com");

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RapidAPIDistanceAirportsViewModel>(body);

            return result;
        }
    }
}

// Çalışan Mesafe Hesaplama Metodu

//private const double EarthRadiusKm = 6371;

//public static double Calculate(double lat1, double lon1, double lat2, double lon2)
//{
//    var dLat = ToRadians(lat2 - lat1);
//    var dLon = ToRadians(lon2 - lon1);
//    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
//            Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
//            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
//    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
//    return EarthRadiusKm * c;
//}

//private static double ToRadians(double angle) => angle * Math.PI / 180.0;