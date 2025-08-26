using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.MessageCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers
{
    public class CreateMessageCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateMessageCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMessageCommand command)
        {
            _context.Messages.Add(new Message
            {
                Email = command.Email,
                Phone = command.Phone,
                MessageDetail = command.MessageDetail,
                Subject = command.Subject,
                Surname = command.Surname,
                Name = command.Name
            });

            await _context.SaveChangesAsync();
        }
    }
}
