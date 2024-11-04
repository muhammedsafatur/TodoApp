﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Category;

public record CategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


};