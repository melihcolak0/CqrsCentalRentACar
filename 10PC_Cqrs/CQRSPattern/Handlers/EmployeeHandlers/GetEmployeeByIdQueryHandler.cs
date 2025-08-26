using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.EmployeeQueries;
using _10PC_Cqrs.CQRSPattern.Results.EmployeeResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetEmployeeByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery query)
        {
            var value = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == query.Id);

            return new GetEmployeeByIdQueryResult
            {
                EmployeeId = value.EmployeeId,
                NameSurname = value.NameSurname,
                Profession = value.Profession,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
