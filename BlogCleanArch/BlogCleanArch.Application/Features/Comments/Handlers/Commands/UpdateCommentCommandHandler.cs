using Application.Contracts.Persistence;
using Application.DTOs.Comment.Validators;
using Application.Exceptions;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using FluentValidation.Results;
using MediatR;


namespace Application.Features.Comments.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CommentDto, CancellationToken.None);
        
        
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var comment = await _unitOfWork.CommentRepository.Get(request.CommentDto.Id);

        if (comment is null)
            throw new NotFoundException(nameof(comment), request.CommentDto.Id);
        
        _mapper.Map(request.CommentDto, comment);
        
        await _unitOfWork.CommentRepository.Update(comment);
        return Unit.Value;
    }
}