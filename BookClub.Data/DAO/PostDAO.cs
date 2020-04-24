using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookClub.Data.DAO
{
    public class PostDAO : IPostDAO
    {
        private ApplicationDbContext _context;
        public PostDAO()
        {
            _context = new ApplicationDbContext();
        }

      //  public Task AddPost(Post post)
      //  {
      //      _context.Post.Add(post);
      //      _context.SaveChanges();
      //  }

        public IEnumerable<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            return _context.Post.Find(id);
                //.Where(post => post.Id == id)
                //.Include(post => post.ApplicationUser)
                //.Include(post => post.Replies.Select(reply => reply.ApplicationUser))
                //.Include(post => post.Discussion)
                //.First();
        }
    } 
}
