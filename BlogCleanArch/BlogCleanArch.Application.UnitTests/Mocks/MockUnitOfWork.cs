using Application.Contracts.Persistence;
using Moq;

namespace BlogCleanArch.Application.UnitTests.Mocks;

public class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetUnitOfWork()
    {
        var mockUow = new Mock<IUnitOfWork>();
        
        var mockPostRepository = MockPostRepository.GetPostRepository();
        var mockCommentRepository = MockCommentRepository.GetCommentRepository();

        mockUow.Setup(r => r.PostRepository).Returns(mockPostRepository.Object);
        mockUow.Setup(r => r.CommentRepository).Returns(mockCommentRepository.Object);

        return mockUow;
    }
}