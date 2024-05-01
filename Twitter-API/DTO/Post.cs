namespace DTO
{
    public class Post
    {
        public int postID { get; set; }
        public required string postText { get; set; }
        public DateTime postDate { get; set; }
        public int TimelineID { get; set; }
    }
}
