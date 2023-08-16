namespace Application.DTOs.Post;

public class CreatePostDto : IPostDto
{
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    
}