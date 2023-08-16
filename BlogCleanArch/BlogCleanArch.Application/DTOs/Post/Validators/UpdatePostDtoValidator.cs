using FluentValidation;

namespace Application.DTOs.Post.Validators;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidator()
    {
        Include(new IPostValidator());
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
    }
}