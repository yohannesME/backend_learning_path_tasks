using Application.Contracts.Persistence;

namespace BlogCleanArch.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogDbContext _context;
    private IPostRepository _postRepository;
    private ICommentRepository _pommentRepository;

    public UnitOfWork(BlogDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
    
    public IPostRepository PostRepository => 
        _postRepository ?? new PostRepository(_context);
    
    public ICommentRepository CommentRepository => 
        _pommentRepository ?? new CommentRepository(_context);

}