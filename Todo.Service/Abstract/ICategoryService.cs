using Core.Entities;
using Models.Category;

namespace SweetDictionary.Service.Abstract;

public interface ICategoryService
{

    ReturnModel<List<CategoryResponseDto>> GetAllCategories();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryAddRequestDto> Add(CategoryAddRequestDto dto);
    ReturnModel<UpdateCategoryRequestDto> Update(UpdateCategoryRequestDto dto);

    ReturnModel<CategoryResponseDto> Delete(int id);

}
