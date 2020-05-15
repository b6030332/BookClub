using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.ViewModels.AdminUsers
{
    public class EditUserViewModel
    {
        
            public string Id { get; set; }


            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [Display(Name = "First Name")]
            [StringLength(50)]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            [StringLength(50)]
            public string LastName { get; set; }

           
            public IEnumerable<SelectListItem> RolesList { get; set; }

        
    }
}