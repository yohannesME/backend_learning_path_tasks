using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private static ApiDbContext _context;

    public CommentController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetComment()
    {
        try
        {
            var comments = await _context.Comments.ToListAsync();
            return Ok(comments);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        try
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if ( comment == null)
            {
                return NoContent();
            }
            return Ok(comment);
        }
        catch (Exception e)
        {                                                                                                           
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment(Comment comment)
    {
        try
        {
            var commentPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == comment.PostId);
            if (commentPost == null)
            {
                return BadRequest();
            }

            // comment.Post = commentPost;
            commentPost.Comments.Add(comment);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", comment.Id, comment);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteComment(int id)
    {
        try
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateComment(int id, Comment comment)
    {
        try
        {
            var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (commentToUpdate == null)
            {
                return NotFound();
            }
            // you can only update the text of a comment
            commentToUpdate.Text = comment.Text;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

}