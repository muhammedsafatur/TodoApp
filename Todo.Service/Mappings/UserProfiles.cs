using AutoMapper;
using Models.Category;
using Models.Entities;
using Models.Todos;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<ChangePasswordRequestDto, User>();
        CreateMap<LoginRequestDto, User>();
        CreateMap<UpdateRequestDto, User>();
        CreateMap<RegisterRequestDto, User>();

    }
}
