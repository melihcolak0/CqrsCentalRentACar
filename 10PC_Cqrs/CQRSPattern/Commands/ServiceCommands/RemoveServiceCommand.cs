namespace _10PC_Cqrs.CQRSPattern.Commands.ServiceCommands
{
    public class RemoveServiceCommand
    {
        public int Id { get; set; }

        public RemoveServiceCommand(int id)
        {
            Id = id;
        }
    }
}
