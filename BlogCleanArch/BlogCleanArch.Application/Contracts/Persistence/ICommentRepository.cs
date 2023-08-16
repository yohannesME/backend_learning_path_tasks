using Domain;

namespace Application.Contracts.Persistence;

public interface ICommentRepository : IGenericRepository<Comment>
{
    public Task<List<Comment>> GetCommentsWithPostId(int postId);
}