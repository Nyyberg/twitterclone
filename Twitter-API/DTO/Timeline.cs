using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Timeline
    {
        public int id {  get; set; }

        public List<int> PostIDs { get; set; } = new List<int>();

    }
    
}
