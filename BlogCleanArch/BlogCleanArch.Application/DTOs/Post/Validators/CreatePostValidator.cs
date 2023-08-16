using FluentValidation;

namespace Application.DTOs.Post.Validators;

public class CreatePostValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostValidator()
    {
        Include(new IPostValidator());
        
    }
}