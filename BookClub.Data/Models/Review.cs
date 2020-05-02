using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ReviewContent { get; set; }

        public Nullable<System.DateTime> Created { get; set; }

        public int BookId { get; set; }

        public virtual ApplicationUser User { get; set; }
      
    }
}
