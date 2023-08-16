using Application.Contracts.Persistence;
using Application.DTOs.Comment.Validators;
using Application.Features.Comments.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;

    namespace Application.Features.Comments.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CommentDto);
        var response = new BaseCommandResponse();

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var comment = _mapper.Map<Comment>(request.CommentDto);
            comment = await _unitOfWork.CommentRepository.Add(comment);
            
            response.Message = "Creation Successful";
        }

        return response;
    }
}