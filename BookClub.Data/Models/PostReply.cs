﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int? PostId { get; set; }
       
        public virtual Post Post { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
