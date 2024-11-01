using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Models.Entities;

public class Task:Entity<Guid> 
{
    public string Title    { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}
