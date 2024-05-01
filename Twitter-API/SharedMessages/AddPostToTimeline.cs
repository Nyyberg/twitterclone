namespace Messaging.SharedMessages
{
    public class AddPostToTimeline
    {
        public string Message { get; set; }
        public int PostId { get; set; }

        public AddPostToTimeline(string message, int postID)
        {
            Message = message;
            PostId = postID;
        }
    }
}
