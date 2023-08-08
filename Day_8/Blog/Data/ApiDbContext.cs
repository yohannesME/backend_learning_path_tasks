using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class ApiDbContext : DbContext     
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
    
        modelBuilder.Entity<Post>(entity =>
        {
            // 1 - Many
            entity.HasMany(p => p.Comments);
        });
    
    }
}