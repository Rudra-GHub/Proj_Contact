using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class Contact
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Mobile No.")]
        [MaxLength(10), MinLength(10)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Status")]
        public string Status { get; set; }
        
    }
}