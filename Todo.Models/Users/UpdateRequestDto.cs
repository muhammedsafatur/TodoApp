﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Users;

public record UpdateRequestDto(

    string UserName,
    DateTime BirthDate

    );

