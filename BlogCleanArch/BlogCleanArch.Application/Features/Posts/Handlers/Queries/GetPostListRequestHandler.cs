using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Requests.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<PostDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }
    
    public async Task<List<PostDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
    {
        var posts = await _unitOfWork.PostRepository.GetPostsWithComments();
        return _mapper.Map<List<PostDto>>(posts);
    }
}