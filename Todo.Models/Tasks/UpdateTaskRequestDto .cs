using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models.Tasks;

public record UpdateTaskRequestDto(
    
    Guid Id,
    string Title,
    string Description,
    DateTime CreateTime,
    DateTime DueDate,
    bool IsCompleted,
    Models.Enums Priority

    );

