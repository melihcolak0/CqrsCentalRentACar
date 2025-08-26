using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers
{
    public class CreateEmployeeCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateEmployeeCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateEmployeeCommand command)
        {
            _context.Employees.Add(new Employee
            {
                ImageUrl = command.ImageUrl,
                Profession = command.Profession,
                NameSurname = command.NameSurname
            });

            await _context.SaveChangesAsync();
        }
    }
}
