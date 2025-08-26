namespace _10PC_Cqrs.CQRSPattern.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
