using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Hosting;
using Models.Entities;
using Models.Todos;
using Repository.Repositories.Abstract;
using Service.Abstract;
using Service.Constants;
using Service.Rules;

namespace Service.Concretes;

public class TodoService : ITodosService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    private readonly TodoBusinessRules _businessRules;

    public TodoService(ITodoRepository todoRepository, IMapper mapper, TodoBusinessRules businessRules)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public Task<ReturnModel<TodoResponseDto>> Add(CreateTodoRequestDto dto, string userId)
    {
        _businessRules.TodoTitleMustBeUnique(dto.Title);

        Todo createdTodo = _mapper.Map<Todo>(dto);
        createdTodo.Id = Guid.NewGuid();
        createdTodo.UserId = userId;



        Todo todo = _todoRepository.Add(createdTodo);



        TodoResponseDto response = _mapper.Map<TodoResponseDto>(todo);

        return Task.FromResult(new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = Messages.TodoAddedMessage,
            Status = 200,
            Success = true
        });
    }

    public ReturnModel<TodoResponseDto> DeleteById(Guid id)
    {
        _businessRules.TodoIsPresent(id);

        Todo? todo = _todoRepository.GetById(id);
        Todo deletedTodo = _todoRepository.Delete(todo);

        var response = new TodoResponseDto
        {
            Title = deletedTodo.Title,
            CreatedTime=deletedTodo.CreatedTime,
            DueDate = deletedTodo.DueDate,
            Description = deletedTodo.Description,
            Id =deletedTodo.Id,
            PriorityEnum = deletedTodo.Priority,
            IsCompleted = deletedTodo.IsCompleted
        };

        return new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = Messages.TodoDeletedMessage,
            Status = 204,
            Success = true
        };
    }


    public ReturnModel<List<TodoResponseDto>> GetAll()
    {
        var todos = _todoRepository.GetAll();
        List<TodoResponseDto> responses = _mapper.Map<List<TodoResponseDto>>(todos);

        return new ReturnModel<List<TodoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<TodoResponseDto>> GetAllByTitleContains(string text)
    {
        var todos = _todoRepository.GetAll(x => x.Title.Contains(text));
        var responses = _mapper.Map<List<TodoResponseDto>>(todos);
        return new ReturnModel<List<TodoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<TodoResponseDto>> GetAllTodosByCategoryId(int categoryId)
    {
        List<Todo> todos = _todoRepository.GetAll(x => x.CategoryId == categoryId);
        List<TodoResponseDto> responses = _mapper.Map<List<TodoResponseDto>>(todos);
        return new ReturnModel<List<TodoResponseDto>>
        {
            Data = responses,
            Message = $"Kategori Id sine göre Taskler listelendi : Kategori Id: {categoryId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<TodoResponseDto>> GetAllTodosByUserId(string userId)
    {
        List<Todo> todos = _todoRepository.GetAll();
        List<TodoResponseDto> responses = _mapper.Map<List<TodoResponseDto>>(todos);

        return new ReturnModel<List<TodoResponseDto>>
        {
            Data = responses,
            Message = $"Yazar Id sine göre Taskler listelendi : Yazar Id: {userId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<TodoResponseDto> GetById(Guid id)
    {
        _businessRules.TodoIsPresent(id);

        var todos = _todoRepository.GetById(id);
        var response = _mapper.Map<TodoResponseDto>(todos);
        return new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = "İlgili task gösterildi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<TodoResponseDto> UpdateById(UpdateTodoRequestDto dto)
    {
        _businessRules.TodoIsPresent(dto.Id);

        Todo todo = _todoRepository.GetById(dto.Id);

        todo.Title = dto.Title;
        todo.Description = dto.Description;

        _todoRepository.Update(todo);

        TodoResponseDto response = _mapper.Map<TodoResponseDto>(todo);

        return new ReturnModel<TodoResponseDto>
        {
            Data = response,
            Message = "task Güncellendi.",
            Status = 200,
            Success = true
        };
    }

   
}
