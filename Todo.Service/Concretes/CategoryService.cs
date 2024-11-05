using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Models.Category;
using Models.Entities;
using Repository.Repositories.Abstract;

using Service.Abstract;

namespace Service.Concretes;

public class CategoryService(ICategoryRepository _categoryRepository, IMapper _mapper) : ICategoryService 
{
    public ReturnModel<CreateCategoryRequestDto> Add(CreateCategoryRequestDto dto)
    {
        Category category = _mapper.Map<Category>(dto);

        _categoryRepository.Add(category);

        return new ReturnModel<CreateCategoryRequestDto>
        {
            Message = "Kategori Eklendi.",
            Status = 201,
            Success = true
        };

    }

    public ReturnModel<CategoryResponseDto> Delete(int id)
    {
        Category category = CheckGetById(id);

        _categoryRepository.Delete(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Message = "Kategori silindi.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAllCategories()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Status = 200,
            Success = true
        };
       
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        Category category = CheckGetById(id);
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<UpdateCategoryRequestDto> Update(UpdateCategoryRequestDto dto)
    {
        Category category = CheckGetById(dto.Id);
        category.Name = dto.Name;

        _categoryRepository.Update(category);

        return new ReturnModel<UpdateCategoryRequestDto>
        {
            Message = "Kategori Güncellendi.",
            Success = true,
            Status = 200
        };
    }
    // Private Methods
    private Category CheckGetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if(category is null)
        {
            throw new NotFoundException("İlgili id ye ait Kategori bulunamadı: "+id);
        }
        return category;
    }
}
