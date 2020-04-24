using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
