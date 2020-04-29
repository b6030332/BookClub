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
    public class DiscussionDAO : IDiscussionDAO
    {
        private ApplicationDbContext _context;

        public DiscussionDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAllDiscussions()
        {
            return _context.Discussion;
                
                //.Include(d => d.Posts);
        }

        public Discussion GetDiscussionID(int id)
        {
            Discussion discussion = _context.Discussion
                 .Where(d => d.Id == id)
                 .Include(d => d.Posts.Select(p => p.ApplicationUser))
                 .Include(d => d.Posts.Select(p => p.Replies.Select(r => r.ApplicationUser)))
                 .FirstOrDefault();

            return discussion;
        }

        public IEnumerable<Post> GetPostsByDiscussion(int id)
        {
            Discussion discussion = _context.Discussion.Find(id);
            return discussion.Posts.ToList();
        }
        public void AddDiscussion(Discussion discussion, Book book)
        {
            var currentBook = _context.Book.FirstOrDefault(b => b.Id == book.Id);

            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
               (x => x.Id == currentUserId);

            discussion.ApplicationUser = currentUser;
            discussion.Books = currentBook;


            _context.Discussion.Add(discussion);
            _context.SaveChanges();
        }
    }
}
