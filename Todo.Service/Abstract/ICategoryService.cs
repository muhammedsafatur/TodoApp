using Core.Entities;
using Models.Category;

namespace Service.Abstract;

public interface ICategoryService
{

    ReturnModel<List<CategoryResponseDto>> GetAllCategories();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CreateCategoryRequestDto> Add(CreateCategoryRequestDto dto);
    ReturnModel<UpdateCategoryRequestDto> Update(UpdateCategoryRequestDto dto);

    ReturnModel<CategoryResponseDto> Delete(int id);

}
