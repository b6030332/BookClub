using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using BookClub.ViewModels.Reply;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace BookClub.Controllers
{
   
    public class ReplyController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IReplyDAO _replyService;
        public ReplyController()
        {
            _postService = new PostService();
            _replyService = new ReplyService();
        }
        [HttpGet]
        public ActionResult DeleteReply(int id)
        {
          
           // var post = _postService.GetPost(id);

            return View(_replyService.GetReply(id));
        }
        [HttpPost]
        public ActionResult DeleteReply(int id, PostReply reply, Post post)
        {
            PostReply replies = new PostReply();
            
            _replyService.DeleteReply(id, reply, post);

            return RedirectToAction("GetPost", "Post", new { id = post.Id });
        }
        [HttpGet]
        public ActionResult AddReply(int id)
        {
            var post = _postService.GetPost(id);

            AddReplyViewModel addReply = new AddReplyViewModel()
            {
                PostId = post.Id,
                PostTitle = post.Title,
                PostContent = post.Content,
                
            };

            return View(addReply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReply(AddReplyViewModel model, Post post)
        {
            if (ModelState.IsValid)

            {
                PostReply reply = new PostReply();

                reply.Content = model.ReplyContent;
                reply.Created = DateTime.Now;


                _replyService.AddReply(reply, post);

                return RedirectToAction("GetPost", "Post", new { id = model.PostId });

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateReply(int id)
        {
            PostReply reply = _replyService.GetReply(id);
            return View(reply);
        }
        [HttpPost]
        public ActionResult UpdateReply(int id, PostReply reply, Post post)
        {
            try
            {
                _replyService.UpdateReply(reply);
                return RedirectToAction("GetPost", "Post", new { id = reply.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}