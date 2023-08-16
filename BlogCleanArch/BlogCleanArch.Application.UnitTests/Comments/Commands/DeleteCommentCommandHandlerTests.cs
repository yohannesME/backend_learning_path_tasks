using Application.Contracts.Persistence;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Requests.Commands;
using Application.Profiles;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Comments.Commands;

public class DeleteCommentCommandHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    DeleteCommentCommandHandler _handler;

    public DeleteCommentCommandHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);
        
    }   
    
    [Fact]
    public async Task DeleteCommentTest()
    {
        var comments = await _mockRepo.Object.CommentRepository.GetAll();
        comments.Count.ShouldBe(4);
        var result = await _handler.Handle(new DeleteCommentCommand(){Id = 1}, CancellationToken.None);
        comments = await _mockRepo.Object.CommentRepository.GetAll();
        
        comments.Count.ShouldBe(3);
        result.ShouldBeOfType<Unit>();
    }
}