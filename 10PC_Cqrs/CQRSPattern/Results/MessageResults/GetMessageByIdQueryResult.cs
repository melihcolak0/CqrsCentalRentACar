namespace _10PC_Cqrs.CQRSPattern.Results.MessageResults
{
    public class GetMessageByIdQueryResult
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
