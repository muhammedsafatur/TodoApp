using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Category;

public record UpdateCategoryRequestDto
(
    int Id,string Name, string Title, string Description
    );
