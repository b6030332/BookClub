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
        IEnumerable<Post> GetAllPosts();
        
    }
}
