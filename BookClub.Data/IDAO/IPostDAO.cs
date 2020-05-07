using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IPostDAO
    {
        Post GetPost(int id);
        void AddPost(Post post, Discussion discussion);
        IEnumerable<Post> GetRecentPosts(int nofposts);
        IEnumerable<Post> GetAllPosts();

        
    }
}
