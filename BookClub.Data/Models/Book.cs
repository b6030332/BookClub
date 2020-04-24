using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Format { get; set; }
       
        public double Price { get; set; }
        public string Blurb { get; set; }
        [Required]
        public Int64 ISBN { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }

    }
}
