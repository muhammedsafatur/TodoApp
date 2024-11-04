using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Todos;

public record TodoResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public string CategoryName { get; set; }
    public string UserName { get; set; }
    public Enums Priority { get; set; }



}



