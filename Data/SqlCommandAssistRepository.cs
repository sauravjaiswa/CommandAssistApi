using CommandAssistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAssistApi.Data
{
    public class SqlCommandAssistRepository : ICommandAssistRepository
    {
        private readonly CommandContext commandContext;

        public SqlCommandAssistRepository(CommandContext commandContext)
        {
            this.commandContext = commandContext;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            commandContext.Commands.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return commandContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return commandContext.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (commandContext.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            //Nothing
        }
    }
}
