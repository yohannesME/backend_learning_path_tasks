using Application.Contracts.Persistence;
using Application.DTOs.Comment;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries;

public class GetCommentDetailRequestHandler : IRequestHandler<GetCommentDetailRequest, CommentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCommentDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }
    
 
    public  async Task<CommentDto> Handle(GetCommentDetailRequest request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.Get(request.Id);
        return _mapper.Map<CommentDto>(comments);
    }
}