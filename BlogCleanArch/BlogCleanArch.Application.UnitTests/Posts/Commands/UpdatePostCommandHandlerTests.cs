using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Handlers.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Profiles;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Posts.Commands;

public class UpdatePostCommandHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    UpdatePostCommandHandler _handler;

    public UpdatePostCommandHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new UpdatePostCommandHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task UpdatePostTest()
    {
        UpdatePostDto updatePostDto = new UpdatePostDto()
        {
            Id = 1,
            Content = "Test Content 1",
            Title = "Test Title",
        };
        
        var result = await _handler.Handle(new UpdatePostCommand(){PostDto = updatePostDto}, CancellationToken.None);
        
        var posts = await _mockRepo.Object.PostRepository.GetAll();

        posts.Count.ShouldBe(2);
        posts[0].Content.ShouldBeEquivalentTo("Test Content 1");
        result.ShouldBeOfType<Unit>();
        
    }
}