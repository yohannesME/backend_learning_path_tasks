using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogCleanArch.Persistence.Configurations.Entities;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(
            new Post()
            {
                Id = 1,
                Title = "Test Post 1",
                Content = "Test Content 1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            },
            new Post()
            {
                Id = 2,
                Title = "Test Post 2",
                Content = "Test Content 2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }
        );
    }
}