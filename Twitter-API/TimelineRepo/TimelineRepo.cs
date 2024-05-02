
using DTO;
using Microsoft.EntityFrameworkCore;

namespace TimelineRepo
{
    public class TimelineRepo : ITimelineRepo
    {
        private DbContextOptions<TimelineDbContext> _options;

        public TimelineRepo() 
        {
            _options = new DbContextOptionsBuilder<TimelineDbContext>().UseInMemoryDatabase("TimelineDB").Options;
        }

        public async Task AddPostToTimeline(Post newpost)
        {
            using(var context = new TimelineDbContext(_options, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped))
            {
                var timeline = context.Timelines.Find(newpost.TimelineID);
                if(timeline == null)
                {
                    throw new ArgumentException("Timeline is not found", nameof(newpost.TimelineID));
                }
                timeline.PostIDs.Add(newpost.postID);
                await context.SaveChangesAsync();
            }
        }

        public Timeline CreateTimeline(Timeline newtimeline)
        {
            using (var context = new TimelineDbContext(_options, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped))
            {
               context.Timelines.Add(newtimeline);
               context.SaveChanges();
            }
            return newtimeline;
        }

        public Timeline GetTimeline(int timelineId)
        {
            using (var context = new TimelineDbContext(_options, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped))
            {
                var timeline = context.Timelines.Find(timelineId);
                if (timeline == null)
                {
                    throw new ArgumentException("Timeline not found.", nameof(timelineId));
                }
                return timeline;
            }

        }
    }
}
