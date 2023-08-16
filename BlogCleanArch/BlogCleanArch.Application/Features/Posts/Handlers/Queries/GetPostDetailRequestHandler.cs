using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, PostDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }
    
 
    public  async Task<PostDto> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
    {
        var posts = await _unitOfWork.PostRepository.Get(request.Id);
        return _mapper.Map<PostDto>(posts);
    }
}