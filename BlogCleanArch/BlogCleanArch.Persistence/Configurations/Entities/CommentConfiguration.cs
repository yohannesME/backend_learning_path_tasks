using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogCleanArch.Persistence.Configurations.Entities;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(
            new Comment()
            {
                Id = 1,
                Text = "Test Comment 1",
                PostId = 1, 
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            },
            new Comment()
            {
                Id = 2,
                Text = "Test Comment 2",
                PostId = 1,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            },
            new Comment()
            {
                Id = 3,
                Text = "Test Comment 3",
                PostId = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            },
            new Comment()
            {
                Id = 4,
                Text = "Test Comment 4",
                PostId = 2,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            });
    }
}