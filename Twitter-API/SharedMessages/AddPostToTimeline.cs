namespace Messaging.SharedMessages
{
    public class AddPostToTimeline
    {
        public string Message { get; set; }
        public int PostId { get; set; }

        public int TimelineId { get; set; }

        public AddPostToTimeline(string message, int postID, int timlineId)
        {
            Message = message;
            PostId = postID;
            TimelineId = timlineId;
        }
    }
}
