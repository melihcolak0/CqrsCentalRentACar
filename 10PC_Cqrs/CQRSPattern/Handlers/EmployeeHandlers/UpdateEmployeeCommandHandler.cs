using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateEmployeeCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateEmployeeCommand command)
        {
            var value = await _context.Employees.FindAsync(command.EmployeeId);

            value.NameSurname = command.NameSurname;
            value.Profession = command.Profession;
            value.ImageUrl = command.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
