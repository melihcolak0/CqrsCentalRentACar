namespace _10PC_Cqrs.CQRSPattern.Commands.MessageCommands
{
    public class RemoveMessageCommand
    {
        public int Id { get; set; }

        public RemoveMessageCommand(int id)
        {
            Id = id;
        }
    }
}
