using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Models.Entities;

public class Category:Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Task> Tasks { get; set; }
}
