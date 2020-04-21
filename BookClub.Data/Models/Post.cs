using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual Discussion Discussion { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
