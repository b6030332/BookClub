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
    public class DiscussionController : Controller
    {
        private readonly IDiscussionDAO _discussionService;
        private readonly IPostDAO _postService;
        public DiscussionController()
        {
            _discussionService = new DiscussionService();
        }

        // GET: Discussion
        //  public ActionResult GetAllDiscussions()
        // {
        //    IEnumerable<DiscussionListingModel> discussions = _discussionService.GetAllDiscussions()
        //        .Select(discussion => new DiscussionListingModel {

        //           Id = discussion.Id,
        //           Name = discussion.Title,
        //          Description = discussion.Description
        //      });

        //  var model = new DiscussionIndexModel
        //  {
        //      DiscussionList = discussions
        //  };

        //  return View(model);
        //}
        public ActionResult GetAllDiscussions()
        {
            IEnumerable<Discussion> discussions = _discussionService.GetAllDiscussions();
            return View("GetAllDiscussions", discussions);
        }

        public ActionResult Topic(int id)
        {
            var discussion = _discussionService.GetDiscussionID(id);

            //var book = _bookService.GetBookID(id);

            // var posts = _postService.GetPostsByDiscussion(id);

            var posts = discussion.Posts;

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.ApplicationUser.Id,
                AuthorRating = post.ApplicationUser.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                ReplyCount = post.Replies.Count(),
                DiscussionId = post.Discussion.Id,
                DiscussionName = post.Discussion.Title,
                DiscussionImageURL = post.Discussion.Image,
                DiscussionDescription = post.Discussion.Description

            });

            var model = new DiscussionTopicModel
            {
                Posts = postListings,
                Discussion = BuildDiscussionListing(discussion)

            };

            return View(model);
        }

        private DiscussionListingModel BuildDiscussionListing(Discussion discussion)
        {
            return new DiscussionListingModel
            {
                Id = discussion.Id,
                Name = discussion.Title,
                Description = discussion.Description,
                ImageURL = discussion.Image
                
            };
        }
    }
        
    }
