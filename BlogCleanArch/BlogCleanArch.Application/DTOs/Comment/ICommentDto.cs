namespace Application.DTOs.Comment.Validators;

public interface ICommentDto
{
    public string Text { get; set; }
    public int PostId { get; set; }
}