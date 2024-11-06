using Microsoft.AspNetCore.Mvc;
using Models.Category;
using Service.Abstract;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAllCategories();
        return Ok(result);
    }

    [HttpGet("getbyid/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }
}
