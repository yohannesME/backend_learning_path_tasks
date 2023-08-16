using Application.DTOs.Comment;
using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Comments.Requests.Queries;

public class GetCommentDetailRequest : IRequest<CommentDto>
{
    public int Id { get; set; }

}