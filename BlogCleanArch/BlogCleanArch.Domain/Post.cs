using Domain.Common;

namespace Domain;

public class Post : BaseDomainEntity
{
    public Post()
    {
        Comments = new HashSet<Comment>();
    }

    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public ICollection<Comment> Comments { get; set; }
}