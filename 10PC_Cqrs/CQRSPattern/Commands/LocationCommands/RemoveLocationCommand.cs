namespace _10PC_Cqrs.CQRSPattern.Commands.LocationCommands
{
    public class RemoveLocationCommand
    {
        public int Id { get; set; }

        public RemoveLocationCommand(int id)
        {
            Id = id;
        }
    }
}
