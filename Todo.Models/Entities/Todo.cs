using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities;

public class Todo : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime DueDate { get; set; }
    public Enums Priority { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}
