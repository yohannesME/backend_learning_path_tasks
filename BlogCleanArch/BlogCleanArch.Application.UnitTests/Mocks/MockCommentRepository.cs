using Application.Contracts.Persistence;
using Domain;
using Moq;

namespace BlogCleanArch.Application.UnitTests.Mocks;

public class MockCommentRepository
{
    public static Mock<ICommentRepository> GetCommentRepository()
    {
        var comments = new List<Comment>
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
            },
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
        };
        
        var mockCommentRepo = new Mock<ICommentRepository>();
        
        mockCommentRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);
        
        mockCommentRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
        {
            comments.Add(comment);
            return comment;
        });
        
        return mockCommentRepo;
    }
}