﻿using CommandAssistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAssistApi.Data
{
    public interface ICommandAssistRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}
