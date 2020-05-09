using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Service.Service
{
    public class ReplyService : IReplyDAO
    {
        private IReplyDAO _dao;
        public ReplyService()
        {
            _dao = new ReplyDAO();
        }

        public void AddReply(PostReply reply, Post post)
        {
            _dao.AddReply(reply, post);
        }

        public void DeleteReply(int id, PostReply reply, Post posts)
        {
            _dao.DeleteReply(id, reply, posts);
        }

        public PostReply GetReply(int id)
        {
            return _dao.GetReply(id);
        }
    }
}
