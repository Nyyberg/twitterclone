using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService.DTOs
{
    public class AddPostDTO
    {
        public string PostText {  get; set; }
        public int TimelineID { get; set; }
        public DateTime postDate { get; set; }
    }
}
