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
        
        // Get all the comments
        mockCommentRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);
        
        // Add a single comment
        mockCommentRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
        {
            comments.Add(comment);
            return comment;
        });

        // Get a comment with post id
        mockCommentRepo.Setup(r => r.GetCommentsWithPostId(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            return comments.Where(c => c.PostId == id).ToList();
        });
        
        // Get a comment with id
        mockCommentRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            return comments.Find(c => c.Id == id);
        });
        
        // Delete Implememtation for the DeleteCommentCommandHandler
        mockCommentRepo.Setup(r => r.Delete(It.IsAny<Comment>())).Callback((Comment comment) =>
        {
            comments.Remove(comment);
        });
        
      
        
        return mockCommentRepo;
    }
}