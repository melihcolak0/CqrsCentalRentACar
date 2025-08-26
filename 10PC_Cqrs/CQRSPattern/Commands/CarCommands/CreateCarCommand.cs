namespace _10PC_Cqrs.CQRSPattern.Commands.CarCommands
{
    public class CreateCarCommand
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Seat { get; set; }
        public string Transmission { get; set; }
        public string Petrol { get; set; }
        public string Year { get; set; }
        public string Gear { get; set; }
        public string Km { get; set; }
        public decimal Review { get; set; }
        public string ImageUrl { get; set; }
        public decimal PriceByDay { get; set; }
    }
}
