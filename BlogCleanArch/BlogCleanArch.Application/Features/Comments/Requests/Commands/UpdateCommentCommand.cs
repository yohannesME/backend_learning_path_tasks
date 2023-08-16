using Application.DTOs.Comment;

using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public UpdateCommentDto CommentDto { get; set; }
}