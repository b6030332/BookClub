using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookClub.Data.DAO;

namespace BookClub.Service.Service
{
    public class DiscussionService : IDiscussionDAO
    {
        private IDiscussionDAO _dao;

        public DiscussionService()
        {
            _dao = new DiscussionDAO();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAllDiscussions()
        {
            return _dao.GetAllDiscussions();
        }

        public Discussion GetDiscussionID(int id)
        {
            return _dao.GetDiscussionID(id);

        }

        public IEnumerable<Post> GetPostsByDiscussion(int id)
        {
            return _dao.GetPostsByDiscussion(id);
        }
        public void AddDiscussion(Discussion discussion, Book book)
        {
            _dao.AddDiscussion(discussion, book);
        }

        public IEnumerable<Post> GetSearchedPosts(Discussion discussion, string searchQuery)
        {
            return _dao.GetSearchedPosts(discussion, searchQuery);
        }
    }
}
