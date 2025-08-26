namespace _10PC_Cqrs.CQRSPattern.Results.FeatureResults
{
    public class GetFeatureByIdQueryResult
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
