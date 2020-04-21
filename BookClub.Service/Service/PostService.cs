using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookClub.Service.Service
{
    public class PostService : IPostDAO
    {
        private readonly ApplicationDbContext _context;
        public PostService()
        {
            _context = new ApplicationDbContext();
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            return _context.Post.Where(post => post.Id == id)
                .Include(post => post.ApplicationUser)
                .Include(post => post.Replies.Select(reply => reply.ApplicationUser))
                .Include(post => post.Discussion)
                .First();
        }

        public IEnumerable<Post> GetPostsByDiscussion(int id)
        {
            IEnumerable<Post> posts = _context.Discussion
                .Where(discussion => discussion.Id == id)
                .First()
                .Posts;

            return posts;
                
        }
    }
}
