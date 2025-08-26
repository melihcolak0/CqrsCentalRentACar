using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.MessageCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers
{
    public class UpdateMessageCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateMessageCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateMessageCommand command)
        {
            var value = await _context.Messages.FindAsync(command.MessageId);

            value.Surname = command.Surname;
            value.Name = command.Name;
            value.Phone = command.Phone;
            value.Email = command.Email;
            value.MessageDetail = command.MessageDetail;
            value.Subject = command.Subject;

            await _context.SaveChangesAsync();
        }
    }
}
