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
                 .Include(d => d.Books.Title)
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
    }
}
