namespace Models.Users;

public record RegisterRequestDto(

    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password
    );



