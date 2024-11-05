using Models.Entities;
using Models.Users;



namespace Service.Abstract;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);

    Task<User> LoginAsync(LoginRequestDto dto);

    Task<string> DeleteAsync(string id);

    Task<User> UpdateAsync(string id,UpdateRequestDto dto);
    Task<string> ChangePasswordAsync(string id,ChangePasswordRequestDto dto);


}
