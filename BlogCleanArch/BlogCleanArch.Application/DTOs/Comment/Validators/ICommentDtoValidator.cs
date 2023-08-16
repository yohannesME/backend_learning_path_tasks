using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Comment.Validators;

public class ICommentDtoValidator : AbstractValidator<ICommentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public ICommentDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        RuleFor(x => x.PostId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(async (id, token) =>
            {
                var postExists = await _unitOfWork.PostRepository.Exists(id);
                return postExists;
            }).WithMessage("{PropertyName} does not exist.");
    }
}