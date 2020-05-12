using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity;

namespace BookClub.Data.DAO
{
    public class DiscussionDAO : IDiscussionDAO
    {
        private ApplicationDbContext _context;

        public DiscussionDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAllDiscussions()
        {
            return _context.Discussion;


        }

        public Discussion GetDiscussionID(int id)
        {
            Discussion discussion = _context.Discussion.Find(id);
            //.Where(d => d.Id == id)
            //.Include(d => d.Posts.Select(p => p.ApplicationUser))
            //.Include(d => d.Posts.Select(p => p.Replies.Select(r => r.ApplicationUser)))
            //.FirstOrDefault();

            return discussion;
        }

        public IEnumerable<Post> GetPostsByDiscussion(int id)
        {
            Discussion discussion = _context.Discussion.Find(id);
            return discussion.Posts.ToList();
        }
        public void AddDiscussion(Discussion discussion)
        {
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
               (x => x.Id == currentUserId);

            discussion.ApplicationUser = currentUser;
            
            _context.Discussion.Add(discussion);
            _context.SaveChanges();
        }

        //public IEnumerable<Post> GetSearchedPosts(Discussion discussion, string searchQuery)
        //{

        //    return string.IsNullOrEmpty(searchQuery)
        //        ? discussion.Posts 
        //        : discussion.Posts
        //        .Where(post => post.Title.Contains(searchQuery)
        //        || post.Content.Contains(searchQuery));



        //if search query returns null, display posts or if fullfilled, find content


        public void UpdateDiscussion(Discussion discussion)
        {
            Discussion _discussion = GetDiscussionID(discussion.Id);
            _discussion.Title = discussion.Title;
            _discussion.Description = discussion.Description;
            _context.SaveChanges();
        }

        public void DeleteDiscussion(Discussion discussion)
        {
            //find post instance of post to deleete
            var deleteDiscussion = _context.Discussion.FirstOrDefault(d => d.Id == discussion.Id);

            //if not null, delete post
            if (deleteDiscussion != null)
            {

                //call remove & save changes on the post that is found above
                _context.Discussion.Remove(deleteDiscussion);
                _context.SaveChanges();
            }
        }
    }
}

