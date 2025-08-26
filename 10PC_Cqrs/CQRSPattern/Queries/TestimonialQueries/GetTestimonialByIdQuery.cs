namespace _10PC_Cqrs.CQRSPattern.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
