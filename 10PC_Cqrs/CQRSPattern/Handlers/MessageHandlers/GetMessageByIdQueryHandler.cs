using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.MessageQueries;
using _10PC_Cqrs.CQRSPattern.Results.MessageResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers
{
    public class GetMessageByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetMessageByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetMessageByIdQueryResult> Handle(GetMessageByIdQuery query)
        {
            var value = await _context.Messages.AsNoTracking().FirstOrDefaultAsync(x => x.MessageId == query.Id);

            return new GetMessageByIdQueryResult
            {
                MessageId = value.MessageId,
                Name = value.Name,
                Surname = value.Surname,
                Subject = value.Subject,
                MessageDetail = value.MessageDetail,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}
