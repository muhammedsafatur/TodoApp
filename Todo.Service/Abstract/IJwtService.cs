using Models.Entities;
using Models.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}
