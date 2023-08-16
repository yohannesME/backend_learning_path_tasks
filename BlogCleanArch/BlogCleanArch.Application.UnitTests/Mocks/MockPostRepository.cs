using Application.Contracts.Persistence;
using Domain;
using Moq;

namespace BlogCleanArch.Application.UnitTests.Mocks;

public class MockPostRepository
{
    public static Mock<IPostRepository> GetPostRepository()
    {
        var Posts = new List<Post>
        {
            new Post()
            {
                Id = 1,
                Title = "Test Post 1",
                Content = "Test Content 1",
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 1,
                        Text = "Test Comment 1",
                        PostId = 1
                    },
                    new Comment()
                    {
                        Id = 2,
                        Text = "Test Comment 2",
                        PostId = 1
                    }
                }
            },
            new Post()
            {
                Id = 2,
                Title = "Test Post 2",
                Content = "Test Content 2",
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 3,
                        Text = "Test Comment 3",
                        PostId = 2
                    },
                    new Comment()
                    {
                        Id = 4,
                        Text = "Test Comment 4",
                        PostId = 2
                    }
                }
            }
        };
        var mockPostRepo = new Mock<IPostRepository>();
        
        mockPostRepo.Setup(r => r.GetAll()).ReturnsAsync(Posts);
        
        mockPostRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) =>
        {
            Posts.Add(post);
            return post;
        });
        
        return mockPostRepo;
    }
}