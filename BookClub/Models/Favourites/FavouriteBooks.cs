using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookClub.Models.Favourites
{
    public class FavouriteBooks : BookClub.Data.Models.Book
    {
        public int Quantity { get; set; }
    }
}