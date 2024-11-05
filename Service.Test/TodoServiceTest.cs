using AutoMapper;
using Core.Exceptions;
using Models.Entities;
using Models.Todos;
using Moq;
using NUnit.Framework;
using Repository.Repositories.Abstract;
using Service.Concretes;
using Service.Constants;
using Service.Rules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Test
{
    public class TodoServiceTest
    {
        private TodoService _todoService;
        private Mock<ITodoRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<TodoBusinessRules> _mockRules; // Mock oluþturuldu

       
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ITodoRepository>();
            _mockMapper = new Mock<IMapper>();

            // TodoBusinessRules için mock nesnesini oluþtururken baðýmlýlýðý geçelim
            _mockRules = new Mock<TodoBusinessRules>(_mockRepository.Object);

            _todoService = new TodoService(_mockRepository.Object, _mockMapper.Object, _mockRules.Object);
        }

        [Test]
        public async Task TodoService_WhenTodoAdded_ReturnSuccess()
        {
            // Arrange
            var dto = new CreateTodoRequestDto(
                "deneme",
                "deneme",
                true,
                DateTime.UtcNow,
                DateTime.UtcNow,
                1,
                "userId",
                Todo.PriorityEnum.High
            );

            var todo = new Todo
            {
                Title = dto.Title,
                IsCompleted = false,
                DueDate = DateTime.UtcNow,
                CreatedTime = DateTime.Now,
                Priority = Todo.PriorityEnum.High,
                UserId = dto.UserId,
                Id = Guid.NewGuid(),
                UpdatedTime = DateTime.Now,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };

            var response = new TodoResponseDto
            {
                UserName = "deneme",
                CategoryName = "deneme",
                Description = "deneme",
                CreatedTime = DateTime.Now,
                DueDate = DateTime.MaxValue,
                IsCompleted = false,
                PriorityEnum = Todo.PriorityEnum.High,
                Id = todo.Id,
                Title = "deneme"
            };

            _mockMapper.Setup(x => x.Map<Todo>(dto)).Returns(todo);
            _mockRepository.Setup(x => x.Add(todo)).Returns(todo);
            _mockMapper.Setup(x => x.Map<TodoResponseDto>(todo)).Returns(response);

            // Act
            _mockRules.Setup(x => x.TodoTitleMustBeUnique(dto.Title)); // Mock üzerinden setup yapýldý
            var result = await _todoService.Add(dto, "userId");

            // Assert 
            _mockRules.Verify(x => x.TodoTitleMustBeUnique(dto.Title), Times.Once); // Verifiy
            Assert.IsTrue(result.Success);
            Assert.AreEqual(response, result.Data);
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual("Task Eklendi.", result.Message);
        }

        [Test]
        public void TodoService_WhenTodoIsPresent_RemoveTodo()
        {
            // Arrange
            Guid id = Guid.Parse("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
            var todo = new Todo
            {
                Id = id,
                Title = "dto.Title",
                Description = "dto.Content",
                CategoryId = 1,
                UserId = "DENEME",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            _mockRules.Setup(x => x.TodoIsPresent(id)); // Mock üzerinden setup yapýldý

            _mockRepository.Setup(x => x.GetById(id)).Returns(todo);
            _mockRepository.Setup(x => x.Delete(todo)).Returns(todo);

            // Act
            var result = _todoService.DeleteById(id);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void TodoService_WhenTodoIsNotPresent_RemoveFailed()
        {
            // Arrange 
            Guid id = Guid.Parse("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
            _mockRules.Setup(x => x.TodoIsPresent(id)).Throws(new NotFoundException(Messages.TodoIsNotPresentMessage(id)));

            // Assert
            Assert.Throws<NotFoundException>(() => _todoService.DeleteById(id), Messages.TodoIsNotPresentMessage(id));
        }

        [Test]
        public void TodoService_WhenGetAllByTitleContainsFilter_ReturnsList()
        {
            // Arrange
            string text = "deneme";
            var todos = new List<Todo>();
            var todoResponseDto = new List<TodoResponseDto>();
            _mockRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Todo, bool>>>()))
                           .Returns(todos);
            _mockMapper.Setup(x => x.Map<List<TodoResponseDto>>(todos)).Returns(todoResponseDto);

            // Act
            var result = _todoService.GetAllByTitleContains(text);

            // Assert
            Assert.AreEqual(todoResponseDto, result.Data);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(200, result.Status);
        }
    }
}
