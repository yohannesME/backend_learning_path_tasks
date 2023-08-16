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
        var post =  await _dbContext.Posts.FindAsync(id);
        
        var comment = await _dbContext.Comments.Where(c => c.PostId == post.Id).ToListAsync();
        post.Comments = comment;
        
        return post;
    }

    public async Task<List<Post>> GetPostsWithComments()
    {
        var posts =  await _dbContext.Posts.ToListAsync();
        foreach (var post in posts)  
        {
            var comment = await _dbContext.Comments.Where(c => c.PostId == post.Id).ToListAsync();
            post.Comments = comment;
        }
        return posts;
    }
}