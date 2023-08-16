using Application.DTOs.Comment;
using Application.DTOs.Common;

namespace Application.DTOs.Post;

public class PostDto : BaseDto, IPostDto
{
    public PostDto()
    {
        Comments = new HashSet<CommentDto>();
    }

    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public ICollection<CommentDto> Comments { get; set; }
}