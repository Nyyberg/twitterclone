using Microsoft.AspNetCore.Mvc;
using TimelineService;
using TimelineService.DTOs;

namespace Profile.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineService _timelineService;
        public TimelineController(ITimelineService timelineService) 
        {
            _timelineService = timelineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTimeline(GetTimelineDTO getTimeline)
        {
            var timeline = _timelineService.GetTimeline(getTimeline.TimelineID);
            return Ok(timeline);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeline(CreateTimelineDTO createTimeline)
        {
            _timelineService.CreateTimeline(createTimeline);
            return Ok();
        }

        [HttpPost]
        [Route("AddPostToTimeline")]
        public async Task<IActionResult> AddPostToTimeline(AddPostToTimelineDTO addPostToTimeline)
        {
            await _timelineService.AddPostToTimeline(addPostToTimeline);
            return Ok();
        }
    }
}
