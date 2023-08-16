using Application.Contracts.Persistence;
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

public class DeletePostCommandHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    DeletePostCommandHandler _handler;

    public DeletePostCommandHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new DeletePostCommandHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task DeletePostTest()
    {


        var result = await _handler.Handle(new DeletePostCommand(){Id = 1}, CancellationToken.None);
        
        var posts = await _mockRepo.Object.PostRepository.GetAll();

        posts.Count.ShouldBe(1);
        result.ShouldBeOfType<Unit>();
        
    }
}