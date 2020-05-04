using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.ApplicationUser
{
    public class ProfileModel
    { 
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? MemberSince { get; set; }

    } 
}