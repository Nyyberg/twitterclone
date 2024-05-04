using DTO;
using Microsoft.AspNetCore.Mvc;
using PostService;
using PostService.DTOs;
using System.Text.Json;

namespace Post_API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        IPostService _postService;

        public PostController(IPostService postService) 
        { 
            _postService = postService;

        }

        [HttpGet]
        public ActionResult GetAllPosts()
        {
            var post = _postService.GetAllPosts();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]AddPostDTO addPostDTO)
        {
            var post = await _postService.CreatePost(addPostDTO);
            return Ok(post);
        }

        [HttpDelete]
        public ActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdatePost(UpdatePostDTO updatePostDTO)
        {
            _postService.UpdatePost(updatePostDTO);
            return Ok();
        }

        [HttpGet]
        public async Task<Timeline> Get()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("Http://localhost:8080/timline");
            string jsondata = await response.Content.ReadAsStringAsync();
            Timeline timeline = JsonSerializer.Deserialize<Timeline>(jsondata);
            return timeline;
        }

        [HttpGet]
        [Route("GetPost")]
        public ActionResult GetPost(int id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }
    }
}
