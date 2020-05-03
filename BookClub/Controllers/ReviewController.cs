using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Book;
using BookClub.Models.JointViews;
using BookClub.Models.Review;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BookClub.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewDAO _reviewService;
        private readonly IBookDAO _bookService;
        public ReviewController()
        {
            _reviewService = new ReviewService();
            _bookService = new BookService();
        }
        // GET: Review
        public ActionResult GetReviewByBook(int id)
        {
            //First, finding the Id of a Book needed to add a Review.

            var book = _bookService.GetBookId(id);

            var reviews = book.Reviews;

            // Maps the the values from new custom model (ReviewViewModel) to Review entity model. 

            var listofReviews = reviews.Select(review => new ReviewViewModel
            {
                Id = review.Id,
                BookId = review.BookId,
                BookName = review.Book.Title,
                ReviewContent = review.ReviewContent,
                AuthorName = review.User.UserName,
                DateCreated = review.Created.ToString(),
                Rating = review.Rating,
            });

            ViewBag.BookId = id;

            return View(listofReviews);
        }
        
        [HttpPost]

        //The parameters passed here are the names of the input types and text area in GetReviewByBook
        public ActionResult AddReview(int id, int rating, string bookContent)
        {
            // Mapping values from Review Entity to new values in GetReviewsByBook
            
                Review review = new Review();
                review.BookId = id;
                review.ReviewContent = bookContent;
                review.Created = DateTime.Now;
                review.Rating = rating;

                _reviewService.AddReview(review);
                
                return RedirectToAction("GetReviewByBook","Review", new { id = review.BookId });
            
        }
        
        // var model = new BookReviewModel
        //{
        //    Reviews = listofReviews,
        // Book = BuildNewBook(book)
        /// };

        //  return View(model);
        // }
        //private NewBook BuildNewBook(Book book)
        //{
        //    return new NewBook
        //    {
        //        Id = book.Id,
        //        Title = book.Title,
        //        Blurb = book.Blurb,
        //        Genre = book.Genre.Name,
        //        BookImage = book.Image
        //    };
        //}
    }
}