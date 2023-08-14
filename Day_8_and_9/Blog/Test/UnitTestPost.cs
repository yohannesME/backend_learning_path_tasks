using Blog.Controllers;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test;

public class UnitTestPost
{
    [Fact]
    public async void TestCreatePost()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);

        // Tests create post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        Assert.Single(context.Posts);

    }
    
    [Fact]
    public async void TestGetPost()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        
        //when asking for existing post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        IActionResult result = await post.GetPost(1);
        ObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        
        //when asking for non exitsting post
        IActionResult result2 = await post.GetPost(2);
        NoContentResult objectResult2 = Assert.IsType<NoContentResult>(result2);
        Assert.Equal(204, objectResult2.StatusCode);
        
    }
    
    [Fact]
    public async void TestDeletePost()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        
        //when deleting existing post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        IActionResult result = await post.DeletePost(1);
        NoContentResult objectResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, objectResult.StatusCode);
        
        //when deleting non exitsting post
        IActionResult result2 = await post.DeletePost(2);
        NotFoundResult objectResult2 = Assert.IsType<NotFoundResult>(result2);
        Assert.Equal(404, objectResult2.StatusCode);
        
    }
    
    [Fact]
    public async void TestUpdatePost()
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApiDbContext(optionsBuilder.Options);
        
        //when updating existing post
        var post = new PostController(context);
        await post.CreatePost(new Post(){Id = 1});
        IActionResult result = await post.UpdatePost(1, new Post(){Content = "hello"});
        NoContentResult objectResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, objectResult.StatusCode);
        
        //when updating non exitsting post
        IActionResult result2 = await post.UpdatePost(3, new Post(){Id = 4});
        NotFoundResult objectResult2 = Assert.IsType<NotFoundResult>(result2);
        Assert.Equal(404, objectResult2.StatusCode);
        
    }

}