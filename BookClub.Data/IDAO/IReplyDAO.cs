using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IReplyDAO
    {
        PostReply GetReply(int id);
        void AddReply(PostReply reply, Post post);
        void DeleteReply(int id, PostReply reply, Post posts);
        void UpdateReply(PostReply reply);
    }
}
