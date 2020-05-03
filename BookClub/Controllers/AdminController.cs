using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Discussion;
using BookClub.Models.Post;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IDiscussionDAO _discussionService;
        private readonly IBookDAO _bookService;
        public AdminController()
        {
            _postService = new PostService();
            _discussionService = new DiscussionService();
            _bookService = new BookService();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult AddPost(int id)
        {
            //Find the id of discussion we're posting in 
            var discussion = _discussionService.GetDiscussionID(id);
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(NewPost model, Discussion discussion)
        {
            //Map the new post values for NewPost model to be pushed into database
            
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.Title = model.Title;
                post.Content = model.Content;
                post.Created = DateTime.Now;
                
                //logic for adding post with user and discussion id is processed in the POSTDAO 

                _postService.AddPost(post, discussion);
                return RedirectToAction("GetD", "Discussion", new { id = discussion.Id });
            }
            return View(model);
            
        }
        [HttpGet]
        public ActionResult AddDiscussion(int id)
        {
            //Find the id of book we're posting discussion in 
            var book = _bookService.GetBookId(id);
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscussion(NewDiscussion model, Book book)
        {
            //Map the new Discussion values for NewDiscussion model to be pushed into database

            if (ModelState.IsValid)

            {
                Discussion discussion = new Discussion();
                discussion.Title = model.Title;
                discussion.Description = model.Content;
                discussion.Created = DateTime.Now;

                //logic for adding discussion with user and book id is processed in the DiscussionDAO 

                _discussionService.AddDiscussion(discussion, book);
                
                return RedirectToAction("GetB", "Book", new { id = discussion.BookId });
            }

            return View(model);
        }
    }
}