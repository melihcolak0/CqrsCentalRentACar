namespace _10PC_Cqrs.Models
{
    public class RapidAPIFuelPriceViewModel
    {
        public string currency { get; set; }
        public string lpg { get; set; }
        public string diesel { get; set; }
        public string gasoline { get; set; }
        public string country { get; set; }

        public string gasolineTL { get; set; }
        public string dieselTL { get; set; }
        public string lpgTL { get; set; }
    }
}
