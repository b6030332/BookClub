using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class Challenges
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Until { get; set; }
        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }


    }
}
