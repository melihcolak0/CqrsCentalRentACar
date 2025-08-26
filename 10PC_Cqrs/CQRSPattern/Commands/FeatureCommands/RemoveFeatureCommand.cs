namespace _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands
{
    public class RemoveFeatureCommand
    {
        public int Id { get; set; }

        public RemoveFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
