using MediatR;

namespace Application.Features.Posts.Requests.Commands;

public class DeletePostCommand : IRequest
{
    public int Id { get; set; }
}