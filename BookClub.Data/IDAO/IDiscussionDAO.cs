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
        IEnumerable<ApplicationUser> GetActiveUsers();

        Task Create(Discussion discussion);


        Task Delete(int discussionId);
        Task UpdateDiscussionTitle(int dicussionId, string newTitle);
        Task UpdateDiscussionDescription(int discussionId, string newDescription);
    
    }
}
