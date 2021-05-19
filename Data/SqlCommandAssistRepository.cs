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

        public IEnumerable<Command> GetAllCommands()
        {
            return commandContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return commandContext.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
