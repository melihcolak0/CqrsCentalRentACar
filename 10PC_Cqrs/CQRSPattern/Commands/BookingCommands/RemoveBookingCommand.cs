namespace _10PC_Cqrs.CQRSPattern.Commands.BookingCommands
{
    public class RemoveBookingCommand
    {
        public int Id { get; set; }

        public RemoveBookingCommand(int id)
        {
            Id = id;
        }
    }
}
