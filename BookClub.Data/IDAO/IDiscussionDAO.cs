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
        
        void AddDiscussion(Discussion discussion);
        void UpdateDiscussion(Discussion discussion);
        void DeleteDiscussion(Discussion discussion);

        IEnumerable<Post> GetPostsByDiscussion(int id);

       
    }
}
