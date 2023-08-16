using Domain;

namespace Application.Contracts.Persistence;

public interface IPostRepository : IGenericRepository<Post>
{
    public Task<Post> GetPostWithComments(int id);
    public Task<List<Post>> GetPostsWithComments();

}