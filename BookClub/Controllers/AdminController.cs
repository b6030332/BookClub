﻿using BookClub.Data.IDAO;
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
        [HttpGet]
        public ActionResult AddDiscussion(int id)
        {
            var book = _bookService.GetBookId(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscussion(NewDiscussion model, Book book)
        {

            if (ModelState.IsValid)

            {
                Discussion discussion = new Discussion();
                discussion.Title = model.Title;
                discussion.Description = model.Content;
                discussion.Created = DateTime.Now;
                //discussion.BookId = book.Id;


                _discussionService.AddDiscussion(discussion, book);



                return RedirectToAction("GetDiscussionsByBook", "Book", new { id = discussion.BookId });
            }

            return View(model);
        }
    }
}