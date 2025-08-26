namespace _10PC_Cqrs.CQRSPattern.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public int Id { get; set; }

        public RemoveCarCommand(int id)
        {
            Id = id;
        }
    }
}
