namespace Messaging.SharedMessages
{
    public class AddPostToTimeline
    {
        public string Message { get; set; }
        public int PostId { get; set; }

        public int TimelineId { get; set; }

    }
}
