using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class DeleteCommentCommand : IRequest
{
    public int Id { get; set; }
}