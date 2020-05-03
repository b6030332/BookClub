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
    public class PostDAO : IPostDAO
    {
        private ApplicationDbContext _context;
        public PostDAO()
        {
            _context = new ApplicationDbContext();
        }

        public void AddPost(Post post, Discussion discussion)
        {
            //Find the firstordefault instance of Disccusion, passing the Id
            var currentDiscussion = _context.Discussion.FirstOrDefault(d => d.Id == discussion.Id);

            //Find the firstordefault instance of User through identity framework, given with MVC startup
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            //Map the values above to their respective properties in Post entity 

            post.ApplicationUser = currentUser;
            post.Discussion = currentDiscussion;

            //Push and save values to database 

            _context.Post.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Post.ToList();
        }

        public Post GetPost(int id)
        {
            return _context.Post.Find(id);
                //.Where(post => post.Id == id)
                //.Include(post => post.ApplicationUser)
                //.Include(post => post.Replies.Select(reply => reply.ApplicationUser))
                //.Include(post => post.Discussion)
                //.First();
        }

        //Grab a collection of recent posts to display
        public IEnumerable<Post> GetRecentPosts(int nofposts)
        {
            //Order them by descencing using the date attribute in Post table
            return GetAllPosts().OrderByDescending(post => post.Created).Take(nofposts);
        }
    } 
}
