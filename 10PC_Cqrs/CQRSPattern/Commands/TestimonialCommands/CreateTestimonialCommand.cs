namespace _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand
    {
        public string NameSurname { get; set; }
        public string Profession { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
