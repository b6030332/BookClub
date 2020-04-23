using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
   public class Discussion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Image { get; set; }
        public int? BookId { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual Book Books { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
