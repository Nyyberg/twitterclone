using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostRepo
{
    public interface IPostRepo
    {
        public List<Post> GetAllPosts();
        public Post GetById(int id);
        public Post CreatePost(Post post);
        public void UpdatePost(Post post);
        public void DeletePost(int id);
    }
}
