using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    
    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.CommentRepository.Get(request.Id);
        
        if (comment is null)
            throw new NotFoundException(nameof(comment), request.Id);
        
        await _unitOfWork.CommentRepository.Delete(comment);

        return Unit.Value;
    }
}