using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.MessageResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers
{
    public class GetMessageQueryHandler
    {
        private readonly CqrsContext _context;

        public GetMessageQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetMessageQueryResult>> Handle()
        {
            var values = await _context.Messages.AsNoTracking().ToListAsync();

            return values.Select(x => new GetMessageQueryResult
            {
                MessageId = x.MessageId,
                Email = x.Email,
                MessageDetail = x.MessageDetail,
                Name = x.Name,
                Phone = x.Phone,
                Subject = x.Subject,
                Surname = x.Surname
            }).ToList();
        }
    }
}
