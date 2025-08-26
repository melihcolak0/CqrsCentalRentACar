namespace _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands
{
    public class UpdateFeatureCommand
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
