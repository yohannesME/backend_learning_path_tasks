using Application.DTOs.Comment;
using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Comments.Requests.Queries;

public class GetCommentListRequest : IRequest<List<CommentDto>>
{
    public int Id { get; set; }
}