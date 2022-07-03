using AutoMapper;
using ToDo.Application.DTO;
using ToDo.Domain.Entities;

namespace ToDo.Application.Helpers
{
    public class AutoMapperApplicationProfile : Profile
    {
        public AutoMapperApplicationProfile()
        {
            CreateMap<Todo, TodoDTO>();
            CreateMap<NewTodoDTO, Todo>();
        }

    }
}
