using BookClub.Data.IDAO;
using BookClub.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookClub.Data.DAO
{
    public class ReplyDAO : IReplyDAO
    {
       private ApplicationDbContext _context;
        public ReplyDAO()
        {
            _context = new ApplicationDbContext();
        }

        public void AddReply(PostReply reply, Post post)
        {
            //Find the firstordefault instance of Post, passing the Id
            var currentPost = _context.Post.FirstOrDefault(d => d.Id == post.Id);

            //Find the firstordefault instance of User through identity framework, given with MVC startup
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            //Map the values above to their respective properties in Reply entity 

            reply.ApplicationUser = currentUser;
            reply.Post = currentPost;

            //Push and save values to database 

            _context.Replies.Add(reply);
            _context.SaveChanges(); 
        }

        public void DeleteReply(int id, PostReply reply, Post posts)
        {
            //find first or default instance of reply to delete
                var replytoDelete = _context.Replies.FirstOrDefault(r => r.Id == id);

            //if result is not null, remove from database & save changes 
                if (replytoDelete != null)
                {

                    _context.Replies.Remove(replytoDelete);
                    _context.SaveChanges();
                }
         }

        
        public PostReply GetReply(int id)
        {
            return _context.Replies.Find(id);
        }

        public void UpdateReply(PostReply reply)
        {
            PostReply _reply = GetReply(reply.Id);
            _reply.Content = reply.Content;
            _context.SaveChanges();
        }

    }
}
