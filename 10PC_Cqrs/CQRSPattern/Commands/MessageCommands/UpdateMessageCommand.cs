namespace _10PC_Cqrs.CQRSPattern.Commands.MessageCommands
{
    public class UpdateMessageCommand
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
    }
}
