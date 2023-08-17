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
                Content = "Test Content 1"
            },
            new Post()
            {
                Id = 2,
                Title = "Test Post 2",
                Content = "Test Content 2"
            }
        };
        var mockPostRepo = new Mock<IPostRepository>();
        
        // Get all the posts
        mockPostRepo.Setup(r => r.GetAll()).ReturnsAsync(Posts);
        
        // Get a single Post
        mockPostRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Posts.Find(p => p.Id == id);
        });
        
        
        // get post with details
        mockPostRepo.Setup(r => r.GetPostWithComments(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            return Posts.Find(p => p.Id == id);
        });
        
        // get all posts with details
        mockPostRepo.Setup(r => r.GetPostsWithComments()).ReturnsAsync(Posts);

        mockPostRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) =>
        {
            Posts.Add(post);
            return post;
        });
        
        // Delete Implememtation for the DeletePostCommandHandler
        mockPostRepo.Setup(r => r.Delete(It.IsAny<Post>())).Callback((Post post) =>
        {
            Posts.Remove(post);
        });
        
        return mockPostRepo;
    }
}