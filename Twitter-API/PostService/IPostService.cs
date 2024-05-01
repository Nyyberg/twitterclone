using DTO;
using PostService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostService
{
    public interface IPostService
    {
        public List<Post> GetAllPosts();
        public Post GetById(int id);
        public Post CreatePost(AddPostDTO addPost);
        public void UpdatePost(UpdatePostDTO updatePost);
        public void DeletePost(int id);
    }
}
