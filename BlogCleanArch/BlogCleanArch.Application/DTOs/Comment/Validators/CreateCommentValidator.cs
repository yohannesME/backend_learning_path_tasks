using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Comment.Validators;

public class CreateCommentValidator : AbstractValidator<ICommentDto>
{
    public CreateCommentValidator(IUnitOfWork unitOfWork)
    {
        Include(new ICommentDtoValidator(unitOfWork));
    }
}