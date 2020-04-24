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
    public class PostService : IPostDAO
    {
        private IPostDAO _dao;
        public PostService()
        {
            _dao = new PostDAO();
        }

      //  public Task AddPost(Post post)
       // {
        //    _dao.AddPost(post);
        //}

        public IEnumerable<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            return _dao.GetPost(id);
        }

      
    }
}
