using Application.DTOs.Comment;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Comments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogCleanArch.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("post/{postId}")]
    public async Task<ActionResult<List<CommentDto>>> GetWithPostId(int postId)
    {
        var comment = await _mediator.Send(new GetCommentListRequest(){Id = postId});
        return Ok(comment);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> Get(int id)
    {
        var comment = await _mediator.Send(new GetCommentDetailRequest() { Id = id });
        return Ok(comment);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreateCommentDto comment)
    {
        var command = new CreateCommentCommand() { CommentDto = comment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CommentDto comment)
    {
        var command = new UpdateCommentCommand() { CommentDto = comment };
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCommentCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    
    
}