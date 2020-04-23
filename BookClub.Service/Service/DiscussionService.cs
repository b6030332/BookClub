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
    public class DiscussionService : IDiscussionDAO
    {
        private readonly ApplicationDbContext _context;
        public DiscussionService()
        {
            _context = new ApplicationDbContext();
        }

        public Task Create(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int discussionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAllDiscussions()
        {
            return _context.Discussion.Include(d => d.Posts);
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


        public Task UpdateDiscussionDescription(int discussionId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDiscussionTitle(int dicussionId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
