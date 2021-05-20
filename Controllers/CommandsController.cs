using AutoMapper;
using CommandAssistApi.Data;
using CommandAssistApi.Dtos;
using CommandAssistApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly ICommandAssistRepository repository;
        private readonly IMapper mapper;

        public CommandsController(ICommandAssistRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = repository.GetAllCommands();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);
            repository.CreateCommand(commandModel);
            repository.SaveChanges();

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            mapper.Map(commandUpdateDto, commandModelFromRepo);
            repository.UpdateCommand(commandModelFromRepo);
            repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(commandToPatch, commandModelFromRepo);
            repository.UpdateCommand(commandModelFromRepo);
            repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult deleteCommand(int id)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            repository.DeleteCommand(commandModelFromRepo);
            repository.SaveChanges();

            return NoContent();
        }
    }
}
