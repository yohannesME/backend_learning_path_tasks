namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IPostRepository PostRepository { get; }
    ICommentRepository CommentRepository { get; }
}