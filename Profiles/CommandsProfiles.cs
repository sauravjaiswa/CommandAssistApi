using AutoMapper;
using CommandAssistApi.Dtos;
using CommandAssistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandAssistApi.Profiles
{
    public class CommandsProfiles : Profile
    {
        public CommandsProfiles()
        {
            //Source->Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
