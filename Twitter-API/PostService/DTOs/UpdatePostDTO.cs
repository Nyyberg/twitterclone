using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService.DTOs
{
    public class UpdatePostDTO
    {
        public int PostID { get; set; }
        public string PostText { get; set; }
        public DateTime postDate { get; set; }

    }
}
