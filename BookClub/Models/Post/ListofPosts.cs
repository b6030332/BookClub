﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookClub.Data.Models;

namespace BookClub.Models.Post
{
    public class ListofPosts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public int DiscussionId { get; set; }
        public string DiscussionName { get; set; }
        public string DiscussionDescription { get; set; }

        public string BookImage { get; set; }

        public int RepliesCount { get; set; }


       
    }
}