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
    
    
        modelBuilder.Entity<Comment>(entity =>
        {
            // 1 - Many
            entity.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
        });
    
    }
}