using Application.Contracts.Persistence;
using Application.DTOs.Comment;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Queries;
using Application.Profiles;
using AutoMapper;
using BlogCleanArch.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit.Abstractions;

namespace BlogCleanArch.Application.UnitTests.Comments.Queries;

public class GetCommentListRequestHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    GetCommentListRequestHandler _handler;

    public GetCommentListRequestHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetCommentListRequestHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task GetCommentListTest()
    {

        var result = await _handler.Handle(new GetCommentListRequest(){Id = 1}, CancellationToken.None);
        
        var comments = await _mockRepo.Object.CommentRepository.GetAll();

        result.ShouldBeOfType<List<CommentDto>>();
        
        result.Count.ShouldBe(2);
        
    }
    
}