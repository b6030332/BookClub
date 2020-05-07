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
        public void DeletePost(int id, Post post)
        {
            //find post instance of post to deleete
            var deletePost = _context.Post.FirstOrDefault(p => p.Id == id);
            
            //if not null, delete post
            if (deletePost != null)
            {

             //call remove & save changes on the post that is found above
                _context.Post.Remove(deletePost);
                _context.SaveChanges();
            }

        }
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Post.ToList();
        }

        public Post GetPost(int id)
        {
            return _context.Post.Find(id);
               
        }

        //Grab a collection of recent posts to display
        public IEnumerable<Post> GetRecentPosts(int nofposts)
        {
            //Order them by descencing using the date attribute in Post table
            return GetAllPosts().OrderByDescending(post => post.Created).Take(nofposts);
        }
    } 
}
