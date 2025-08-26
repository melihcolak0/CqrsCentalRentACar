namespace _10PC_Cqrs.CQRSPattern.Queries.CarQueries
{
    public class GetCarFuelTypeByModelQuery
    {
        public string Model { get; set; }

        public GetCarFuelTypeByModelQuery(string model)
        {
            Model = model;
        }
    }
}
