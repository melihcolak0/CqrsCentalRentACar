namespace _10PC_Cqrs.CQRSPattern.Results.EmployeeResults
{
    public class GetEmployeeByIdQueryResult
    {
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
    }
}
