using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Entities;

public class Entity<TId>
{
    public required TId Id { get; set; }
    public DateTime Created { get; set; }   
    public DateTime Updated { get; set; }
    = DateTime.Now;
    

}
