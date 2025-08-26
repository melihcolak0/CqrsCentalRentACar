namespace _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand
    {
        public string NameSurname { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
    }
}
