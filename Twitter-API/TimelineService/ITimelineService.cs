using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineService.DTOs;

namespace TimelineService
{
    public interface ITimelineService
    {
        public void CreateTimeline(CreateTimelineDTO newTimeline);

        public Task AddPostToTimeline(AddPostToTimelineDTO newPost);

        public Timeline GetTimeline(int TimlineID);
    }
}
