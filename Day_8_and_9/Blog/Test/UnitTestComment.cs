using Blog.Controllers;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test;

public class UnitTestComment
{
    [Fact]
    public async void TestCreateComment()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        // first create a post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        

        // Tests create comment
        var comment = new CommentController(context);
        await comment.CreateComment(new Comment(){Id = 1, PostId = 1});
        Assert.Single(context.Comments);

    }
    
    [Fact]
    public async void TestGetComment()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        
        // first create a post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        
        //when asking for existing comment
        var comment = new CommentController(context);
        await comment.CreateComment(new Comment(){Id = 1, PostId = 1});
        IActionResult result = await comment.GetComment(1);
        ObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        
        //when asking for non exitsting comment
        IActionResult result2 = await comment.GetComment(2);
        NoContentResult objectResult2 = Assert.IsType<NoContentResult>(result2);
        Assert.Equal(204, objectResult2.StatusCode);
        
    }
    
    [Fact]
    public async void TestDeleteComment()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        
        // first create a post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        
        //when deleting existing comment
        var comment = new CommentController(context);
        await comment.CreateComment(new Comment(){Id = 1, PostId = 1});
        IActionResult result = await comment.DeleteComment(1);
        NoContentResult objectResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, objectResult.StatusCode);
        
        //when deleting non existing comment
        IActionResult result2 = await comment.DeleteComment(2);
        NotFoundResult objectResult2 = Assert.IsType<NotFoundResult>(result2);
        Assert.Equal(404, objectResult2.StatusCode);
        
    }
    
}