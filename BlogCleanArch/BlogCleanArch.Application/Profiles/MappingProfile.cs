using Application.DTOs.Comment;
using Application.DTOs.Post;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();


        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
    
}