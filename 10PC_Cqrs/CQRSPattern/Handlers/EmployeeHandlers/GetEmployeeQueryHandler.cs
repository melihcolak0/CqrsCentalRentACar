using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.EmployeeResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers
{
    public class GetEmployeeQueryHandler
    {
        private readonly CqrsContext _context;

        public GetEmployeeQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle()
        {
            var values = await _context.Employees.AsNoTracking().ToListAsync();

            return values.Select(x => new GetEmployeeQueryResult
            {
                EmployeeId = x.EmployeeId,
                ImageUrl = x.ImageUrl,
                NameSurname = x.NameSurname,
                Profession = x.Profession
            }).ToList();
        }
    }
}
