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

namespace BlogCleanArch.Application.UnitTests.Comments.Commands;

public class GetCommentDetailRequestHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    GetCommentDetailRequestHandler _handler;

    public GetCommentDetailRequestHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockRepo = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new GetCommentDetailRequestHandler(_mockRepo.Object, _mapper);
        
    }
    
    [Fact]
    public async Task GetCommentDetailTest()
    {

        var result = await _handler.Handle(new GetCommentDetailRequest(){Id = 1}, CancellationToken.None);
        result.ShouldBeOfType<CommentDto>();
        
    }
    
}