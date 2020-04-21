using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.PostReply;
using BookClub.Service.Service;
using BookClub.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostDAO _postService;
        public PostController()
        {
            _postService = new PostService();
        }
        // GET: Post
        public ActionResult GetPost(int id)
        {
            Post post = _postService.GetPost(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.ApplicationUser.Id,
                AuthorName = post.ApplicationUser.UserName,
                AuthorImageURL = post.ApplicationUser.ProfileImage,
                AuthorRating = post.ApplicationUser.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };
            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.ApplicationUser.UserName,
                AuthorId = reply.ApplicationUser.Id,
                AuthorImageURL = reply.ApplicationUser.ProfileImage,
                AuthorRating = reply.ApplicationUser.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
            
        }
    }
}