using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Todos;

public record UpdateTodoRequestDto(

    Guid Id,
    string Title,
    string Description,
    DateTime CreateTime,
    DateTime DueDate,
    bool IsCompleted,
    Enum PriorityEnum

    );

