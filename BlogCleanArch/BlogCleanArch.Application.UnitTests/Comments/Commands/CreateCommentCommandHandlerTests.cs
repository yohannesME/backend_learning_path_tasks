
using Application.Contracts.Persistence;
using Application.DTOs.Comment;
using Application.DTOs.Post;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Posts.Handlers.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Comments.Commands;

public class CreateCommentCommandHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    CreateCommentCommandHandler _handler;

    public CreateCommentCommandHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateCommentCommandHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task CreateCommentTest()
    {
        // create a post
        CreatePostDto newpost = new CreatePostDto()
        {
            Content = "Test Content",
            Title = "Test Title",
        };

        var posthandler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);
        await posthandler.Handle(new CreatePostCommand(){PostDto = newpost}, CancellationToken.None);

        var posts = await _mockRepo.Object.PostRepository.GetAll();
        
        CreateCommentDto comment = new CreateCommentDto()
        {
            PostId = 1,
            Text = "Test"
        };
        
        var result = await _handler.Handle(new CreateCommentCommand(){CommentDto = comment}, CancellationToken.None);
        var comments = await _mockRepo.Object.CommentRepository.GetAll();
        
        comments.Count.ShouldBe(5);
        result.ShouldBeOfType<BaseCommandResponse>();
    }
}