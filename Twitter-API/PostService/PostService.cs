using AutoMapper;
using DTO;
using Messaging.SharedMessages;
using MessagingService;
using PostRepo;
using PostService.DTOs;

namespace PostService
{
    public class PostService : IPostService
    {
        IPostRepo _postRepo;
        IMapper _mapper;
        private MessagingClient _messagingClient;

        public PostService(IPostRepo postRepo, IMapper mapper, MessagingClient messagingClient) 
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _messagingClient = messagingClient;
        }

        public async Task<Post>  CreatePost(AddPostDTO addPost)
        {
           addPost.postDate = DateTime.Now;
           var post = await _postRepo.CreatePost(_mapper.Map<Post>(addPost));
           await _messagingClient.Send<AddPostToTimeline>(new AddPostToTimeline { Message = "adding post to timeline", PostId = post.postID,TimelineId = post.TimelineID }, "AddPostToTimeline");
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
