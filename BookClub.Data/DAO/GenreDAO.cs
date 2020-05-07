using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class GenreDAO : IGenreDAO
    {
        private ApplicationDbContext _context;
        public GenreDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre;
        }
    }
}
