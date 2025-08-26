namespace _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands
{
    public class RemoveEmployeeCommand
    {
        public int Id { get; set; }

        public RemoveEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
