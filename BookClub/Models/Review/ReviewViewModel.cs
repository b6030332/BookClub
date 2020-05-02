﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; } 
    }

}