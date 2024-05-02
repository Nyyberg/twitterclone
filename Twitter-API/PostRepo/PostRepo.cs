using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;

namespace PostRepo
{
    public class PostRepo : IPostRepo
    {
        private DbContextOptions<RepoDbContext> repoContextOptions;

        public PostRepo()
        {
            repoContextOptions = new DbContextOptionsBuilder<RepoDbContext>().UseInMemoryDatabase("PostDB").Options;

        }
        


        public async Task<Post> CreatePost(Post post)
        {
            using (var context = new RepoDbContext(repoContextOptions, ServiceLifetime.Scoped))
            {
                 context.posts.Add(post);
                context.SaveChanges();
                return post;
            }
        }

        public void DeletePost(int id)
        {
            using (var context = new RepoDbContext(repoContextOptions, ServiceLifetime.Scoped))
            {
                var post = context.posts.FirstOrDefault(p => p.postID == id);
                context.posts.Remove(post);
                context.SaveChanges();
            }
        }

        public List<Post> GetAllPosts()
        {
            using (var context = new RepoDbContext(repoContextOptions, ServiceLifetime.Scoped))
            {
                var posts = context.posts.ToList();
                return posts;
            }
        }

        public Post GetById(int id)
        {
            using (var context = new RepoDbContext(repoContextOptions, ServiceLifetime.Scoped))
            {
                var post = context.posts.FirstOrDefault(p => p.postID == id);
                return post;
            }
        }

        public void UpdatePost(Post post)
        {
            using (var context = new RepoDbContext(repoContextOptions, ServiceLifetime.Scoped))
            {
                Post postUpdate = context.posts.Find(post.postID);
                postUpdate.postText = post.postText;
                context.posts.Update(postUpdate);
                context.SaveChanges();
            }
        }
    }
}
