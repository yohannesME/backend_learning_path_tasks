namespace Blog.Models
{
    public class Comment : BaseEntity

    {
        public string Text { get; set; } = "";
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}