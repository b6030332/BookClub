using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models;
using BookClub.Models.Book;
using BookClub.Models.Discussion;
using BookClub.Service.Service;
using BookClub.ViewModels.Book;
using BookClub.ViewModels.JointViewModels;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookClub.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;
        private IBookDAO _bookService;
        private IDiscussionDAO _discussionService;
        public BookController()
        {
            _context = new ApplicationDbContext();
            _bookService = new BookService();
            _discussionService = new DiscussionService();
        }
        
        public ActionResult GetAllBooks(string option, string search, int? page)
        {
            //Returns certain list of books on the condition the user searches by: Genre, Author, Title
            if (option == "Genre")
            {
                //'ToPagedList...' - If the page parameter has got value of null, then use value of 1
                //Otherwise uses whatever value is present within page parameter
                //5 = number of items per page
                return View(_context.Book.Where(b => b.Genre.Name == search || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else if (option == "Author")
            {
                return View(_context.Book.Where(b => b.Author.Name == search || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(_context.Book.Where(b => b.Title.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5)); 
            }
        }
        public ActionResult GetBookId(int id)
        {
            //Grab id of book
            Book books = _bookService.GetBookId(id);

            //Map properties of custom view model to raw database entities
            BookDetailViewModel bookDetail = new BookDetailViewModel()
            {
                Id = books.Id,
                BookTitle = books.Title,
                BookImage = books.Image,
                ISBN = books.ISBN,
                Price = books.Price,
                Publisher = books.Publisher,
                Format = books.Format,
                Blurb = books.Blurb,
                Year = books.Year,
                GenreName = books.Genre.Name,
                AuthorName = books.Author.Name,
                AuthorId = books.Author.Id
                
                
                
            };

            return View(bookDetail);
        }
        
        
        public ActionResult GetB(int id)
        {
            //find id of book
            var book = _bookService.GetBookId(id);

            //set new properties for ICollection<Discussions> for the view 
            var discussions = book.Discussions;

            //map custome view model properties to raw entity models 
            var listofDiscussions = discussions.Select(discussion => new ListofDiscussions
            {
                Id = discussion.Id,
                AuthorId = discussion.ApplicationUser.Id,
                AuthorName = discussion.ApplicationUser.UserName,
                Title = discussion.Title,
                Content = discussion.Description,
                DatePosted = discussion.Created.ToString(),
                BookId = discussion.Books.Id,
                BookName = discussion.Books.Title,
                BookBlurb = discussion.Books.Blurb
                //BookImage = discussion.Books.Image

            });

            //create custom model to wrap 'ListofDiscussions' to IEnumerable for view
            var model = new BookDiscussionViewModel
            {
                Discussions = listofDiscussions,
                Book = BuildNewBook(book)
            };

            return View(model);
        }

        //Map customer model to properties in raw entity models to access in the view
        private NewBook BuildNewBook(Book book)
        {
            return new NewBook
            {
                Id = book.Id,
                Title = book.Title,
                Blurb = book.Blurb,
                Genre = book.Genre.Name,
                BookImage = book.Image

            };
        }
       
        
    }
}

    
