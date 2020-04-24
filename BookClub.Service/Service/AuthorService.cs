using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Service.Service
{
    public class AuthorService : IAuthorDAO
    {
        private IAuthorDAO _dao;
        public AuthorService()
        {
            _dao = new AuthorDAO();
        }

        public Author GetAuthor(int id)
        {
            return _dao.GetAuthor(id);
        }

        public IEnumerable<Book> GetBooksByAuthor(int id)
        {
            return _dao.GetBooksByAuthor(id);
        }
    }
}
