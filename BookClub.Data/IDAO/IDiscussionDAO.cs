using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IDiscussionDAO
    {
        Discussion GetDiscussionID(int id);
        IEnumerable<Discussion> GetAllDiscussions();
        IEnumerable<Post> GetPostsByDiscussion(int id);
        IEnumerable<ApplicationUser> GetActiveUsers();

        void AddDiscussion(Discussion discussion, Book book);
    }
}
