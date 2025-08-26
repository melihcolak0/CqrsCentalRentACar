namespace _10PC_Cqrs.CQRSPattern.Queries.EmployeeQueries
{
    public class GetEmployeeByIdQuery
    {
        public int Id { get; set; }

        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
