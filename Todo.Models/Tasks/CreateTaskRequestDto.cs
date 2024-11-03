using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models.Tasks;

public record CreateTaskRequestDto(string Title,string Description,bool IsCompleted,DateTime DueDate,int CategoryId,string UserId,PriorityEnum Priority);

