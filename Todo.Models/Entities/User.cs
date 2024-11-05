using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public class User : IdentityUser
{
    public DateTime BirthDate
    { get; set; }
  
    public List<Todo> Todos { get; set; }

}
