using _10PC_Cqrs.Models;
using Newtonsoft.Json;
using System.Buffers.Text;

namespace _10PC_Cqrs.AIImplementation
{
    public class RapidAPIAirportsService
    {
        private readonly HttpClient _httpClient;

        public RapidAPIAirportsService(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "My_API_Key");
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "geodatamaster.p.rapidapi.com");
        }

        public async Task<List<RapidAPIAirportsViewModel>> GetAirportsAsync()
        {
            var response = await _httpClient.GetAsync("https://geodatamaster.p.rapidapi.com/api/v1/airport/?country_alpha2=TR");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // API’den dönen JSON içinde "airports": [] var, o yüzden wrapper class lazım
            var root = JsonConvert.DeserializeObject<Root>(json);

            return root?.Airports ?? new List<RapidAPIAirportsViewModel>();
        }
    }

    public class Root
    {
        [JsonProperty("airports")]
        public List<RapidAPIAirportsViewModel> Airports { get; set; }
    }
}
