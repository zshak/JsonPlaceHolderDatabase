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

        [HttpGet("/posts/{id}/comments")]
        public async Task<IActionResult> GetCommentsById(int id)
        {
            return Ok(await _placeHolderService.GetCommentsById(id));
        }

        [HttpGet("/comments")]
        public async Task<IActionResult> GetCommentsByIdQuerry(int id)
        {
            return Ok(await _placeHolderService.GetCommentsByIdQuery(id));
        }
    }
}
