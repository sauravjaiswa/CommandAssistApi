using CommandAssistApi.Data;
using CommandAssistApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAssistApi.Controllers
{
    //api/commands
    //[Route("api/[controller]")]
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommandAssistRepository repository = new MockCommandAssistRepository();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = repository.GetAppCommands();
            return Ok(commandItems);
        }

        //GET api/commands/5
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}
