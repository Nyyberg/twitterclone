using AutoMapper;
using DTO;
using EasyNetQ;
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
        private IMessagingClient _messagingClient;

        public PostService(IPostRepo postRepo, IMapper mapper, IMessagingClient messagingClient) 
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _messagingClient = messagingClient;
        }

        public async Task<Post>  CreatePost(AddPostDTO addPost)
        {
            _messagingClient = new MessagingClient(RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualHost=/;username=guest;password=guest"));
           Console.WriteLine("sending post");
           addPost.postDate = DateTime.Now;
           var post = await _postRepo.CreatePost(_mapper.Map<Post>(addPost));
           await _messagingClient.Send(new AddPostToTimeline { Message = "adding post to timeline", PostId = post.postID,TimelineId = post.TimelineID }, "NASA");
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
