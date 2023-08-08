using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentManager : ControllerBase
{
    private static ApiDbContext _context;

    public CommentManager(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetComment()
    {
        var comments = await _context.Comments.ToListAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        return Ok(comment);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetComment", comment.Id, comment);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteComment(int id)
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
    
    [HttpPatch]
    public async Task<IActionResult> UpdateComment(int id, Comment comment)
    {
        var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (commentToUpdate == null)
        {
            return NotFound();
        }
        _context.Comments.Remove(commentToUpdate);
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}