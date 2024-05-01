using AutoMapper;
using DTO;
using TimelineRepo;
using TimelineService.DTOs;

namespace TimelineService
{
    public class TimelineService : ITimelineService
    {
        private ITimelineRepo _timelineRepo;
        private readonly IMapper _mapper;

        public TimelineService(ITimelineRepo timelineRepo, IMapper mapper) 
        { 
            _timelineRepo = timelineRepo;
            _mapper = mapper;
        }
        public async Task AddPostToTimeline(AddPostToTimelineDTO newPost)
        {
            await _timelineRepo.AddPostToTimeline(_mapper.Map<Post>(newPost));
        }

        public void CreateTimeline(CreateTimelineDTO newTimeline)
        {
            _timelineRepo.CreateTimeline(_mapper.Map<Timeline>(newTimeline));
        }

        public Timeline GetTimeline(int TimelineID)
        {
            return _timelineRepo.GetTimeline(TimelineID);
        }
    }
}
