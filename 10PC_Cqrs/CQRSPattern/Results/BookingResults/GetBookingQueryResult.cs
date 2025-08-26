namespace _10PC_Cqrs.CQRSPattern.Results.BookingResults
{
    public class GetBookingQueryResult
    {
        public int BookingId { get; set; }
        public string PickUpAirport { get; set; }
        public string DropOffAirport { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}
