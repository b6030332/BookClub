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
        IEnumerable<Post> GetRecentPosts(int nofposts);
        IEnumerable<Post> GetAllPosts();
        void AddPost(Post post, Discussion discussion);
        void DeletePost(Post post);


        //Ajax methods
        IEnumerable<PostReply> BuildPostTable();
        Post AjaxPost(int id);
        void AJAXAddReply(PostReply replies);
    }
}
