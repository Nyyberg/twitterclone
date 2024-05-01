using AutoMapper;
using DTO;
using PostRepo;
using PostService.DTOs;

namespace PostService
{
    public class PostService : IPostService
    {
        IPostRepo _postRepo;
        IMapper _mapper;

        public PostService(IPostRepo postRepo, IMapper mapper) 
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }

        public Post CreatePost(AddPostDTO addPost)
        {
           addPost.postDate = DateTime.Now;
           var post = _postRepo.CreatePost(_mapper.Map<Post>(addPost));
           return post;
        }

        public void DeletePost(int id)
        {
            _postRepo.DeletePost(id);
        }

        public List<Post> GetAllPosts()
        {
            var posts = _postRepo.GetAllPosts();
            return posts;
        }

        public Post GetById(int id)
        {
            var post = _postRepo.GetById(id);
            return post;
        }

        public void UpdatePost(UpdatePostDTO updatePost)
        {
            updatePost.postDate = DateTime.Now;
            _postRepo.UpdatePost(_mapper.Map<Post>(updatePost));
            
        }
    }
}
