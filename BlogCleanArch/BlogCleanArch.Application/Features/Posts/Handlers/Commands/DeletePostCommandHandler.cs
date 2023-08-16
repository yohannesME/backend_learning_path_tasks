using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.Get(request.Id);

        if (post is null)
            throw new NotFoundException(nameof(post), request.Id);
        
        await _unitOfWork.PostRepository.Delete(post);
        
        return Unit.Value;
    }
}