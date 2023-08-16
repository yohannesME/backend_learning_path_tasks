using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogCleanArch.Persistence.Repositories;

public class PostRepository : GenericRepository<Post> , IPostRepository
{   
    private readonly BlogDbContext _dbContext;
    
    public PostRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Post> GetPostWithComments(int id)
    {
        return await _dbContext.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Post>> GetPostsWithComments()
    {
        return await _dbContext.Posts.Include(p => p.Comments).ToListAsync();
    }
}