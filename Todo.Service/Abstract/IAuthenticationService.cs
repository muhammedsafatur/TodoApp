using Models.Tokens;
using Models.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract;

public interface IAuthenticationService
{

    Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto);
    Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto);
}
