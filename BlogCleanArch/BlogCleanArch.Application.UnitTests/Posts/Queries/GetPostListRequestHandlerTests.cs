using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Handlers.Queries;
using Application.Features.Posts.Requests.Queries;
using Application.Profiles;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Posts.Queries;

public class GetPostListRequestHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    GetPostListRequestHandler _handler;

    public GetPostListRequestHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetPostListRequestHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task GetPostListTest()
    {

        var result = await _handler.Handle(new GetPostListRequest(), CancellationToken.None);
        
        var posts = await _mockRepo.Object.PostRepository.GetAll();

        result.ShouldBeOfType<List<PostDto>>();
        
        result.Count.ShouldBe(2);
        
    }
}