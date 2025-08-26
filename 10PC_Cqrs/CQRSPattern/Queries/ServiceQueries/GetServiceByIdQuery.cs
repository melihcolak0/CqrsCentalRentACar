namespace _10PC_Cqrs.CQRSPattern.Queries.ServiceQueries
{
    public class GetServiceByIdQuery
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
