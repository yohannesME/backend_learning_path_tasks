using Application.Contracts.Persistence;
using Application.DTOs.Comment;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries;

public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCommentListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }
    
    public async Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.GetCommentsWithPostId(request.Id);
        return _mapper.Map<List<CommentDto>>(comments);
    }
}