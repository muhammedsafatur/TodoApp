using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models.Category;

public record UpdateCategoryRequestDto
(
    int Id, string Title,string Description
    );
