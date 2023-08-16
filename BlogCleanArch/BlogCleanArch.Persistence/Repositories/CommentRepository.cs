using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogCleanArch.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment> , ICommentRepository
{
    private readonly BlogDbContext _dbContext;
    public CommentRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Comment>> GetCommentsWithPostId(int postId)
    {
        var comment =  await _dbContext.Comments.Where(c => c.PostId == postId).ToListAsync();

        return comment;
    }
}