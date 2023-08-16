using Application.Contracts.Persistence;
using Application.DTOs.Post.Validators;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.PostDto);

        
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var post = await _unitOfWork.PostRepository.Get(request.PostDto.Id);

        if (post is null)
            throw new NotFoundException(nameof(post), request.PostDto.Id);
        
        _mapper.Map(request.PostDto, post);
        await _unitOfWork.PostRepository.Update(post);
        
        return Unit.Value;
    }
}