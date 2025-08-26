namespace _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands
{
    public class UpdateEmployeeCommand
    {
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
    }
}
