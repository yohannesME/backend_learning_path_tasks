using Application.DTOs.Comment.Validators;

namespace Application.DTOs.Comment;

public class CreateCommentDto : ICommentDto
{
    public string Text { get; set; } = "";
    public int PostId { get; set; }
}