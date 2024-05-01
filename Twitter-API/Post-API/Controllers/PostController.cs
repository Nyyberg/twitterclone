using Microsoft.AspNetCore.Mvc;
using PostService;
using PostService.DTOs;

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
        public ActionResult CreatePost([FromBody]AddPostDTO addPostDTO)
        {
            var post = _postService.CreatePost(addPostDTO);
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
        [Route("GetPost")]
        public ActionResult GetPost(int id)
        {
            var post = _postService.GetById(id);
            return Ok(post);
        }
    }
}
