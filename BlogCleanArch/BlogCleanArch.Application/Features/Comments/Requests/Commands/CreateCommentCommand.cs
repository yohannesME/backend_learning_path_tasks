using Application.DTOs.Comment;
using Application.Responses;
using MediatR;

namespace Application.Features.Comments.Requests.Commands;

public class CreateCommentCommand : IRequest<BaseCommandResponse>
{
    public CreateCommentDto CommentDto { get; set; }
}