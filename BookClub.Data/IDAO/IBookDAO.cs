using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IBookDAO
    {
        IList<Book> GetAllBooks();
        IList<Discussion> GetDiscussionsByBook(int id);

        Book GetBookId(int id);
        
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
