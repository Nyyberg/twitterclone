using AutoMapper;
using DTO;
using MessagingService;
using NSubstitute;
using PostRepo;
using PostService;

namespace Posttest
{
    public class PostserviceTest
    {
        private PostService.PostService _postservice;
        private IPostRepo _postrepo;
        private IMapper _mapper;
        private IMessagingClient _messagingClient;

        public PostserviceTest() 
        {
            _postrepo = Substitute.For<IPostRepo>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void Get_All_Post_Success_Test()
        {
            //Arrange
            _postrepo = Substitute.For<IPostRepo>();
            _mapper = Substitute.For<IMapper>();
            _messagingClient = Substitute.For<IMessagingClient>();
            _postservice = new PostService.PostService(_postrepo, _mapper, _messagingClient);

            _postrepo.GetAllPosts().Returns(new List<Post> { new Post { postDate = DateTime.Now, postID = 1, postText = "america ya :D", TimelineID = 1 } });

            //Act
            _postservice.GetAllPosts();

            //Assert
            _postrepo.Received(1).GetAllPosts();
        }
    }
}