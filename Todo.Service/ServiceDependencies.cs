using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concretes;

using Service.Rules;

using System.Reflection;


namespace Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependenies(this IServiceCollection services)
    {
        services.AddScoped<ITodosService, TodoService>();
        //services.AddScoped<IUserService, UserService>();
       // services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        //services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<TodoBusinessRules>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        return services;
    }
}
