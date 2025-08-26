namespace _10PC_Cqrs.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public string AreaCode { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
