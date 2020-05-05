using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Discussion;
using BookClub.Models.Post;
using BookClub.Models.Reply;
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
        private readonly IReplyDAO _replyService;
        private readonly IDiscussionDAO _discussionService;
        private readonly IBookDAO _bookService;
        

     public AdminController()
        { 
            _postService = new PostService();
            _discussionService = new DiscussionService();
            _bookService = new BookService();
            _replyService = new ReplyService();
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
                return RedirectToAction("GetPostsByDiscussion", "Discussion", new { id = discussion.Id });
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
        public ActionResult AddReply_(int id)
        {
            var post = _postService.GetPost(id);

            //var model = new ListofPostReply
            //{
                
            //    PostContent = post.Content,
            //    PostTitle = post.Title,
            //    PostId = post.Id,

            //    AuthorId = post.ApplicationUser.Id,
            //    AuthorName = User.Identity.Name,
            //    IsAuthorAdmin = User.IsInRole("Admin"),

            //    DiscussionId = post.Discussion.Id,
            //    DiscussionName = post.Discussion.Title,

            //    Created = DateTime.Now

            //};

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReply_(NewPostReply model, Post post)
        {
            if (ModelState.IsValid)

            {
                PostReply reply = new PostReply();

                reply.Content = model.Content;
                reply.Created = DateTime.Now;
                //model.PostContent = reply.Post.Content;
                //model.PostTitle = reply.Post.Title;
                //model.PostId = reply.Post.Id;

                //model.AuthorId = reply.ApplicationUser.Id;
                //model.AuthorName = User.Identity.Name;
                //model.IsAuthorAdmin = User.IsInRole("Admin");

                //model.DiscussionId = post.Discussion.Id;
                //model.DiscussionName = post.Discussion.Title;

                

                _replyService.AddReply(reply, post);

                return RedirectToAction("GetPost", "Post", new { id = post.Id });

            }

            return View(model);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddReply(ListofPostReply model, Post post)
        //{
        //    var reply = BuildReply(model);

        //    _replyService.AddReply(reply, post);

        //    return RedirectToAction("GetPostId", "Post", new { id = model.PostId });
        //}

        //private PostReply BuildReply(ListofPostReply model)
        //{
        //    var post = _postService.GetPost(model.PostId);

        //    return new PostReply
        //    {
        //        Post = post,
        //        Content = model.ReplyContent,
        //        Created = DateTime.Now

        //    };

        //}
    }
}