using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Todos;

public record CreateTodoRequestDto(string Title, string Description, bool IsCompleted, DateTime DueDate, DateTime CreatedTime, int CategoryId, string UserId,Enum PriorityEnum  );

