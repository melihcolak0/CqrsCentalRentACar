namespace _10PC_Cqrs.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }    
        public string PickUpAirport { get; set; }
        public string DropOffAirport { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
