using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetPostListRequest : IRequest<List<PostDto>>
{
    
}