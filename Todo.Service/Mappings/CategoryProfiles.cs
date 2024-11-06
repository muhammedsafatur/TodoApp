using AutoMapper;
using Models.Category;
using Models.Entities;
using Models.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings;

public class CategoryProfiles : Profile
{
    public CategoryProfiles()
    {
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<UpdateCategoryRequestDto, Category>();

    }
}
