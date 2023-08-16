using Application.Contracts.Persistence;
using Domain;

namespace BlogCleanArch.Persistence.Repositories;

public class PostRepository : GenericRepository<Post> , IPostRepository
{   
    private readonly BlogDbContext _dbContext;
    
    public PostRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}