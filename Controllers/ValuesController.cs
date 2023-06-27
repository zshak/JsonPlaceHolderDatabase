using JsonPlaceHolder.Models;
using JsonPlaceHolder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonPlaceHolder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPlaceHolderService _placeHolderService;

        public ValuesController(IPlaceHolderService iplaceHolder)
        {
            _placeHolderService = iplaceHolder;
        }
        [HttpGet("/posts")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _placeHolderService.GetAllPosts());
        }

        [HttpGet ("/posts/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await _placeHolderService.GetPostById(id));
        }


        [HttpPost("/posts")]
        public async Task<IActionResult> AddPost(int userId, string title, string body)
        {
            await _placeHolderService.AddPost(userId, title, body);
            return Ok();
        }

        [HttpPut ("/posts/{userId}")]
        public async Task<IActionResult> UpdatePost(int userId, string title, string body)
        {
            await _placeHolderService.UpdatePost(userId, title, body);
            return Ok();
        }

        [HttpDelete("/posts/{userId}")]
        public async Task<IActionResult> DeletePost(int userId)
        {
            await _placeHolderService.DeletePost(userId);
            return Ok();
        }
    }
}
