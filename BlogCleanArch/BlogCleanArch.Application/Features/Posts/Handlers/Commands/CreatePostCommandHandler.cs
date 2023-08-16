
using Application.Contracts.Persistence;
using Application.DTOs.Post;
using Application.DTOs.Post.Validators;
using Application.Features.Posts.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }

    public async Task<BaseCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreatePostValidator();
        var validationResult = await validator.ValidateAsync(request.PostDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            
        }
        else
        {
            var post = _mapper.Map<Post>(request.PostDto );
            
            post = await _unitOfWork.PostRepository.Add(post);

            response.Message = "Creation Successful";
            response.Success = true;
            response.Id = post.Id;
        }

        return response;
    }
}