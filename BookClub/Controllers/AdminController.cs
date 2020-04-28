﻿using BookClub.Data.IDAO;
using BookClub.Data.Models;
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
        public AdminController()
        {
            _postService = new PostService();
            _discussionService = new DiscussionService();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult AddPost(int id)
        {
            var discussion = _discussionService.GetDiscussionID(id);
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(NewPost model, Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.Title = model.Title;
                post.Content = model.Content;
                post.Created = DateTime.Now;

                _postService.AddPost(post, discussion);
                return RedirectToAction("GetPostsByDiscussion", "Discussion", new { id = discussion.Id });
            }
            return View(model);
            
        }
    }
}