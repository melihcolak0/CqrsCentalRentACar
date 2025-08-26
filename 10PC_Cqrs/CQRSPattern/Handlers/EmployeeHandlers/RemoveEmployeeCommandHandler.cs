using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers
{
    public class RemoveEmployeeCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveEmployeeCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveEmployeeCommand command)
        {
            var value = await _context.Employees.FindAsync(command.Id);

            _context.Employees.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
