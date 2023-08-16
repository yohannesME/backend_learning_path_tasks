using Application.DTOs.Comment;
using Application.DTOs.Common;

namespace Application.DTOs.Post;

public class UpdatePostDto : BaseDto, IPostDto
{
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";   
    public ICollection<CommentDto> Comments { get; set; }

}