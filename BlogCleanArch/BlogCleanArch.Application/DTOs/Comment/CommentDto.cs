using Application.DTOs.Comment.Validators;
using Application.DTOs.Common;
using Application.DTOs.Post;

namespace Application.DTOs.Comment;

public class CommentDto : BaseDto, ICommentDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Text { get; set; } = "";
    public int PostId { get; set; }
    public PostDto Post { get; set; } = default!;
}