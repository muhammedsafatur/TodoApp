using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Category;
using Models.Todos;
using Repository.Repositories.Abstract;
using Service.Abstract;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ITodosService _todoservice) : ControllerBase
    {
        [HttpGet("getall")]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            var result = _todoservice.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateTodoRequestDto dto)
        {

            // kullanıcının tokenden id alanının alınması.
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var result = _todoservice.Add(dto, userId);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {

            var result = _todoservice.GetById(id);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateTodoRequestDto dto)
        {
            var result = _todoservice.UpdateById(dto);
            return Ok(result);
        }

        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _todoservice.GetAllTodosByCategoryId(id);
            return Ok(result);
        }

        [HttpGet("getallbyauthorid")]
        public IActionResult GetaAllByUserId(string userId)
        {

            var result = _todoservice.GetAllTodosByUserId(userId);
            return Ok(result);
        }

        [HttpGet("getallbytitlecontains")]
        public IActionResult GetAllByTitleContains(string text)
        {
            var result = _todoservice.GetAllByTitleContains(text);
            return Ok(result);
        }


        [HttpGet("ownpost")]
        public IActionResult OwnTasks()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var result = _todoservice.GetAllTodosByUserId(userId);

            return Ok(result);

        }
    }
}
