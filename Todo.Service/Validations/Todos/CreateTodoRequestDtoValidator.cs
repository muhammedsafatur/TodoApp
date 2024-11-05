using FluentValidation;
using Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations.Todos;

public class CreateTodoRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateTodoRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Task Başlığı boş olamaz.")
            .Length(2, 50).WithMessage("Task Başlığı Minimum 2 max 50 karakterli olmalıdır.");


        RuleFor(x => x.Description).NotEmpty().WithMessage("Task İçeriği boş olamaz.");
    }
}
