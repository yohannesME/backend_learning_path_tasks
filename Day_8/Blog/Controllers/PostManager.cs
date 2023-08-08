using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private static ApiDbContext _context;
    
    public PostController(ApiDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPost()
    {
        var posts = await _context.Posts.ToListAsync();
        return Ok(posts);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        return Ok(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPost", post.Id, post);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
        {
            return NotFound();
        }
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        var postToUpdate = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (postToUpdate == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(postToUpdate);
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}