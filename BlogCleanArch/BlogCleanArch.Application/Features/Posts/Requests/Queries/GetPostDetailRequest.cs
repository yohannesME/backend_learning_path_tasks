using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetPostDetailRequest : IRequest<PostDto>
{
    public int Id { get; set; }

}