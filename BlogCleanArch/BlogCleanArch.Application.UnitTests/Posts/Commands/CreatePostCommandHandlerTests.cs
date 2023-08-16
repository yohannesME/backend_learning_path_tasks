using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Handlers.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Posts.Commands;

public class CreatePostCommandHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    CreatePostCommandHandler _handler;

    public CreatePostCommandHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new CreatePostCommandHandler(_mockRepo.Object, _mapper);


    }
    
    [Fact]
    public async Task<BaseCommandResponse> CreatePostTest()
    {
        CreatePostDto newpost = new CreatePostDto()
        {
            Content = "Test Content",
            Title = "Test Title",
        };
        
        var result = await _handler.Handle(new CreatePostCommand(){PostDto = newpost}, CancellationToken.None);
        
        var posts = await _mockRepo.Object.PostRepository.GetAll();

        
        posts.Count.ShouldBe(3);
        posts[2].Content.ShouldBeEquivalentTo("Test Content");
        result.ShouldBeOfType<BaseCommandResponse>();
        
        return result;
    }
}