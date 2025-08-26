namespace _10PC_Cqrs.CQRSPattern.Commands.SliderCommands
{
    public class CreateSliderCommand
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string CarouselClass { get; set; }
    }
}
