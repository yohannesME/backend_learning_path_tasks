using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Handlers.Queries;
using Application.Features.Posts.Requests.Queries;
using Application.Profiles;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace BlogCleanArch.Application.UnitTests.Posts.Commands;

public class GetPostDetailRequestHandlerTests
{
    private IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;

    public GetPostDetailRequestHandlerTests()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public async Task GetPostDetailTest()
    {
        var handler = new GetPostDetailRequestHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetPostDetailRequest(), CancellationToken.None);

        result.ShouldBeOfType<List<PostDto>>();
        
    }

}