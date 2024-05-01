using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineRepo
{
    public interface ITimelineRepo
    {
        public Timeline CreateTimeline(Timeline newtimeline);

        Task AddPostToTimeline(Post newpost);

        
    }
}
