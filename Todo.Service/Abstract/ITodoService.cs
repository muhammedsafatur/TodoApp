﻿using Core.Entities;
using Models.Todos;

namespace Service.Abstract;

public interface ITodosService
{
    Task<ReturnModel<TodoResponseDto>> Add(CreateTodoRequestDto dto, string userId);
    ReturnModel<ReturnModel<TodoResponseDto>> GetAll();
    ReturnModel<TodoResponseDto> GetById(Guid id);
    ReturnModel<TodoResponseDto> UpdateById(UpdateTodoRequestDto dto);
    ReturnModel<TodoResponseDto> DeleteById(Guid id);
    ReturnModel<List<TodoResponseDto>> GetAllTodosByCategoryId(int categoryId);
    ReturnModel<List<TodoResponseDto>> GetAllTodosByUserId(Guid userId);
    ReturnModel<List<TodoResponseDto>> GetAllByTitleContains(string text);
}