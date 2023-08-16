using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand : IRequest<Unit>
{
    public UpdatePostDto PostDto { get; set; }
}