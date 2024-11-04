using AutoMapper;
using Models.Entities;
using Models.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings;

public class TodoProfiles:Profile
{public TodoProfiles()
    {
        CreateMap<CreateTodoRequestDto, Todo>();
        CreateMap<Todo, TodoResponseDto>();
        CreateMap<UpdateTodoRequestDto, Todo>();

    }
}
