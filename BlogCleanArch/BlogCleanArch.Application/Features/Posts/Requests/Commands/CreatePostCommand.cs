using Application.DTOs.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<BaseCommandResponse>
{
    public CreatePostDto PostDto { get; set; }

}
