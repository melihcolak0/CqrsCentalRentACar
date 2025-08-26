namespace _10PC_Cqrs.CQRSPattern.Results.SliderResults
{
    public class GetSliderByIdQueryResult
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string CarouselClass { get; set; }
    }
}
