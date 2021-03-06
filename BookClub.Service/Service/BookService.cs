﻿using BookClub.Data;
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
    public class BookService : IBookDAO
    {
        private IBookDAO _dao;
        public BookService()
        {
            _dao = new BookDAO();
        }

        public void AddBook(Book book)
        {
            _dao.AddBook(book);
        }

        public void DeleteBook(Book book)
        {
            _dao.DeleteBook(book);
        }

        public IList<Book> GetAllBooks()
        {
            return _dao.GetAllBooks();
        }

        public Book GetBookId(int id)
        {
            return _dao.GetBookId(id);
        }

        public IList<Discussion> GetDiscussionsByBook(int id)
        {
            IList<Discussion> discussions = _dao.GetDiscussionsByBook(id);
            return discussions;
        }

        public void UpdateBook(Book book)
        {
            _dao.UpdateBook(book);
        }
    }
}
