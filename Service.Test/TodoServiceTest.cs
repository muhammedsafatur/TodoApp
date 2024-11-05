using AutoMapper;
using Core.Exceptions;
using Models.Entities;
using Models.Todos;
using Moq;
using Repository.Repositories.Abstract;
using Service.Concretes;
using Service.Constants;
using Service.Rules;



namespace Service.Test;

public class PostServiceTest
{
    private TodoService _todoService;

    private Mock<ITodoRepository> _mockRepository;

    private Mock<IMapper> _mockMapper;

    private Mock<TodoBusinessRules> _mockRules;


    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<ITodoRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockRules = new Mock<TodoBusinessRules>(_mockRepository.Object);

        _todoService = new TodoService(_mockRepository.Object, _mockMapper.Object, _mockRules.Object);
    }


    [Test]
    public async Task TodoService_WhenPostAdded_ReturnSuccess()
    {

        // Arrange
        CreateTodoRequestDto dto = new CreateTodoRequestDto(
    "deneme",           // Title
    "deneme",           // Description
    true,                  // CategoryId
    DateTime.UtcNow,   // DueDate
    DateTime.UtcNow,   // CreatedTime
    1,                  // Priority (örnek bir deðer; uygun þekilde ayarlayýn)
    "userId",          // UserId (örnek bir deðer; uygun þekilde ayarlayýn)
    Todo.PriorityEnum.High // PriorityEnum (örnek bir deðer; uygun þekilde ayarlayýn)
);
        Todo todo = new Todo
        {
            Title = dto.Title,
            IsCompleted = true,
            DueDate = DateTime.UtcNow,
            CreatedTime = DateTime.Now,
            Priority=Todo.PriorityEnum.High,
            UserId=dto.UserId, 
            Id=new Guid(),
            UpdatedTime = DateTime.Now,          
            Description = dto.Description,
            CategoryId = dto.CategoryId
            
        };

        TodoResponseDto response = new TodoResponseDto
        {
            UserName = "deneme",
            CategoryName = "deneme",
            Description = "deneme",
            CreatedTime = DateTime.Now,
            DueDate =DateTime.MaxValue,
            IsCompleted = false,
            PriorityEnum=null,
            Id = new Guid("{EEF23537-D755-4B37-8A99-831089A5D0F1}"),
            Title = "deneme"

        };

        _mockMapper.Setup(x => x.Map<Todo>(dto)).Returns(todo);
        _mockRepository.Setup(x => x.Add(todo)).Returns(todo);
        _mockMapper.Setup(x => x.Map<TodoResponseDto>(todo)).Returns(response);

        // Act 

        var result = await _todoService.Add(dto, "{AEF23537-D755-4B37-8A99-831089A5D0F1}");

        // Assert 
        Assert.IsTrue(result.Success);
        Assert.AreEqual(response, result.Data);
        Assert.AreEqual(200, result.Status);
        Assert.AreEqual("Post eklendi.", result.Message);

    }

    [Test]
    public void TodoService_WhenPostIsPresent_RemovePost()
    {
        // Arrange
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
        Todo todo = new Todo
        {
            Id = id,
            Title = "dto.Title",
            Description = "dto.Content",
            CategoryId = 1,
            UserId = "DENEME",
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now
        };


        _mockRules.Setup(x => x.TodoIsPresent(id)).Returns(true);


        _mockRepository.Setup(x => x.GetById(id)).Returns(todo);
        _mockRepository.Setup(x => x.Delete(todo)).Returns(todo);


        // Act

        var result = _todoService.DeleteById(id);

        // Assert

        Assert.IsTrue(result.Success);
    }

    [Test]
    public void TodoService_WhenPostIsNotPresent_RemoveFailed()
    {
        // Arrange 
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");

        _mockRules.Setup(x => x.TodoIsPresent(id)).Throws(new NotFoundException(Messages.TodoIsNotPresentMessage(id)));

        //Assert
        Assert.Throws<NotFoundException>(() => _todoService.DeleteById(id), Messages.TodoIsNotPresentMessage(id));
    }

    [Test]
    public void TodoService_WhenGetAllByTitleContainsFilter_ReturnsList()
    {
        // Arange

        string text = "deneme";
        List<Todo> todos = new List<Todo>();
        List<TodoResponseDto> todoResponseDto = new();
        _mockRepository.Setup(x => x.GetAll(x => x.Title.Contains(text))).Returns(todos);
        _mockMapper.Setup(x => x.Map<List<TodoResponseDto>>(todos)).Returns(todoResponseDto);


        // Act
        var result = _todoService.GetAllByTitleContains(text);
        //Assert
        Assert.AreEqual(todoResponseDto, result.Data);
        Assert.IsTrue(result.Success);
        Assert.AreEqual(200, result.Status);
    }

}
