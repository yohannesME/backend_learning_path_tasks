using Application.DTOs.Comment.Validators;
using Application.DTOs.Common;

namespace Application.DTOs.Comment;

public class UpdateCommentDto : BaseDto, ICommentDto
{
    public string Text { get; set; } = "";
    public int PostId { get; set; }
}