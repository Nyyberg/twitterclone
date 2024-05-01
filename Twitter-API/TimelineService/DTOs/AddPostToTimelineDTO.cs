using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineService.DTOs
{
    public class AddPostToTimelineDTO
    {
        public int PostId { get; set; }
        public int TimelineId { get; set; }
    }
}
