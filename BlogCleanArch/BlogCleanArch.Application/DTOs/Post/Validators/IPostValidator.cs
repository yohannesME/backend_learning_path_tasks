using FluentValidation;

namespace Application.DTOs.Post.Validators;

public class IPostValidator : AbstractValidator<IPostDto>
{
    public IPostValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
    
}