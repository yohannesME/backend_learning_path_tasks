using Domain.Common;

namespace Domain;

public class Comment : BaseDomainEntity
{
    public string Text { get; set; } = "";
    public int PostId { get; set; }

}