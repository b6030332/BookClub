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
    public class GenreService : IGenreDAO
    {
        private IGenreDAO _dao;
        public GenreService()
        {
            _dao = new GenreDAO();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _dao.GetAllGenres();
        }
    }
}
