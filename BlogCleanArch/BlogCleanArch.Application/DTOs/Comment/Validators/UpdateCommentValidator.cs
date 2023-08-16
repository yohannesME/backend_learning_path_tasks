using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Comment.Validators;

public class UpdateCommentValidator : AbstractValidator<CommentDto>
{
    public UpdateCommentValidator(IUnitOfWork unitOfWork)
    {
        Include(new ICommentDtoValidator(unitOfWork));
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
    }
}