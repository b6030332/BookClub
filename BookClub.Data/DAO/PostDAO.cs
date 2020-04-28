using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity;

namespace BookClub.Data.DAO
{
    public class PostDAO : IPostDAO
    {
        private ApplicationDbContext _context;
        public PostDAO()
        {
            _context = new ApplicationDbContext();
        }

        public void AddPost(Post post, Discussion discussion)
        {
            var currentDiscussion = _context.Discussion.FirstOrDefault(d => d.Id == discussion.Id);

            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            post.ApplicationUser = currentUser;
            post.Discussion = currentDiscussion;

            _context.Post.Add(post);
            _context.SaveChanges();
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
