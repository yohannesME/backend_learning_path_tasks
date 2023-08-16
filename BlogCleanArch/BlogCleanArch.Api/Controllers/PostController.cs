using Application.DTOs.Post;
using Application.Features.Posts.Requests.Commands;
using Application.Features.Posts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogCleanArch.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> Get()
    {
        var post = await _mediator.Send(new GetPostListRequest());
        return Ok(post);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> Get(int id)
    {
        var post = await _mediator.Send(new GetPostDetailRequest() { Id = id });
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreatePostDto post)
    {
        var command = new CreatePostCommand() { PostDto = post };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PostDto post)
    {
        var command = new UpdatePostCommand() { PostDto = post };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePostCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    



}